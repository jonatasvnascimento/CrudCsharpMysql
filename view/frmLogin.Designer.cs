namespace CrudCsharpMysql.view
{
    partial class frmLogin
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
            this.lblCriarConta = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.checkbxShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLembrarSenha = new System.Windows.Forms.CheckBox();
            this.lblEsqueceuSenha = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCriarConta
            // 
            this.lblCriarConta.AutoSize = true;
            this.lblCriarConta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCriarConta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.lblCriarConta.Location = new System.Drawing.Point(81, 451);
            this.lblCriarConta.Name = "lblCriarConta";
            this.lblCriarConta.Size = new System.Drawing.Size(109, 16);
            this.lblCriarConta.TabIndex = 19;
            this.lblCriarConta.Text = "Create Account";
            this.lblCriarConta.Click += new System.EventHandler(this.lblCriarConta_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(64, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Dont Have an Account";
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnLimpar.Location = new System.Drawing.Point(28, 344);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(216, 35);
            this.btnLimpar.TabIndex = 16;
            this.btnLimpar.Text = "CLEAR";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(28, 293);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(216, 35);
            this.btnLogin.TabIndex = 17;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // checkbxShowPassword
            // 
            this.checkbxShowPassword.AutoSize = true;
            this.checkbxShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkbxShowPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkbxShowPassword.Location = new System.Drawing.Point(182, 250);
            this.checkbxShowPassword.Name = "checkbxShowPassword";
            this.checkbxShowPassword.Size = new System.Drawing.Size(59, 20);
            this.checkbxShowPassword.TabIndex = 15;
            this.checkbxShowPassword.Text = "Show";
            this.checkbxShowPassword.UseVisualStyleBackColor = true;
            this.checkbxShowPassword.CheckedChanged += new System.EventHandler(this.checkbxShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(28, 197);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(216, 35);
            this.txtPassword.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(28, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(28, 137);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(216, 35);
            this.txtUsername.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(28, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(28, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Get Started";
            // 
            // checkBoxLembrarSenha
            // 
            this.checkBoxLembrarSenha.AutoSize = true;
            this.checkBoxLembrarSenha.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkBoxLembrarSenha.Location = new System.Drawing.Point(28, 250);
            this.checkBoxLembrarSenha.Name = "checkBoxLembrarSenha";
            this.checkBoxLembrarSenha.Size = new System.Drawing.Size(116, 20);
            this.checkBoxLembrarSenha.TabIndex = 20;
            this.checkBoxLembrarSenha.Text = "Remenber me";
            this.checkBoxLembrarSenha.UseVisualStyleBackColor = true;
            // 
            // lblEsqueceuSenha
            // 
            this.lblEsqueceuSenha.AutoSize = true;
            this.lblEsqueceuSenha.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEsqueceuSenha.Location = new System.Drawing.Point(78, 424);
            this.lblEsqueceuSenha.Name = "lblEsqueceuSenha";
            this.lblEsqueceuSenha.Size = new System.Drawing.Size(118, 16);
            this.lblEsqueceuSenha.TabIndex = 21;
            this.lblEsqueceuSenha.Text = "Forgot Password?";
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExit.Location = new System.Drawing.Point(257, 3);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(14, 16);
            this.lblExit.TabIndex = 22;
            this.lblExit.Text = "x";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(274, 544);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblEsqueceuSenha);
            this.Controls.Add(this.checkBoxLembrarSenha);
            this.Controls.Add(this.lblCriarConta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.checkbxShowPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriarConta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox checkbxShowPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxLembrarSenha;
        private System.Windows.Forms.Label lblEsqueceuSenha;
        private System.Windows.Forms.Label lblExit;
    }
}