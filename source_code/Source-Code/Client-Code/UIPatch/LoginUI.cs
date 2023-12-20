using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Client_Code.UIPatch
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
            txt_InputPassword.PasswordChar = '*';
            AddMouseEffect(this);
        }

        #region Xu_Ly_Giao_Dien
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            timer_Exit.Start();
        }

        private void timer_Exit_Tick(object sender, EventArgs e)
        {
            double opacityStep = 0.05;
            this.Opacity -= opacityStep;
            if (this.Opacity <= 0)
            {
                timer_Hidden.Stop();
                Environment.Exit(0);
            }
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

        private void timer_Hidden_Tick(object sender, EventArgs e)
        {
            double opacityStep = 0.05;
            this.Opacity -= opacityStep;
            if (this.Opacity <= 0)
            {
                timer_Hidden.Stop();
                this.WindowState = FormWindowState.Minimized;
                Opacity = 1;
            }
        }

        private void btn_Minimum_Click(object sender, EventArgs e)
        {
            timer_Hidden.Start();
        }
        #endregion

        #region Xu_Ly_Du_Lieu
        public string thisUser, passUser;
        public string ipAdmin;
        public Socket sourceConnect;
        public int port;
        public string ipFtpServer;

        private void CheckAccount(WaitingUI waitingUI)
        {
            sourceConnect.SendTo(Encoding.UTF8.GetBytes("UserConverter|" + txt_InputUser.Text), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            byte[] data = new byte[1024];
            EndPoint tempPoint = new IPEndPoint(IPAddress.Any, 0);
            int countData = sourceConnect.ReceiveFrom(data, ref tempPoint);
            string message = Encoding.UTF8.GetString(data, 0, countData);
            string userConverter = (message.Split('|'))[1];
            string checkPer = RunTask.DownloadFileFromFTP(userConverter, txt_InputPassword.Text, ipFtpServer, ".Importal/.per", "App-Data/.per");

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

            sourceConnect.SendTo(Encoding.UTF8.GetBytes("CheckActivity|" + userConverter), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            countData = sourceConnect.ReceiveFrom(data, ref tempPoint);
            message = Encoding.UTF8.GetString(data, 0, countData);
            if (message.Split('|')[2] == "1")
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.content = "This account is being logged in somewhere else";
                noticeUI.ShowDialog();
                waitingUI.closePer = true;
                waitingUI.Invoke(() =>
                {
                    waitingUI.Close();
                });
                return;
            }

            checkPer = File.ReadAllText("App-Data/.per");
            File.Delete("App-Data/.per");
            if (checkPer != "1")
            {
                waitingUI.closePer = true;
                waitingUI.Invoke(() =>
                {
                    waitingUI.Close();
                });
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "This account does not have access";
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
            thisUser = userConverter;
            passUser = txt_InputPassword.Text;
            this.Invoke(() =>
            {
                DeEncryEmail();
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
                noticeUI.content = "Please enter all information including username and password to log in to the client";
                noticeUI.ShowDialog();
                return;
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool checkRegularEmail = Regex.IsMatch(txt_InputUser.Text, pattern);
            if (!checkRegularEmail)
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "Email format is wrong";
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

        public string userMail, passwordMail;

        private void DeEncryEmail()
        {
            byte[] data = new byte[5024];
            sourceConnect.SendTo(Encoding.UTF8.GetBytes("GetPLKeyRsa|"), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            EndPoint tempPoint = new IPEndPoint(IPAddress.Any, 0);
            int countData = sourceConnect.ReceiveFrom(data, ref tempPoint);
            string message = Encoding.UTF8.GetString(data, 0, countData);
            File.WriteAllText("public_key.pem", message.Split('|')[1]);
            sourceConnect.SendTo(Encoding.UTF8.GetBytes("GetPVKeyRsa|"), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            tempPoint = new IPEndPoint(IPAddress.Any, 0);
            countData = sourceConnect.ReceiveFrom(data, ref tempPoint);
            message = Encoding.UTF8.GetString(data, 0, countData);
            File.WriteAllText("private_key.pem", message.Split('|')[1]);

            File.Move("./App-Data/user_mail.encry", "ma_hoa.encry");
            Process process = new Process();
            process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            userMail = File.ReadAllText("giai_ma.txt");
            File.Delete("giai_ma.txt");
            File.Move("ma_hoa.encry", "./App-Data/user_mail.encry");

            File.Move("./App-Data/password_mail.encry", "ma_hoa.encry");
            process = new Process();
            process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            passwordMail = File.ReadAllText("giai_ma.txt");
            File.Delete("giai_ma.txt");
            File.Move("ma_hoa.encry", "./App-Data/password_mail.encry");
            File.Delete("private_key.pem");
            File.Delete("public_key.pem");
        }

        private void btn_ForgotPassword_Click(object sender, EventArgs e)
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Please waiting...";
            waitingUI.content = "Checking request...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool checkRegularEmail = Regex.IsMatch(txt_InputUser.Text, pattern);
            if (!checkRegularEmail)
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "Email format is wrong. Please enter the correct email address to find the password for your account";
                noticeUI.ShowDialog();
                waitingUI.closePer = true;
                waitingUI.Invoke(() =>
                {
                    waitingUI.Close();
                });
                return;
            }
            sourceConnect.SendTo(Encoding.UTF8.GetBytes("UserConverter|" + txt_InputUser.Text), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            byte[] data = new byte[5024];
            EndPoint tempPoint = new IPEndPoint(IPAddress.Any, 0);
            int countData = sourceConnect.ReceiveFrom(data, ref tempPoint);
            string message = Encoding.UTF8.GetString(data, 0, countData);
            string userConverter = (message.Split('|'))[1];
            if (userConverter == "")
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "Couldn't find any accounts associated with the email address you entered";
                waitingUI.closePer = true;
                waitingUI.Invoke(() =>
                {
                    waitingUI.Close();
                });
                noticeUI.ShowDialog();
                return;
            }
            DeEncryEmail();
            waitingUI.closePer = true;
            string codeRandom = RunTask.RamdomCode();
            RunTask.SendEmail(userMail, passwordMail, "REQUEST FORGET PASSWORD", $"Hi user {txt_InputUser.Text}\nWe noticed that you requested the forgot password function at {RunTask.GetCurrentDateTime()}.If it's really you, enter this code and we'll make a new password for you\nCode is: {codeRandom}\n\n\nFrom FXTGroup with love!!!", txt_InputUser.Text);
            waitingUI.Invoke(() =>
            {
                waitingUI.Close();
            });
            InputCodeEmailUI inputCodeEmailUI = new InputCodeEmailUI();
            inputCodeEmailUI.emailAddress = txt_InputUser.Text;
            inputCodeEmailUI.ShowDialog();
            if (codeRandom != inputCodeEmailUI.code)
            {
                NoticeUI notice = new NoticeUI();
                notice.title = "Error";
                notice.typeNotice = "Error";
                notice.content = "The verification code you entered is incorrect, the change is aborted";
                notice.ShowDialog();
                return;
            }
            codeRandom = RunTask.RamdomCode();
            data = new byte[5124];
            sourceConnect.SendTo(Encoding.UTF8.GetBytes("ChangePassword|" + userConverter + "|" + codeRandom), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            NoticeUI noticeUI1 = new NoticeUI();
            noticeUI1.title = "Information";
            noticeUI1.typeNotice = "Information";
            noticeUI1.content = "New password for your account is: " + codeRandom;
            noticeUI1.ShowDialog();
        }
        #endregion

        #region Xu_Ly_Tao_Tai_Khoan
        private void CreateAccount_Click(object sender, EventArgs e)
        {
            DeEncryEmail();
            CreateAccountUI createAccountUI = new CreateAccountUI();
            createAccountUI.userEmail = userMail;
            createAccountUI.passwordEmail = passwordMail;
            createAccountUI.ipAdmin = ipAdmin;
            createAccountUI.sourceConnection = sourceConnect;
            createAccountUI.port = port;
            createAccountUI.ShowDialog();
        }
        #endregion

        private void lbl_CreateAcc_Click(object sender, EventArgs e)
        {
            CreateAccount_Click(sender, e);
        }
    }
}
