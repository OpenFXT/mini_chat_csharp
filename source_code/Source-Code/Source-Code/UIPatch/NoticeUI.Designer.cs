namespace Source_Code.UIPatch
{
    partial class NoticeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeUI));
            lbl_TitleNotice = new Label();
            btn_Exit = new Button();
            pic_TypeNotice = new PictureBox();
            lbl_ContentNotice = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_TypeNotice).BeginInit();
            SuspendLayout();
            // 
            // lbl_TitleNotice
            // 
            lbl_TitleNotice.Dock = DockStyle.Top;
            lbl_TitleNotice.Font = new Font("Engravers MT", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_TitleNotice.ForeColor = Color.White;
            lbl_TitleNotice.Location = new Point(0, 0);
            lbl_TitleNotice.Name = "lbl_TitleNotice";
            lbl_TitleNotice.Size = new Size(450, 25);
            lbl_TitleNotice.TabIndex = 0;
            lbl_TitleNotice.Text = "Notice\r\n";
            lbl_TitleNotice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(190, 215);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(75, 23);
            btn_Exit.TabIndex = 1;
            btn_Exit.Text = "Close";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // pic_TypeNotice
            // 
            pic_TypeNotice.Image = (Image)resources.GetObject("pic_TypeNotice.Image");
            pic_TypeNotice.Location = new Point(15, 93);
            pic_TypeNotice.Name = "pic_TypeNotice";
            pic_TypeNotice.Size = new Size(50, 50);
            pic_TypeNotice.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_TypeNotice.TabIndex = 2;
            pic_TypeNotice.TabStop = false;
            // 
            // lbl_ContentNotice
            // 
            lbl_ContentNotice.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ContentNotice.Location = new Point(68, 33);
            lbl_ContentNotice.Name = "lbl_ContentNotice";
            lbl_ContentNotice.Size = new Size(370, 174);
            lbl_ContentNotice.TabIndex = 3;
            lbl_ContentNotice.Text = "This is content of notification";
            lbl_ContentNotice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NoticeUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 250);
            Controls.Add(lbl_ContentNotice);
            Controls.Add(pic_TypeNotice);
            Controls.Add(btn_Exit);
            Controls.Add(lbl_TitleNotice);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NoticeUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoticeUI";
            Load += NoticeUI_Load;
            ((System.ComponentModel.ISupportInitialize)pic_TypeNotice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_TitleNotice;
        private Button btn_Exit;
        private PictureBox pic_TypeNotice;
        private Label lbl_ContentNotice;
    }
}