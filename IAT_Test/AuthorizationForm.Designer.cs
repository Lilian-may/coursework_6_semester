namespace IAT_Test
{
    partial class AuthorizationForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(50, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(224, 32);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Имя пользователя:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(50, 120);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(101, 32);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(278, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 39);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(278, 120);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(300, 39);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(278, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(140, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(438, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 50);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 300);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Name = "RegistrationForm";
            Text = "Авторизация";
            Load += RegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
