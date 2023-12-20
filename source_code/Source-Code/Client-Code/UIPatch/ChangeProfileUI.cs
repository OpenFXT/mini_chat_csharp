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
    public partial class ChangeProfileUI : Form
    {
        public ChangeProfileUI()
        {
            InitializeComponent();
        }

        public string name, password, pathPicture = "", birthday, email;
        public bool change = false;

        private void ChangeProfileUI_Load(object sender, EventArgs e)
        {
            txt_Email.Text = email;
            txt_Birthday.Text = birthday;
            txt_Name.Text = name;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            change = true;
            if (txt_Password.Text[0] != '*')
            {
                password = txt_Password.Text;
            }
            birthday = txt_Birthday.Text;
            name = txt_Name.Text;
            this.Close();
        }

        private void ChangeProfileUI_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btn_Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg";
            openFileDialog.Title = "Chọn tệp tin JPG";
            openFileDialog.ShowDialog();
            pathPicture = openFileDialog.FileName;
        }
    }
}
