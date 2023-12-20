using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client_Code.UIPatch
{
    public partial class ClientUI : Form
    {
        public ClientUI()
        {
            InitializeComponent();
            AddMouseEffect(pan_Top);
            ConnectingIP();
            LoginEvent();
        }

        #region Xu_Ly_Giao_Dien
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

        private void btn_Minimum_Click(object sender, EventArgs e)
        {
            timer_Hidden.Start();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Su_Kien_Dang_Nhap
        private string ipAdmin;
        private string[] statusUser;
        private bool CheckActiveServer()
        {
            statusUser = RunTask.DecryptionCode(File.ReadAllText("./App-Data/status_user.txt").Trim()).Split('|');
            RunTask.DownloadFileFromFTP(statusUser[0], statusUser[1], ipFtpServer, ".status", "status.txt");
            string[] status = File.ReadAllText("status.txt").Split('|');
            File.Delete("status.txt");
            if (status[0] == "1")
            {
                ipAdmin = status[1];
                return true;
            }
            return false;
        }

        private string thisUser, thisPassword;
        private string id, name, mail, birthday, joinday;

        private void LoadProfile()
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Please waiting";
            waitingUI.content = "Loading profile...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Importal/.profile", "profile.txt");
            string[] profile = RunTask.DecryptionCode(File.ReadAllText("profile.txt").Trim()).Split('|');
            File.Delete("profile.txt");
            id = profile[0].Substring(1);
            name = profile[1];
            birthday = profile[2];
            mail = profile[3];
            joinday = profile[4];

            try { File.Delete("profile.jpg"); } catch { }
            RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Importal/.pic", "./App-Data/profile.jpg");
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private List<string> friendListNameUser = new List<string>();
        private string userMail, passwordMail;

        private void LoginEvent()
        {
            if (!CheckActiveServer())
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "Server not active";
                noticeUI.ShowDialog();
                Environment.Exit(0);
            }
            LoginUI loginUI = new LoginUI();
            loginUI.ipAdmin = ipAdmin;
            loginUI.sourceConnect = sourceConnection;
            loginUI.port = int.Parse(ipAddressAndPort[1]);
            loginUI.ipFtpServer = ipFtpServer;
            loginUI.ShowDialog();
            thisUser = loginUI.thisUser;
            thisPassword = loginUI.passUser;
            userMail = loginUI.userMail;
            passwordMail = loginUI.passwordMail;

            LoadProfile();
            LoadFriendList();
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("GetName|" + thisUser), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            byte[] data = new byte[1024];
            EndPoint end = new IPEndPoint(IPAddress.Any, 0);
            int countData = sourceConnection.ReceiveFrom(data, ref end);
            thisName = (Encoding.UTF8.GetString(data, 0, countData)).Split('|')[1];
            lbl_ID.Text = "#" + thisUser + " - " + thisName;

            string newProfile = "#" + thisUser.Substring(4) + "|" + name + "|" + birthday + "|" + mail + "|" + joinday + "|1|" + ipAddressAndPort[0];
            newProfile = RunTask.CryptionCode(newProfile);
            File.WriteAllText("data.txt", newProfile);
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Importal/.profile");
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "data.txt", ".Importal/.profile");

            sourceConnection.SendTo(Encoding.UTF8.GetBytes("Login|" + thisUser), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
        }

        private Socket sourceConnection;
        private string[] ipAddressAndPort;
        private string thisName;

        private void ConnectingIP()
        {
            try
            {
                ipAddressAndPort = File.ReadAllLines("./App-Data/ip_address_and_port.txt");
                sourceConnection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint connectPoint = new IPEndPoint(IPAddress.Parse(ipAddressAndPort[0]), int.Parse(ipAddressAndPort[1]));
                sourceConnection.Bind(connectPoint);
            }
            catch
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.content = "An error occurred while connecting to the network";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                Environment.Exit(0);
            }
        }
        #endregion

        #region Xu_Ly_Du_Lieu
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            ChangeProfileUI changeProfileUI = new ChangeProfileUI();
            changeProfileUI.name = thisName;
            changeProfileUI.email = mail;
            changeProfileUI.birthday = birthday;
            changeProfileUI.password = thisPassword;
            changeProfileUI.ShowDialog();

            if (!changeProfileUI.change)
            {
                return;
            }

            changeProfileUI.name = RunTask.StandardizeString(changeProfileUI.name);
            NoticeUI noticeUI = new NoticeUI();
            if (changeProfileUI.name.Length < 6)
            {
                noticeUI.title = "Error";
                noticeUI.content = "Your name is too short";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                return;
            }

            if (changeProfileUI.password.Length < 6)
            {
                noticeUI.title = "Error";
                noticeUI.content = "Password is too short";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                return;
            }

            DateTime dateValue;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");
            if (!DateTime.TryParseExact(changeProfileUI.birthday, "dd/MM/yyyy", culture, DateTimeStyles.None, out dateValue))
            {
                noticeUI.title = "Error";
                noticeUI.content = "Incorrect date of birth format";
                noticeUI.typeNotice = "Error";
                noticeUI.ShowDialog();
                return;
            }

            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Please waiting...";
            waitingUI.content = "Checking request...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            Thread.Sleep(1000);

            //string codeRandom = RunTask.RamdomCode();
            //RunTask.SendEmail(userMail, passwordMail, "REQUEST CHANGE INFORMATION", $"Hi user {thisName}\nWe noticed that you requested the change information function at {RunTask.GetCurrentDateTime()}.If it's really you, enter this code and we'll make a new informaiton for you\nCode is: {codeRandom}\n\n\nFrom FXTGroup with love!!!", mail);
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });

            //InputCodeEmailUI inputCodeEmailUI = new InputCodeEmailUI();
            //inputCodeEmailUI.emailAddress = mail;
            //inputCodeEmailUI.ShowDialog();

            //if (codeRandom != inputCodeEmailUI.code)
            //{
            //    NoticeUI notice = new NoticeUI();
            //    notice.title = "Error";
            //    notice.typeNotice = "Error";
            //    notice.content = "The verification code you entered is incorrect, the change is aborted";
            //    notice.ShowDialog();
            //    return;
            //}
            Thread.Sleep(1000);
            waitingUI.content = "Completing...";
            waitingUI.closePer = false;
            newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            if (changeProfileUI.pathPicture != "")
            {
                RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Importal/.pic");
                RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, changeProfileUI.pathPicture, ".Importal/.pic");
            }

            string newProfile = "#" + thisUser.Substring(4) + "|" + changeProfileUI.name + "|" + changeProfileUI.birthday + "|" + mail + "|" + joinday + "|1|" + ipAddressAndPort[0];
            newProfile = RunTask.CryptionCode(newProfile);
            File.WriteAllText("data.txt", newProfile);
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Importal/.profile");
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "data.txt", ".Importal/.profile");
            File.Delete("data.txt");
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("ChangePassword|" + thisUser + "|" + changeProfileUI.password), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
            birthday = changeProfileUI.birthday;
            name = changeProfileUI.name;
            thisPassword = changeProfileUI.password;
            noticeUI = new NoticeUI();
            noticeUI.title = "Information";
            noticeUI.typeNotice = "Information";
            noticeUI.content = "Changes will apply the next time you log in";
            noticeUI.ShowDialog();
        }

        private void btn_Ring_Click(object sender, EventArgs e)
        {
            NoticeUI noticeUI = new NoticeUI();
            noticeUI.title = "Information";
            noticeUI.typeNotice = "Information";
            noticeUI.content = "Feature is in testing";
            noticeUI.ShowDialog();
        }

        private void btn_AddIcoon_Click(object sender, EventArgs e)
        {
            enabled = false;
            friendPanelHeight = 0;
            Loopack();
            LoadFriendList();
            NoticeUI noticeUI = new NoticeUI();
            noticeUI.title = "Information";
            noticeUI.typeNotice = "Information";
            noticeUI.content = "Feature is in testing";
            noticeUI.ShowDialog();
        }

        private void btn_RemoveChat_Click(object sender, EventArgs e)
        {
            idCurrentBox = "";
            pan_Main.Controls.Remove(pan_RightMain);
            pic_Logo.Visible = true;
            firstClick = 0;
            foreach (Control control in pan_LeftMain.Controls)
            {
                control.BackColor = Color.Transparent;
            }
        }

        private string ipFtpServer = File.ReadAllText("./App-Data/ftp_ip.txt");

        private Panel AddPanelMessage(string[] part)
        {
            // Name
            Label lbl_NameFriendChat = new Label();
            lbl_NameFriendChat.AutoSize = true;
            lbl_NameFriendChat.BackColor = Color.Transparent;
            lbl_NameFriendChat.Font = new Font("Time News Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_NameFriendChat.ForeColor = Color.White;
            lbl_NameFriendChat.Location = new Point(46, 12);
            lbl_NameFriendChat.Name = "lbl_NameFriendChat";
            lbl_NameFriendChat.Size = new Size(84, 15);
            lbl_NameFriendChat.TabIndex = 1;
            lbl_NameFriendChat.Text = part[0];

            // Pic
            PictureBox pic_ImageFriendChat = new PictureBox();
            pic_ImageFriendChat.BackColor = Color.Black;
            pic_ImageFriendChat.Location = new Point(17, 7);
            pic_ImageFriendChat.Name = "pic_ImageFriendChat";
            pic_ImageFriendChat.Size = new Size(25, 25);
            pic_ImageFriendChat.TabIndex = 0;
            pic_ImageFriendChat.TabStop = false;
            pic_ImageFriendChat.Image = Image.FromFile(part[1]);
            pic_ImageFriendChat.SizeMode = PictureBoxSizeMode.StretchImage;

            // Message
            Label lbl_MessageFriendChat = new Label();
            lbl_MessageFriendChat.BackColor = Color.Transparent;
            lbl_MessageFriendChat.Text = part[2];
            lbl_MessageFriendChat.MaximumSize = new Size(500, 0);
            lbl_MessageFriendChat.AutoSize = true;
            lbl_MessageFriendChat.Font = new Font("Time News Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MessageFriendChat.ForeColor = Color.White;
            lbl_MessageFriendChat.Location = new Point(50, 31);
            lbl_MessageFriendChat.Name = "lbl_MessageFriendChat";
            lbl_MessageFriendChat.Click += new EventHandler(pan_File_Click);
            lbl_MessageFriendChat.TabIndex = 1;

            // Time
            Label lbl_TimeFriendChat = new Label();
            lbl_TimeFriendChat.BackColor = Color.Transparent;
            lbl_TimeFriendChat.AutoSize = true;
            lbl_TimeFriendChat.BackColor = Color.Transparent;
            lbl_TimeFriendChat.ForeColor = Color.White;
            lbl_TimeFriendChat.Location = new Point(557, 17);
            lbl_TimeFriendChat.Name = "lbl_TimeFriendChat";
            lbl_TimeFriendChat.Size = new Size(34, 15);
            lbl_TimeFriendChat.TabIndex = 2;
            lbl_TimeFriendChat.Text = part[3];

            // Panel
            Panel pan_ContentFriendChat = new Panel();
            pan_ContentFriendChat.AutoSize = true;
            pan_ContentFriendChat.Controls.Add(lbl_NameFriendChat);
            pan_ContentFriendChat.Controls.Add(pic_ImageFriendChat);
            pan_ContentFriendChat.Controls.Add(lbl_MessageFriendChat);
            pan_ContentFriendChat.Controls.Add(lbl_TimeFriendChat);
            pan_ContentFriendChat.Location = new Point(0, sumHeight);
            pan_ContentFriendChat.Name = "pan_ContentFriendChat";
            pan_ContentFriendChat.Size = new Size(656, 48);
            pan_ContentFriendChat.TabIndex = 0;
            pan_ContentFriendChat.BackgroundImage = Image.FromFile("Background-Client-Chat.jpg");
            sumHeight += (pan_ContentFriendChat.Height + lbl_MessageFriendChat.Height - 10);
            return pan_ContentFriendChat;
        }

        private int sumHeight = 0;
        private string idCurrentBox = "";

        private void LoadMessage(string nameFriend, string pathPicFriend, string id)
        {
            sumHeight = 0;
            idCurrentBox = id;
            pan_ChatContent.Invoke(() => { pan_ChatContent.Controls.Clear(); });

            lbl_NameFriendBox.Invoke(() => { lbl_NameFriendBox.Text = nameFriend; });
            pic_Friend.Invoke(() => { pic_Friend.BackgroundImage = Image.FromFile(pathPicFriend); });
            btn_Active.Invoke(() => { btn_Active.Image = null; });
            if (idCurrentBox != "bingid")
                sourceConnection.SendTo(Encoding.UTF8.GetBytes("CheckActivity|" + id), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Conversation/" + id + ".conversation", id + ".txt");

            string content = File.ReadAllText(id + ".txt");
            string[] lines = RunTask.DecryptionCode(content).Split('\n');
            File.Delete(id + ".txt");
            Panel panel = new Panel();
            if (id == "bingid")
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    if (lines[i].Substring(0, 6) == id)
                        lines[i] = nameFriend + "|" + pathPicFriend + lines[i].Substring(6);
                    else
                        lines[i] = "Bạn" + "|" + "./App-Data/profile.jpg" + lines[i].Substring(9);
                    panel = AddPanelMessage(lines[i].Split('|'));
                    pan_ChatContent.Invoke(() => { pan_ChatContent.Controls.Add(panel); });
                }
            }
            else
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    if (lines[i].Substring(0, 9) == id)
                        lines[i] = nameFriend + "|" + pathPicFriend + lines[i].Substring(9);
                    else
                        lines[i] = "Bạn" + "|" + "./App-Data/profile.jpg" + lines[i].Substring(9);
                    panel = AddPanelMessage(lines[i].Split('|'));
                    pan_ChatContent.Invoke(() => { pan_ChatContent.Controls.Add(panel); });
                }
            }
            pan_ChatContent.Invoke(() => { pan_ChatContent.ScrollControlIntoView(panel); });

        }

        private void AddPanelFriend(string[] partOf)
        {
            // Pictrue
            PictureBox pic_MyFriend = new PictureBox();
            pic_MyFriend.BackColor = Color.Transparent;
            pic_MyFriend.Location = new Point(13, 6);
            pic_MyFriend.Name = "pic_MyFriend";
            pic_MyFriend.Size = new Size(28, 28);
            pic_MyFriend.TabIndex = 0;
            pic_MyFriend.TabStop = false;
            pic_MyFriend.Image = Image.FromFile(partOf[0]);
            pic_MyFriend.SizeMode = PictureBoxSizeMode.StretchImage;

            // Name
            Label lbl_NameMyFriend = new Label();
            lbl_NameMyFriend.AutoSize = true;
            lbl_NameMyFriend.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_NameMyFriend.ForeColor = Color.White;
            lbl_NameMyFriend.Location = new Point(50, 12);
            lbl_NameMyFriend.Name = partOf[3];
            lbl_NameMyFriend.Size = new Size(119, 17);
            lbl_NameMyFriend.TabIndex = 1;
            lbl_NameMyFriend.Text = partOf[1];
            lbl_NameMyFriend.BackColor = Color.Transparent;
            lbl_NameMyFriend.Click += new EventHandler(friend_Click);

            // Message
            PictureBox pic_NewMessage = new PictureBox();
            pic_NewMessage.Location = new Point(208, 8);
            pic_NewMessage.Name = partOf[3];
            pic_NewMessage.Size = new Size(25, 25);
            pic_NewMessage.TabIndex = 2;
            pic_NewMessage.TabStop = false;
            pic_NewMessage.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_NewMessage.BackColor = Color.Transparent;
            if (partOf[2] == "1")
                pic_NewMessage.Image = Image.FromFile("./Source-File-Inside-2/New_Message_Icon.png");

            // Panel
            Panel pan_Friend = new Panel();
            pan_Friend.BackColor = Color.Transparent;
            pan_Friend.Controls.Add(pic_NewMessage);
            pan_Friend.Controls.Add(lbl_NameMyFriend);
            pan_Friend.Controls.Add(pic_MyFriend);
            pan_Friend.Location = new Point(0, friendPanelHeight);
            pan_Friend.Name = partOf[3];
            pan_Friend.Size = new Size(245, 40);
            pan_Friend.TabIndex = 0;
            friendPanelHeight += 45;
            try { pan_LeftMain.Invoke(() => { pan_LeftMain.Controls.Add(pan_Friend); }); } catch { pan_LeftMain.Controls.Add(pan_Friend); }
        }

        int firstClick = 0;

        private void friend_Click(object sender, EventArgs e)
        {
            if (firstClick == 0)
            {
                firstClick = 1;
                pic_Logo.Visible = false;
                pan_Main.Controls.Add(pan_RightMain);
            }

            Label thisSender = sender as Label;
            Panel panel = (Panel)thisSender.Parent;
            Panel panelParent = (Panel)panel.Parent;
            foreach (Control control in panelParent.Controls)
            {
                control.BackColor = Color.Transparent;
            }
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".NewMess/" + thisSender.Name + ".new");
            foreach (Control control in panel.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    if (pictureBox.Name == panel.Name)
                    {
                        pictureBox.Image = null;
                    }
                }
            }
            panel.BackColor = Color.Lime;
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Plesea wait";
            waitingUI.content = "Opening...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            LoadMessage(thisSender.Text, panel.Name + ".jpg", panel.Name);
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private int friendPanelHeight = 0;

        private void TransferFileServerClient(string filePath)
        {
            byte[] fileData = new byte[51200];

            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            int bytesRead = sourceConnection.ReceiveFrom(fileData, ref endPoint);

            try { FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write); fileStream.Write(fileData, 0, bytesRead); fileStream.Close(); } catch { }
        }

        private void LoadFriendList()
        {
            try { pan_LeftMain.Invoke(() => { pan_LeftMain.Controls.Clear(); }); } catch { }
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Please wait";
            waitingUI.content = "Loading friend list...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            friendListNameUser.Clear();
            friendListNameUser = RunTask.GetFtpDirectoryListing(thisUser, thisPassword, ipFtpServer, ".Conversation");
            for (int i = 0; i < friendListNameUser.Count; i++)
            {
                friendListNameUser[i] = friendListNameUser[i].Substring(14, 9);
                if (friendListNameUser[i] == "bingid.co")
                    continue;
                sourceConnection.SendTo(Encoding.UTF8.GetBytes("GetPicture|" + friendListNameUser[i]), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
                TransferFileServerClient(friendListNameUser[i] + ".jpg");
                sourceConnection.SendTo(Encoding.UTF8.GetBytes("GetName|" + friendListNameUser[i]), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
                byte[] data = new byte[1024];
                EndPoint end = new IPEndPoint(IPAddress.Any, 0);
                int countData = sourceConnection.ReceiveFrom(data, ref end);
                string nameUser = (Encoding.UTF8.GetString(data, 0, countData)).Split('|')[1];
                string check = RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".NewMess/" + friendListNameUser[i] + ".new", "data.txt");
                try { File.Delete("data.txt"); } catch { }
                if (check == "")
                    friendListNameUser[i] = friendListNameUser[i] + ".jpg" + "|" + nameUser + "|1|" + friendListNameUser[i];
                else
                    friendListNameUser[i] = friendListNameUser[i] + ".jpg" + "|" + nameUser + "|0|" + friendListNameUser[i];
            }
            for (int i = 0; i < friendListNameUser.Count; i++)
            {
                if (friendListNameUser[i] == "bingid.co")
                    continue;
                AddPanelFriend(friendListNameUser[i].Split('|'));
            }
            string bingChatSource = "./App-Data/bing.jpg|Bing Chat|0|bingid";
            AddPanelFriend(bingChatSource.Split('|'));
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
            HandleNetwork();
        }
        #endregion

        #region Lap_Trinh_Mang
        private void ReCheckActivity(string userid, string status)
        {
            if (idCurrentBox == userid && status == "1")
                btn_Active.Image = Image.FromFile("./App-Data/Active_Friend_Icon.png");
        }

        private void Destroy()
        {
            this.Invoke(() =>
            {
                this.Close();
            });
        }

        private void HandleCase(object arguments)
        {
            object[] args = (object[])arguments;
            string command = (string)args[0];
            IPEndPoint endPoint = (IPEndPoint)args[1];
            string[] splitArguments = command.Split('|');
            switch (splitArguments[0])
            {
                case "ReCheckActivity":
                    {
                        try { ReCheckActivity(splitArguments[1], splitArguments[2]); } catch { }
                        break;
                    }
                case "Destroy":
                    {
                        Destroy();
                        break;
                    }
                case "SendTo":
                    {
                        SendTo(splitArguments[1], splitArguments[2], splitArguments[3]);
                        break;
                    }
                case "ReCallVoiceCheck":
                    {
                        ReCallVoiceCheck(splitArguments[1], splitArguments[2]);
                        break;
                    }
                case "CallVoiceCheck":
                    {
                        CallVoiceCheck(splitArguments[1], splitArguments[2]);
                        break;
                    }
                case "GetFriendship":
                    {
                        GetFriendship(splitArguments[1], splitArguments[2]);
                        break;
                    }
                case "ReloadFriend":
                    {
                        ReloadFriend();
                        break;
                    }
            }
        }

        private void MainHandle()
        {
            while (true)
            {
                byte[] data = new byte[5120];
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                int countByte = 0;
                try
                {
                    countByte = sourceConnection.ReceiveFrom(data, ref endPoint);
                }
                catch { continue; }
                if (!enabled)
                {
                    MessageBox.Show("Stop handling...", "Thread handling reporter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                object command = Encoding.UTF8.GetString(data, 0, countByte);
                object endPointString = (object)endPoint;
                object[] objects = { command, endPointString };
                new Thread(new ParameterizedThreadStart(HandleCase)).Start((object)objects);
            }
        }

        private bool enabled = false;

        private void HandleNetwork()
        {
            enabled = true;
            Thread handleEnable = new Thread(new ThreadStart(MainHandle));
            handleEnable.Start();
        }

        private void Loopack()
        {
            IPEndPoint thisEndPoint = new IPEndPoint(IPAddress.Parse(ipAddressAndPort[0]), int.Parse(ipAddressAndPort[1]));
            sourceConnection.SendTo(new byte[] { }, thisEndPoint);
        }
        #endregion

        private void ClientUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            string newProfile = "#" + thisUser.Substring(4) + "|" + name + "|" + birthday + "|" + mail + "|" + joinday + "|0";
            newProfile = RunTask.CryptionCode(newProfile);
            File.WriteAllText("data.txt", newProfile);
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Importal/.profile");
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "data.txt", ".Importal/.profile");
            File.WriteAllText("bing.txt", "0062 0069 006E 0067 0069 0064 007C 0043 0068 00E0 006F 0020 0062 1EA1 006E 002C 0020 0074 00F4 0069 0020 0063 00F3 0020 0074 0068 1EC3 0020 0067 0069 00FA 0070 0020 0067 00EC 0020 0063 0068 006F 0020 0062 1EA1 006E 007C 004F 0076 0065 0072 0074 0069 006D 0065 000A");
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Conversation/bingid.conversation");
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "bing.txt", ".Conversation/bingid.conversation");
            File.Delete("bing.txt");
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("Logout|" + thisUser), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            Environment.Exit(0);
        }

        #region Gui_Tin_Nhan
        private void btn_Send_Click(object sender, EventArgs e)
        {
            NoticeUI noticeUI = new NoticeUI();
            if (txt_InputMessage.Text == "" || txt_InputMessage.Text.Length < 4)
            {
                noticeUI.title = "Error";
                noticeUI.typeNotice = "Error";
                noticeUI.content = "The message format is incorrect, please check. Messages must be blank and without the words \"File\" or \"Voic\" at the beginning of the message";
                noticeUI.ShowDialog();
                return;
            }
            if (!sendFile)
            {
                if (txt_InputMessage.Text.Substring(0, 4) == "File")
                {
                    noticeUI.title = "Error";
                    noticeUI.typeNotice = "Error";
                    noticeUI.content = "The message format is incorrect, please check. Messages must be blank and without the words \"File\" or \"Voic\" at the beginning of the message";
                    noticeUI.ShowDialog();
                    return;
                }
            }
            sendFile = false;
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("Send|" + thisUser + "|" + idCurrentBox + "|" + txt_InputMessage.Text), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse((ipAddressAndPort[1]))));
            RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Conversation/" + idCurrentBox + ".conversation", "conversationCurrent.txt");
            string sourceConversation = File.ReadAllText("conversationCurrent.txt").Trim();
            sourceConversation = RunTask.DecryptionCode(sourceConversation);
            sourceConversation += (thisUser + "|" + txt_InputMessage.Text + "|" + RunTask.GetCurrentDateTime2());
            sourceConversation = RunTask.CryptionCode(sourceConversation) + "000A";
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Conversation/" + idCurrentBox + ".conversation");
            File.WriteAllText("saveConversation.txt", sourceConversation);
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "saveConversation.txt", ".Conversation/" + idCurrentBox + ".conversation");
            File.Delete("saveConversation.txt");
            File.Delete("conversationCurrent.txt");
            LoadMessage(lbl_NameFriendBox.Text, idCurrentBox + ".jpg", idCurrentBox);
            txt_InputMessage.Text = "";
        }
        #endregion

        #region Nhan_Tin_Nhan
        private bool receiver = false;

        private void SendTo(string sender, string message, string nameSender)
        {
            while (receiver)
            {
            }
            receiver = true;
            message = message.Replace('\n', ' ');
            RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Conversation/" + sender + ".conversation", "chat.txt");
            string sourceChat = File.ReadAllText("chat.txt").Trim();
            File.Delete("chat.txt");
            sourceChat = sourceChat + " " + RunTask.CryptionCode(sender + "|" + message + "|" + RunTask.GetCurrentDateTime2()) + "000A";
            File.WriteAllText("convertchat.txt", sourceChat);
            RunTask.DeleteFileFromFTP(thisUser, thisPassword, ipFtpServer, ".Conversation/" + sender + ".conversation");
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "convertchat.txt", ".Conversation/" + sender + ".conversation");
            File.Delete("convertchat.txt");
            receiver = false;

            AudioFileReader reader = new AudioFileReader(@"./App-Data/notice.mp3");
            WaveOut player = new WaveOut();
            player.Init(reader);
            player.Play();

            if (idCurrentBox == sender)
            {
                LoadMessage(nameSender, sender + ".jpg", sender);
                return;
            }
            File.WriteAllText("tempNew.txt", "");
            RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, "tempNew.txt", ".NewMess/" + sender + ".new");
            File.Delete("tempNew.txt");

            foreach (Control control in pan_LeftMain.Controls)
            {
                if (control.Name == sender)
                {
                    foreach (Control control2 in control.Controls)
                    {
                        if (control2.Name == sender && control2 is PictureBox)
                        {
                            PictureBox pictureBox = (PictureBox)control2;
                            pictureBox.Invoke(() =>
                            {
                                pictureBox.Image = Image.FromFile("./Source-File-Inside-2/New_Message_Icon.png");
                            });
                        }
                    }
                }
            }
        }
        #endregion

        #region Yeu_Cau_Call_Voice
        private void ReCallVoiceCheck(string access, string ip)
        {
            if (access != "1")
            {
                ipCallVoice = "";
                requestVoice = false;
            }
            else
            {
                ipCallVoice = ip;
                requestVoice = false;
            }
        }

        private bool requestVoice = false;
        private string ipCallVoice = "";

        private void CallVoiceStream(object sender, EventArgs e)
        {
            if (idCurrentBox == "bingid")
                return;
            requestVoice = true;
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("CallVoiceCheck|" + idCurrentBox + "|" + thisName), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.title = "Please wait";
            waitingUI.content = "Calling to " + lbl_NameFriendBox.Text + "...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            Thread.Sleep(1000);
            while (requestVoice) { }
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
            requestVoice = false;
            if (ipCallVoice == "")
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Call voice information";
                noticeUI.content = "Unable to connect to " + lbl_NameFriendBox.Text;
                noticeUI.ShowDialog();
                return;
            }
            enabled = false;
            Loopack();

            CallingUI callingUI = new CallingUI();
            callingUI.callSocket = sourceConnection;
            callingUI.thisIp = ipAddressAndPort[0];
            callingUI.port = int.Parse(ipAddressAndPort[1]);
            callingUI.guestIp = ipCallVoice;
            callingUI.name = lbl_NameFriendBox.Text;
            callingUI.ShowDialog();

            sourceConnection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint connectPoint = new IPEndPoint(IPAddress.Parse(ipAddressAndPort[0]), int.Parse(ipAddressAndPort[1]));
            sourceConnection.Bind(connectPoint);
            HandleNetwork();
        }
        #endregion

        #region Nhan_Yeu_Cau_Call
        private void CallVoiceCheck(string ip, string nameCallUser)
        {
            DialogResult dialogResult = MessageBox.Show(nameCallUser + " wants to connect voice chat with you, do you want to connect?", "Voice chat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                sourceConnection.SendTo(Encoding.UTF8.GetBytes("ReCallVoiceCheck|1|" + ipAddressAndPort[0]), new IPEndPoint(IPAddress.Parse(ip), int.Parse(ipAddressAndPort[1])));
                enabled = false;
                Loopack();

                CallingUI callingUI = new CallingUI();
                callingUI.callSocket = sourceConnection;
                callingUI.thisIp = ipAddressAndPort[0];
                callingUI.port = int.Parse(ipAddressAndPort[1]);
                callingUI.guestIp = ip;
                callingUI.name = nameCallUser;
                callingUI.ShowDialog();

                sourceConnection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint connectPoint = new IPEndPoint(IPAddress.Parse(ipAddressAndPort[0]), int.Parse(ipAddressAndPort[1]));
                sourceConnection.Bind(connectPoint);
                HandleNetwork();
                return;
            }
            sourceConnection.SendTo(Encoding.UTF8.GetBytes("ReCallVoiceCheck|0|"), new IPEndPoint(IPAddress.Parse(ip), int.Parse(ipAddressAndPort[1])));
            return;
        }
        #endregion

        #region Xu_Ly_Tim_Ban_Be
        private void pic_SearchIcon_Click(object sender, EventArgs e)
        {
            NoticeUI noticeUI = new NoticeUI();
            if (txt_Search.Text == "")
            {
                noticeUI = new NoticeUI();
                noticeUI.title = "Information";
                noticeUI.content = "Please enter the id of the person you want to connect with, this part cannot be left blank";
                noticeUI.typeNotice = "Information";
                noticeUI.ShowDialog();
                return;
            }

            if (txt_Search.Text == thisUser.Substring(4))
            {
                noticeUI = new NoticeUI();
                noticeUI.title = "Information";
                noticeUI.content = "This is your id";
                noticeUI.typeNotice = "Information";
                noticeUI.ShowDialog();
                return;
            }

            List<string> listIDFriend = RunTask.GetFtpDirectoryListing(thisUser, thisPassword, ipFtpServer, ".Conversation");
            for (int i = 0; i < listIDFriend.Count; i++) { listIDFriend[i] = listIDFriend[i].Substring(18, 5); };
            for (int i = 0; i < listIDFriend.Count; i++)
            {
                if (listIDFriend[i] == txt_Search.Text)
                {
                    noticeUI = new NoticeUI();
                    noticeUI.title = "Information";
                    noticeUI.content = "You and this person are already connected";
                    noticeUI.typeNotice = "Information";
                    noticeUI.ShowDialog();
                    return;
                }
            }

            sourceConnection.SendTo(Encoding.UTF8.GetBytes("GetFriendship|" + thisUser + "|user" + txt_Search.Text + "|" + thisName), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            noticeUI = new NoticeUI();
            noticeUI.title = "Information";
            noticeUI.content = "Invitation sent";
            noticeUI.typeNotice = "Information";
            noticeUI.ShowDialog();
            return;
        }

        private void GetFriendship(string userRequest, string nameRequest)
        {
            DialogResult dialogResult = MessageBox.Show(nameRequest + " wants to be friend with you, do you agree or not?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                sourceConnection.SendTo(Encoding.UTF8.GetBytes("ReGetFriendship|" + thisUser + "|" + userRequest), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
            }
        }

        private void ReloadFriend()
        {
            enabled = false;
            friendPanelHeight = 0;
            Loopack();
            LoadFriendList();
        }
        #endregion

        #region Xu_Ly_Gui_File
        private bool sendFile = false;

        private void btn_AttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.ValidateNames = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (idCurrentBox == "bingid")
                return;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string timeSend = RunTask.GetCurrentDateTime3();
                string newNameFile = ".TotalFile/" + "File_" + timeSend + Path.GetExtension(openFileDialog.FileName);
                RunTask.UploadFileToFTP(thisUser, thisPassword, ipFtpServer, openFileDialog.FileName, newNameFile);
                sourceConnection.SendTo(Encoding.UTF8.GetBytes("Upload|" + thisUser + "|" + idCurrentBox + "|" + newNameFile), new IPEndPoint(IPAddress.Parse(ipAdmin), int.Parse(ipAddressAndPort[1])));
                txt_InputMessage.Text = "File_" + timeSend + Path.GetExtension(openFileDialog.FileName);
                sendFile = true;
                btn_Send_Click(sender, e);
            }
        }

        private void pan_File_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text.Substring(0,4) == "File")
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        fbd.SelectedPath = fbd.SelectedPath.Replace("\\", "/");
                        RunTask.DownloadFileFromFTP(thisUser, thisPassword, ipFtpServer, ".TotalFile/" + label.Text, fbd.SelectedPath + "/" + label.Text);
                        MessageBox.Show("File saved at " + fbd.SelectedPath + "/" + label.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion
    }
}
