namespace Source_Code.UIPatch
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
            lbl_Title = new Label();
            lbl_ContentWait = new Label();
            pic_IconWaiting = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pic_IconWaiting).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Dock = DockStyle.Top;
            lbl_Title.Font = new Font("Engravers MT", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Title.ForeColor = Color.White;
            lbl_Title.Location = new Point(0, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(450, 25);
            lbl_Title.TabIndex = 1;
            lbl_Title.Text = "Please waiting...";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_ContentWait
            // 
            lbl_ContentWait.Dock = DockStyle.Top;
            lbl_ContentWait.Font = new Font("Courier New", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ContentWait.Location = new Point(0, 25);
            lbl_ContentWait.Name = "lbl_ContentWait";
            lbl_ContentWait.Size = new Size(450, 155);
            lbl_ContentWait.TabIndex = 2;
            lbl_ContentWait.Text = "This is content of waiting";
            lbl_ContentWait.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pic_IconWaiting
            // 
            pic_IconWaiting.Dock = DockStyle.Bottom;
            pic_IconWaiting.Image = (Image)resources.GetObject("pic_IconWaiting.Image");
            pic_IconWaiting.Location = new Point(0, 183);
            pic_IconWaiting.Name = "pic_IconWaiting";
            pic_IconWaiting.Size = new Size(450, 67);
            pic_IconWaiting.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_IconWaiting.TabIndex = 3;
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
            Controls.Add(lbl_Title);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WaitingUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WaitingUI";
            FormClosing += WaitingUI_FormClosing;
            Load += WaitingUI_Load;
            ((System.ComponentModel.ISupportInitialize)pic_IconWaiting).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Title;
        private Label lbl_ContentWait;
        private PictureBox pic_IconWaiting;
    }
}