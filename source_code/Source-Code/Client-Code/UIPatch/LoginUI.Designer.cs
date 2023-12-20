namespace Client_Code.UIPatch
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
            pic_Logo = new PictureBox();
            lbl_Title = new Label();
            lbl_Product = new Label();
            btn_Login = new PictureBox();
            btn_ForgotPassword = new Button();
            txt_InputPassword = new TextBox();
            txt_InputUser = new TextBox();
            lbl_InputPassword = new Label();
            lbl_InputEmail = new Label();
            lbl_CreateAcc = new Label();
            timer_Hidden = new System.Windows.Forms.Timer(components);
            timer_Exit = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pic_Logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Login).BeginInit();
            SuspendLayout();
            // 
            // btn_Exit
            // 
            btn_Exit.AutoSize = true;
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Exit.ForeColor = Color.White;
            btn_Exit.Location = new Point(779, 3);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(20, 14);
            btn_Exit.TabIndex = 1;
            btn_Exit.Text = "X";
            btn_Exit.TextAlign = ContentAlignment.MiddleCenter;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // btn_Minimum
            // 
            btn_Minimum.AutoSize = true;
            btn_Minimum.BackColor = Color.Transparent;
            btn_Minimum.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Minimum.ForeColor = Color.White;
            btn_Minimum.Location = new Point(763, 3);
            btn_Minimum.Name = "btn_Minimum";
            btn_Minimum.Size = new Size(14, 14);
            btn_Minimum.TabIndex = 2;
            btn_Minimum.Text = "-";
            btn_Minimum.TextAlign = ContentAlignment.MiddleCenter;
            btn_Minimum.Click += btn_Minimum_Click;
            // 
            // pic_Logo
            // 
            pic_Logo.BackColor = Color.Transparent;
            pic_Logo.Image = (Image)resources.GetObject("pic_Logo.Image");
            pic_Logo.Location = new Point(222, 3);
            pic_Logo.Name = "pic_Logo";
            pic_Logo.Size = new Size(357, 305);
            pic_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Logo.TabIndex = 3;
            pic_Logo.TabStop = false;
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.BackColor = Color.Transparent;
            lbl_Title.Font = new Font("Engravers MT", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Title.ForeColor = Color.White;
            lbl_Title.Location = new Point(4, 5);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(116, 14);
            lbl_Title.TabIndex = 4;
            lbl_Title.Text = "Chat login";
            // 
            // lbl_Product
            // 
            lbl_Product.AutoSize = true;
            lbl_Product.Font = new Font("Segoe UI Symbol", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Product.ForeColor = Color.White;
            lbl_Product.Location = new Point(6, 432);
            lbl_Product.Name = "lbl_Product";
            lbl_Product.Size = new Size(155, 13);
            lbl_Product.TabIndex = 8;
            lbl_Product.Text = "Login UI by FXTStrix2202";
            // 
            // btn_Login
            // 
            btn_Login.Image = (Image)resources.GetObject("btn_Login.Image");
            btn_Login.Location = new Point(521, 250);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(82, 76);
            btn_Login.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Login.TabIndex = 14;
            btn_Login.TabStop = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_ForgotPassword
            // 
            btn_ForgotPassword.BackColor = Color.White;
            btn_ForgotPassword.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ForgotPassword.Location = new Point(485, 302);
            btn_ForgotPassword.Name = "btn_ForgotPassword";
            btn_ForgotPassword.Size = new Size(28, 24);
            btn_ForgotPassword.TabIndex = 13;
            btn_ForgotPassword.Text = "?";
            btn_ForgotPassword.UseVisualStyleBackColor = false;
            btn_ForgotPassword.Click += btn_ForgotPassword_Click;
            // 
            // txt_InputPassword
            // 
            txt_InputPassword.Location = new Point(211, 303);
            txt_InputPassword.Name = "txt_InputPassword";
            txt_InputPassword.Size = new Size(272, 23);
            txt_InputPassword.TabIndex = 11;
            // 
            // txt_InputUser
            // 
            txt_InputUser.Location = new Point(211, 250);
            txt_InputUser.Name = "txt_InputUser";
            txt_InputUser.Size = new Size(300, 23);
            txt_InputUser.TabIndex = 12;
            // 
            // lbl_InputPassword
            // 
            lbl_InputPassword.AutoSize = true;
            lbl_InputPassword.BackColor = Color.Transparent;
            lbl_InputPassword.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InputPassword.ForeColor = Color.White;
            lbl_InputPassword.Location = new Point(207, 276);
            lbl_InputPassword.Name = "lbl_InputPassword";
            lbl_InputPassword.Size = new Size(83, 20);
            lbl_InputPassword.TabIndex = 9;
            lbl_InputPassword.Text = "Password:";
            // 
            // lbl_InputEmail
            // 
            lbl_InputEmail.AutoSize = true;
            lbl_InputEmail.BackColor = Color.Transparent;
            lbl_InputEmail.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InputEmail.ForeColor = Color.White;
            lbl_InputEmail.Location = new Point(209, 221);
            lbl_InputEmail.Name = "lbl_InputEmail";
            lbl_InputEmail.Size = new Size(55, 20);
            lbl_InputEmail.TabIndex = 10;
            lbl_InputEmail.Text = "Email:";
            // 
            // lbl_CreateAcc
            // 
            lbl_CreateAcc.AutoSize = true;
            lbl_CreateAcc.BackColor = Color.Transparent;
            lbl_CreateAcc.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            lbl_CreateAcc.ForeColor = Color.White;
            lbl_CreateAcc.Location = new Point(209, 338);
            lbl_CreateAcc.Name = "lbl_CreateAcc";
            lbl_CreateAcc.Size = new Size(240, 17);
            lbl_CreateAcc.TabIndex = 15;
            lbl_CreateAcc.Text = "You don't have an account! Create one?";
            lbl_CreateAcc.Click += lbl_CreateAcc_Click;
            // 
            // timer_Hidden
            // 
            timer_Hidden.Interval = 10;
            timer_Hidden.Tick += timer_Hidden_Tick;
            // 
            // timer_Exit
            // 
            timer_Exit.Interval = 10;
            timer_Exit.Tick += timer_Exit_Tick;
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_CreateAcc);
            Controls.Add(btn_Login);
            Controls.Add(btn_ForgotPassword);
            Controls.Add(txt_InputPassword);
            Controls.Add(txt_InputUser);
            Controls.Add(lbl_InputPassword);
            Controls.Add(lbl_InputEmail);
            Controls.Add(lbl_Product);
            Controls.Add(lbl_Title);
            Controls.Add(pic_Logo);
            Controls.Add(btn_Minimum);
            Controls.Add(btn_Exit);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginUI";
            ((System.ComponentModel.ISupportInitialize)pic_Logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Login).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label btn_Exit;
        private Label btn_Minimum;
        private PictureBox pic_Logo;
        private Label lbl_Title;
        private Label lbl_Product;
        private PictureBox btn_Login;
        private Button btn_ForgotPassword;
        private TextBox txt_InputPassword;
        private TextBox txt_InputUser;
        private Label lbl_InputPassword;
        private Label lbl_InputEmail;
        private Label lbl_CreateAcc;
        private System.Windows.Forms.Timer timer_Hidden;
        private System.Windows.Forms.Timer timer_Exit;
    }
}