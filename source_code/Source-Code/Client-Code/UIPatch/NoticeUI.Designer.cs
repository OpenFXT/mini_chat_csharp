namespace Client_Code.UIPatch
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
            lbl_TitleNotification = new Label();
            pan_TitleNotification = new Panel();
            pic_TypeNotice = new PictureBox();
            lbl_ContentNotice = new Label();
            btn_Exit = new Button();
            pan_TitleNotification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_TypeNotice).BeginInit();
            SuspendLayout();
            // 
            // lbl_TitleNotification
            // 
            lbl_TitleNotification.BackColor = Color.Transparent;
            lbl_TitleNotification.Dock = DockStyle.Fill;
            lbl_TitleNotification.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_TitleNotification.ForeColor = Color.White;
            lbl_TitleNotification.Location = new Point(0, 0);
            lbl_TitleNotification.Name = "lbl_TitleNotification";
            lbl_TitleNotification.Size = new Size(448, 39);
            lbl_TitleNotification.TabIndex = 0;
            lbl_TitleNotification.Text = "Title notification";
            lbl_TitleNotification.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pan_TitleNotification
            // 
            pan_TitleNotification.BackgroundImage = (Image)resources.GetObject("pan_TitleNotification.BackgroundImage");
            pan_TitleNotification.BackgroundImageLayout = ImageLayout.Stretch;
            pan_TitleNotification.BorderStyle = BorderStyle.FixedSingle;
            pan_TitleNotification.Controls.Add(lbl_TitleNotification);
            pan_TitleNotification.Dock = DockStyle.Top;
            pan_TitleNotification.Location = new Point(0, 0);
            pan_TitleNotification.Name = "pan_TitleNotification";
            pan_TitleNotification.Size = new Size(450, 41);
            pan_TitleNotification.TabIndex = 1;
            // 
            // pic_TypeNotice
            // 
            pic_TypeNotice.BackColor = Color.Transparent;
            pic_TypeNotice.Image = (Image)resources.GetObject("pic_TypeNotice.Image");
            pic_TypeNotice.Location = new Point(12, 107);
            pic_TypeNotice.Name = "pic_TypeNotice";
            pic_TypeNotice.Size = new Size(50, 50);
            pic_TypeNotice.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_TypeNotice.TabIndex = 3;
            pic_TypeNotice.TabStop = false;
            // 
            // lbl_ContentNotice
            // 
            lbl_ContentNotice.BackColor = Color.Transparent;
            lbl_ContentNotice.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ContentNotice.Location = new Point(70, 47);
            lbl_ContentNotice.Name = "lbl_ContentNotice";
            lbl_ContentNotice.Size = new Size(370, 174);
            lbl_ContentNotice.TabIndex = 4;
            lbl_ContentNotice.Text = "This is content of notification";
            lbl_ContentNotice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(186, 215);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(75, 23);
            btn_Exit.TabIndex = 5;
            btn_Exit.Text = "Close";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // NoticeUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 250);
            Controls.Add(btn_Exit);
            Controls.Add(lbl_ContentNotice);
            Controls.Add(pic_TypeNotice);
            Controls.Add(pan_TitleNotification);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NoticeUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoticeUI";
            Load += NoticeUI_Load;
            pan_TitleNotification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_TypeNotice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_TitleNotification;
        private Panel pan_TitleNotification;
        private PictureBox pic_TypeNotice;
        private Label lbl_ContentNotice;
        private Button btn_Exit;
    }
}