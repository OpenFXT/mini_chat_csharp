namespace Client_Code.UIPatch
{
    partial class CreateAccountUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccountUI));
            lbl_Title = new Label();
            pan_Main = new Panel();
            btn_Cancel = new Button();
            btn_Create = new Button();
            pic_Pic = new PictureBox();
            txt_Retype = new TextBox();
            txt_Password = new TextBox();
            txt_Birthday = new TextBox();
            txt_Name = new TextBox();
            txt_Email = new TextBox();
            lbl_Retype = new Label();
            lbl_Pasword = new Label();
            lbl_Birthday = new Label();
            lbl_Name = new Label();
            lbl_Title_Email = new Label();
            pan_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Pic).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.BackColor = Color.White;
            lbl_Title.Dock = DockStyle.Top;
            lbl_Title.Font = new Font("Engravers MT", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Title.Location = new Point(0, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(530, 24);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "Create account";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pan_Main
            // 
            pan_Main.BackgroundImage = (Image)resources.GetObject("pan_Main.BackgroundImage");
            pan_Main.BackgroundImageLayout = ImageLayout.Stretch;
            pan_Main.Controls.Add(btn_Cancel);
            pan_Main.Controls.Add(btn_Create);
            pan_Main.Controls.Add(pic_Pic);
            pan_Main.Controls.Add(txt_Retype);
            pan_Main.Controls.Add(txt_Password);
            pan_Main.Controls.Add(txt_Birthday);
            pan_Main.Controls.Add(txt_Name);
            pan_Main.Controls.Add(txt_Email);
            pan_Main.Controls.Add(lbl_Retype);
            pan_Main.Controls.Add(lbl_Pasword);
            pan_Main.Controls.Add(lbl_Birthday);
            pan_Main.Controls.Add(lbl_Name);
            pan_Main.Controls.Add(lbl_Title_Email);
            pan_Main.Dock = DockStyle.Bottom;
            pan_Main.Location = new Point(0, 27);
            pan_Main.Name = "pan_Main";
            pan_Main.Size = new Size(530, 293);
            pan_Main.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(286, 258);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(101, 23);
            btn_Cancel.TabIndex = 3;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // btn_Create
            // 
            btn_Create.Location = new Point(107, 258);
            btn_Create.Name = "btn_Create";
            btn_Create.Size = new Size(101, 23);
            btn_Create.TabIndex = 3;
            btn_Create.Text = "Create";
            btn_Create.UseVisualStyleBackColor = true;
            btn_Create.Click += btn_Create_Click;
            // 
            // pic_Pic
            // 
            pic_Pic.Image = (Image)resources.GetObject("pic_Pic.Image");
            pic_Pic.Location = new Point(398, 26);
            pic_Pic.Name = "pic_Pic";
            pic_Pic.Size = new Size(114, 196);
            pic_Pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Pic.TabIndex = 2;
            pic_Pic.TabStop = false;
            // 
            // txt_Retype
            // 
            txt_Retype.Location = new Point(107, 199);
            txt_Retype.Name = "txt_Retype";
            txt_Retype.Size = new Size(270, 23);
            txt_Retype.TabIndex = 1;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(107, 155);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(270, 23);
            txt_Password.TabIndex = 1;
            // 
            // txt_Birthday
            // 
            txt_Birthday.Location = new Point(107, 109);
            txt_Birthday.Name = "txt_Birthday";
            txt_Birthday.Size = new Size(270, 23);
            txt_Birthday.TabIndex = 1;
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(107, 65);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(270, 23);
            txt_Name.TabIndex = 1;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(107, 26);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(270, 23);
            txt_Email.TabIndex = 1;
            // 
            // lbl_Retype
            // 
            lbl_Retype.AutoSize = true;
            lbl_Retype.BackColor = Color.Transparent;
            lbl_Retype.Font = new Font("Book Antiqua", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Retype.ForeColor = Color.White;
            lbl_Retype.Location = new Point(32, 200);
            lbl_Retype.Name = "lbl_Retype";
            lbl_Retype.Size = new Size(53, 18);
            lbl_Retype.TabIndex = 0;
            lbl_Retype.Text = "Retype:";
            // 
            // lbl_Pasword
            // 
            lbl_Pasword.AutoSize = true;
            lbl_Pasword.BackColor = Color.Transparent;
            lbl_Pasword.Font = new Font("Book Antiqua", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Pasword.ForeColor = Color.White;
            lbl_Pasword.Location = new Point(32, 156);
            lbl_Pasword.Name = "lbl_Pasword";
            lbl_Pasword.Size = new Size(69, 18);
            lbl_Pasword.TabIndex = 0;
            lbl_Pasword.Text = "Password:";
            // 
            // lbl_Birthday
            // 
            lbl_Birthday.AutoSize = true;
            lbl_Birthday.BackColor = Color.Transparent;
            lbl_Birthday.Font = new Font("Book Antiqua", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Birthday.ForeColor = Color.White;
            lbl_Birthday.Location = new Point(32, 110);
            lbl_Birthday.Name = "lbl_Birthday";
            lbl_Birthday.Size = new Size(63, 18);
            lbl_Birthday.TabIndex = 0;
            lbl_Birthday.Text = "Birthday:";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.BackColor = Color.Transparent;
            lbl_Name.Font = new Font("Book Antiqua", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Name.ForeColor = Color.White;
            lbl_Name.Location = new Point(32, 68);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(48, 18);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "Name:";
            // 
            // lbl_Title_Email
            // 
            lbl_Title_Email.AutoSize = true;
            lbl_Title_Email.BackColor = Color.Transparent;
            lbl_Title_Email.Font = new Font("Book Antiqua", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Title_Email.ForeColor = Color.White;
            lbl_Title_Email.Location = new Point(32, 26);
            lbl_Title_Email.Name = "lbl_Title_Email";
            lbl_Title_Email.Size = new Size(46, 18);
            lbl_Title_Email.TabIndex = 0;
            lbl_Title_Email.Text = "Email:";
            // 
            // CreateAccountUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 320);
            Controls.Add(pan_Main);
            Controls.Add(lbl_Title);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateAccountUI";
            Text = "CreateAccountUI";
            pan_Main.ResumeLayout(false);
            pan_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Pic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Title;
        private Panel pan_Main;
        private PictureBox pic_Pic;
        private TextBox txt_Retype;
        private TextBox txt_Password;
        private TextBox txt_Birthday;
        private TextBox txt_Name;
        private TextBox txt_Email;
        private Label lbl_Retype;
        private Label lbl_Pasword;
        private Label lbl_Birthday;
        private Label lbl_Name;
        private Label lbl_Title_Email;
        private Button btn_Create;
        private Button btn_Cancel;
    }
}