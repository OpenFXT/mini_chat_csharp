namespace Client_Code.UIPatch
{
    partial class ChangeProfileUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeProfileUI));
            lbl_Email = new Label();
            lbl_Name = new Label();
            lbl_Password = new Label();
            lbl_Birthday = new Label();
            lbl_Pic = new Label();
            btn_Update = new Button();
            btn_Cancel = new Button();
            txt_Email = new TextBox();
            txt_Name = new TextBox();
            txt_Password = new TextBox();
            txt_Birthday = new TextBox();
            btn_Pic = new Button();
            SuspendLayout();
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(22, 25);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(39, 15);
            lbl_Email.TabIndex = 0;
            lbl_Email.Text = "Email:";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(22, 59);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(42, 15);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "Name:";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new Point(22, 95);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(60, 15);
            lbl_Password.TabIndex = 0;
            lbl_Password.Text = "Password:";
            // 
            // lbl_Birthday
            // 
            lbl_Birthday.AutoSize = true;
            lbl_Birthday.Location = new Point(22, 129);
            lbl_Birthday.Name = "lbl_Birthday";
            lbl_Birthday.Size = new Size(54, 15);
            lbl_Birthday.TabIndex = 0;
            lbl_Birthday.Text = "Birthday:";
            // 
            // lbl_Pic
            // 
            lbl_Pic.AutoSize = true;
            lbl_Pic.Location = new Point(22, 167);
            lbl_Pic.Name = "lbl_Pic";
            lbl_Pic.Size = new Size(47, 15);
            lbl_Pic.TabIndex = 0;
            lbl_Pic.Text = "Picture:";
            // 
            // btn_Update
            // 
            btn_Update.Location = new Point(56, 207);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(107, 31);
            btn_Update.TabIndex = 1;
            btn_Update.Text = "Update";
            btn_Update.UseVisualStyleBackColor = true;
            btn_Update.Click += btn_Update_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(214, 207);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(107, 31);
            btn_Cancel.TabIndex = 1;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // txt_Email
            // 
            txt_Email.Enabled = false;
            txt_Email.Location = new Point(105, 22);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(248, 23);
            txt_Email.TabIndex = 2;
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(105, 58);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(248, 23);
            txt_Name.TabIndex = 2;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(105, 92);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(248, 23);
            txt_Password.TabIndex = 2;
            txt_Password.Text = "******";
            // 
            // txt_Birthday
            // 
            txt_Birthday.Location = new Point(105, 128);
            txt_Birthday.Name = "txt_Birthday";
            txt_Birthday.Size = new Size(248, 23);
            txt_Birthday.TabIndex = 2;
            // 
            // btn_Pic
            // 
            btn_Pic.Location = new Point(105, 162);
            btn_Pic.Name = "btn_Pic";
            btn_Pic.Size = new Size(41, 25);
            btn_Pic.TabIndex = 3;
            btn_Pic.Text = "...";
            btn_Pic.UseVisualStyleBackColor = true;
            btn_Pic.Click += btn_Pic_Click;
            // 
            // ChangeProfileUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(btn_Pic);
            Controls.Add(txt_Birthday);
            Controls.Add(txt_Password);
            Controls.Add(txt_Name);
            Controls.Add(txt_Email);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Update);
            Controls.Add(lbl_Pic);
            Controls.Add(lbl_Birthday);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Name);
            Controls.Add(lbl_Email);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(400, 300);
            MinimumSize = new Size(400, 300);
            Name = "ChangeProfileUI";
            Text = "Change Information";
            FormClosing += ChangeProfileUI_FormClosing;
            Load += ChangeProfileUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Email;
        private Label lbl_Name;
        private Label lbl_Password;
        private Label lbl_Birthday;
        private Label lbl_Pic;
        private Button btn_Update;
        private Button btn_Cancel;
        private TextBox txt_Email;
        private TextBox txt_Name;
        private TextBox txt_Password;
        private TextBox txt_Birthday;
        private Button btn_Pic;
    }
}