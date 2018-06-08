using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using System.Security.Authentication;

namespace GetBearerToken
{
    class Program
    {
        public struct RuntimeOptions
        {
            public RunningMode runningMode;
            public string tenantName;
            public string authUrl;
            public string clientId;
            public string key;
            public string resource;
            public string redirectUrl;
            public bool adminConsent;
        }

        public enum RunningMode
        {
            Native = 1,
            Web
        }

        static void PrintHelp()
        {
            Console.WriteLine("GetBearerToken");
            Console.WriteLine("    Sample application for obtaning an Azure AD token for a specific resource. ");
            Console.WriteLine();
            Console.WriteLine("Parameters:");
            Console.WriteLine("    m:    Running mode. Values can be 1 for native applicaitons or 2 for web application where");
            Console.WriteLine("          a client secret is required. ");
            Console.WriteLine("    t:    Tenant name. For example: \"contoso.onmicrosoft.com\" ");
            Console.WriteLine("    a:    Authentication URL. This parameter is optional. ");
            Console.WriteLine("    c:    ClientId of your application.");
            Console.WriteLine("    k:    Key or client secret ");
            Console.WriteLine("    r:    Resource for which the token is required. For example \"https://graph.microsoft.com\"");
            Console.WriteLine("    u:    Redirect URL");
            Console.WriteLine("    f:    Force admin consent");
            Console.WriteLine("    ?:    Displays this info.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("    Get a token for a native application:");
            Console.WriteLine("          GetBearerToken.exe -t contoso.onmicrosoft.com -c \"e4a29f65-55e4 -4b91-9f56-aeda50cd1ed1\"");
            Console.WriteLine("          -u \"http://localhost\" -r \"https://manage.office.com\" -m 1");
            Console.WriteLine("    Get a token for a native application and force admin consent:");
            Console.WriteLine("          GetBearerToken.exe -t contoso.onmicrosoft.com -c \"e4a29f65-55e4 -4b91-9f56-aeda50cd1ed1\"");
            Console.WriteLine("          -u \"http://localhost\" -r \"https://manage.office.com\" -m 1 -f");
            Console.WriteLine("    Get a token for a web application:");
            Console.WriteLine("          GetBearerToken.exe -t contoso.onmicrosoft.com -c \"e4a29f65-55e4 -4b91-9f56-aeda50cd1ed1\"");
            Console.WriteLine("          -k \"hjw9Grzzj1vb00G/0G0CEUz/F9/XoeYZ4KfVzSRyUf8=\" -r \"https://graph.microsoft.com\" -m 2");
        }
        static bool ParseArguments(int argc, string[] argv, ref RuntimeOptions runtimeOptions)
        {
            runtimeOptions.authUrl = "https://login.windows.net";
            for (int i = 0; i < argc; i++)
            {
                switch (argv[i][0])
                {
                    case '-':
                    case '/':
                    case '\\':
                        if (0 == argv[i][1])
                        {
                            return false;
                        }
                        switch (Char.ToLower(argv[i][1]))
                        {
                            case 'm':
                                if (i + 1 < argc)
                                {
                                    if (Convert.ToInt32(argv[i + 1]) == 1)
                                    {
                                        runtimeOptions.runningMode = RunningMode.Native;
                                    }
                                    else if (Convert.ToInt32(argv[i + 1]) == 2)
                                    {
                                        runtimeOptions.runningMode = RunningMode.Web;
                                    }
                                    else return false;
                                }
                                else
                                    return false;
                                break;
                            case 't':
                                if (i + 1 < argc)
                                {
                                    runtimeOptions.tenantName = argv[i + 1];
                                    i++;
                                }
                                else
                                    return false;
                                break;
                            case 'a':
                                if (i + 1 < argc)
                                {
                                    runtimeOptions.authUrl = argv[i + 1];
                                    i++;
                                }
                                else
                                    return false;
                                break;
                            case 'c':
                                if (i + 1 < argc)
                                {
                                    runtimeOptions.clientId = argv[i + 1];
                                    i++;
                                }
                                else
                                    return false;
                                break;
                            case 'k':
                                if (i + 1 < argc)
                                {
                                    runtimeOptions.key = argv[i + 1];
                                    i++;
                                }
                                else
                                    return false;
                                break;
                            case 'r':
                                if (i + 1 < argc)
                                {
                                    runtimeOptions.resource = argv[i + 1];
                                    i++;
                                }
                                else
                                    return false;
                                break;
                            case 'u':
                                if (i + 1 < argc)
                                {
                                    runtimeOptions.redirectUrl = argv[i + 1];
                                    i++;
                                }
                                else
                                    return false;
                                break;
                            case 'f':
                                { 
                                    runtimeOptions.adminConsent = true;
                                }
                                break;
                            case '?':
                            default:
                                return false;
                        }
                        break;
                }
            }

            return true;
        }

        private static AuthenticationContext authenticationContext;

        // <summary>
        /// Perform any required app initialization.
        /// This is where authentication with Active Directory is performed.
        public static async Task<string> GetTokenWeb(RuntimeOptions runtimeOptions)
        {
            // Get OAuth token using client credentials 
            string tenantName = runtimeOptions.tenantName;
            
            string authString = runtimeOptions.authUrl + "/" + tenantName;

            authenticationContext = new AuthenticationContext(authString, false);

            // Config for OAuth client credentials  
            string clientId = runtimeOptions.clientId;
            string key = runtimeOptions.key;
            ClientCredential clientCred = new ClientCredential(clientId, key);
            
            string resource = runtimeOptions.resource;
            string token;
            try
            {
                AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(resource, clientCred);
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
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }
        
        }

        // <summary>
        /// Perform any required app initialization.
        /// This is where authentication with Active Directory is performed.
        public static async Task<string> GetTokenNative(RuntimeOptions runtimeOptions)
        {
            // Get OAuth token using client credentials 
            string tenantName = runtimeOptions.tenantName;

            string authString = runtimeOptions.authUrl + "/" + tenantName;

            authenticationContext = new AuthenticationContext(authString, false);

            // Config for OAuth client credentials  
            string clientId = runtimeOptions.clientId;

            string resource = runtimeOptions.resource;
            Uri redirectUri = new Uri(runtimeOptions.redirectUrl);
            string token;
            AuthenticationResult authenticationResult;
            try
            {
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
                Console.WriteLine(ex.ToString());
                return string.Empty;
            }

        }
        static void Main(string[] args)
        {
            RuntimeOptions runtimeOptions = new RuntimeOptions();
            if (!ParseArguments(args.Length, args, ref runtimeOptions))
            {
                PrintHelp();
            }
            Task<string> t;
            switch (runtimeOptions.runningMode)
            {
                case RunningMode.Native:
                    t = GetTokenNative(runtimeOptions);
                    t.Wait();

                    Console.WriteLine(t.Result);

                    break;

                case RunningMode.Web:
                    t = GetTokenWeb(runtimeOptions);
                    t.Wait();

                    Console.WriteLine("Bearer " + t.Result);

                    break;
            }

        }
    }
}
