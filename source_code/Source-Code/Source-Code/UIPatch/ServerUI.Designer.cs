namespace Source_Code.UIPatch
{
    partial class ServerUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerUI));
            pan_Left = new Panel();
            pan_Logout = new Panel();
            lbl_Logout = new Label();
            pic_Logout = new PictureBox();
            pic_Logo = new PictureBox();
            pan_ViewLog = new Panel();
            lbl_ViewLog = new Label();
            pic_ViewLog = new PictureBox();
            pan_ManageUser = new Panel();
            lbl_ManageUser = new Label();
            pic_ManageUser = new PictureBox();
            pan_Dashboard = new Panel();
            lbl_Dashboard = new Label();
            pic_Dashboard = new PictureBox();
            pan_Profile = new Panel();
            lbl_Profile = new Label();
            pic_Profile = new PictureBox();
            pan_ServerTitle = new Panel();
            lbl_ServerTitle = new Label();
            pic_ServerTitle = new PictureBox();
            pan_Right = new Panel();
            pan_RightSubDashboard = new Panel();
            grp_Chart = new GroupBox();
            lbl_Free = new Label();
            lbl_Used = new Label();
            pan_Chart = new Panel();
            grp_Status = new GroupBox();
            pic_Status = new PictureBox();
            lbl_Time = new Label();
            lbl_HostConnected = new Label();
            lbl_MaximumHosts = new Label();
            lbl_Status = new Label();
            lbl_TimeTitle = new Label();
            lbl_HostConnectedTitle = new Label();
            lbl_MaximumHostsTitle = new Label();
            lbl_StatusTitle = new Label();
            btn_Active = new Button();
            pan_RightSubProfile = new Panel();
            grp_YourPicture = new GroupBox();
            btn_ChangeYourPicture = new Button();
            pic_YourPicture = new PictureBox();
            grp_InfoProfile = new GroupBox();
            btn_ChangeInfo = new Button();
            txt_Email = new TextBox();
            txt_Birthday = new TextBox();
            txt_Password = new TextBox();
            txt_YourName = new TextBox();
            txt_User = new TextBox();
            lbl_Email = new Label();
            lbl_Birthday = new Label();
            lbl_Password = new Label();
            lbl_YourName = new Label();
            lbl_NameAcc = new Label();
            pan_RightSubViewLog = new Panel();
            txt_ViewLog = new RichTextBox();
            pan_RightSubManage = new Panel();
            pan_TitleManage = new Panel();
            lbl_Operation = new Label();
            lbl_StatusManageUser = new Label();
            lbl_JoinDateManageUser = new Label();
            lbl_EmailManageUser = new Label();
            lbl_BirthdayManageUser = new Label();
            lbl_NameManageUser = new Label();
            lbl_IDManageUser = new Label();
            pan_Top = new Panel();
            btn_Minimum = new Label();
            btn_Exit = new Label();
            lbl_Title = new Label();
            countTime = new System.Windows.Forms.Timer(components);
            timer_Exit = new System.Windows.Forms.Timer(components);
            timer_Hidden = new System.Windows.Forms.Timer(components);
            pan_Left.SuspendLayout();
            pan_Logout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Logo).BeginInit();
            pan_ViewLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_ViewLog).BeginInit();
            pan_ManageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_ManageUser).BeginInit();
            pan_Dashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Dashboard).BeginInit();
            pan_Profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Profile).BeginInit();
            pan_ServerTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_ServerTitle).BeginInit();
            pan_RightSubDashboard.SuspendLayout();
            grp_Chart.SuspendLayout();
            grp_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Status).BeginInit();
            pan_RightSubProfile.SuspendLayout();
            grp_YourPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_YourPicture).BeginInit();
            grp_InfoProfile.SuspendLayout();
            pan_RightSubViewLog.SuspendLayout();
            pan_RightSubManage.SuspendLayout();
            pan_TitleManage.SuspendLayout();
            pan_Top.SuspendLayout();
            SuspendLayout();
            // 
            // pan_Left
            // 
            pan_Left.BackColor = Color.MidnightBlue;
            pan_Left.Controls.Add(pan_Logout);
            pan_Left.Controls.Add(pic_Logo);
            pan_Left.Controls.Add(pan_ViewLog);
            pan_Left.Controls.Add(pan_ManageUser);
            pan_Left.Controls.Add(pan_Dashboard);
            pan_Left.Controls.Add(pan_Profile);
            pan_Left.Controls.Add(pan_ServerTitle);
            pan_Left.Location = new Point(0, 30);
            pan_Left.Name = "pan_Left";
            pan_Left.Size = new Size(205, 370);
            pan_Left.TabIndex = 0;
            // 
            // pan_Logout
            // 
            pan_Logout.Controls.Add(lbl_Logout);
            pan_Logout.Controls.Add(pic_Logout);
            pan_Logout.Location = new Point(0, 336);
            pan_Logout.Name = "pan_Logout";
            pan_Logout.Size = new Size(205, 32);
            pan_Logout.TabIndex = 6;
            // 
            // lbl_Logout
            // 
            lbl_Logout.BackColor = Color.Transparent;
            lbl_Logout.Dock = DockStyle.Right;
            lbl_Logout.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Logout.ForeColor = Color.White;
            lbl_Logout.Location = new Point(47, 0);
            lbl_Logout.Name = "lbl_Logout";
            lbl_Logout.Size = new Size(158, 32);
            lbl_Logout.TabIndex = 1;
            lbl_Logout.Text = "Log out";
            lbl_Logout.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Logout.Click += lbl_Logout_Click;
            // 
            // pic_Logout
            // 
            pic_Logout.BackColor = Color.Transparent;
            pic_Logout.Dock = DockStyle.Left;
            pic_Logout.Image = (Image)resources.GetObject("pic_Logout.Image");
            pic_Logout.Location = new Point(0, 0);
            pic_Logout.Name = "pic_Logout";
            pic_Logout.Size = new Size(41, 32);
            pic_Logout.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Logout.TabIndex = 0;
            pic_Logout.TabStop = false;
            // 
            // pic_Logo
            // 
            pic_Logo.BackColor = Color.Transparent;
            pic_Logo.Image = (Image)resources.GetObject("pic_Logo.Image");
            pic_Logo.Location = new Point(10, 185);
            pic_Logo.Name = "pic_Logo";
            pic_Logo.Size = new Size(185, 140);
            pic_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Logo.TabIndex = 5;
            pic_Logo.TabStop = false;
            // 
            // pan_ViewLog
            // 
            pan_ViewLog.Controls.Add(lbl_ViewLog);
            pan_ViewLog.Controls.Add(pic_ViewLog);
            pan_ViewLog.Dock = DockStyle.Top;
            pan_ViewLog.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            pan_ViewLog.Location = new Point(0, 135);
            pan_ViewLog.Name = "pan_ViewLog";
            pan_ViewLog.Size = new Size(205, 32);
            pan_ViewLog.TabIndex = 4;
            // 
            // lbl_ViewLog
            // 
            lbl_ViewLog.BackColor = Color.Transparent;
            lbl_ViewLog.Dock = DockStyle.Right;
            lbl_ViewLog.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ViewLog.ForeColor = Color.White;
            lbl_ViewLog.Location = new Point(47, 0);
            lbl_ViewLog.Name = "lbl_ViewLog";
            lbl_ViewLog.Size = new Size(158, 32);
            lbl_ViewLog.TabIndex = 1;
            lbl_ViewLog.Text = "View log";
            lbl_ViewLog.TextAlign = ContentAlignment.MiddleLeft;
            lbl_ViewLog.Click += lbl_ViewLog_Click;
            // 
            // pic_ViewLog
            // 
            pic_ViewLog.BackColor = Color.Transparent;
            pic_ViewLog.Dock = DockStyle.Left;
            pic_ViewLog.Image = (Image)resources.GetObject("pic_ViewLog.Image");
            pic_ViewLog.Location = new Point(0, 0);
            pic_ViewLog.Name = "pic_ViewLog";
            pic_ViewLog.Size = new Size(41, 32);
            pic_ViewLog.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ViewLog.TabIndex = 0;
            pic_ViewLog.TabStop = false;
            // 
            // pan_ManageUser
            // 
            pan_ManageUser.Controls.Add(lbl_ManageUser);
            pan_ManageUser.Controls.Add(pic_ManageUser);
            pan_ManageUser.Dock = DockStyle.Top;
            pan_ManageUser.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            pan_ManageUser.Location = new Point(0, 103);
            pan_ManageUser.Name = "pan_ManageUser";
            pan_ManageUser.Size = new Size(205, 32);
            pan_ManageUser.TabIndex = 3;
            // 
            // lbl_ManageUser
            // 
            lbl_ManageUser.BackColor = Color.Transparent;
            lbl_ManageUser.Dock = DockStyle.Right;
            lbl_ManageUser.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ManageUser.ForeColor = Color.White;
            lbl_ManageUser.Location = new Point(47, 0);
            lbl_ManageUser.Name = "lbl_ManageUser";
            lbl_ManageUser.Size = new Size(158, 32);
            lbl_ManageUser.TabIndex = 1;
            lbl_ManageUser.Text = "Management user";
            lbl_ManageUser.TextAlign = ContentAlignment.MiddleLeft;
            lbl_ManageUser.Click += lbl_ManageUser_Click;
            // 
            // pic_ManageUser
            // 
            pic_ManageUser.BackColor = Color.Transparent;
            pic_ManageUser.Dock = DockStyle.Left;
            pic_ManageUser.Image = (Image)resources.GetObject("pic_ManageUser.Image");
            pic_ManageUser.Location = new Point(0, 0);
            pic_ManageUser.Name = "pic_ManageUser";
            pic_ManageUser.Size = new Size(41, 32);
            pic_ManageUser.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ManageUser.TabIndex = 0;
            pic_ManageUser.TabStop = false;
            // 
            // pan_Dashboard
            // 
            pan_Dashboard.Controls.Add(lbl_Dashboard);
            pan_Dashboard.Controls.Add(pic_Dashboard);
            pan_Dashboard.Dock = DockStyle.Top;
            pan_Dashboard.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            pan_Dashboard.Location = new Point(0, 71);
            pan_Dashboard.Name = "pan_Dashboard";
            pan_Dashboard.Size = new Size(205, 32);
            pan_Dashboard.TabIndex = 2;
            // 
            // lbl_Dashboard
            // 
            lbl_Dashboard.BackColor = Color.Transparent;
            lbl_Dashboard.Dock = DockStyle.Right;
            lbl_Dashboard.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Dashboard.ForeColor = Color.White;
            lbl_Dashboard.Location = new Point(47, 0);
            lbl_Dashboard.Name = "lbl_Dashboard";
            lbl_Dashboard.Size = new Size(158, 32);
            lbl_Dashboard.TabIndex = 1;
            lbl_Dashboard.Text = "Dashboard";
            lbl_Dashboard.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Dashboard.Click += lbl_Dashboard_Click;
            // 
            // pic_Dashboard
            // 
            pic_Dashboard.BackColor = Color.Transparent;
            pic_Dashboard.Dock = DockStyle.Left;
            pic_Dashboard.Image = (Image)resources.GetObject("pic_Dashboard.Image");
            pic_Dashboard.Location = new Point(0, 0);
            pic_Dashboard.Name = "pic_Dashboard";
            pic_Dashboard.Size = new Size(41, 32);
            pic_Dashboard.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Dashboard.TabIndex = 0;
            pic_Dashboard.TabStop = false;
            // 
            // pan_Profile
            // 
            pan_Profile.Controls.Add(lbl_Profile);
            pan_Profile.Controls.Add(pic_Profile);
            pan_Profile.Dock = DockStyle.Top;
            pan_Profile.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            pan_Profile.Location = new Point(0, 39);
            pan_Profile.Name = "pan_Profile";
            pan_Profile.Size = new Size(205, 32);
            pan_Profile.TabIndex = 1;
            // 
            // lbl_Profile
            // 
            lbl_Profile.BackColor = Color.Transparent;
            lbl_Profile.Dock = DockStyle.Right;
            lbl_Profile.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Profile.ForeColor = Color.White;
            lbl_Profile.Location = new Point(47, 0);
            lbl_Profile.Name = "lbl_Profile";
            lbl_Profile.Size = new Size(158, 32);
            lbl_Profile.TabIndex = 1;
            lbl_Profile.Text = "My profile";
            lbl_Profile.TextAlign = ContentAlignment.MiddleLeft;
            lbl_Profile.Click += lbl_Profile_Click;
            // 
            // pic_Profile
            // 
            pic_Profile.BackColor = Color.Transparent;
            pic_Profile.Dock = DockStyle.Left;
            pic_Profile.Image = (Image)resources.GetObject("pic_Profile.Image");
            pic_Profile.Location = new Point(0, 0);
            pic_Profile.Name = "pic_Profile";
            pic_Profile.Size = new Size(41, 32);
            pic_Profile.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Profile.TabIndex = 0;
            pic_Profile.TabStop = false;
            // 
            // pan_ServerTitle
            // 
            pan_ServerTitle.Controls.Add(lbl_ServerTitle);
            pan_ServerTitle.Controls.Add(pic_ServerTitle);
            pan_ServerTitle.Dock = DockStyle.Top;
            pan_ServerTitle.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            pan_ServerTitle.Location = new Point(0, 0);
            pan_ServerTitle.Name = "pan_ServerTitle";
            pan_ServerTitle.Size = new Size(205, 39);
            pan_ServerTitle.TabIndex = 0;
            // 
            // lbl_ServerTitle
            // 
            lbl_ServerTitle.Dock = DockStyle.Right;
            lbl_ServerTitle.Font = new Font("Engravers MT", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ServerTitle.ForeColor = Color.White;
            lbl_ServerTitle.Location = new Point(50, 0);
            lbl_ServerTitle.Name = "lbl_ServerTitle";
            lbl_ServerTitle.Size = new Size(155, 39);
            lbl_ServerTitle.TabIndex = 1;
            lbl_ServerTitle.Text = "|    SERVER      ";
            lbl_ServerTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pic_ServerTitle
            // 
            pic_ServerTitle.Image = (Image)resources.GetObject("pic_ServerTitle.Image");
            pic_ServerTitle.Location = new Point(6, 2);
            pic_ServerTitle.Name = "pic_ServerTitle";
            pic_ServerTitle.Size = new Size(38, 34);
            pic_ServerTitle.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ServerTitle.TabIndex = 0;
            pic_ServerTitle.TabStop = false;
            // 
            // pan_Right
            // 
            pan_Right.BackColor = Color.Black;
            pan_Right.Location = new Point(203, 30);
            pan_Right.Name = "pan_Right";
            pan_Right.Size = new Size(797, 370);
            pan_Right.TabIndex = 1;
            // 
            // pan_RightSubDashboard
            // 
            pan_RightSubDashboard.BackColor = Color.Tomato;
            pan_RightSubDashboard.Controls.Add(grp_Chart);
            pan_RightSubDashboard.Controls.Add(grp_Status);
            pan_RightSubDashboard.Location = new Point(3, 3);
            pan_RightSubDashboard.Name = "pan_RightSubDashboard";
            pan_RightSubDashboard.Size = new Size(790, 364);
            pan_RightSubDashboard.TabIndex = 0;
            // 
            // grp_Chart
            // 
            grp_Chart.BackColor = Color.MidnightBlue;
            grp_Chart.Controls.Add(lbl_Free);
            grp_Chart.Controls.Add(lbl_Used);
            grp_Chart.Controls.Add(pan_Chart);
            grp_Chart.Font = new Font("Courier New", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            grp_Chart.ForeColor = Color.White;
            grp_Chart.Location = new Point(428, 3);
            grp_Chart.Name = "grp_Chart";
            grp_Chart.Size = new Size(358, 358);
            grp_Chart.TabIndex = 1;
            grp_Chart.TabStop = false;
            grp_Chart.Text = "Chart";
            // 
            // lbl_Free
            // 
            lbl_Free.AutoSize = true;
            lbl_Free.BackColor = Color.Transparent;
            lbl_Free.Font = new Font("Courier New", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Free.ForeColor = Color.Aqua;
            lbl_Free.Location = new Point(189, 330);
            lbl_Free.Name = "lbl_Free";
            lbl_Free.Size = new Size(53, 17);
            lbl_Free.TabIndex = 1;
            lbl_Free.Text = "Free:";
            // 
            // lbl_Used
            // 
            lbl_Used.AutoSize = true;
            lbl_Used.BackColor = Color.Transparent;
            lbl_Used.Font = new Font("Courier New", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Used.ForeColor = Color.Yellow;
            lbl_Used.Location = new Point(6, 330);
            lbl_Used.Name = "lbl_Used";
            lbl_Used.Size = new Size(53, 17);
            lbl_Used.TabIndex = 1;
            lbl_Used.Text = "Used:";
            // 
            // pan_Chart
            // 
            pan_Chart.Location = new Point(47, 20);
            pan_Chart.Name = "pan_Chart";
            pan_Chart.Size = new Size(270, 270);
            pan_Chart.TabIndex = 0;
            pan_Chart.Paint += pan_Chart_Paint;
            // 
            // grp_Status
            // 
            grp_Status.BackColor = Color.White;
            grp_Status.Controls.Add(pic_Status);
            grp_Status.Controls.Add(lbl_Time);
            grp_Status.Controls.Add(lbl_HostConnected);
            grp_Status.Controls.Add(lbl_MaximumHosts);
            grp_Status.Controls.Add(lbl_Status);
            grp_Status.Controls.Add(lbl_TimeTitle);
            grp_Status.Controls.Add(lbl_HostConnectedTitle);
            grp_Status.Controls.Add(lbl_MaximumHostsTitle);
            grp_Status.Controls.Add(lbl_StatusTitle);
            grp_Status.Controls.Add(btn_Active);
            grp_Status.Font = new Font("Courier New", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            grp_Status.Location = new Point(5, 3);
            grp_Status.Name = "grp_Status";
            grp_Status.Size = new Size(417, 358);
            grp_Status.TabIndex = 0;
            grp_Status.TabStop = false;
            grp_Status.Text = "Status";
            // 
            // pic_Status
            // 
            pic_Status.Image = (Image)resources.GetObject("pic_Status.Image");
            pic_Status.Location = new Point(289, 33);
            pic_Status.Name = "pic_Status";
            pic_Status.Size = new Size(128, 128);
            pic_Status.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Status.TabIndex = 2;
            pic_Status.TabStop = false;
            // 
            // lbl_Time
            // 
            lbl_Time.AutoSize = true;
            lbl_Time.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Time.ForeColor = Color.Black;
            lbl_Time.Location = new Point(170, 137);
            lbl_Time.Name = "lbl_Time";
            lbl_Time.Size = new Size(44, 17);
            lbl_Time.TabIndex = 1;
            lbl_Time.Text = "None";
            // 
            // lbl_HostConnected
            // 
            lbl_HostConnected.AutoSize = true;
            lbl_HostConnected.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_HostConnected.ForeColor = Color.Black;
            lbl_HostConnected.Location = new Point(170, 105);
            lbl_HostConnected.Name = "lbl_HostConnected";
            lbl_HostConnected.Size = new Size(44, 17);
            lbl_HostConnected.TabIndex = 1;
            lbl_HostConnected.Text = "None";
            // 
            // lbl_MaximumHosts
            // 
            lbl_MaximumHosts.AutoSize = true;
            lbl_MaximumHosts.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MaximumHosts.ForeColor = Color.Black;
            lbl_MaximumHosts.Location = new Point(170, 73);
            lbl_MaximumHosts.Name = "lbl_MaximumHosts";
            lbl_MaximumHosts.Size = new Size(44, 17);
            lbl_MaximumHosts.TabIndex = 1;
            lbl_MaximumHosts.Text = "None";
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Status.ForeColor = Color.Black;
            lbl_Status.Location = new Point(170, 44);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(44, 17);
            lbl_Status.TabIndex = 1;
            lbl_Status.Text = "None";
            // 
            // lbl_TimeTitle
            // 
            lbl_TimeTitle.AutoSize = true;
            lbl_TimeTitle.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_TimeTitle.Location = new Point(21, 136);
            lbl_TimeTitle.Name = "lbl_TimeTitle";
            lbl_TimeTitle.Size = new Size(116, 17);
            lbl_TimeTitle.TabIndex = 1;
            lbl_TimeTitle.Text = "Time active:";
            // 
            // lbl_HostConnectedTitle
            // 
            lbl_HostConnectedTitle.AutoSize = true;
            lbl_HostConnectedTitle.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_HostConnectedTitle.Location = new Point(21, 104);
            lbl_HostConnectedTitle.Name = "lbl_HostConnectedTitle";
            lbl_HostConnectedTitle.Size = new Size(143, 17);
            lbl_HostConnectedTitle.TabIndex = 1;
            lbl_HostConnectedTitle.Text = "Host connected:";
            // 
            // lbl_MaximumHostsTitle
            // 
            lbl_MaximumHostsTitle.AutoSize = true;
            lbl_MaximumHostsTitle.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MaximumHostsTitle.Location = new Point(21, 72);
            lbl_MaximumHostsTitle.Name = "lbl_MaximumHostsTitle";
            lbl_MaximumHostsTitle.Size = new Size(125, 17);
            lbl_MaximumHostsTitle.TabIndex = 1;
            lbl_MaximumHostsTitle.Text = "Maximum host:";
            // 
            // lbl_StatusTitle
            // 
            lbl_StatusTitle.AutoSize = true;
            lbl_StatusTitle.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StatusTitle.Location = new Point(21, 43);
            lbl_StatusTitle.Name = "lbl_StatusTitle";
            lbl_StatusTitle.Size = new Size(134, 17);
            lbl_StatusTitle.TabIndex = 1;
            lbl_StatusTitle.Text = "Server status:";
            // 
            // btn_Active
            // 
            btn_Active.BackColor = Color.MidnightBlue;
            btn_Active.Font = new Font("Courier New", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Active.ForeColor = Color.Lime;
            btn_Active.Location = new Point(6, 303);
            btn_Active.Name = "btn_Active";
            btn_Active.Size = new Size(405, 55);
            btn_Active.TabIndex = 0;
            btn_Active.Text = "Active";
            btn_Active.UseVisualStyleBackColor = false;
            btn_Active.Click += btn_Active_Click;
            // 
            // pan_RightSubProfile
            // 
            pan_RightSubProfile.BackColor = Color.Tomato;
            pan_RightSubProfile.Controls.Add(grp_YourPicture);
            pan_RightSubProfile.Controls.Add(grp_InfoProfile);
            pan_RightSubProfile.Location = new Point(3, 3);
            pan_RightSubProfile.Name = "pan_RightSubProfile";
            pan_RightSubProfile.Size = new Size(790, 364);
            pan_RightSubProfile.TabIndex = 0;
            // 
            // grp_YourPicture
            // 
            grp_YourPicture.BackColor = Color.White;
            grp_YourPicture.Controls.Add(btn_ChangeYourPicture);
            grp_YourPicture.Controls.Add(pic_YourPicture);
            grp_YourPicture.Font = new Font("Courier New", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            grp_YourPicture.Location = new Point(555, 3);
            grp_YourPicture.Name = "grp_YourPicture";
            grp_YourPicture.Size = new Size(232, 358);
            grp_YourPicture.TabIndex = 1;
            grp_YourPicture.TabStop = false;
            grp_YourPicture.Text = "Picture";
            // 
            // btn_ChangeYourPicture
            // 
            btn_ChangeYourPicture.BackColor = Color.MidnightBlue;
            btn_ChangeYourPicture.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ChangeYourPicture.ForeColor = Color.White;
            btn_ChangeYourPicture.Location = new Point(38, 315);
            btn_ChangeYourPicture.Name = "btn_ChangeYourPicture";
            btn_ChangeYourPicture.Size = new Size(157, 31);
            btn_ChangeYourPicture.TabIndex = 3;
            btn_ChangeYourPicture.Text = "Change";
            btn_ChangeYourPicture.UseVisualStyleBackColor = false;
            btn_ChangeYourPicture.Click += btn_ChangeYourPicture_Click;
            // 
            // pic_YourPicture
            // 
            pic_YourPicture.Dock = DockStyle.Top;
            pic_YourPicture.Location = new Point(3, 20);
            pic_YourPicture.Name = "pic_YourPicture";
            pic_YourPicture.Size = new Size(226, 285);
            pic_YourPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_YourPicture.TabIndex = 0;
            pic_YourPicture.TabStop = false;
            // 
            // grp_InfoProfile
            // 
            grp_InfoProfile.BackColor = Color.White;
            grp_InfoProfile.Controls.Add(btn_ChangeInfo);
            grp_InfoProfile.Controls.Add(txt_Email);
            grp_InfoProfile.Controls.Add(txt_Birthday);
            grp_InfoProfile.Controls.Add(txt_Password);
            grp_InfoProfile.Controls.Add(txt_YourName);
            grp_InfoProfile.Controls.Add(txt_User);
            grp_InfoProfile.Controls.Add(lbl_Email);
            grp_InfoProfile.Controls.Add(lbl_Birthday);
            grp_InfoProfile.Controls.Add(lbl_Password);
            grp_InfoProfile.Controls.Add(lbl_YourName);
            grp_InfoProfile.Controls.Add(lbl_NameAcc);
            grp_InfoProfile.Font = new Font("Courier New", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            grp_InfoProfile.ForeColor = Color.Black;
            grp_InfoProfile.Location = new Point(5, 3);
            grp_InfoProfile.Name = "grp_InfoProfile";
            grp_InfoProfile.Size = new Size(544, 358);
            grp_InfoProfile.TabIndex = 0;
            grp_InfoProfile.TabStop = false;
            grp_InfoProfile.Text = "Profile";
            // 
            // btn_ChangeInfo
            // 
            btn_ChangeInfo.BackColor = Color.MidnightBlue;
            btn_ChangeInfo.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ChangeInfo.ForeColor = Color.White;
            btn_ChangeInfo.Location = new Point(142, 314);
            btn_ChangeInfo.Name = "btn_ChangeInfo";
            btn_ChangeInfo.Size = new Size(287, 38);
            btn_ChangeInfo.TabIndex = 2;
            btn_ChangeInfo.Text = "Change Information";
            btn_ChangeInfo.UseVisualStyleBackColor = false;
            btn_ChangeInfo.Click += btn_ChangeInfo_Click;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(142, 241);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(376, 24);
            txt_Email.TabIndex = 1;
            // 
            // txt_Birthday
            // 
            txt_Birthday.Location = new Point(142, 189);
            txt_Birthday.Name = "txt_Birthday";
            txt_Birthday.Size = new Size(376, 24);
            txt_Birthday.TabIndex = 1;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(142, 137);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(376, 24);
            txt_Password.TabIndex = 1;
            // 
            // txt_YourName
            // 
            txt_YourName.Location = new Point(142, 87);
            txt_YourName.Name = "txt_YourName";
            txt_YourName.Size = new Size(376, 24);
            txt_YourName.TabIndex = 1;
            // 
            // txt_User
            // 
            txt_User.Location = new Point(142, 41);
            txt_User.Name = "txt_User";
            txt_User.Size = new Size(376, 24);
            txt_User.TabIndex = 1;
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Email.Location = new Point(18, 244);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(62, 17);
            lbl_Email.TabIndex = 0;
            lbl_Email.Text = "Email:";
            // 
            // lbl_Birthday
            // 
            lbl_Birthday.AutoSize = true;
            lbl_Birthday.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Birthday.Location = new Point(18, 192);
            lbl_Birthday.Name = "lbl_Birthday";
            lbl_Birthday.Size = new Size(98, 17);
            lbl_Birthday.TabIndex = 0;
            lbl_Birthday.Text = "Birth day:";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Password.Location = new Point(18, 140);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(89, 17);
            lbl_Password.TabIndex = 0;
            lbl_Password.Text = "Password:";
            // 
            // lbl_YourName
            // 
            lbl_YourName.AutoSize = true;
            lbl_YourName.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_YourName.Location = new Point(18, 90);
            lbl_YourName.Name = "lbl_YourName";
            lbl_YourName.Size = new Size(98, 17);
            lbl_YourName.TabIndex = 0;
            lbl_YourName.Text = "Your name:";
            // 
            // lbl_NameAcc
            // 
            lbl_NameAcc.AutoSize = true;
            lbl_NameAcc.Font = new Font("Courier New", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_NameAcc.Location = new Point(18, 43);
            lbl_NameAcc.Name = "lbl_NameAcc";
            lbl_NameAcc.Size = new Size(98, 17);
            lbl_NameAcc.TabIndex = 0;
            lbl_NameAcc.Text = "User name:";
            // 
            // pan_RightSubViewLog
            // 
            pan_RightSubViewLog.BackColor = Color.Tomato;
            pan_RightSubViewLog.Controls.Add(txt_ViewLog);
            pan_RightSubViewLog.Location = new Point(3, 3);
            pan_RightSubViewLog.Name = "pan_RightSubViewLog";
            pan_RightSubViewLog.Size = new Size(791, 364);
            pan_RightSubViewLog.TabIndex = 0;
            // 
            // txt_ViewLog
            // 
            txt_ViewLog.BackColor = Color.Black;
            txt_ViewLog.Dock = DockStyle.Fill;
            txt_ViewLog.Font = new Font("Courier New", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            txt_ViewLog.ForeColor = Color.Lime;
            txt_ViewLog.Location = new Point(0, 0);
            txt_ViewLog.Name = "txt_ViewLog";
            txt_ViewLog.Size = new Size(791, 364);
            txt_ViewLog.TabIndex = 0;
            txt_ViewLog.Text = "View log...";
            // 
            // pan_RightSubManage
            // 
            pan_RightSubManage.AutoScroll = true;
            pan_RightSubManage.BackColor = Color.Tomato;
            pan_RightSubManage.Controls.Add(pan_TitleManage);
            pan_RightSubManage.Location = new Point(3, 2);
            pan_RightSubManage.Name = "pan_RightSubManage";
            pan_RightSubManage.Size = new Size(791, 365);
            pan_RightSubManage.TabIndex = 0;
            // 
            // pan_TitleManage
            // 
            pan_TitleManage.BackColor = Color.White;
            pan_TitleManage.Controls.Add(lbl_Operation);
            pan_TitleManage.Controls.Add(lbl_StatusManageUser);
            pan_TitleManage.Controls.Add(lbl_JoinDateManageUser);
            pan_TitleManage.Controls.Add(lbl_EmailManageUser);
            pan_TitleManage.Controls.Add(lbl_BirthdayManageUser);
            pan_TitleManage.Controls.Add(lbl_NameManageUser);
            pan_TitleManage.Controls.Add(lbl_IDManageUser);
            pan_TitleManage.Location = new Point(2, 2);
            pan_TitleManage.Name = "pan_TitleManage";
            pan_TitleManage.Size = new Size(1167, 35);
            pan_TitleManage.TabIndex = 0;
            // 
            // lbl_Operation
            // 
            lbl_Operation.BackColor = Color.MidnightBlue;
            lbl_Operation.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Operation.ForeColor = Color.White;
            lbl_Operation.Location = new Point(1022, 2);
            lbl_Operation.Name = "lbl_Operation";
            lbl_Operation.Size = new Size(144, 32);
            lbl_Operation.TabIndex = 0;
            lbl_Operation.Text = "Operation";
            lbl_Operation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StatusManageUser
            // 
            lbl_StatusManageUser.BackColor = Color.MidnightBlue;
            lbl_StatusManageUser.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StatusManageUser.ForeColor = Color.White;
            lbl_StatusManageUser.Location = new Point(872, 2);
            lbl_StatusManageUser.Name = "lbl_StatusManageUser";
            lbl_StatusManageUser.Size = new Size(149, 32);
            lbl_StatusManageUser.TabIndex = 0;
            lbl_StatusManageUser.Text = "Status";
            lbl_StatusManageUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_JoinDateManageUser
            // 
            lbl_JoinDateManageUser.BackColor = Color.MidnightBlue;
            lbl_JoinDateManageUser.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_JoinDateManageUser.ForeColor = Color.White;
            lbl_JoinDateManageUser.Location = new Point(722, 2);
            lbl_JoinDateManageUser.Name = "lbl_JoinDateManageUser";
            lbl_JoinDateManageUser.Size = new Size(149, 32);
            lbl_JoinDateManageUser.TabIndex = 0;
            lbl_JoinDateManageUser.Text = "Join date";
            lbl_JoinDateManageUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_EmailManageUser
            // 
            lbl_EmailManageUser.BackColor = Color.MidnightBlue;
            lbl_EmailManageUser.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_EmailManageUser.ForeColor = Color.White;
            lbl_EmailManageUser.Location = new Point(468, 2);
            lbl_EmailManageUser.Name = "lbl_EmailManageUser";
            lbl_EmailManageUser.Size = new Size(253, 32);
            lbl_EmailManageUser.TabIndex = 0;
            lbl_EmailManageUser.Text = "Email";
            lbl_EmailManageUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_BirthdayManageUser
            // 
            lbl_BirthdayManageUser.BackColor = Color.MidnightBlue;
            lbl_BirthdayManageUser.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_BirthdayManageUser.ForeColor = Color.White;
            lbl_BirthdayManageUser.Location = new Point(315, 2);
            lbl_BirthdayManageUser.Name = "lbl_BirthdayManageUser";
            lbl_BirthdayManageUser.Size = new Size(152, 32);
            lbl_BirthdayManageUser.TabIndex = 0;
            lbl_BirthdayManageUser.Text = "Birthday";
            lbl_BirthdayManageUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_NameManageUser
            // 
            lbl_NameManageUser.BackColor = Color.MidnightBlue;
            lbl_NameManageUser.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_NameManageUser.ForeColor = Color.White;
            lbl_NameManageUser.Location = new Point(122, 2);
            lbl_NameManageUser.Name = "lbl_NameManageUser";
            lbl_NameManageUser.Size = new Size(192, 32);
            lbl_NameManageUser.TabIndex = 0;
            lbl_NameManageUser.Text = "Name";
            lbl_NameManageUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_IDManageUser
            // 
            lbl_IDManageUser.BackColor = Color.MidnightBlue;
            lbl_IDManageUser.Font = new Font("Courier New", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_IDManageUser.ForeColor = Color.White;
            lbl_IDManageUser.Location = new Point(0, 2);
            lbl_IDManageUser.Name = "lbl_IDManageUser";
            lbl_IDManageUser.Size = new Size(121, 32);
            lbl_IDManageUser.TabIndex = 0;
            lbl_IDManageUser.Text = "ID";
            lbl_IDManageUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pan_Top
            // 
            pan_Top.BackColor = Color.White;
            pan_Top.Controls.Add(btn_Minimum);
            pan_Top.Controls.Add(btn_Exit);
            pan_Top.Controls.Add(lbl_Title);
            pan_Top.Dock = DockStyle.Top;
            pan_Top.Location = new Point(0, 0);
            pan_Top.Name = "pan_Top";
            pan_Top.Size = new Size(1000, 30);
            pan_Top.TabIndex = 2;
            // 
            // btn_Minimum
            // 
            btn_Minimum.AutoSize = true;
            btn_Minimum.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Minimum.Location = new Point(955, 8);
            btn_Minimum.Name = "btn_Minimum";
            btn_Minimum.Size = new Size(14, 14);
            btn_Minimum.TabIndex = 0;
            btn_Minimum.Text = "-";
            btn_Minimum.Click += btn_Minimum_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.AutoSize = true;
            btn_Exit.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Exit.Location = new Point(976, 8);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(20, 14);
            btn_Exit.TabIndex = 0;
            btn_Exit.Text = "X";
            btn_Exit.Click += btn_Exit_Click;
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Engravers MT", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lbl_Title.Location = new Point(7, 10);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(239, 14);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "Server Administration";
            // 
            // countTime
            // 
            countTime.Interval = 1000;
            countTime.Tick += countTime_Tick;
            // 
            // timer_Exit
            // 
            timer_Exit.Interval = 10;
            timer_Exit.Tick += timer_Exit_Tick;
            // 
            // timer_Hidden
            // 
            timer_Hidden.Interval = 10;
            timer_Hidden.Tick += timer_Hidden_Tick;
            // 
            // ServerUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 400);
            Controls.Add(pan_Top);
            Controls.Add(pan_Right);
            Controls.Add(pan_Left);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ServerUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServerUI";
            pan_Left.ResumeLayout(false);
            pan_Logout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Logout).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Logo).EndInit();
            pan_ViewLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_ViewLog).EndInit();
            pan_ManageUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_ManageUser).EndInit();
            pan_Dashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Dashboard).EndInit();
            pan_Profile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_Profile).EndInit();
            pan_ServerTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_ServerTitle).EndInit();
            pan_RightSubDashboard.ResumeLayout(false);
            grp_Chart.ResumeLayout(false);
            grp_Chart.PerformLayout();
            grp_Status.ResumeLayout(false);
            grp_Status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Status).EndInit();
            pan_RightSubProfile.ResumeLayout(false);
            grp_YourPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_YourPicture).EndInit();
            grp_InfoProfile.ResumeLayout(false);
            grp_InfoProfile.PerformLayout();
            pan_RightSubViewLog.ResumeLayout(false);
            pan_RightSubManage.ResumeLayout(false);
            pan_TitleManage.ResumeLayout(false);
            pan_Top.ResumeLayout(false);
            pan_Top.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pan_Left;
        private Panel pan_Right;
        private Panel pan_Top;
        private Label lbl_Title;
        private Label btn_Minimum;
        private Label btn_Exit;
        private Panel pan_ServerTitle;
        private PictureBox pic_ServerTitle;
        private Label lbl_ServerTitle;
        private Panel pan_RightSubProfile;
        private Panel pan_Profile;
        private Label lbl_Profile;
        private PictureBox pic_Profile;
        private Panel pan_Dashboard;
        private Label lbl_Dashboard;
        private PictureBox pic_Dashboard;
        private Panel pan_ManageUser;
        private Label lbl_ManageUser;
        private PictureBox pic_ManageUser;
        private Panel pan_ViewLog;
        private Label lbl_ViewLog;
        private PictureBox pic_ViewLog;
        private Panel pan_Logout;
        private Label lbl_Logout;
        private PictureBox pic_Logout;
        private PictureBox pic_Logo;
        private GroupBox grp_InfoProfile;
        private TextBox txt_Email;
        private TextBox txt_Birthday;
        private TextBox txt_Password;
        private TextBox txt_YourName;
        private TextBox txt_User;
        private Label lbl_Email;
        private Label lbl_Birthday;
        private Label lbl_Password;
        private Label lbl_YourName;
        private Label lbl_NameAcc;
        private Button btn_ChangeInfo;
        private GroupBox grp_YourPicture;
        private Button btn_ChangeYourPicture;
        private PictureBox pic_YourPicture;
        private Panel pan_RightSubDashboard;
        private GroupBox grp_Status;
        private GroupBox grp_Chart;
        private Panel pan_Chart;
        private Button btn_Active;
        private PictureBox pic_Status;
        private Label lbl_Time;
        private Label lbl_HostConnected;
        private Label lbl_MaximumHosts;
        private Label lbl_Status;
        private Label lbl_TimeTitle;
        private Label lbl_HostConnectedTitle;
        private Label lbl_MaximumHostsTitle;
        private Label lbl_StatusTitle;
        private Label lbl_Free;
        private Label lbl_Used;
        private Panel pan_RightSubManage;
        private Panel pan_TitleManage;
        private Label lbl_NameManageUser;
        private Label lbl_IDManageUser;
        private Label lbl_BirthdayManageUser;
        private Label lbl_EmailManageUser;
        private Label lbl_JoinDateManageUser;
        private Label lbl_Operation;
        private Label lbl_StatusManageUser;
        private Panel pan_RightSubViewLog;
        private RichTextBox txt_ViewLog;
        private System.Windows.Forms.Timer countTime;
        private System.Windows.Forms.Timer timer_Exit;
        private System.Windows.Forms.Timer timer_Hidden;
    }
}