namespace _1
{
    partial class Auth_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth_Form));
            this.FieldPass = new System.Windows.Forms.TextBox();
            this.FieldLogin = new System.Windows.Forms.TextBox();
            this.FieldNameLogin = new System.Windows.Forms.Label();
            this.FieldNamePass = new System.Windows.Forms.Label();
            this.RegButton = new System.Windows.Forms.Button();
            this.EnterButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // FieldPass
            // 
            this.FieldPass.Location = new System.Drawing.Point(177, 114);
            this.FieldPass.Margin = new System.Windows.Forms.Padding(4);
            this.FieldPass.Name = "FieldPass";
            this.FieldPass.PasswordChar = '*';
            this.FieldPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FieldPass.ShortcutsEnabled = false;
            this.FieldPass.Size = new System.Drawing.Size(296, 23);
            this.FieldPass.TabIndex = 0;
            this.FieldPass.Enter += new System.EventHandler(this.FieldPass_Enter);
            // 
            // FieldLogin
            // 
            this.FieldLogin.Location = new System.Drawing.Point(177, 61);
            this.FieldLogin.Margin = new System.Windows.Forms.Padding(4);
            this.FieldLogin.Name = "FieldLogin";
            this.FieldLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FieldLogin.Size = new System.Drawing.Size(296, 23);
            this.FieldLogin.TabIndex = 1;
            this.FieldLogin.Enter += new System.EventHandler(this.FieldLogin_Enter);
            // 
            // FieldNameLogin
            // 
            this.FieldNameLogin.AutoSize = true;
            this.FieldNameLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FieldNameLogin.Location = new System.Drawing.Point(52, 64);
            this.FieldNameLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FieldNameLogin.Name = "FieldNameLogin";
            this.FieldNameLogin.Size = new System.Drawing.Size(43, 17);
            this.FieldNameLogin.TabIndex = 2;
            this.FieldNameLogin.Text = "Login";
            this.FieldNameLogin.Click += new System.EventHandler(this.label1_Click);
            // 
            // FieldNamePass
            // 
            this.FieldNamePass.AutoSize = true;
            this.FieldNamePass.Location = new System.Drawing.Point(29, 122);
            this.FieldNamePass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FieldNamePass.Name = "FieldNamePass";
            this.FieldNamePass.Size = new System.Drawing.Size(69, 17);
            this.FieldNamePass.TabIndex = 3;
            this.FieldNamePass.Text = "Password";
            // 
            // RegButton
            // 
            this.RegButton.Location = new System.Drawing.Point(354, 179);
            this.RegButton.Margin = new System.Windows.Forms.Padding(4);
            this.RegButton.Name = "RegButton";
            this.RegButton.Size = new System.Drawing.Size(120, 28);
            this.RegButton.TabIndex = 4;
            this.RegButton.Text = "Регистрация";
            this.RegButton.UseVisualStyleBackColor = true;
            this.RegButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(196, 179);
            this.EnterButton.Margin = new System.Windows.Forms.Padding(4);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(120, 28);
            this.EnterButton.TabIndex = 5;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(29, 179);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(120, 28);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Подключение";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(509, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 31);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Auth_Form
            // 
            this.AcceptButton = this.EnterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(544, 254);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.RegButton);
            this.Controls.Add(this.FieldNamePass);
            this.Controls.Add(this.FieldNameLogin);
            this.Controls.Add(this.FieldLogin);
            this.Controls.Add(this.FieldPass);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Auth_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Auth_Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Auth_Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Auth_Form_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FieldPass;
        private System.Windows.Forms.TextBox FieldLogin;
        private System.Windows.Forms.Label FieldNameLogin;
        private System.Windows.Forms.Label FieldNamePass;
        private System.Windows.Forms.Button RegButton;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

