using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_Code.UIPatch
{
    public partial class CodeEmailInputUI : Form
    {
        public CodeEmailInputUI()
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
            lbl_Title.Text = "Nhập mã xác thực được gửi tới email " + emailAddress + ":";
        }
    }
}
