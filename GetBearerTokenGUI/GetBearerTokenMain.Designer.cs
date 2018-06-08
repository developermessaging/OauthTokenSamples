namespace GetBearerTokenGUI
{
    partial class GetBearerTokenMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.adminConsentBox = new System.Windows.Forms.CheckBox();
            this.redirectUrlBox = new System.Windows.Forms.TextBox();
            this.applicationIDBox = new System.Windows.Forms.TextBox();
            this.tenantIdBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientSecretBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.applicationTokenBtn = new System.Windows.Forms.Button();
            this.decodedTokenBox = new System.Windows.Forms.TextBox();
            this.buttonEWSGetInboxCount = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxEWSTraceToOutput = new System.Windows.Forms.CheckBox();
            this.checkBoxEWSImpersonate = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEWSMailbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxAuthCertificate = new System.Windows.Forms.TextBox();
            this.buttonLoadCertificate = new System.Windows.Forms.Button();
            this.radioButtonAuthWithCertificate = new System.Windows.Forms.RadioButton();
            this.radioButtonAuthWithClientSecret = new System.Windows.Forms.RadioButton();
            this.comboBoxResourceUrl = new System.Windows.Forms.ComboBox();
            this.comboBoxAuthenticationUrl = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1219, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tokenBox
            // 
            this.tokenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokenBox.Location = new System.Drawing.Point(3, 22);
            this.tokenBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tokenBox.Multiline = true;
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tokenBox.Size = new System.Drawing.Size(471, 343);
            this.tokenBox.TabIndex = 26;
            // 
            // adminConsentBox
            // 
            this.adminConsentBox.AutoSize = true;
            this.adminConsentBox.Location = new System.Drawing.Point(7, 33);
            this.adminConsentBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.adminConsentBox.Name = "adminConsentBox";
            this.adminConsentBox.Size = new System.Drawing.Size(141, 24);
            this.adminConsentBox.TabIndex = 25;
            this.adminConsentBox.Text = "Admin consent";
            this.adminConsentBox.UseVisualStyleBackColor = true;
            // 
            // redirectUrlBox
            // 
            this.redirectUrlBox.Location = new System.Drawing.Point(161, 135);
            this.redirectUrlBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.redirectUrlBox.Name = "redirectUrlBox";
            this.redirectUrlBox.Size = new System.Drawing.Size(403, 26);
            this.redirectUrlBox.TabIndex = 23;
            this.redirectUrlBox.Text = "https://localhost";
            // 
            // applicationIDBox
            // 
            this.applicationIDBox.Location = new System.Drawing.Point(161, 63);
            this.applicationIDBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.applicationIDBox.Name = "applicationIDBox";
            this.applicationIDBox.Size = new System.Drawing.Size(403, 26);
            this.applicationIDBox.TabIndex = 21;
            // 
            // tenantIdBox
            // 
            this.tenantIdBox.Location = new System.Drawing.Point(161, 27);
            this.tenantIdBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tenantIdBox.Name = "tenantIdBox";
            this.tenantIdBox.Size = new System.Drawing.Size(403, 26);
            this.tenantIdBox.TabIndex = 20;
            this.tenantIdBox.TextChanged += new System.EventHandler(this.tenantIdBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 174);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Authentication Url*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Redirect Url:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Resource Url*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tenant ID*:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Application ID*:";
            // 
            // clientSecretBox
            // 
            this.clientSecretBox.Location = new System.Drawing.Point(144, 24);
            this.clientSecretBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clientSecretBox.Name = "clientSecretBox";
            this.clientSecretBox.Size = new System.Drawing.Size(420, 26);
            this.clientSecretBox.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 35);
            this.button1.TabIndex = 29;
            this.button1.Text = "DelegateToken";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.delegateTokenBtn_Click);
            // 
            // applicationTokenBtn
            // 
            this.applicationTokenBtn.Location = new System.Drawing.Point(415, 27);
            this.applicationTokenBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.applicationTokenBtn.Name = "applicationTokenBtn";
            this.applicationTokenBtn.Size = new System.Drawing.Size(170, 35);
            this.applicationTokenBtn.TabIndex = 30;
            this.applicationTokenBtn.Text = "Application Token";
            this.applicationTokenBtn.UseVisualStyleBackColor = true;
            this.applicationTokenBtn.Click += new System.EventHandler(this.applicationTokenBtn_Click);
            // 
            // decodedTokenBox
            // 
            this.decodedTokenBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decodedTokenBox.Location = new System.Drawing.Point(3, 22);
            this.decodedTokenBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.decodedTokenBox.Multiline = true;
            this.decodedTokenBox.Name = "decodedTokenBox";
            this.decodedTokenBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.decodedTokenBox.Size = new System.Drawing.Size(695, 343);
            this.decodedTokenBox.TabIndex = 31;
            // 
            // buttonEWSGetInboxCount
            // 
            this.buttonEWSGetInboxCount.Location = new System.Drawing.Point(10, 91);
            this.buttonEWSGetInboxCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEWSGetInboxCount.Name = "buttonEWSGetInboxCount";
            this.buttonEWSGetInboxCount.Size = new System.Drawing.Size(170, 35);
            this.buttonEWSGetInboxCount.TabIndex = 32;
            this.buttonEWSGetInboxCount.Text = "Get inbox count";
            this.buttonEWSGetInboxCount.UseVisualStyleBackColor = true;
            this.buttonEWSGetInboxCount.Click += new System.EventHandler(this.buttonEWSGetInboxCount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxEWSTraceToOutput);
            this.groupBox1.Controls.Add(this.checkBoxEWSImpersonate);
            this.groupBox1.Controls.Add(this.buttonEWSGetInboxCount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxEWSMailbox);
            this.groupBox1.Location = new System.Drawing.Point(597, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 135);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EWS Tests";
            // 
            // checkBoxEWSTraceToOutput
            // 
            this.checkBoxEWSTraceToOutput.AutoSize = true;
            this.checkBoxEWSTraceToOutput.Checked = true;
            this.checkBoxEWSTraceToOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEWSTraceToOutput.Location = new System.Drawing.Point(276, 57);
            this.checkBoxEWSTraceToOutput.Name = "checkBoxEWSTraceToOutput";
            this.checkBoxEWSTraceToOutput.Size = new System.Drawing.Size(143, 24);
            this.checkBoxEWSTraceToOutput.TabIndex = 33;
            this.checkBoxEWSTraceToOutput.Text = "Trace to output";
            this.checkBoxEWSTraceToOutput.UseVisualStyleBackColor = true;
            // 
            // checkBoxEWSImpersonate
            // 
            this.checkBoxEWSImpersonate.AutoSize = true;
            this.checkBoxEWSImpersonate.Location = new System.Drawing.Point(425, 57);
            this.checkBoxEWSImpersonate.Name = "checkBoxEWSImpersonate";
            this.checkBoxEWSImpersonate.Size = new System.Drawing.Size(125, 24);
            this.checkBoxEWSImpersonate.TabIndex = 2;
            this.checkBoxEWSImpersonate.Text = "Impersonate";
            this.checkBoxEWSImpersonate.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mailbox to access:";
            // 
            // textBoxEWSMailbox
            // 
            this.textBoxEWSMailbox.Location = new System.Drawing.Point(150, 25);
            this.textBoxEWSMailbox.Name = "textBoxEWSMailbox";
            this.textBoxEWSMailbox.Size = new System.Drawing.Size(435, 26);
            this.textBoxEWSMailbox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxAuthenticationUrl);
            this.groupBox2.Controls.Add(this.comboBoxResourceUrl);
            this.groupBox2.Controls.Add(this.tenantIdBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.applicationIDBox);
            this.groupBox2.Controls.Add(this.redirectUrlBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 219);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.applicationTokenBtn);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.adminConsentBox);
            this.groupBox3.Location = new System.Drawing.Point(597, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(592, 78);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Token Acquisition";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tokenBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 352);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(477, 368);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Token/error";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.decodedTokenBox);
            this.groupBox5.Location = new System.Drawing.Point(501, 352);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(701, 368);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxAuthCertificate);
            this.groupBox6.Controls.Add(this.buttonLoadCertificate);
            this.groupBox6.Controls.Add(this.radioButtonAuthWithCertificate);
            this.groupBox6.Controls.Add(this.radioButtonAuthWithClientSecret);
            this.groupBox6.Controls.Add(this.clientSecretBox);
            this.groupBox6.Location = new System.Drawing.Point(12, 237);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(579, 109);
            this.groupBox6.TabIndex = 38;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Authentication";
            // 
            // textBoxAuthCertificate
            // 
            this.textBoxAuthCertificate.Location = new System.Drawing.Point(144, 58);
            this.textBoxAuthCertificate.Name = "textBoxAuthCertificate";
            this.textBoxAuthCertificate.Size = new System.Drawing.Size(339, 26);
            this.textBoxAuthCertificate.TabIndex = 31;
            // 
            // buttonLoadCertificate
            // 
            this.buttonLoadCertificate.Location = new System.Drawing.Point(489, 57);
            this.buttonLoadCertificate.Name = "buttonLoadCertificate";
            this.buttonLoadCertificate.Size = new System.Drawing.Size(75, 33);
            this.buttonLoadCertificate.TabIndex = 30;
            this.buttonLoadCertificate.Text = "Select...";
            this.buttonLoadCertificate.UseVisualStyleBackColor = true;
            this.buttonLoadCertificate.Click += new System.EventHandler(this.buttonLoadCertificate_Click);
            // 
            // radioButtonAuthWithCertificate
            // 
            this.radioButtonAuthWithCertificate.AutoSize = true;
            this.radioButtonAuthWithCertificate.Location = new System.Drawing.Point(11, 59);
            this.radioButtonAuthWithCertificate.Name = "radioButtonAuthWithCertificate";
            this.radioButtonAuthWithCertificate.Size = new System.Drawing.Size(110, 24);
            this.radioButtonAuthWithCertificate.TabIndex = 28;
            this.radioButtonAuthWithCertificate.Text = "Certificate:";
            this.radioButtonAuthWithCertificate.UseVisualStyleBackColor = true;
            this.radioButtonAuthWithCertificate.CheckedChanged += new System.EventHandler(this.radioButtonAuthWithCertificate_CheckedChanged);
            // 
            // radioButtonAuthWithClientSecret
            // 
            this.radioButtonAuthWithClientSecret.AutoSize = true;
            this.radioButtonAuthWithClientSecret.Checked = true;
            this.radioButtonAuthWithClientSecret.Location = new System.Drawing.Point(11, 25);
            this.radioButtonAuthWithClientSecret.Name = "radioButtonAuthWithClientSecret";
            this.radioButtonAuthWithClientSecret.Size = new System.Drawing.Size(126, 24);
            this.radioButtonAuthWithClientSecret.TabIndex = 0;
            this.radioButtonAuthWithClientSecret.TabStop = true;
            this.radioButtonAuthWithClientSecret.Text = "Client secret:";
            this.radioButtonAuthWithClientSecret.UseVisualStyleBackColor = true;
            this.radioButtonAuthWithClientSecret.CheckedChanged += new System.EventHandler(this.radioButtonAuthWithClientSecret_CheckedChanged);
            // 
            // comboBoxResourceUrl
            // 
            this.comboBoxResourceUrl.FormattingEnabled = true;
            this.comboBoxResourceUrl.Items.AddRange(new object[] {
            "https://outlook.office365.com"});
            this.comboBoxResourceUrl.Location = new System.Drawing.Point(161, 99);
            this.comboBoxResourceUrl.Name = "comboBoxResourceUrl";
            this.comboBoxResourceUrl.Size = new System.Drawing.Size(403, 28);
            this.comboBoxResourceUrl.TabIndex = 25;
            this.comboBoxResourceUrl.Text = "https://outlook.office365.com";
            // 
            // comboBoxAuthenticationUrl
            // 
            this.comboBoxAuthenticationUrl.FormattingEnabled = true;
            this.comboBoxAuthenticationUrl.Items.AddRange(new object[] {
            "https://login.microsoftonline.com/common",
            "https://login.microsoftonline.com/<tenant>"});
            this.comboBoxAuthenticationUrl.Location = new System.Drawing.Point(161, 171);
            this.comboBoxAuthenticationUrl.Name = "comboBoxAuthenticationUrl";
            this.comboBoxAuthenticationUrl.Size = new System.Drawing.Size(403, 28);
            this.comboBoxAuthenticationUrl.TabIndex = 26;
            // 
            // GetBearerTokenMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 761);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetBearerTokenMain";
            this.Text = "Azure Application Auth Sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.CheckBox adminConsentBox;
        private System.Windows.Forms.TextBox redirectUrlBox;
        private System.Windows.Forms.TextBox applicationIDBox;
        private System.Windows.Forms.TextBox tenantIdBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clientSecretBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button applicationTokenBtn;
        private System.Windows.Forms.TextBox decodedTokenBox;
        private System.Windows.Forms.Button buttonEWSGetInboxCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxEWSImpersonate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEWSMailbox;
        private System.Windows.Forms.CheckBox checkBoxEWSTraceToOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonLoadCertificate;
        private System.Windows.Forms.RadioButton radioButtonAuthWithCertificate;
        private System.Windows.Forms.RadioButton radioButtonAuthWithClientSecret;
        private System.Windows.Forms.TextBox textBoxAuthCertificate;
        private System.Windows.Forms.ComboBox comboBoxResourceUrl;
        private System.Windows.Forms.ComboBox comboBoxAuthenticationUrl;
    }
}

