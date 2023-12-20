namespace Client_Code.UIPatch
{
    partial class CallingUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallingUI));
            lbl_Title = new Label();
            btn_Destroy = new Button();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Dock = DockStyle.Top;
            lbl_Title.Location = new Point(0, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(184, 83);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "`";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Destroy
            // 
            btn_Destroy.Location = new Point(43, 86);
            btn_Destroy.Name = "btn_Destroy";
            btn_Destroy.Size = new Size(88, 52);
            btn_Destroy.TabIndex = 1;
            btn_Destroy.Text = "Stop";
            btn_Destroy.UseVisualStyleBackColor = true;
            btn_Destroy.Click += btn_Destroy_Click;
            // 
            // CallingUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(184, 161);
            Controls.Add(btn_Destroy);
            Controls.Add(lbl_Title);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CallingUI";
            Text = "Calling...";
            FormClosing += CallingUI_FormClosing;
            Load += CallingUI_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Title;
        private Button btn_Destroy;
    }
}