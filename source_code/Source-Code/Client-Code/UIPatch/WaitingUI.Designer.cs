namespace Client_Code.UIPatch
{
    partial class WaitingUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingUI));
            pan_TitleWaiting = new Panel();
            lbl_TitleWaiting = new Label();
            lbl_ContentWait = new Label();
            pic_IconWaiting = new PictureBox();
            pan_TitleWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_IconWaiting).BeginInit();
            SuspendLayout();
            // 
            // pan_TitleWaiting
            // 
            pan_TitleWaiting.BackgroundImage = (Image)resources.GetObject("pan_TitleWaiting.BackgroundImage");
            pan_TitleWaiting.BackgroundImageLayout = ImageLayout.Stretch;
            pan_TitleWaiting.BorderStyle = BorderStyle.FixedSingle;
            pan_TitleWaiting.Controls.Add(lbl_TitleWaiting);
            pan_TitleWaiting.Dock = DockStyle.Top;
            pan_TitleWaiting.Location = new Point(0, 0);
            pan_TitleWaiting.Name = "pan_TitleWaiting";
            pan_TitleWaiting.Size = new Size(450, 41);
            pan_TitleWaiting.TabIndex = 2;
            // 
            // lbl_TitleWaiting
            // 
            lbl_TitleWaiting.BackColor = Color.Transparent;
            lbl_TitleWaiting.Dock = DockStyle.Fill;
            lbl_TitleWaiting.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_TitleWaiting.ForeColor = Color.White;
            lbl_TitleWaiting.Location = new Point(0, 0);
            lbl_TitleWaiting.Name = "lbl_TitleWaiting";
            lbl_TitleWaiting.Size = new Size(448, 39);
            lbl_TitleWaiting.TabIndex = 0;
            lbl_TitleWaiting.Text = "Title waiting";
            lbl_TitleWaiting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ContentWait
            // 
            lbl_ContentWait.Dock = DockStyle.Top;
            lbl_ContentWait.Font = new Font("Courier New", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ContentWait.Location = new Point(0, 41);
            lbl_ContentWait.Name = "lbl_ContentWait";
            lbl_ContentWait.Size = new Size(450, 140);
            lbl_ContentWait.TabIndex = 3;
            lbl_ContentWait.Text = "This is content of waiting";
            lbl_ContentWait.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pic_IconWaiting
            // 
            pic_IconWaiting.Image = (Image)resources.GetObject("pic_IconWaiting.Image");
            pic_IconWaiting.Location = new Point(126, 166);
            pic_IconWaiting.Name = "pic_IconWaiting";
            pic_IconWaiting.Size = new Size(195, 85);
            pic_IconWaiting.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_IconWaiting.TabIndex = 4;
            pic_IconWaiting.TabStop = false;
            // 
            // WaitingUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 250);
            Controls.Add(pic_IconWaiting);
            Controls.Add(lbl_ContentWait);
            Controls.Add(pan_TitleWaiting);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WaitingUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WaitingUI";
            FormClosing += WaitingUI_FormClosing;
            Load += WaitingUI_Load;
            pan_TitleWaiting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_IconWaiting).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pan_TitleWaiting;
        private Label lbl_TitleWaiting;
        private Label lbl_ContentWait;
        private PictureBox pic_IconWaiting;
    }
}