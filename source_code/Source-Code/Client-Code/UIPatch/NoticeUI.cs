using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Code.UIPatch
{
    public partial class NoticeUI : Form
    {
        public NoticeUI()
        {
            InitializeComponent();
            UIDesign();
        }

        #region Thiet_Ke_Giao_Dien
        private void UIDesign()
        {
            //LinearColorTitleNotice();
            AddMouseEffect(lbl_TitleNotification);
        }

        private void LinearColorTitleNotice()
        {
            LinearGradientBrush brush = new LinearGradientBrush(lbl_TitleNotification.ClientRectangle, Color.Black, Color.DarkCyan, LinearGradientMode.Vertical);
            lbl_TitleNotification.BackgroundImage = new Bitmap(lbl_TitleNotification.Width, lbl_TitleNotification.Height);
            Graphics g = Graphics.FromImage(lbl_TitleNotification.BackgroundImage);
            g.FillRectangle(brush, 0, 0, lbl_TitleNotification.Width, lbl_TitleNotification.Height);
        }

        private void AddMouseEffect(Control control)
        {
            control.MouseDown += new MouseEventHandler(Form_MouseDown);
            control.MouseMove += new MouseEventHandler(Form_MouseMove);
            control.MouseUp += new MouseEventHandler(Form_MouseUp);
        }

        private Point mouseOffset;
        private bool isMouseDown = false;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
            int yOffset = -e.Y - SystemInformation.FrameBorderSize.Height;
            mouseOffset = new Point(xOffset, yOffset);
            isMouseDown = true;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        #endregion

        #region Xu_Ly_Du_Lieu
        private void NoticeUI_Load(object sender, EventArgs e)
        {
            lbl_TitleNotification.Text = title;
            lbl_ContentNotice.Text = content;
            if (typeNotice != "Information")
                pic_TypeNotice.Image = Image.FromFile("./Source-File-Inside-2/Error_Notification_Icon.png");
        }

        public string title = "Notification";
        public string content = "Content of notification";
        public string typeNotice = "Information";

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
