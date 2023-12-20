using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Code.UIPatch
{
    public partial class WaitingUI : Form
    {
        public WaitingUI()
        {
            InitializeComponent();
            AddMouseEffect(lbl_TitleWaiting);
        }

        #region Thiet_Ke_Giao_Dien
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
        public string title = "Please waiting...";
        public string content = "";
        public bool closePer = false;

        private void WaitingUI_Load(object sender, EventArgs e)
        {
            lbl_TitleWaiting.Text = title;
            lbl_ContentWait.Text = content;
        }

        private void WaitingUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.closePer)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
