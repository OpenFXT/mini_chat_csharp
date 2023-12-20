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

namespace Source_Code.UIPatch
{
    public partial class WaitingUI : Form
    {
        public WaitingUI()
        {
            InitializeComponent();
            UIDesign();
        }

        #region Thiet_Ke_Giao_Dien
        private void UIDesign()
        {
            AddMouseEffect(lbl_Title);
            LinearColorTitle();
        }

        private void LinearColorTitle()
        {
            LinearGradientBrush brush = new LinearGradientBrush(lbl_Title.ClientRectangle, Color.Black, Color.DarkCyan, LinearGradientMode.Vertical);
            lbl_Title.BackgroundImage = new Bitmap(lbl_Title.Width, lbl_Title.Height);
            Graphics g = Graphics.FromImage(lbl_Title.BackgroundImage);
            g.FillRectangle(brush, 0, 0, lbl_Title.Width, lbl_Title.Height);
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

        private void WaitingUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closePer)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Xu_Ly_Du_Lieu
        private void WaitingUI_Load(object sender, EventArgs e)
        {
            lbl_ContentWait.Text = content;
        }

        public string content = "Content of waiting...";
        public bool closePer = false;
        #endregion
    }
}
