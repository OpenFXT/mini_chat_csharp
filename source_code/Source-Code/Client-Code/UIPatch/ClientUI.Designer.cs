namespace Client_Code.UIPatch
{
    partial class ClientUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientUI));
            pan_Main = new Panel();
            pan_RightMain = new Panel();
            pan_SendMessageBox = new Panel();
            txt_InputMessage = new TextBox();
            btn_Send = new PictureBox();
            btn_AttachFile = new PictureBox();
            pan_ChatContent = new Panel();
            pan_TitleBoxChat = new Panel();
            btn_RemoveChat = new PictureBox();
            btn_Active = new PictureBox();
            btn_CallVoice = new PictureBox();
            btn_Ring = new PictureBox();
            lbl_NameFriendBox = new Label();
            pic_Friend = new Panel();
            pan_Search = new Panel();
            txt_Search = new TextBox();
            pic_SearchIcon = new PictureBox();
            pan_Setting = new Panel();
            label1 = new Label();
            btn_Setting = new PictureBox();
            btn_AddIcoon = new PictureBox();
            pan_Top = new Panel();
            btn_Minimum = new Label();
            btn_Exit = new Label();
            lbl_ID = new Label();
            pan_LeftMain = new Panel();
            pic_Logo = new PictureBox();
            pan_friend = new Panel();
            pic_newmessage = new PictureBox();
            lbl_namemyfriend = new Label();
            pic_myfriend = new PictureBox();
            pan_content = new Panel();
            lbl_timesend = new Label();
            pic_imageoffriend = new PictureBox();
            lbl_message = new Label();
            lbl_nameoffriend = new Label();
            timer_Hidden = new System.Windows.Forms.Timer(components);
            timer_Exit = new System.Windows.Forms.Timer(components);
            pan_Main.SuspendLayout();
            pan_RightMain.SuspendLayout();
            pan_SendMessageBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Send).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_AttachFile).BeginInit();
            pan_TitleBoxChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_RemoveChat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Active).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_CallVoice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_Ring).BeginInit();
            pan_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_SearchIcon).BeginInit();
            pan_Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Setting).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_AddIcoon).BeginInit();
            pan_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo).BeginInit();
            pan_friend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_newmessage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_myfriend).BeginInit();
            pan_content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_imageoffriend).BeginInit();
            SuspendLayout();
            // 
            // pan_Main
            // 
            pan_Main.BackColor = Color.White;
            pan_Main.BackgroundImage = (Image)resources.GetObject("pan_Main.BackgroundImage");
            pan_Main.BackgroundImageLayout = ImageLayout.Stretch;
            pan_Main.Controls.Add(pic_Logo);
            pan_Main.Controls.Add(pan_Search);
            pan_Main.Controls.Add(pan_Setting);
            pan_Main.Controls.Add(pan_Top);
            pan_Main.Controls.Add(pan_LeftMain);
            pan_Main.Dock = DockStyle.Fill;
            pan_Main.Location = new Point(0, 0);
            pan_Main.Name = "pan_Main";
            pan_Main.Size = new Size(906, 530);
            pan_Main.TabIndex = 0;
            // 
            // pan_RightMain
            // 
            pan_RightMain.BackColor = Color.Transparent;
            pan_RightMain.Controls.Add(pan_SendMessageBox);
            pan_RightMain.Controls.Add(pan_ChatContent);
            pan_RightMain.Controls.Add(pan_TitleBoxChat);
            pan_RightMain.Location = new Point(245, 24);
            pan_RightMain.Name = "pan_RightMain";
            pan_RightMain.Size = new Size(656, 506);
            pan_RightMain.TabIndex = 2;
            // 
            // pan_SendMessageBox
            // 
            pan_SendMessageBox.Controls.Add(txt_InputMessage);
            pan_SendMessageBox.Controls.Add(btn_Send);
            pan_SendMessageBox.Controls.Add(btn_AttachFile);
            pan_SendMessageBox.Dock = DockStyle.Bottom;
            pan_SendMessageBox.Location = new Point(0, 470);
            pan_SendMessageBox.Name = "pan_SendMessageBox";
            pan_SendMessageBox.Size = new Size(656, 36);
            pan_SendMessageBox.TabIndex = 0;
            // 
            // txt_InputMessage
            // 
            txt_InputMessage.BackColor = Color.Black;
            txt_InputMessage.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_InputMessage.ForeColor = Color.White;
            txt_InputMessage.Location = new Point(38, 7);
            txt_InputMessage.Name = "txt_InputMessage";
            txt_InputMessage.Size = new Size(586, 22);
            txt_InputMessage.TabIndex = 2;
            txt_InputMessage.Text = "Message input here...";
            // 
            // btn_Send
            // 
            btn_Send.Image = (Image)resources.GetObject("btn_Send.Image");
            btn_Send.Location = new Point(631, 9);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(20, 20);
            btn_Send.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Send.TabIndex = 0;
            btn_Send.TabStop = false;
            btn_Send.Click += btn_Send_Click;
            // 
            // btn_AttachFile
            // 
            btn_AttachFile.Image = (Image)resources.GetObject("btn_AttachFile.Image");
            btn_AttachFile.Location = new Point(12, 8);
            btn_AttachFile.Name = "btn_AttachFile";
            btn_AttachFile.Size = new Size(20, 20);
            btn_AttachFile.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_AttachFile.TabIndex = 0;
            btn_AttachFile.TabStop = false;
            btn_AttachFile.Click += btn_AttachFile_Click;
            // 
            // pan_ChatContent
            // 
            pan_ChatContent.AutoScroll = true;
            pan_ChatContent.BackColor = Color.White;
            pan_ChatContent.Location = new Point(0, 41);
            pan_ChatContent.Name = "pan_ChatContent";
            pan_ChatContent.Size = new Size(656, 437);
            pan_ChatContent.TabIndex = 1;
            // 
            // pan_TitleBoxChat
            // 
            pan_TitleBoxChat.BackColor = Color.Black;
            pan_TitleBoxChat.Controls.Add(btn_RemoveChat);
            pan_TitleBoxChat.Controls.Add(btn_Active);
            pan_TitleBoxChat.Controls.Add(btn_CallVoice);
            pan_TitleBoxChat.Controls.Add(btn_Ring);
            pan_TitleBoxChat.Controls.Add(lbl_NameFriendBox);
            pan_TitleBoxChat.Controls.Add(pic_Friend);
            pan_TitleBoxChat.Dock = DockStyle.Top;
            pan_TitleBoxChat.Location = new Point(0, 0);
            pan_TitleBoxChat.Name = "pan_TitleBoxChat";
            pan_TitleBoxChat.Size = new Size(656, 46);
            pan_TitleBoxChat.TabIndex = 0;
            // 
            // btn_RemoveChat
            // 
            btn_RemoveChat.Image = (Image)resources.GetObject("btn_RemoveChat.Image");
            btn_RemoveChat.Location = new Point(630, 6);
            btn_RemoveChat.Name = "btn_RemoveChat";
            btn_RemoveChat.Size = new Size(20, 20);
            btn_RemoveChat.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_RemoveChat.TabIndex = 2;
            btn_RemoveChat.TabStop = false;
            btn_RemoveChat.Click += btn_RemoveChat_Click;
            // 
            // btn_Active
            // 
            btn_Active.Image = (Image)resources.GetObject("btn_Active.Image");
            btn_Active.Location = new Point(552, 7);
            btn_Active.Name = "btn_Active";
            btn_Active.Size = new Size(20, 20);
            btn_Active.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Active.TabIndex = 2;
            btn_Active.TabStop = false;
            // 
            // btn_CallVoice
            // 
            btn_CallVoice.Image = (Image)resources.GetObject("btn_CallVoice.Image");
            btn_CallVoice.Location = new Point(578, 7);
            btn_CallVoice.Name = "btn_CallVoice";
            btn_CallVoice.Size = new Size(20, 20);
            btn_CallVoice.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_CallVoice.TabIndex = 2;
            btn_CallVoice.TabStop = false;
            btn_CallVoice.Click += CallVoiceStream;
            // 
            // btn_Ring
            // 
            btn_Ring.Image = (Image)resources.GetObject("btn_Ring.Image");
            btn_Ring.Location = new Point(604, 7);
            btn_Ring.Name = "btn_Ring";
            btn_Ring.Size = new Size(20, 20);
            btn_Ring.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Ring.TabIndex = 2;
            btn_Ring.TabStop = false;
            btn_Ring.Click += btn_Ring_Click;
            // 
            // lbl_NameFriendBox
            // 
            lbl_NameFriendBox.AutoSize = true;
            lbl_NameFriendBox.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_NameFriendBox.ForeColor = Color.White;
            lbl_NameFriendBox.Location = new Point(48, 11);
            lbl_NameFriendBox.Name = "lbl_NameFriendBox";
            lbl_NameFriendBox.Size = new Size(93, 17);
            lbl_NameFriendBox.TabIndex = 1;
            lbl_NameFriendBox.Text = "Name Friend";
            // 
            // pic_Friend
            // 
            pic_Friend.BackColor = Color.White;
            pic_Friend.BackgroundImageLayout = ImageLayout.Stretch;
            pic_Friend.Location = new Point(10, 7);
            pic_Friend.Name = "pic_Friend";
            pic_Friend.Size = new Size(31, 26);
            pic_Friend.TabIndex = 0;
            // 
            // pan_Search
            // 
            pan_Search.BackColor = Color.Black;
            pan_Search.Controls.Add(txt_Search);
            pan_Search.Controls.Add(pic_SearchIcon);
            pan_Search.Location = new Point(0, 24);
            pan_Search.Name = "pan_Search";
            pan_Search.Size = new Size(245, 35);
            pan_Search.TabIndex = 0;
            // 
            // txt_Search
            // 
            txt_Search.BackColor = Color.Black;
            txt_Search.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txt_Search.ForeColor = Color.White;
            txt_Search.Location = new Point(31, 6);
            txt_Search.Name = "txt_Search";
            txt_Search.Size = new Size(207, 22);
            txt_Search.TabIndex = 1;
            // 
            // pic_SearchIcon
            // 
            pic_SearchIcon.Image = (Image)resources.GetObject("pic_SearchIcon.Image");
            pic_SearchIcon.Location = new Point(7, 7);
            pic_SearchIcon.Name = "pic_SearchIcon";
            pic_SearchIcon.Size = new Size(18, 18);
            pic_SearchIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_SearchIcon.TabIndex = 0;
            pic_SearchIcon.TabStop = false;
            pic_SearchIcon.Click += pic_SearchIcon_Click;
            // 
            // pan_Setting
            // 
            pan_Setting.BackColor = Color.Black;
            pan_Setting.Controls.Add(label1);
            pan_Setting.Controls.Add(btn_Setting);
            pan_Setting.Controls.Add(btn_AddIcoon);
            pan_Setting.Location = new Point(0, 487);
            pan_Setting.Name = "pan_Setting";
            pan_Setting.Size = new Size(245, 43);
            pan_Setting.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 6F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(66, 24);
            label1.Name = "label1";
            label1.Size = new Size(116, 11);
            label1.TabIndex = 1;
            label1.Text = "ClientUI by FXTStrix2202";
            // 
            // btn_Setting
            // 
            btn_Setting.Image = (Image)resources.GetObject("btn_Setting.Image");
            btn_Setting.Location = new Point(205, 6);
            btn_Setting.Name = "btn_Setting";
            btn_Setting.Size = new Size(32, 33);
            btn_Setting.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_Setting.TabIndex = 0;
            btn_Setting.TabStop = false;
            btn_Setting.Click += btn_Setting_Click;
            // 
            // btn_AddIcoon
            // 
            btn_AddIcoon.Image = (Image)resources.GetObject("btn_AddIcoon.Image");
            btn_AddIcoon.Location = new Point(7, 4);
            btn_AddIcoon.Name = "btn_AddIcoon";
            btn_AddIcoon.Size = new Size(38, 36);
            btn_AddIcoon.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_AddIcoon.TabIndex = 0;
            btn_AddIcoon.TabStop = false;
            btn_AddIcoon.Click += btn_AddIcoon_Click;
            // 
            // pan_Top
            // 
            pan_Top.BorderStyle = BorderStyle.FixedSingle;
            pan_Top.Controls.Add(btn_Minimum);
            pan_Top.Controls.Add(btn_Exit);
            pan_Top.Controls.Add(lbl_ID);
            pan_Top.Dock = DockStyle.Top;
            pan_Top.Location = new Point(0, 0);
            pan_Top.Name = "pan_Top";
            pan_Top.Size = new Size(906, 24);
            pan_Top.TabIndex = 1;
            // 
            // btn_Minimum
            // 
            btn_Minimum.AutoSize = true;
            btn_Minimum.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Minimum.Location = new Point(860, 4);
            btn_Minimum.Name = "btn_Minimum";
            btn_Minimum.Size = new Size(14, 14);
            btn_Minimum.TabIndex = 1;
            btn_Minimum.Text = "-";
            btn_Minimum.Click += btn_Minimum_Click;
            // 
            // btn_Exit
            // 
            btn_Exit.AutoSize = true;
            btn_Exit.Font = new Font("Engravers MT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Exit.Location = new Point(881, 4);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(20, 14);
            btn_Exit.TabIndex = 2;
            btn_Exit.Text = "X";
            btn_Exit.Click += btn_Exit_Click;
            // 
            // lbl_ID
            // 
            lbl_ID.AutoSize = true;
            lbl_ID.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ID.Location = new Point(3, 4);
            lbl_ID.Name = "lbl_ID";
            lbl_ID.Size = new Size(57, 15);
            lbl_ID.TabIndex = 0;
            lbl_ID.Text = "#YourID";
            // 
            // pan_LeftMain
            // 
            pan_LeftMain.AutoScroll = true;
            pan_LeftMain.BackColor = Color.Black;
            pan_LeftMain.BackgroundImage = (Image)resources.GetObject("pan_LeftMain.BackgroundImage");
            pan_LeftMain.BackgroundImageLayout = ImageLayout.Stretch;
            pan_LeftMain.Location = new Point(0, 57);
            pan_LeftMain.Name = "pan_LeftMain";
            pan_LeftMain.Size = new Size(245, 431);
            pan_LeftMain.TabIndex = 0;
            // 
            // pic_Logo
            // 
            pic_Logo.BackColor = Color.Transparent;
            pic_Logo.Dock = DockStyle.Right;
            pic_Logo.Image = (Image)resources.GetObject("pic_Logo.Image");
            pic_Logo.Location = new Point(244, 24);
            pic_Logo.Name = "pic_Logo";
            pic_Logo.Size = new Size(662, 506);
            pic_Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Logo.TabIndex = 4;
            pic_Logo.TabStop = false;
            // 
            // pan_friend
            // 
            pan_friend.Controls.Add(pic_newmessage);
            pan_friend.Controls.Add(lbl_namemyfriend);
            pan_friend.Controls.Add(pic_myfriend);
            pan_friend.Location = new Point(0, 3);
            pan_friend.Name = "pan_friend";
            pan_friend.Size = new Size(245, 40);
            pan_friend.TabIndex = 0;
            // 
            // pic_newmessage
            // 
            pic_newmessage.Location = new Point(208, 8);
            pic_newmessage.Name = "pic_newmessage";
            pic_newmessage.Size = new Size(25, 25);
            pic_newmessage.TabIndex = 2;
            pic_newmessage.TabStop = false;
            // 
            // lbl_namemyfriend
            // 
            lbl_namemyfriend.AutoSize = true;
            lbl_namemyfriend.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_namemyfriend.ForeColor = Color.White;
            lbl_namemyfriend.Location = new Point(50, 12);
            lbl_namemyfriend.Name = "lbl_namemyfriend";
            lbl_namemyfriend.Size = new Size(119, 17);
            lbl_namemyfriend.TabIndex = 1;
            lbl_namemyfriend.Text = "Name My Friend";
            // 
            // pic_myfriend
            // 
            pic_myfriend.BackColor = Color.White;
            pic_myfriend.Location = new Point(13, 6);
            pic_myfriend.Name = "pic_myfriend";
            pic_myfriend.Size = new Size(28, 28);
            pic_myfriend.TabIndex = 0;
            pic_myfriend.TabStop = false;
            // 
            // pan_content
            // 
            pan_content.AutoSize = true;
            pan_content.Controls.Add(lbl_timesend);
            pan_content.Controls.Add(pic_imageoffriend);
            pan_content.Controls.Add(lbl_message);
            pan_content.Controls.Add(lbl_nameoffriend);
            pan_content.Location = new Point(0, 0);
            pan_content.Name = "pan_content";
            pan_content.Size = new Size(656, 48);
            pan_content.TabIndex = 0;
            // 
            // lbl_timesend
            // 
            lbl_timesend.AutoSize = true;
            lbl_timesend.BackColor = Color.Transparent;
            lbl_timesend.ForeColor = Color.White;
            lbl_timesend.Location = new Point(557, 17);
            lbl_timesend.Name = "lbl_timesend";
            lbl_timesend.Size = new Size(34, 15);
            lbl_timesend.TabIndex = 2;
            lbl_timesend.Text = "00:00";
            // 
            // pic_imageoffriend
            // 
            pic_imageoffriend.BackColor = Color.Black;
            pic_imageoffriend.Location = new Point(17, 7);
            pic_imageoffriend.Name = "pic_imageoffriend";
            pic_imageoffriend.Size = new Size(25, 25);
            pic_imageoffriend.TabIndex = 0;
            pic_imageoffriend.TabStop = false;
            // 
            // lbl_message
            // 
            lbl_message.AutoSize = true;
            lbl_message.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_message.ForeColor = Color.Transparent;
            lbl_message.Location = new Point(50, 31);
            lbl_message.Name = "lbl_message";
            lbl_message.Size = new Size(61, 17);
            lbl_message.TabIndex = 1;
            lbl_message.Text = "Message";
            // 
            // lbl_nameoffriend
            // 
            lbl_nameoffriend.AutoSize = true;
            lbl_nameoffriend.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nameoffriend.ForeColor = Color.Transparent;
            lbl_nameoffriend.Location = new Point(46, 12);
            lbl_nameoffriend.Name = "lbl_nameoffriend";
            lbl_nameoffriend.Size = new Size(84, 15);
            lbl_nameoffriend.TabIndex = 1;
            lbl_nameoffriend.Text = "Name friend";
            // 
            // timer_Hidden
            // 
            timer_Hidden.Interval = 10;
            timer_Hidden.Tick += timer_Hidden_Tick;
            // 
            // timer_Exit
            // 
            timer_Exit.Interval = 10;
            timer_Exit.Tick += timer_Exit_Tick;
            // 
            // ClientUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 530);
            Controls.Add(pan_Main);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClientUI";
            FormClosing += ClientUI_FormClosing;
            pan_Main.ResumeLayout(false);
            pan_RightMain.ResumeLayout(false);
            pan_SendMessageBox.ResumeLayout(false);
            pan_SendMessageBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Send).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_AttachFile).EndInit();
            pan_TitleBoxChat.ResumeLayout(false);
            pan_TitleBoxChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_RemoveChat).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Active).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_CallVoice).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_Ring).EndInit();
            pan_Search.ResumeLayout(false);
            pan_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_SearchIcon).EndInit();
            pan_Setting.ResumeLayout(false);
            pan_Setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_Setting).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_AddIcoon).EndInit();
            pan_Top.ResumeLayout(false);
            pan_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_Logo).EndInit();
            pan_friend.ResumeLayout(false);
            pan_friend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_newmessage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_myfriend).EndInit();
            pan_content.ResumeLayout(false);
            pan_content.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_imageoffriend).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pan_Main;
        private Panel pan_Top;
        private Label lbl_ID;
        private Label btn_Minimum;
        private Label btn_Exit;
        private Panel pan_RightMain;
        private Panel pan_LeftMain;
        private Panel pan_Search;
        private TextBox txt_Search;
        private PictureBox pic_SearchIcon;
        private Panel pan_TitleBoxChat;
        private Label lbl_NameFriendBox;
        private Panel pic_Friend;
        private PictureBox btn_RemoveChat;
        private PictureBox btn_CallVoice;
        private PictureBox btn_Ring;
        private Panel pan_ChatContent;
        private Panel pan_content;
        private PictureBox pic_imageoffriend;
        private Label lbl_message;
        private Label lbl_nameoffriend;
        private Label lbl_timesend;
        private Panel pan_SendMessageBox;
        private Panel pan_Setting;
        private PictureBox btn_AttachFile;
        private TextBox txt_InputMessage;
        private PictureBox btn_Send;
        private PictureBox btn_Setting;
        private PictureBox btn_AddIcoon;
        private Label label1;
        private Panel pan_friend;
        private PictureBox pic_newmessage;
        private Label lbl_namemyfriend;
        private PictureBox pic_myfriend;
        private System.Windows.Forms.Timer timer_Hidden;
        private System.Windows.Forms.Timer timer_Exit;
        private PictureBox pic_Logo;
        private PictureBox btn_Active;
    }
}