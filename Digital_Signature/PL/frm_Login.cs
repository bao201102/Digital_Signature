using System;
using System.Security.Cryptography;
using Digital_Signature.BLL;
using Digital_Signature.DTO;
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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin as System.Windows.Forms.IButtonControl;
        }

        private string EncryptMd5(string plainText)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(plainText);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                bunifuSnackbar1.Show(this, "Vui lòng nhập tài khoản và mật khẩu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                UserDTO user = UserBLL.GetUser(txtUsername.Text, EncryptMd5(txtPassword.Text));
                if (user != null)
                {
                    UserTypeDTO userType = UserTypeBLL.GetUserTypeDTO(user.user_type_id);
                    if (userType.type == "Student")
                    {
                        frm_Sign form = new frm_Sign();
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                    else if (userType.type == "Admin")
                    {
                        frm_Verify form = new frm_Verify();
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Sai tên hoặc mật khẩu vui lòng thử lại", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                }
            }
        }

        private void btnHidepass_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
