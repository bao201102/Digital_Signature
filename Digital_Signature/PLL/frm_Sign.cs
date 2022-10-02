using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Signature
{
    public partial class frm_Sign : Form
    {
        public frm_Sign()
        {
            InitializeComponent();
        }

        private void frm_Sign_Load(object sender, EventArgs e)
        {
            if (true)
            {
                bunifuSnackbar1.Show(this, "Bạn đã tạo chữ ký thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (true)
            {
                bunifuSnackbar1.Show(this, "Bạn đã ký văn bản thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
