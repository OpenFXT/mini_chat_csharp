namespace Source_Code
{
    partial class LoginUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUI));
            btn_Exit = new Label();
            btn_Minimum = new Label();
            lbl_Title = new Label();
            pic_Logo = new PictureBox();
            lbl_InputUser = new Label();
            lbl_InputPassword = new Label();
            txt_InputUser = new TextBox();
            txt_InputPassword = new TextBox();
            btn_Login = new PictureBox();
            lbl_Product = new Label();
            timerHidden = new System.Windows.Forms.Timer(components);
            timerExit = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pic_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Login).BeginInit();
            SuspendLayout();
            // 
            // btn_Exit
            // 
            btn_Exit.AutoSize = true;
            btn_Exit.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Location = new Point(778, 4);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(20, 14);
            btn_Exit.TabIndex = 0;
            btn_Exit.Text = "X";
            btn_Exit.TextAlign = ContentAlignment.MiddleCenter;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // btn_Minimum
            // 
            btn_Minimum.AutoSize = true;
            btn_Minimum.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Minimum.ForeColor = Color.White;
            btn_Minimum.Location = new Point(759, 4);
            btn_Minimum.Name = "btn_Minimum";
            btn_Minimum.Size = new Size(14, 14);
            btn_Minimum.TabIndex = 0;
            btn_Minimum.Text = "-";
            btn_Minimum.TextAlign = ContentAlignment.MiddleCenter;
            btn_Minimum.Click += btn_Minimum_Click;
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Engravers MT", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Title.ForeColor = Color.White;
            lbl_Title.Location = new Point(4, 7);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(138, 14);
            lbl_Title.TabIndex = 1;
            lbl_Title.Text = "Server login";
            // 
            // pic_Logo
            // 
            pic_Logo.Image = (Image)resources.GetObject("pic_Logo.Image");
            pic_Logo.Location = new Point(253, 21);
            pic_Logo.Name = "pic_Logo";
            pic_Logo.Size = new Size(300, 250);
            pic_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Logo.TabIndex = 2;
            pic_Logo.TabStop = false;
            // 
            // lbl_InputUser
            // 
            lbl_InputUser.AutoSize = true;
            lbl_InputUser.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InputUser.ForeColor = Color.White;
            lbl_InputUser.Location = new Point(211, 338);
            lbl_InputUser.Name = "lbl_InputUser";
            lbl_InputUser.Size = new Size(46, 20);
            lbl_InputUser.TabIndex = 3;
            lbl_InputUser.Text = "User:";
            // 
            // lbl_InputPassword
            // 
            lbl_InputPassword.AutoSize = true;
            lbl_InputPassword.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InputPassword.ForeColor = Color.White;
            lbl_InputPassword.Location = new Point(209, 393);
            lbl_InputPassword.Name = "lbl_InputPassword";
            lbl_InputPassword.Size = new Size(83, 20);
            lbl_InputPassword.TabIndex = 3;
            lbl_InputPassword.Text = "Password:";
            // 
            // txt_InputUser
            // 
            txt_InputUser.Location = new Point(213, 367);
            txt_InputUser.Name = "txt_InputUser";
            txt_InputUser.Size = new Size(300, 23);
            txt_InputUser.TabIndex = 4;
            // 
            // txt_InputPassword
            // 
            txt_InputPassword.Location = new Point(213, 420);
            txt_InputPassword.Name = "txt_InputPassword";
            txt_InputPassword.Size = new Size(300, 23);
            txt_InputPassword.TabIndex = 4;
            // 
            // btn_Login
            // 
            btn_Login.Image = (Image)resources.GetObject("btn_Login.Image");
            btn_Login.Location = new Point(523, 367);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(82, 76);
            btn_Login.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Login.TabIndex = 6;
            btn_Login.TabStop = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // lbl_Product
            // 
            lbl_Product.AutoSize = true;
            lbl_Product.Font = new Font("Segoe UI Symbol", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Product.ForeColor = Color.White;
            lbl_Product.Location = new Point(5, 580);
            lbl_Product.Name = "lbl_Product";
            lbl_Product.Size = new Size(155, 13);
            lbl_Product.TabIndex = 7;
            lbl_Product.Text = "Login UI by FXTStrix2202";
            // 
            // timerHidden
            // 
            timerHidden.Interval = 10;
            timerHidden.Tick += timerHidden_Tick;
            // 
            // timerExit
            // 
            timerExit.Interval = 10;
            timerExit.Tick += timerExit_Tick;
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 600);
            Controls.Add(lbl_Product);
            Controls.Add(btn_Login);
            Controls.Add(txt_InputPassword);
            Controls.Add(txt_InputUser);
            Controls.Add(lbl_InputPassword);
            Controls.Add(lbl_InputUser);
            Controls.Add(pic_Logo);
            Controls.Add(lbl_Title);
            Controls.Add(btn_Minimum);
            Controls.Add(btn_Exit);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginUI";
            MouseDown += LoginUI_MouseDown;
            MouseMove += LoginUI_MouseMove;
            MouseUp += LoginUI_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pic_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Login).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label btn_Exit;
        private Label btn_Minimum;
        private Label lbl_Title;
        private PictureBox pic_Logo;
        private Label lbl_InputUser;
        private Label lbl_InputPassword;
        private TextBox txt_InputUser;
        private TextBox txt_InputPassword;
        private PictureBox btn_Login;
        private Label lbl_Product;
        private System.Windows.Forms.Timer timerHidden;
        private System.Windows.Forms.Timer timerExit;
    }
}