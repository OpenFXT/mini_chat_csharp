using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Code.UIPatch
{
    public partial class CreateAccountUI : Form
    {
        public CreateAccountUI()
        {
            InitializeComponent();
            AddMouseEffect(lbl_Title);
            txt_Password.PasswordChar = '*';
            txt_Retype.PasswordChar = '*';
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

        public string userEmail, passwordEmail, ipAdmin;
        public Socket sourceConnection;
        public int port;

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (txt_Birthday.Text == "" || txt_Email.Text == "" || txt_Name.Text == "" || txt_Password.Text == "" || txt_Retype.Text == "")
            {
                NoticeUI notice = new NoticeUI();
                notice.title = "Error";
                notice.content = "You must enter all the information completely and cannot leave any part blank";
                notice.typeNotice = "Error";
                notice.ShowDialog();
                return;
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool checkRegularEmail = Regex.IsMatch(txt_Email.Text, pattern);
            if (!checkRegularEmail)
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "Email format is wrong";
                noticeUI.ShowDialog();
                return;
            }
            txt_Name.Text = RunTask.StandardizeString(txt_Name.Text);
            DateTime dateValue;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");
            if (!DateTime.TryParseExact(txt_Birthday.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out dateValue))
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.content = "Incorrect date of birth format";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                return;
            }
            if (txt_Password.Text.Length < 6)
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.content = "Password isn't short";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                return;
            }
            if (txt_Password.Text != txt_Retype.Text)
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.content = "Password and retype password isn't same";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                return;
            }
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Please wait";
            waitingUI.content = "Checking request...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            Thread.Sleep(1000);
            string codeRandom = RunTask.RamdomCode();
            RunTask.SendEmail(userEmail, passwordEmail, "Confirm account creation", "Hey guys,\nFXT Strix 2202 mini chat system recorded an account creation request linked to this email\nIf it's really you, enter the code below to perform the verification.\nCode is: " + codeRandom + "\n\n\nFrom FXTGroup with love!!!", txt_Email.Text);
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
            InputCodeEmailUI inputCodeEmailUI = new InputCodeEmailUI();
            inputCodeEmailUI.emailAddress = txt_Email.Text;
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
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("CreateAccount|" + txt_Email.Text + "|" + txt_Name.Text + "|" + txt_Birthday.Text + "|" + txt_Password.Text), new IPEndPoint(IPAddress.Parse(ipAdmin), port));
            NoticeUI noticeEnd = new NoticeUI();
            noticeEnd.title = "Information";
            noticeEnd.content = "Your account is being created, please wait a minute for your account after this message. Check your email for other information";
            noticeEnd.typeNotice = "Information";
            noticeEnd.ShowDialog();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
