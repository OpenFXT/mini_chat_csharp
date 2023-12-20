namespace Source_Code.UIPatch
{
    partial class CodeEmailInputUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEmailInputUI));
            txt_InputCode = new TextBox();
            lbl_Title = new Label();
            btn_Enter = new Button();
            SuspendLayout();
            // 
            // txt_InputCode
            // 
            txt_InputCode.Location = new Point(41, 59);
            txt_InputCode.Name = "txt_InputCode";
            txt_InputCode.Size = new Size(197, 23);
            txt_InputCode.TabIndex = 0;
            // 
            // lbl_Title
            // 
            lbl_Title.Dock = DockStyle.Top;
            lbl_Title.Location = new Point(0, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(284, 65);
            lbl_Title.TabIndex = 1;
            lbl_Title.Text = "Nhập mã xác thực được gửi tới email none@none.none:";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_Enter
            // 
            btn_Enter.Location = new Point(99, 98);
            btn_Enter.Name = "btn_Enter";
            btn_Enter.Size = new Size(75, 23);
            btn_Enter.TabIndex = 2;
            btn_Enter.Text = "Enter code";
            btn_Enter.UseVisualStyleBackColor = true;
            btn_Enter.Click += btn_Enter_Click;
            // 
            // CodeEmailInputUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 131);
            Controls.Add(btn_Enter);
            Controls.Add(lbl_Title);
            Controls.Add(txt_InputCode);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(300, 170);
            MinimumSize = new Size(300, 170);
            Name = "CodeEmailInputUI";
            Text = "Input Code";
            Load += CodeEmailInputUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_InputCode;
        private Label lbl_Title;
        private Button btn_Enter;
    }
}