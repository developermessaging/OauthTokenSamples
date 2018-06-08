/*
 * By Andrei Ghita, Microsoft Ltd. 2018. Use at your own risk.  No warranties are given.
 * 
 * DISCLAIMER:
 * THIS CODE IS SAMPLE CODE. THESE SAMPLES ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND.
 * MICROSOFT FURTHER DISCLAIMS ALL IMPLIED WARRANTIES INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OF MERCHANTABILITY OR OF FITNESS FOR
 * A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF THE USE OR PERFORMANCE OF THE SAMPLES REMAINS WITH YOU. IN NO EVENT SHALL
 * MICROSOFT OR ITS SUPPLIERS BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
 * BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE
 * SAMPLES, EVEN IF MICROSOFT HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
 * OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
 * */
 
using Exchange = Microsoft.Exchange.WebServices.Data;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace GetBearerTokenGUI
{
    public partial class GetBearerTokenMain : Form
    {
        public GetBearerTokenMain()
        {
            InitializeComponent();
            UpdateAuthUI();
        }

        public struct RuntimeOptions
        {
            public string tenantName;
            public string authUrl;
            public string clientId;
            public string key;
            public X509Certificate2 cert;
            public string resource;
            public string redirectUrl;
            public bool adminConsent;
        }

        private static Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext authenticationContext;

        // <summary>
        /// Perform any required app initialization.
        /// This is where authentication with Active Directory is performed.
        public static async Task<string> GetTokenNative(RuntimeOptions runtimeOptions)
        {
            // Get OAuth token using client credentials 
            string tenantName = runtimeOptions.tenantName;
            string authString = string.Empty;
            authString = runtimeOptions.authUrl + "/" + tenantName;

            authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authString, false);

            // Config for OAuth client credentials  
            string clientId = runtimeOptions.clientId;

            string resource = runtimeOptions.resource;
            Uri redirectUri = new Uri(runtimeOptions.redirectUrl);
            string token;
            try
            {
                AuthenticationResult authenticationResult;
                if (runtimeOptions.adminConsent)
                {
                    authenticationResult = await authenticationContext.AcquireTokenAsync(resource,
                        clientId,
                        redirectUri,
                        new PlatformParameters(PromptBehavior.Auto),
                        UserIdentifier.AnyUser,
                        "prompt=admin_consent");
                }
                else
                {
                    authenticationResult = await authenticationContext.AcquireTokenAsync(resource, clientId, redirectUri, new PlatformParameters(PromptBehavior.Always));
                }
                token = authenticationResult.AccessToken;
                return token;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public static async Task<string> GetTokenWeb(RuntimeOptions runtimeOptions)
        {
            // Get OAuth token using client credentials 
            string tenantName = runtimeOptions.tenantName;

            string authString = runtimeOptions.authUrl + "/" + tenantName;

            authenticationContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authString, false);

            string token;
            try
            {
                AuthenticationResult authenticationResult = null;
                if (runtimeOptions.cert == null)
                {
                    ClientCredential clientCred = new ClientCredential(runtimeOptions.clientId, runtimeOptions.key);
                    authenticationResult = await authenticationContext.AcquireTokenAsync(runtimeOptions.resource, clientCred);
                }
                else
                {
                    ClientAssertionCertificate clientCert = new ClientAssertionCertificate(runtimeOptions.clientId, runtimeOptions.cert);
                    authenticationResult = await authenticationContext.AcquireTokenAsync(runtimeOptions.resource, clientCert);
                }

                token = authenticationResult.AccessToken;
                return token;
            }
            catch (AuthenticationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Acquiring a token failed with the following error: {0}", ex.Message);
                if (ex.InnerException != null)
                {
                    //  You should implement retry and back-off logic according to
                    //  http://msdn.microsoft.com/en-us/library/dn168916.aspx . This topic also
                    //  explains the HTTP error status code in the InnerException message. 
                    Console.WriteLine("Error detail: {0}", ex.InnerException.Message);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        private void delegateTokenBtn_Click(object sender, EventArgs e)
        {
            AcquireDelegateToken();
        }

        public async Task AcquireDelegateToken()
        {   
            if ((comboBoxAuthenticationUrl.Text == String.Empty) ||
                (comboBoxResourceUrl.Text == String.Empty) ||
                (applicationIDBox.Text == String.Empty) ||
                (tenantIdBox.Text == String.Empty))
            {
                MessageBox.Show("Please specify a value for all mandatory fields marked with a \"*\"");
                return;
            }

            if (redirectUrlBox.Text == string.Empty)
            {
                MessageBox.Show("Redirect Url cannot be empty when acquiring a delegate token!");
                return;
            }
            tokenBox.Clear();
            RuntimeOptions runtimeOptions = new RuntimeOptions();
            runtimeOptions.adminConsent = adminConsentBox.Checked;
            runtimeOptions.authUrl = comboBoxAuthenticationUrl.Text;
            runtimeOptions.clientId = applicationIDBox.Text;
            runtimeOptions.resource = comboBoxResourceUrl.Text;
            runtimeOptions.redirectUrl = redirectUrlBox.Text;
            runtimeOptions.tenantName = tenantIdBox.Text;
            string token = await GetTokenNative(runtimeOptions);
            
            tokenBox.Text = token;
            Tuple<bool, string, string, string> decodedTokem = TryDecodeToken(token);
            decodedTokenBox.Clear();
            decodedTokenBox.Text += decodedTokem.Item2;
            decodedTokenBox.Text += decodedTokem.Item3;
        }

        public async Task AcquireApplicationToken()
        {
            if ((comboBoxAuthenticationUrl.Text == String.Empty) ||
                (comboBoxResourceUrl.Text == String.Empty) ||
                (applicationIDBox.Text == String.Empty) ||
                (tenantIdBox.Text == String.Empty))
            {
                MessageBox.Show("Please specify a value for all mandatory fields marked with a \"*\"");
                return;
            }

            X509Certificate2 authCertificate = null;
            if (radioButtonAuthWithClientSecret.Checked)
            {
                if (clientSecretBox.Text == string.Empty)
                {
                    MessageBox.Show("Client Secret cannot be empty when acquiring an application token!");
                    return;
                }
            }
            else
            {
                try
                {
                    authCertificate = (X509Certificate2)textBoxAuthCertificate.Tag;
                } catch { }
                if (authCertificate == null)
                {
                    MessageBox.Show("Please select a valid authentication certificate");
                    return;
                }
            }

            tokenBox.Clear();
            RuntimeOptions runtimeOptions = new RuntimeOptions();
            runtimeOptions.adminConsent = adminConsentBox.Checked;
            runtimeOptions.authUrl = comboBoxAuthenticationUrl.Text;
            runtimeOptions.clientId = applicationIDBox.Text;
            runtimeOptions.resource = comboBoxResourceUrl.Text;
            runtimeOptions.key = clientSecretBox.Text;
            runtimeOptions.cert = authCertificate;
            runtimeOptions.tenantName = tenantIdBox.Text;
            string token = await GetTokenWeb(runtimeOptions);

            tokenBox.Text = token;
            Tuple<bool, string, string, string> decodedTokem = TryDecodeToken(token);
            decodedTokenBox.Clear();
            decodedTokenBox.Text += decodedTokem.Item2;
            decodedTokenBox.Text += decodedTokem.Item3;

        }

        private void applicationTokenBtn_Click(object sender, EventArgs e)
        {
            AcquireApplicationToken();
        }

        // Borrowed this from Office365APIEditor for convenience
        public static string parseJsonResponse(string Data)
        {
            string tabString = "\t";

            int indentCount = 0;
            int quoteCount = 0;
            var result = from c in Data
                         let quotes = (c == '"') ? quoteCount++ : quoteCount
                         let lineBreak = (c == ',' && quotes % 2 == 0) ? c + Environment.NewLine + string.Concat(Enumerable.Repeat(tabString, indentCount)) : null
                         let openChar = (c == '{' || c == '[') ? c + Environment.NewLine + string.Concat(Enumerable.Repeat(tabString, ++indentCount)) : c.ToString()
                         let closeChar = (c == '}' || c == ']') ? Environment.NewLine + string.Concat(Enumerable.Repeat(tabString, --indentCount)) + c : c.ToString()
                         select (lineBreak == null) ? (openChar.Length > 1) ? openChar : closeChar : lineBreak;

            return string.Concat(result);

        }

        // Borrowed this from Office365APIEditor for convenience
        private Tuple<bool, string, string, string> TryDecodeToken(string Token)
        {
            string decodedHeader = "";
            string decodedClaim = "";
            string decodedSignature = "";
            bool result = false;

            try
            {
                string[] tokenParts = Token.Split('.');

                if (tokenParts.Length < 2)
                {
                    return new Tuple<bool, string, string, string>(false, "", "", "");
                }

                decodedHeader = parseJsonResponse(Encoding.UTF8.GetString(ConvertFromBase64String(tokenParts[0])));
                decodedClaim = parseJsonResponse(Encoding.UTF8.GetString(ConvertFromBase64String(tokenParts[1])));
                decodedSignature = BitConverter.ToString(ConvertFromBase64String(tokenParts[2]));
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return new Tuple<bool, string, string, string>(result, decodedHeader, decodedClaim, decodedSignature);
        }

        // Borrowed this from Office365APIEditor for convenience
        private byte[] ConvertFromBase64String(string Data)
        {
            string temp = Data.Replace('-', '+').Replace('_', '/');

            switch (temp.Length % 4)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    temp += "==";
                    break;
                case 3:
                    temp += "=";
                    break;
                default:
                    throw new Exception();
            }

            return Convert.FromBase64String(temp);
        }

        private Exchange.ExchangeService GetExchangeService()
        {
            Exchange.ExchangeService exchangeService = new Exchange.ExchangeService(Exchange.ExchangeVersion.Exchange2013);
            exchangeService.Url = new Uri("https://outlook.office365.com/EWS/exchange.asmx");
            exchangeService.TraceListener = new EWSTracer(decodedTokenBox);
            if (checkBoxEWSTraceToOutput.Checked)
            {
                exchangeService.TraceEnabled = true;
                exchangeService.TraceFlags = Exchange.TraceFlags.All;
            }
            return exchangeService;
        }

        private void buttonEWSGetInboxCount_Click(object sender, EventArgs e)
        {
            Exchange.ExchangeService exchangeService = GetExchangeService();

            string mbx = textBoxEWSMailbox.Text;

            if (checkBoxEWSImpersonate.Checked)
            {
                if (String.IsNullOrEmpty(mbx))
                {
                    MessageBox.Show("When impersonation is selected, you must specify the mailbox to impersonate");
                    return;
                }
                exchangeService.ImpersonatedUserId = new Exchange.ImpersonatedUserId(Exchange.ConnectingIdType.SmtpAddress, mbx);
            }

            if (tokenBox.Text == string.Empty)
            {
                AcquireDelegateToken();
            }

            try
            {
                exchangeService.Credentials = new Exchange.OAuthCredentials(tokenBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
                return;
            }

            try
            {
                Exchange.Folder inbox = null;
                if (!String.IsNullOrEmpty(mbx))
                {
                    // Specify the mailbox to access
                    inbox = Exchange.Folder.Bind(exchangeService, new Exchange.FolderId(Exchange.WellKnownFolderName.Inbox, new Exchange.Mailbox(mbx)));
                }
                else
                {
                    // Don't specify the mailbox
                    inbox = Exchange.Folder.Bind(exchangeService, Exchange.WellKnownFolderName.Inbox);
                }

                MessageBox.Show(string.Format("Inbox message count = {0}", inbox.TotalCount.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }
        }

        private void buttonLoadCertificate_Click(object sender, EventArgs e)
        {
            FormChooseAuthCertificate oForm = new FormChooseAuthCertificate();
            DialogResult result = oForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            textBoxAuthCertificate.Tag = oForm.Certificate;
            textBoxAuthCertificate.Text = oForm.Certificate.Subject;
        }

        private void UpdateAuthUI()
        {
            bool bUsingClientSecret = radioButtonAuthWithClientSecret.Checked;

            textBoxAuthCertificate.Enabled = !bUsingClientSecret;
            buttonLoadCertificate.Enabled = !bUsingClientSecret;
            clientSecretBox.Enabled = bUsingClientSecret;
        }

        private void radioButtonAuthWithCertificate_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }


        private void radioButtonAuthWithClientSecret_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAuthUI();
        }

        private void tenantIdBox_TextChanged(object sender, EventArgs e)
        {
            comboBoxAuthenticationUrl.Items[1] = "https://login.microsoftonline.com/" + tenantIdBox.Text;
        }
    }
}
