using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Renci.SshNet;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net.Mail;
using System.Text;

namespace Source_Code.UIPatch
{
    public partial class ServerUI : Form
    {
        public ServerUI()
        {
            InitializeComponent();
            AddMouseEffect(pan_Top);
            ConnectIPAddress();
            LoginEvent();
        }

        #region Thiet_Ke_Giao_Dien

        private void DisableControl()
        {
            txt_Birthday.Enabled = false;
            txt_Email.Enabled = false;
            txt_Password.Enabled = false;
            txt_User.Enabled = false;
            txt_YourName.Enabled = false;
        }

        private void UIDesign()
        {
            AddMouseEffect(pan_Top);
            TransparentControl();
            LinearColorServerTitle();
            DisableControl();
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

        private void TransparentControl()
        {
            pic_ServerTitle.BackColor = Color.Transparent;
            lbl_ServerTitle.BackColor = Color.Transparent;
        }

        private void LinearColorServerTitle()
        {
            LinearGradientBrush brush = new LinearGradientBrush(pan_ServerTitle.ClientRectangle, Color.Black, Color.DarkCyan, LinearGradientMode.Vertical);
            pan_ServerTitle.BackgroundImage = new Bitmap(pan_ServerTitle.Width, pan_ServerTitle.Height);
            Graphics g = Graphics.FromImage(pan_ServerTitle.BackgroundImage);
            g.FillRectangle(brush, 0, 0, pan_ServerTitle.Width, pan_ServerTitle.Height);
        }

        private void RefreshPanelDashboardMenuTransparent()
        {
            pan_Profile.BackColor = Color.Transparent;
            pan_Dashboard.BackColor = Color.Transparent;
            pan_ViewLog.BackColor = Color.Transparent;
            pan_ManageUser.BackColor = Color.Transparent;
            pan_Logout.BackColor = Color.Transparent;
        }

        private void lbl_Profile_Click(object sender, EventArgs e)
        {
            pan_Right.Controls.Clear();
            pic_YourPicture.Image.Dispose();
            RefreshPanelDashboardMenuTransparent();
            pan_Profile.BackColor = Color.Tomato;
            LoadProfile();
        }
        private void lbl_Dashboard_Click(object sender, EventArgs e)
        {
            pan_Right.Controls.Clear();
            RefreshPanelDashboardMenuTransparent();
            pan_Dashboard.BackColor = Color.Tomato;
            LoadDashboard();
        }

        private void lbl_ManageUser_Click(object sender, EventArgs e)
        {
            pan_Right.Controls.Clear();
            RefreshPanelDashboardMenuTransparent();
            pan_ManageUser.BackColor = Color.Tomato;
            pan_RightSubManage.Controls.Clear();
            pan_TitleManage.Location = new Point(2, 2);
            pan_RightSubManage.Controls.Add(pan_TitleManage);
            LoadUser();
        }

        private void lbl_ViewLog_Click(object sender, EventArgs e)
        {
            pan_Right.Controls.Clear();
            RefreshPanelDashboardMenuTransparent();
            pan_ViewLog.BackColor = Color.Tomato;
            LoadViewLog();
        }

        private void lbl_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to get rid of the server administrator?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                btn_Exit_Click(sender, e);
            }
        }
        #endregion

        #region Su_Kien_Dang_Nhap
        private string ipFtpServer = File.ReadAllText("./App-Data/ftp_ip.txt");
        private string userAdmin, passwordAdmin;

        private void CallLoginUI()
        {
            LoginUI loginRequest = new LoginUI();
            loginRequest.ipFtpServer = ipFtpServer;
            loginRequest.ShowDialog();
            userAdmin = loginRequest.userAdmin;
            passwordAdmin = loginRequest.passwordAdmin;
        }

        private void LoadKeyEncry()
        {
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".Importal/.public", "public_key.pem");
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".Importal/.private", "private_key.pem");
        }

        private string passwordRoot;
        private string[] statusUser;

        private void LoadPasswordRoot()
        {
            WaitingUI loadRoot = new WaitingUI();
            loadRoot.content = "Loading root key...";
            loadRoot.closePer = false;
            Thread rootThread = new Thread(() =>
            {
                loadRoot.ShowDialog();
            });
            rootThread.Start();
            File.Move("./App-Data/key.encry", "ma_hoa.encry");
            Process process = new Process();
            process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
            process.Start();
            process.WaitForExit();
            passwordRoot = File.ReadAllText("giai_ma.txt");
            File.Move("ma_hoa.encry", "./App-Data/key.encry");
            File.Delete("giai_ma.txt");

            File.Move("./App-Data/status.encry", "ma_hoa.encry");
            process.Start();
            process.WaitForExit();
            File.Delete("public_key.pem");
            File.Delete("private_key.pem");
            statusUser = File.ReadAllText("giai_ma.txt").Split('|');
            File.Delete("giai_ma.txt");
            File.Move("ma_hoa.encry", "./App-Data/status.encry");

            loadRoot.Invoke(() =>
            {
                loadRoot.closePer = true;
                loadRoot.Close();
            });
        }

        private void ResetPermissionAdmin()
        {
            string userRoot = "root";
            using (var client = new SshClient(ipFtpServer, userRoot, passwordRoot))
            {
                client.Connect();
                client.RunCommand("chown -R FXT /home/AdminFolder/.MyData");
                client.RunCommand("chgrp -R FXTGroup /home/AdminFolder/.MyData");
                client.RunCommand("chmod -R u+rwx,g+rx-w,o-rwx /home/AdminFolder/.MyData");
                client.RunCommand("chown -R FXT /home/AdminFolder/.Importal");
                client.RunCommand("chgrp -R FXTGroup /home/AdminFolder/.Importal/");
                client.RunCommand("chmod -R u+rwx,g+rx-w,o-rwx /home/AdminFolder/.Importal");
                client.RunCommand("chown FXT /home/AdminFolder/.UserData");
                client.RunCommand("chgrp -R FXTGroup /home/AdminFolder/.UserData/");
                client.RunCommand("chmod -R u+rwx,g+rx-w,o-rwx /home/AdminFolder/.UserData");
                client.RunCommand("chmod -R u+rwx,g+rx-w,o-rwx /home/AdminFolder");
                client.Disconnect();
                DenyReadConversation();
            }
        }

        private void DenyReadConversation()
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.content = "Deny read conversation permission...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            userInforList = new List<UserInfo>();
            string[] listUser = RunTask.ListDirectories(userAdmin, passwordAdmin, ipFtpServer, ".UserData");
            for (int i = 0; i < listUser.Length; i++)
            {
                ResetPermissionUser(listUser[i]);
                RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, $".UserData/{listUser[i]}/.Importal/.profile", "data2.txt");
                string[] partOf = RunTask.DecryptionCode((File.ReadAllText("data2.txt")).Trim()).Split('|');
                UserInfo userInfo = new UserInfo();
                userInfo._id = int.Parse(partOf[0].Substring(1));
                userInfo._name = partOf[1];
                userInfo._birthday = partOf[2];
                userInfo._email = partOf[3];
                userInfo._joinday = partOf[4];
                userInfo._active = true;
                if (partOf[5] == "0")
                    userInfo._active = false;
                userInforList.Add(userInfo);
                File.Delete("data2.txt");
            }
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private void LoginEvent()
        {
            CallLoginUI();
            LoadKeyEncry();
            LoadPasswordRoot();
            ResetPermissionAdmin();
            LoadProfile();
        }
        #endregion

        #region Xu_Ly_Du_Lieu
        private string[] ipAddressAndPort = File.ReadAllLines("./App-Data/ip_address_and_port.txt");
        private Socket socketConnection;

        private void ConnectIPAddress()
        {
            try
            {
                socketConnection = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint connectPoint = new IPEndPoint(IPAddress.Parse(ipAddressAndPort[0]), int.Parse(ipAddressAndPort[1]));
                socketConnection.Bind(connectPoint);
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

        private string yourName = "";
        private string yourEmail = "";
        private string birthday = "";
        private string pathYourPicture = "";

        private void LoadProfile()
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.content = "Loading profile...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            pan_Profile.BackColor = Color.Tomato;
            try
            {
                File.Delete("./App-Data/profile.jpg");
            }
            catch { }
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.profile", "./App-Data/profile.unicode");
            string sourceFile = File.ReadAllText("./App-Data/profile.unicode");
            sourceFile = RunTask.DecryptionCode(sourceFile);
            string[] sourceData = sourceFile.Split('|');
            yourName = sourceData[0];
            birthday = sourceData[2];
            yourEmail = sourceData[1];
            File.Delete("./App-Data/profile.unicode");

            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.mypic", "./App-Data/profile.jpg");
            pathYourPicture = "./App-Data/profile.jpg";

            txt_User.Text = userAdmin;
            txt_User.Enabled = false;
            txt_YourName.Text = yourName;
            txt_Birthday.Text = birthday;
            txt_Email.Text = yourEmail;
            txt_Password.Text = "**********" + passwordAdmin[passwordAdmin.Length - 3] + passwordAdmin[passwordAdmin.Length - 2] + passwordAdmin[passwordAdmin.Length - 1];
            pic_YourPicture.Image = Image.FromFile(pathYourPicture);

            pan_Right.Controls.Add(pan_RightSubProfile);

            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private void btn_ChangeYourPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg";
            openFileDialog.Title = "Chọn tệp tin JPG";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "")
                return;
            pic_YourPicture.Image.Dispose();
            File.Delete("./App-Data/profile.jpg");
            File.Copy(openFileDialog.FileName, "./App-Data/profile.jpg");
            RunTask.DeleteFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.mypic");
            RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "./App-Data/profile.jpg", ".MyData/.mypic");

            NoticeUI noticeUI = new NoticeUI();
            noticeUI.title = "Information";
            noticeUI.content = "Changed photo successfully";
            noticeUI.typeNotice = "Information";
            UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): " + "Change profile successful");
            noticeUI.ShowDialog();
            LoadProfile();
        }

        private string userMail, passwordMail;

        private void btn_ChangeInfo_Click(object sender, EventArgs e)
        {
            if (txt_Password.Text[0] == '*')
                txt_Password.Text = passwordAdmin;
            if (yourName != txt_YourName.Text || yourEmail != txt_Email.Text || passwordAdmin != txt_Password.Text || birthday != txt_Birthday.Text)
            {
                txt_YourName.Text = RunTask.StandardizeString(txt_YourName.Text);
                NoticeUI noticeUI = new NoticeUI();
                if (txt_YourName.Text.Length < 6)
                {
                    noticeUI.title = "Error";
                    noticeUI.content = "Your name is too short";
                    noticeUI.typeNotice = "Error";
                    noticeUI.ShowDialog();
                    lbl_Profile_Click(sender, e);
                    return;
                }
                if (txt_Password.Text.Length < 6)
                {
                    noticeUI.title = "Error";
                    noticeUI.content = "Password is too short";
                    noticeUI.typeNotice = "Error";
                    noticeUI.ShowDialog();
                    lbl_Profile_Click(sender, e);
                    return;
                }
                DateTime dateValue;
                CultureInfo culture = CultureInfo.CreateSpecificCulture("vi-VN");
                if (!DateTime.TryParseExact(txt_Birthday.Text, "dd/MM/yyyy", culture, DateTimeStyles.None, out dateValue))
                {
                    noticeUI.title = "Error";
                    noticeUI.content = "Incorrect date of birth format";
                    noticeUI.typeNotice = "Error";
                    noticeUI.ShowDialog();
                    lbl_Profile_Click(sender, e);
                    return;
                }
                if (string.IsNullOrEmpty(txt_Email.Text))
                {
                    noticeUI.title = "Error";
                    noticeUI.content = "Incorrect email format";
                    noticeUI.typeNotice = "Error";
                    noticeUI.ShowDialog();
                    lbl_Profile_Click(sender, e);
                    return;
                }
                try
                {
                    WaitingUI waitUI = new WaitingUI();
                    waitUI.content = "Checking request...";
                    waitUI.closePer = false;
                    Thread newThread = new Thread(() =>
                    {
                        waitUI.ShowDialog();
                    });
                    newThread.Start();
                    var mailAddress = new MailAddress(txt_Email.Text);
                    File.Move("./App-Data/user_mail.encry", "ma_hoa.encry");
                    LoadKeyEncry();
                    Process process = new Process();
                    process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
                    process.Start();
                    process.WaitForExit();
                    userMail = File.ReadAllText("giai_ma.txt");
                    File.Delete("giai_ma.txt");
                    File.Move("ma_hoa.encry", "./App-Data/user_mail.encry");

                    File.Move("./App-Data/password_mail.encry", "ma_hoa.encry");
                    process = new Process();
                    process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
                    process.Start();
                    process.WaitForExit();
                    passwordMail = File.ReadAllText("giai_ma.txt");
                    File.Delete("giai_ma.txt");
                    File.Move("ma_hoa.encry", "./App-Data/password_mail.encry");

                    File.Delete("public_key.pem");
                    File.Delete("private_key.pem");

                    string codeRandom = RunTask.RamdomCode();
                    RunTask.SendEmail(userMail, passwordMail, "Verify Information Change", "Hi, FXT\nFXTGroup system recognizes you have a request to change your profile information right now. Please enter the code below to confirm the change is valid.\nCode is: " + codeRandom, txt_Email.Text);

                    waitUI.BeginInvoke(() =>
                    {
                        waitUI.closePer = true;
                        waitUI.Close();
                    });
                    Thread.Sleep(1000);
                    CodeEmailInputUI codeInput = new CodeEmailInputUI();
                    codeInput.emailAddress = txt_Email.Text;
                    codeInput.ShowDialog();
                    if (codeRandom != codeInput.code)
                    {
                        noticeUI.title = "Error";
                        noticeUI.content = "The verification code you entered is incorrect, the change is aborted";
                        noticeUI.typeNotice = "Error";
                        noticeUI.ShowDialog();
                        lbl_Profile_Click(sender, e);
                        return;
                    }

                    waitUI.content = "Completing...";
                    waitUI.closePer = false;
                    newThread = new Thread(() =>
                    {
                        waitUI.ShowDialog();
                    });
                    newThread.Start();
                    string newProfile = txt_YourName.Text + "|" + txt_Email.Text + "|" + txt_Birthday.Text;
                    File.WriteAllText("./App-Data/profile.unicode", RunTask.CryptionCode(newProfile));
                    RunTask.DeleteFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.profile");
                    RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "./App-Data/profile.unicode", ".MyData/.profile");
                    File.Delete("./App-Data/profile.unicode");
                    using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
                    {
                        client.Connect();
                        client.RunCommand($"echo \"{txt_Password.Text}\" | passwd --stdin {userAdmin}");
                        client.Disconnect();
                        passwordAdmin = txt_Password.Text;
                    }
                    ResetPermissionAdmin();
                    waitUI.BeginInvoke(() =>
                    {
                        waitUI.closePer = true;
                        waitUI.Close();
                    });

                    noticeUI.title = "Information";
                    noticeUI.content = "Success";
                    noticeUI.typeNotice = "Information";
                    noticeUI.ShowDialog();
                    lbl_Profile_Click(sender, e);
                    UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): " + "Change profile successful");
                    return;
                }
                catch (FormatException)
                {
                    noticeUI.title = "Error";
                    noticeUI.content = "Incorrect email format";
                    noticeUI.typeNotice = "Error";
                    noticeUI.ShowDialog();
                    lbl_Profile_Click(sender, e);
                    return;
                }
            }
            else
            {
                ResetPermissionAdmin();
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Information";
                noticeUI.content = "Success";
                noticeUI.typeNotice = "Information";
                noticeUI.ShowDialog();
                lbl_Profile_Click(sender, e);
                return;
            }
        }

        private int maximumHostConnected = 15;
        private int hostConnected = 0;
        private int statusServer = 0;
        private int timeActive = 0;
        private void LoadDashboard()
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.content = "Loading dashboard...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            RunTask.DownloadFileFromFTP(statusUser[0], statusUser[1], ipFtpServer, ".status", "status.txt");
            string sourceStatus = File.ReadAllText("status.txt").Trim();
            statusServer = int.Parse(sourceStatus[0] + "");
            File.Delete("status.txt");
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".Importal/.maxhost", "maxhost.txt");
            maximumHostConnected = int.Parse(File.ReadAllText("maxhost.txt").Trim());
            File.Delete("maxhost.txt");
            if (statusServer == 0)
            {
                lbl_Status.ForeColor = Color.Red;
                lbl_Status.Text = "Not actived";
                pic_Status.Image = Image.FromFile("./Source-File-Inside/Server_NotActived.png");
            }
            else
            {
                lbl_Status.ForeColor = Color.Lime;
                lbl_Status.Text = "Actived";
                pic_Status.Image = Image.FromFile("./Source-File-Inside/Server_Active.gif");
            }
            lbl_HostConnected.Text = hostConnected + "";
            lbl_MaximumHosts.Text = maximumHostConnected + "";
            lbl_Time.Text = RunTask.ChuyenDoi(timeActive);
            pan_Chart.Refresh();
            pan_Right.Controls.Add(pan_RightSubDashboard);

            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private void countTime_Tick(object sender, EventArgs e)
        {
            timeActive++;
            lbl_Time.Invoke(() =>
            {
                lbl_Time.Text = RunTask.ChuyenDoi(timeActive);
            });
        }

        private string logString = "";
        private bool lockLog = false;

        private void UpdateLogFile(string contentUpdate)
        {
            while (lockLog)
            {
                //locking
            }
            lockLog = true;
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.log", "log.txt");
            logString = RunTask.DecryptionCode(File.ReadAllText("log.txt").Trim());
            File.Delete("log.txt");
            logString = logString + contentUpdate;
            File.WriteAllText("log.txt", RunTask.CryptionCode(logString) + "000A");
            RunTask.DeleteFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.log");
            RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "log.txt", ".MyData/.log");
            File.Delete("log.txt");
            try
            {
                txt_ViewLog.Invoke(() =>
                {
                    txt_ViewLog.Text = logString;
                });
            }
            catch { }
            ResetPermissionAdmin();
            lockLog = false;
        }

        private void btn_Active_Click(object sender, EventArgs e)
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.content = "Processing...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            string userRoot = "root";
            using (var client = new SshClient(ipFtpServer, userRoot, passwordRoot))
            {
                client.Connect();
                client.RunCommand("chmod -R u+rwx,g-rwx,o-rwx /home/tempuser");
                client.Disconnect();
            }
            if (statusServer == 0)
            {
                statusServer = 1;
                File.WriteAllText("status.txt", "1|" + ipAddressAndPort[0]);
                RunTask.DeleteFileFromFTP(statusUser[0], statusUser[1], ipFtpServer, ".status");
                RunTask.UploadFileToFTP(statusUser[0], statusUser[1], ipFtpServer, "status.txt", ".status");
                countTime.Start();
                btn_Active.ForeColor = Color.Red;
                btn_Active.Text = "Deactivate";
                File.Delete("status.txt");
                UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): Server activation successful\n");
                LoadDashboard();
                HandleNetwork();
            }
            else
            {
                countTime.Stop();
                statusServer = 0;
                File.WriteAllText("status.txt", "0");
                RunTask.DeleteFileFromFTP(statusUser[0], statusUser[1], ipFtpServer, ".status");
                RunTask.UploadFileToFTP(statusUser[0], statusUser[1], ipFtpServer, "status.txt", ".status");
                btn_Active.ForeColor = Color.Lime;
                btn_Active.Text = "Active";
                File.Delete("status.txt");
                UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): Deactivate the server successful with time " + RunTask.ChuyenDoi(timeActive) + '\n');
                timeActive = 0;
                LoadDashboard();
                enabled = false;
                Loopack();
                ServerCloseHandle();
            }
            pan_Chart.Refresh();
            using (var client = new SshClient(ipFtpServer, userRoot, passwordRoot))
            {
                client.Connect();
                client.RunCommand("chmod -R u+rx-w,g-rwx,o-rwx /home/tempuser");
                client.Disconnect();
            }
            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private void ServerCloseHandle()
        {
            if(hostConnected > 0)
            {
                string logAll = "Log(" + RunTask.GetCurrentDateTime() + "): All user disconneted";
                UpdateLogFile(logAll);
            }
            hostConnected = 0;
            lbl_HostConnected.Invoke(() =>
            {
                lbl_HostConnected.Text = hostConnected + "";
            });
            
            string[] listUser = RunTask.ListDirectories(userAdmin, passwordAdmin, ipFtpServer, ".UserData");
            for (int i = 0; i < listUser.Length; i++)
            {
                ResetPermissionUser(listUser[i]);
                RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, $".UserData/{listUser[i]}/.Importal/.profile", "data3.txt");
                string[] partOf = RunTask.DecryptionCode((File.ReadAllText("data3.txt")).Trim()).Split('|');
                string ipDestroy = "";
                try { ipDestroy = partOf[6];
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("Destroy|"), new IPEndPoint(IPAddress.Parse(ipDestroy), int.Parse(ipAddressAndPort[1])));
                }
                catch { }
                File.Delete("data1.txt");
            }
        }

        private void DrawCirCleChar(int a, int b)
        {
            Graphics graphics = pan_Chart.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            Brush brushRed = new SolidBrush(Color.Yellow);
            Brush brushGreen = new SolidBrush(Color.Aqua);

            float ratioYellow = ((float)a / b) * 100;
            float ratioAqua = 100 - ratioYellow;

            graphics.DrawPie(pen, new Rectangle(0, 0, pan_Chart.Width, pan_Chart.Height), 0, ratioYellow * 3.6f);
            graphics.DrawPie(pen, new Rectangle(0, 0, pan_Chart.Width, pan_Chart.Height), ratioYellow * 3.6f, ratioAqua * 3.6f);

            graphics.FillPie(brushRed, new Rectangle(0, 0, pan_Chart.Width, pan_Chart.Height), 0, ratioYellow * 3.6f);
            graphics.FillPie(brushGreen, new Rectangle(0, 0, pan_Chart.Width, pan_Chart.Height), ratioYellow * 3.6f, ratioAqua * 3.6f);

            Font font = new Font("Courier New", 9);
            SolidBrush brushText = new SolidBrush(Color.Black);
            string aText = "Used: " + ratioYellow + "%";
            string bText = "Free: " + ratioAqua + "%";
            if (ratioYellow == 0)
                aText = "";
            if (ratioAqua == 0)
                bText = "";

            SizeF sizeA = graphics.MeasureString(aText, font);
            SizeF sizeB = graphics.MeasureString(bText, font);

            float angleRed = ratioYellow * 3.6f / 2;
            float angleGreen = ratioYellow * 3.6f + ratioAqua * 3.6f / 2;

            float radianRed = angleRed * (float)Math.PI / 180;
            float radianGreen = angleGreen * (float)Math.PI / 180;

            float radius = Math.Min(pan_Chart.Width, pan_Chart.Height) / 2 - 50;

            float xA = pan_Chart.Width / 2 + radius * (float)Math.Cos(radianRed) - sizeA.Width / 2;
            float yA = pan_Chart.Height / 2 + radius * (float)Math.Sin(radianRed) - sizeA.Height / 2;

            float xB = pan_Chart.Width / 2 + radius * (float)Math.Cos(radianGreen) - sizeB.Width / 2;
            float yB = pan_Chart.Height / 2 + radius * (float)Math.Sin(radianGreen) - sizeB.Height / 2;

            graphics.DrawString(aText, font, brushText, new PointF(xA, yA));
            graphics.DrawString(bText, font, brushText, new PointF(xB, yB));

            lbl_Free.Text = bText;
            lbl_Used.Text = aText;
        }

        private void pan_Chart_Paint(object sender, PaintEventArgs e)
        {
            DrawCirCleChar(int.Parse(hostConnected + ""), int.Parse(maximumHostConnected + ""));
        }

        private void AddRowUser(UserInfo userAdd, int index)
        {
            // ID
            Label value_id = new Label();
            value_id.BackColor = Color.White;
            value_id.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            value_id.ForeColor = Color.Black;
            value_id.Location = new Point(1, 2);
            value_id.Name = "value_id";
            value_id.Size = new Size(120, 32);
            value_id.TabIndex = 0;
            value_id.Text = userAdd._id + "";
            value_id.TextAlign = ContentAlignment.MiddleCenter;

            // Name
            Label value_name = new Label();
            value_name.BackColor = Color.White;
            value_name.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            value_name.ForeColor = Color.Black;
            value_name.Location = new Point(122, 2);
            value_name.Name = "value_name";
            value_name.Size = new Size(192, 32);
            value_name.TabIndex = 0;
            value_name.Text = userAdd._name;
            value_name.TextAlign = ContentAlignment.MiddleCenter;

            // Birthday
            Label value_birthday = new Label();
            value_birthday.BackColor = Color.White;
            value_birthday.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            value_birthday.ForeColor = Color.Black;
            value_birthday.Location = new Point(315, 1);
            value_birthday.Name = "value_birthday";
            value_birthday.Size = new Size(152, 32);
            value_birthday.TabIndex = 0;
            value_birthday.Text = userAdd._birthday;
            value_birthday.TextAlign = ContentAlignment.MiddleCenter;

            // Email
            Label value_email = new Label();
            value_email.BackColor = Color.White;
            value_email.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            value_email.ForeColor = Color.Black;
            value_email.Location = new Point(468, 1);
            value_email.Name = "value_email";
            value_email.Size = new Size(253, 32);
            value_email.TabIndex = 0;
            value_email.Text = userAdd._email;
            value_email.TextAlign = ContentAlignment.MiddleCenter;

            // Join
            Label value_join = new Label();
            value_join.BackColor = Color.White;
            value_join.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            value_join.ForeColor = Color.Black;
            value_join.Location = new Point(722, 1);
            value_join.Name = "value_join";
            value_join.Size = new Size(149, 32);
            value_join.TabIndex = 0;
            value_join.Text = userAdd._joinday;
            value_join.TextAlign = ContentAlignment.MiddleCenter;

            // Status
            string statusUser = "Active";
            if (!userAdd._active)
                statusUser = "Inactive";
            Label value_status = new Label();
            value_status.BackColor = Color.White;
            value_status.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            if (statusUser == "Inactive")
            {
                value_status.ForeColor = Color.Red;
            }
            else
                value_status.ForeColor = Color.Lime;
            value_status.Location = new Point(872, 1);
            value_status.Name = "value_status";
            value_status.Size = new Size(149, 32);
            value_status.TabIndex = 0;
            value_status.Text = statusUser;
            value_status.TextAlign = ContentAlignment.MiddleCenter;

            // Del
            Label operation_del = new Label();
            operation_del.BackColor = Color.White;
            operation_del.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            operation_del.ForeColor = Color.Red;
            operation_del.Location = new Point(1031, 1);
            operation_del.Name = userAdd._id + "";
            operation_del.Size = new Size(124, 32);
            operation_del.TabIndex = 0;
            operation_del.Text = "Delete user";
            operation_del.TextAlign = ContentAlignment.MiddleCenter;
            operation_del.Click += new EventHandler(Del_Click_Event);

            // Panel
            Panel pan_displayusermanage = new Panel();
            pan_displayusermanage.BackColor = Color.White;
            pan_displayusermanage.Controls.Add(value_name);
            pan_displayusermanage.Controls.Add(value_email);
            pan_displayusermanage.Controls.Add(operation_del);
            pan_displayusermanage.Controls.Add(value_status);
            pan_displayusermanage.Controls.Add(value_join);
            pan_displayusermanage.Controls.Add(value_birthday);
            pan_displayusermanage.Controls.Add(value_id);
            pan_displayusermanage.Location = new Point(2, 2 + 35 * index + 1);
            pan_displayusermanage.Name = "pan_displayusermanage";
            pan_displayusermanage.Size = new Size(1167, 35);
            pan_displayusermanage.TabIndex = 1;
            pan_RightSubManage.Controls.Add(pan_displayusermanage);
        }

        private void Del_Click_Event(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string delObject = label.Name;
            DeleteUser(delObject);
            pan_RightSubManage.Controls.Clear();
            pan_TitleManage.Location = new Point(2, 2);
            pan_RightSubManage.Controls.Add(pan_TitleManage);
            LoadUser();
        }

        private List<UserInfo> userInforList = new List<UserInfo>();

        private void DeleteUser(string id)
        {
            if(statusServer == 1)
            {
                NoticeUI noticeUI = new NoticeUI();
                noticeUI.title = "Error";
                noticeUI.content = "To perform this function, you must deactivate the server first";
                noticeUI.ShowDialog();
                return;
            }
            DialogResult result = MessageBox.Show("You really want to delete the user" + id, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) { return; }
            WaitingUI deleWait = new WaitingUI();
            deleWait.content = "Deleting...";
            deleWait.closePer = false;
            Thread deleThreard = new Thread(() =>
            {
                deleWait.ShowDialog();
            });
            deleThreard.Start();
            string userRoot = "root";
            using (var client = new SshClient(ipFtpServer, userRoot, passwordRoot))
            {
                client.Connect();
                client.RunCommand("pkill -u user" + id);
                client.RunCommand("userdel -r user" + id);
                client.Disconnect();
            }
            UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): Delete account \"user" + id + "\" success");
            deleWait.closePer = true;
            deleWait.Invoke(() =>
            {
                deleWait.Close();
            });
        }

        private void ResetPermissionUser(string nameUserReset)
        {
            string userRoot = "root";
            using (var client = new SshClient(ipFtpServer, userRoot, passwordRoot))
            {
                client.Connect();
                client.RunCommand($"chown -R {nameUserReset} /home/AdminFolder/.UserData/{nameUserReset}");
                client.RunCommand($"chgrp -R FXTGroup /home/AdminFolder/.UserData/{nameUserReset}");
                client.RunCommand($"chmod -R u+rwx,g-rwx,o-rwx /home/AdminFolder/.UserData/{nameUserReset}/.Conversation");
                client.Disconnect();
            }
        }

        private void LoadUser()
        {
            WaitingUI loadWait = new WaitingUI();
            loadWait.content = "Loading all users....";
            loadWait.closePer = false;
            Thread loadThread = new Thread(() =>
            {
                loadWait.ShowDialog();
            });
            loadThread.Start();
            ResetPermissionAdmin();
            string[] listUser = RunTask.ListDirectories(userAdmin, passwordAdmin, ipFtpServer, ".UserData");
            for (int i = 0; i < listUser.Length; i++)
            {
                RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, $".UserData/{listUser[i]}/.Importal/.profile", "data.txt");
                string[] partOf = RunTask.DecryptionCode((File.ReadAllText("data.txt")).Trim()).Split('|');
                UserInfo userInfo = new UserInfo();
                userInfo._id = int.Parse(partOf[0].Substring(1));
                userInfo._name = partOf[1];
                userInfo._birthday = partOf[2];
                userInfo._email = partOf[3];
                userInfo._joinday = partOf[4];
                userInfo._active = true;
                if (partOf[5] == "0")
                    userInfo._active = false;
                AddRowUser(userInfo, i + 1);
                File.Delete("data.txt");
            }
            pan_Right.Controls.Add(pan_RightSubManage);
            loadWait.Invoke(() =>
            {
                loadWait.closePer = true;
                loadWait.Close();
            });
        }

        private void LoadViewLog()
        {
            WaitingUI waitingUI = new WaitingUI();
            waitingUI.content = "Loading log...";
            waitingUI.closePer = false;
            Thread newThread = new Thread(() =>
            {
                waitingUI.ShowDialog();
            });
            newThread.Start();
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".MyData/.log", "log.txt");
            logString = RunTask.DecryptionCode(File.ReadAllText("log.txt"));
            txt_ViewLog.Text = logString;
            File.Delete("log.txt");
            pan_Right.Controls.Add(pan_RightSubViewLog);

            waitingUI.Invoke(() =>
            {
                waitingUI.closePer = true;
                waitingUI.Close();
            });
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (statusServer == 1)
                btn_Active_Click(sender, e);
            timer_Exit.Start();
        }

        private void timer_Exit_Tick(object sender, EventArgs e)
        {
            double opacityStep = 0.05;
            this.Opacity -= opacityStep;
            if (this.Opacity <= 0)
            {
                timer_Exit.Stop();
                Environment.Exit(0);
            }
        }

        private void btn_Minimum_Click(object sender, EventArgs e)
        {
            timer_Hidden.Start();
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
        #endregion

        #region Lap_Trinh_Mang
        private void ChangePassword (string user, IPEndPoint iPEnd, string code)
        {
            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand($"echo \"{code}\" | passwd --stdin {user}");
                client.Disconnect();
            }
            UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): Change information " + user + " successful");
            return;
        }

        private void GetPLKeyRsa(EndPoint endPoint)
        {
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".Importal/.public", "public_key.pem");
            string sourceData = "RepPLKeyRsa|" + File.ReadAllText("public_key.pem");
            byte[] data = Encoding.UTF8.GetBytes(sourceData);
            File.Delete("public_key.pem");
            socketConnection.SendTo(data, endPoint);
            return;
        }

        private void GetPVKeyRsa(EndPoint endPoint)
        {
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".Importal/.private", "private_key.pem");
            string sourceData = "RepPLKeyRsa|" + File.ReadAllText("private_key.pem");
            byte[] data = Encoding.UTF8.GetBytes(sourceData);
            File.Delete("private_key.pem");
            socketConnection.SendTo(data, endPoint);
            return;
        }

        private void UserConverter(string email, IPEndPoint endPoint)
        {
            for(int i = 0; i< userInforList.Count;i++)
            {
                if(email == userInforList[i]._email)
                {
                    string sourceData = "RepUserConverter" + "|user" + userInforList[i]._id;
                    byte[] data = Encoding.UTF8.GetBytes(sourceData);
                    socketConnection.SendTo(data, endPoint);
                    return;
                }
            }
            string sourceData2 = "RepUserConverter" + "|";
            byte[] data2 = Encoding.UTF8.GetBytes(sourceData2);
            socketConnection.SendTo(data2, endPoint);
        }

        private void GetPicture(string userGet, IPEndPoint endPoint)
        {
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + userGet + "/.Importal/.pic", "data.jpg");
            FileStream fileStream = new FileStream("data.jpg", FileMode.Open, FileAccess.Read);
            byte[] imageData = new byte[fileStream.Length];
            fileStream.Read(imageData, 0, (int)fileStream.Length);
            socketConnection.SendTo(imageData, endPoint);
            fileStream.Close();
            File.Delete("data.jpg");
        }

        private void GetName(string nameUser, IPEndPoint endPoint)
        {
            for(int i = 0;i<userInforList.Count;i++)
            {
                if ("user" + userInforList[i]._id == nameUser)
                {
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("ReGetName|" + userInforList[i]._name), endPoint);
                    return;
                }
            }
        }

        private void CheckActivity(string nameUser, IPEndPoint endPoint)
        {
            for(int i = 0; i < userInforList.Count; i++)
            {
                if ("user" + userInforList[i]._id == nameUser)
                {
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("ReCheckActivity|" + nameUser + "|" + ((userInforList[i]._active)?1:0)), endPoint);
                    return;
                }
            }
            socketConnection.SendTo(Encoding.UTF8.GetBytes("ReCheckActivity|"), endPoint);
        }

        private bool reloadenable = false;

        private void ReloadUserServer()
        {
            while (reloadenable) { }
            reloadenable = true;
            userInforList = new List<UserInfo>();
            string[] listUser = RunTask.ListDirectories(userAdmin, passwordAdmin, ipFtpServer, ".UserData");
            for (int i = 0; i < listUser.Length; i++)
            {
                ResetPermissionUser(listUser[i]);
                RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, $".UserData/{listUser[i]}/.Importal/.profile", "data1.txt");
                string[] partOf = RunTask.DecryptionCode((File.ReadAllText("data1.txt")).Trim()).Split('|');
                UserInfo userInfo = new UserInfo();
                userInfo._id = int.Parse(partOf[0].Substring(1));
                userInfo._name = partOf[1];
                userInfo._birthday = partOf[2];
                userInfo._email = partOf[3];
                userInfo._joinday = partOf[4];
                userInfo._active = true;
                if (partOf[5] == "0")
                    userInfo._active = false;
                userInforList.Add(userInfo);
                File.Delete("data1.txt");
            }
            reloadenable = false;
        }

        private bool handleLogout = false;

        private void Logout(string user)
        {
            while(handleLogout) { Thread.Sleep(3000); };
            handleLogout = true;
            ReloadUserServer();
            hostConnected--;
            if (hostConnected < 0)
                hostConnected = 0;
            lbl_HostConnected.Invoke(() =>
            {
                lbl_HostConnected.Text = hostConnected + "";
            });
            pan_Chart.Invoke(() =>
            {
                pan_Chart.Refresh();
            });
            UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): " + user + " disconnected");
            handleLogout = false;
        }

        private bool handleLogin = false;

        private void Login(string user)
        {
            while(handleLogin) { Thread.Sleep(3000); }
            handleLogin = true;
            ReloadUserServer();
            hostConnected++;
            lbl_HostConnected.Invoke(() =>
            {
                lbl_HostConnected.Text = hostConnected + "";
            });
            pan_Chart.Invoke(() =>
            {
                pan_Chart.Refresh();
            });
            UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): " + user + " connected");
            handleLogin = false;
        }

        private void HandleCase(object arguments)
        {
            object[] args = (object[])arguments;
            string command = (string)args[0];
            IPEndPoint endPoint = (IPEndPoint)args[1];
            string[] splitArguments = command.Split('|');
            switch (splitArguments[0])
            {
                case "CreateAccount":
                    {
                        CreateAccount(splitArguments[1], splitArguments[2], splitArguments[3], splitArguments[4]);
                        break;
                    }
                case "Upload":
                    {
                        UpLoadFile(splitArguments[1], splitArguments[2], splitArguments[3]);
                        break;
                    }
                case "CallVoiceCheck":
                    {
                        CallVoiceCheck(splitArguments[1], splitArguments[2], endPoint);
                        break;
                    }
                case "Logout":
                    {
                        Logout(splitArguments[1]);
                        break;
                    }
                case "Login":
                    {
                        Login(splitArguments[1]);
                        break;
                    }
                case "ReloadUserServer":
                    {
                        ReloadUserServer();
                        break;
                    }
                case "CheckActivity":
                    {
                        CheckActivity(splitArguments[1], endPoint);
                        break;
                    }
                case "GetName":
                    {
                        GetName(splitArguments[1], endPoint);
                        break;
                    }
                case "ChangePassword":
                    {
                        ChangePassword(splitArguments[1], endPoint, splitArguments[2]);
                        break;
                    }
                case "UserConverter":
                    {
                        UserConverter(splitArguments[1], endPoint);
                        break;
                    }
                case "GetPLKeyRsa":
                    {
                        GetPLKeyRsa(endPoint);
                        break;
                    }
                case "GetPVKeyRsa":
                    {
                        GetPVKeyRsa(endPoint);
                        break;
                    }
                case "GetPicture":
                    {
                        GetPicture(splitArguments[1], endPoint);
                        break;
                    }
                case "Send":
                    {
                        Send(splitArguments[1], splitArguments[2], splitArguments[3], endPoint);
                        break;
                    }
                case "ReGetFriendship":
                    {
                        ReGetFriendship(splitArguments[1], splitArguments[2]);
                        break;
                    }
                case "GetFriendship":
                    {
                        GetFriendship(splitArguments[1], splitArguments[2], splitArguments[3]);
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
                    countByte = socketConnection.ReceiveFrom(data, ref endPoint);
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
        private bool sshBool = false;

        private void HandleNetwork()
        {
            enabled = true;
            Thread handleEnable = new Thread(new ThreadStart(MainHandle));
            handleEnable.Start();
        }

        private void Loopack()
        {
            IPEndPoint thisEndPoint = new IPEndPoint(IPAddress.Parse(ipAddressAndPort[0]), int.Parse(ipAddressAndPort[1]));
            socketConnection.SendTo(new byte[] { }, thisEndPoint);
        }
        #endregion

        #region Xu_Ly_Gui_Tin_Nhan
        private bool sending = false, bingrequest = false;

        private void Send(string sender, string receiver, string message, IPEndPoint endPoint)
        {
            if(receiver == "bingid")
            {
                while (bingrequest) { }
                bingrequest = true;
                Process process = new Process();
                process.StartInfo.FileName = "node.exe";
                string bingAI = "./node_modules/bing-chat/bing.js";
                process.StartInfo.Arguments = $"--no-warnings {bingAI} \"{message}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                message = File.ReadAllText("file.txt");
                File.Delete("file.txt");
                socketConnection.SendTo(Encoding.UTF8.GetBytes("SendTo|" + receiver + "|" + message + "|" + "Bing Chat"), endPoint);
                bingrequest = false;
                return;
            }
            while (sending) { }
            sending = true;
            for (int i = 0; i < userInforList.Count; i++)
            {
                if(receiver == "user" + userInforList[i]._id && userInforList[i]._active)
                {
                    RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + receiver + "/.Importal/.profile", "readip.txt");
                    string nameSender = "";
                    for(int j = 0; j < userInforList.Count; j++)
                    {
                        if ("user" + userInforList[j]._id == sender)
                        {
                            nameSender = userInforList[j]._name;
                            break;
                        }
                    }
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("SendTo|" + sender + "|" + message + "|" + nameSender), new IPEndPoint(IPAddress.Parse(RunTask.DecryptionCode(File.ReadAllText("readip.txt").Trim()).Split('|')[6]), int.Parse(ipAddressAndPort[1])));
                    File.Delete("readip.txt");
                    sending = false;
                    return;
                }
            }
            while(sshBool) { }
            sshBool = true;
            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand("chown -R FXT /home/AdminFolder/.UserData/" + receiver);
                client.Disconnect();
            }
            sshBool = false;
            File.WriteAllText("tempNew.txt", "");
            RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "tempNew.txt", ".UserData/" + receiver + "/.NewMess/" + sender + ".new");
            File.Delete("tempNew.txt");
            RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + receiver + "/.Conversation/" + sender + ".conversation", "chat.txt");
            string sourceChat = File.ReadAllText("chat.txt").Trim();
            File.Delete("chat.txt");
            sourceChat = sourceChat + " " + RunTask.CryptionCode(sender + "|" + message + "|" + RunTask.GetCurrentDateTime2()) + "000A";
            File.WriteAllText("converchat.txt", sourceChat);
            RunTask.DeleteFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + receiver + "/.Conversation/" + sender + ".conversation");
            RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "converchat.txt", ".UserData/" + receiver + "/.Conversation/" + sender + ".conversation");
            File.Delete("converchat.txt");
            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand("chown -R " + receiver + " /home/AdminFolder/.UserData/" + receiver);
                client.Disconnect();
            }
            sending = false;
        }
        #endregion

        #region Xu_Ly_Call_Voice
        private void CallVoiceCheck(string userRequest, string nameUserCall, IPEndPoint endPoint)
        {
            for(int i = 0;i <userInforList.Count;i++)
            {
                if("user" + userInforList[i]._id == userRequest && userInforList[i]._active)
                {
                    RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + userRequest + "/.Importal/.profile", "getip.txt");
                    string sourceProfile = File.ReadAllText("getip.txt").Trim();
                    sourceProfile = RunTask.DecryptionCode(sourceProfile);
                    string getIp = sourceProfile.Split('|')[6];
                    File.Delete("getip.txt");
                    string guestIp = endPoint.Address.ToString();
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("CallVoiceCheck|" + guestIp + "|" + nameUserCall), new IPEndPoint(IPAddress.Parse(getIp), int.Parse(ipAddressAndPort[1])));
                    return;
                }
            }
            socketConnection.SendTo(Encoding.UTF8.GetBytes("ReCallVoiceCheck|0|"), endPoint);
        }
        #endregion

        #region Xu_Ly_Ket_Ban
        bool checkadd = false;

        private void GetFriendship(string userRequest, string userBeRequest, string nameRequest)
        {
            while (checkadd) { }
            ReloadUserServer();
            checkadd = true;
            for(int i = 0; i<userInforList.Count; i++)
            {
                if (userBeRequest == "user" + userInforList[i]._id && userInforList[i]._active)
                {
                    RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + userBeRequest + "/.Importal/.profile", "getip.txt");
                    string getIp = File.ReadAllText("getip.txt").Trim();
                    string getIP = RunTask.DecryptionCode(getIp).Split('|')[6];
                    File.Delete("getip.txt");
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("GetFriendship|" + userRequest + "|" + nameRequest), new IPEndPoint(IPAddress.Parse(getIP), int.Parse(ipAddressAndPort[1])));
                    checkadd = false;
                    return;
                }
            }
            checkadd = false;
        }

        bool checkadd2 = false;

        private void ReGetFriendship(string user1, string user2)
        {
            while(checkadd2) { }
            checkadd2 = true;
            string defaultChat = user1 + "|Xin chào|" + RunTask.GetCurrentDateTime2() + '\n' + user2 + "|Xin chào|" + RunTask.GetCurrentDateTime2();
            defaultChat = RunTask.CryptionCode(defaultChat) + "000A";
            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand("chown -R FXT /home/AdminFolder/.UserData/" + user1);
                client.RunCommand("chown -R FXT /home/AdminFolder/.UserData/" + user2);
                client.Disconnect();
            }
            File.WriteAllText("default.txt", defaultChat);
            RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "default.txt", ".UserData/" + user1 + "/.Conversation/" + user2 + ".conversation");
            RunTask.UploadFileToFTP(userAdmin, passwordAdmin, ipFtpServer, "default.txt", ".UserData/" + user2 + "/.Conversation/" + user1 + ".conversation");
            File.Delete("default.txt");

            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand("chown -R " + user1 + " /home/AdminFolder/.UserData/" + user1);
                client.RunCommand("chown -R " + user2 + " /home/AdminFolder/.UserData/" + user2);
                client.Disconnect();
            }

            for (int i = 0; i < userInforList.Count; i++)
            {
                if (user1 == "user" + userInforList[i]._id && userInforList[i]._active)
                {
                    RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + user1 + "/.Importal/.profile", "getip2.txt");
                    string getIp = File.ReadAllText("getip2.txt").Trim();
                    string getIP = RunTask.DecryptionCode(getIp).Split('|')[6];
                    File.Delete("geti2p.txt");
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("ReloadFriend"), new IPEndPoint(IPAddress.Parse(getIP), int.Parse(ipAddressAndPort[1])));
                }
                if (user2 == "user" + userInforList[i]._id && userInforList[i]._active)
                {
                    RunTask.DownloadFileFromFTP(userAdmin, passwordAdmin, ipFtpServer, ".UserData/" + user2 + "/.Importal/.profile", "getip2.txt");
                    string getIp = File.ReadAllText("getip2.txt").Trim();
                    string getIP = RunTask.DecryptionCode(getIp).Split('|')[6];
                    File.Delete("getip2.txt");
                    socketConnection.SendTo(Encoding.UTF8.GetBytes("ReloadFriend"), new IPEndPoint(IPAddress.Parse(getIP), int.Parse(ipAddressAndPort[1])));
                }
            }
            checkadd2 = false;
        }
        #endregion

        #region Xu_Ly_Gui_File
        private void UpLoadFile(string sourceUser, string destUser, string fileName)
        {
            while (sshBool) { }
            sshBool = true;
            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand($"cp /home/AdminFolder/.UserData/{sourceUser}/{fileName} /home/AdminFolder/.UserData/{destUser}/.TotalFile/");
                client.RunCommand($"chown -R /home/AdminFolder/.UserData/{destUser} {destUser}");
                client.Disconnect();
            }
            sshBool = false;
        }
        #endregion

        #region Xu_Ly_Yeu_Cau_Tao_Tai_Khoan
        bool create = false;

        private void CreateAccount(string email, string name, string birthday, string password) 
        {
            ReloadUserServer();
            for(int i = 0; i< userInforList.Count; i++)
            {
                if (userInforList[i]._email == email)
                {
                    if(userMail == null) {
                        var mailAddress = new MailAddress(txt_Email.Text);
                        File.Move("./App-Data/user_mail.encry", "ma_hoa.encry");
                        LoadKeyEncry();
                        Process process = new Process();
                        process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
                        process.Start();
                        process.WaitForExit();
                        userMail = File.ReadAllText("giai_ma.txt");
                        File.Delete("giai_ma.txt");
                        File.Move("ma_hoa.encry", "./App-Data/user_mail.encry");

                        File.Move("./App-Data/password_mail.encry", "ma_hoa.encry");
                        process = new Process();
                        process.StartInfo.FileName = "./App-Data/Giai-Ma.exe";
                        process.Start();
                        process.WaitForExit();
                        passwordMail = File.ReadAllText("giai_ma.txt");
                        File.Delete("giai_ma.txt");
                        File.Move("ma_hoa.encry", "./App-Data/password_mail.encry");

                        File.Delete("public_key.pem");
                        File.Delete("private_key.pem");
                    }
                    RunTask.SendEmail(userMail, passwordMail, "Account already exists", $"Hey, {userInforList[i]._name}\nThe FXT Strix 2202 system recognizes the request to create an account linked to your email, if that's you, that's fine. If not you, please keep your account information more secure.\n\n\nFrom FXTGroup with love!!!", email);
                    return;
                }
            }
            string id;
            while (true)
            {
                bool same = false;
                id = RunTask.RandomID();
                for(int i = 0; i < userInforList.Count; i++)
                {
                    if (userInforList[i]._id == int.Parse(id))
                    {
                        same = true;
                        break;
                    }
                }
                if (!same)
                    break;
            }
            id = "user" + id;
            while (sshBool) { }
            sshBool = true;
            using (var client = new SshClient(ipFtpServer, "root", passwordRoot))
            {
                client.Connect();
                client.RunCommand("useradd -m -d /home/AdminFolder/.UserData/" + id + " " + id);
                client.RunCommand($"echo {password} | passwd --stdin {id}");
                client.RunCommand($"usermod -G FXTGroup {id}");
                client.RunCommand($"mkdir /home/AdminFolder/.UserData/{id}/.TotalFile");
                client.RunCommand($"mkdir /home/AdminFolder/.UserData/{id}/.NewMess");
                client.RunCommand($"mkdir /home/AdminFolder/.UserData/{id}/.Conversation");
                client.RunCommand($"mkdir /home/AdminFolder/.UserData/{id}/.Importal");
                client.RunCommand($"cp /home/AdminFolder/.pic /home/AdminFolder/.UserData/{id}/.Importal/");
                client.RunCommand($"chown -R {id} /home/AdminFolder/.UserData/{id}");
                client.RunCommand($"chgrp -R FXTGroup /home/AdminFolder/.UserData/{id}");
                client.Disconnect();
            }
            sshBool = false;
            while (create) { }
            create = true;
            File.WriteAllText("readper.txt", "1");
            RunTask.UploadFileToFTP(id, password, ipFtpServer, "readper.txt", ".Importal/.per");
            File.Delete("readper.txt");
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");
            string sourceProfile = "#" + id.Substring(4) + "|" + name + "|" + birthday + "|" + email + "|" + formattedDate + "|0";
            File.WriteAllText("profileNew.txt", RunTask.CryptionCode(sourceProfile));
            RunTask.UploadFileToFTP(id, password, ipFtpServer, "profileNew.txt", ".Importal/.profile");
            File.Delete("profileNew.txt");
            File.WriteAllText("bingNew.txt", "0062 0069 006E 0067 0069 0064 007C 0043 0068 00E0 006F 0020 0062 1EA1 006E 002C 0020 0074 00F4 0069 0020 0063 00F3 0020 0074 0068 1EC3 0020 0067 0069 00FA 0070 0020 0067 00EC 0020 0063 0068 006F 0020 0062 1EA1 006E 007C 004F 0076 0065 0072 0074 0069 006D 0065 000A");
            RunTask.UploadFileToFTP(id, password, ipFtpServer, "bingNew.txt", ".Conversation/bingid.conversation");
            create = false;
            UpdateLogFile("Log(" + RunTask.GetCurrentDateTime() + "): Create account " + id + " successful");
            ReloadUserServer();
        }
        #endregion
    }
}
