using Source_Code.UIPatch;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Source_Code
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
            UIDesign();
        }

        #region Thiet_Ke_Giao_Dien
        private void btn_Minimum_Click(object sender, EventArgs e)
        {
            timerHidden.Start();
        }

        private void timerHidden_Tick(object sender, EventArgs e)
        {
            double opacityStep = 0.05;
            this.Opacity -= opacityStep;
            if (this.Opacity <= 0)
            {
                timerHidden.Stop();
                this.WindowState = FormWindowState.Minimized;
                Opacity = 1;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            timerExit.Start();
        }

        private void timerExit_Tick(object sender, EventArgs e)
        {
            double opacityStep = 0.05;
            this.Opacity -= opacityStep;
            if (this.Opacity <= 0)
            {
                timerHidden.Stop();
                Environment.Exit(0);
            }
        }

        private Point mouseOffset;
        private bool isMouseDown = false;

        private void LoginUI_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void LoginUI_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
            int yOffset = -e.Y - SystemInformation.FrameBorderSize.Height;
            mouseOffset = new Point(xOffset, yOffset);
            isMouseDown = true;
        }

        private void LoginUI_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void UIDesign()
        {
            TransparentBackgroundContainer();
            BackgroundLinearGradientBrushForm();
            txt_InputPassword.PasswordChar = '*';
        }

        private void TransparentBackgroundContainer()
        {
            pic_Logo.BackColor = Color.Transparent;
            lbl_InputUser.BackColor = Color.Transparent;
            lbl_Title.BackColor = Color.Transparent;
            lbl_InputPassword.BackColor = Color.Transparent;
        }

        private void BackgroundLinearGradientBrushForm()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
            new Point(0, 0),
            new Point(0, Height),
            Color.Black,
            Color.DarkCyan);
            this.BackColor = Color.Black;
            this.BackgroundImage = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(BackgroundImage))
            {
                g.FillRectangle(gradientBrush, new Rectangle(0, 0, Width, Height));
            }
        }
        #endregion

        #region Xu_Ly_Du_Lieu
        public string ipFtpServer, userAdmin, passwordAdmin;

        private void CheckAccount(WaitingUI waitingUI)
        {
            string checkPer = RunTask.DownloadFileFromFTP(txt_InputUser.Text, txt_InputPassword.Text, ipFtpServer, ".Importal/.per", "App-Data/.per");
            if (checkPer != "")
            {
                waitingUI.closePer = true;
                waitingUI.Invoke(() =>
                {
                    waitingUI.Close();
                });
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = checkPer;
                noticeUI.ShowDialog();
                txt_InputPassword.Invoke(() =>
                {
                    txt_InputPassword.Text = "";
                });
                return;
            }
            checkPer = File.ReadAllText("App-Data/.per");
            File.Delete("App-Data/.per");
            if (checkPer != "0")
            {
                waitingUI.closePer = true;
                waitingUI.Invoke(() =>
                {
                    waitingUI.Close();
                });
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "This account does not have administrative access";
                noticeUI.ShowDialog();
                txt_InputPassword.Invoke(() =>
                {
                    txt_InputPassword.Text = "";
                });
                return;
            }
            waitingUI.closePer = true;
            waitingUI.Invoke(() =>
            {
                waitingUI.Close();
            });
            userAdmin = txt_InputUser.Text;
            passwordAdmin = txt_InputPassword.Text;
            this.Invoke(() =>
            {
                this.Close();
            });
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_InputUser.Text == "" || txt_InputPassword.Text == "")
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "Please enter all information including username and password to log in to the server";
                noticeUI.ShowDialog();
                return;
            }
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.content = "Checking credentials...";
            waitingUI.closePer = false;
            new Thread(() =>
            {
                CheckAccount(waitingUI);
            }).Start();
            waitingUI.ShowDialog();
        }

        private void btn_ForgotPassword_Click(object sender, EventArgs e)
        {
            if (txt_InputUser.Text == "")
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Information";
                noticeUI.typeNotice = "Information";
                noticeUI.content = "You must enter your username before using the forgot password function";
                noticeUI.ShowDialog();
                return;
            }

        }
        #endregion
    }
}
