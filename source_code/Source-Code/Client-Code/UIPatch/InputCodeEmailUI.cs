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
    public partial class InputCodeEmailUI : Form
    {
        public InputCodeEmailUI()
        {
            InitializeComponent();
        }

        public string code = "";
        public string emailAddress;

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            code = txt_InputCode.Text;
            this.Close();
        }

        private void CodeEmailInputUI_Load(object sender, EventArgs e)
        {
            lbl_Title.Text = "Enter the verification code sent to the email " + emailAddress + ":";
        }
    }
}
