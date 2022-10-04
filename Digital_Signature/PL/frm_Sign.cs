using Digital_Signature.BLL;
using Digital_Signature.DAL;
using Digital_Signature.DTO;
using Digital_Signature.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel.Configuration;
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
                Messbox messBox = new Messbox();
                bool result = messBox.ShowMess();
                if (result == true)
                {
                    string fullName = txtName.Text;
                    string gender = cbGender.Text;
                    string graYear = txtYear.Text;
                    string email = txtEmail.Text;
                    string birthPlace = txtBorn.Text;
                    string phone = txtPhone.Text;
                    string ethic = cbReligion.Text;
                    //Valiate tham số nhập vào
                    string[] infoArr = { fullName, gender, graYear, email, birthPlace, phone, ethic };
                    int count = 0;
                    for (int i = 0; i < infoArr.Length; i++)
                    {
                        if (infoArr[i] != "")
                        {
                            count++;
                        }
                    }
                    string[] infoHex = new string[infoArr.Length];
                    if (count == infoArr.Length)
                    {
                        for (int i = 0; i < infoArr.Length; i++)
                        {
                            string hex = "";
                            foreach (int item in infoArr[i])
                            {
                                hex += item + " ";
                            }
                            infoHex[i] = hex;
                        }
                        //for(int i = 0; i < infoHex.Length; i++)
                        //{
                        //    MessageBox.Show(infoHex[i]);
                        //}
                    }
                    else
                    {
                        bunifuSnackbar1.Show(this, "Vui lòng nhập đủ thông tin", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    //bunifuSnackbar1.Show(this, "Bạn đã ký văn bản thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Không tìm thấy khóa bí mật. Vui lòng thử lại", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                }
                
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

        private void btnCreateSig_Click(object sender, EventArgs e)
        {
            Random rs = new Random();
            //Sinh ngẫu nhiên p, q
            int p = rs.Next(0, 100);
            int q = rs.Next(0, 100);
            if(p != q)
            {
                //Sinh khóa bí mật và khóa công khai
                int publicKey = KeyBLL.createPublicKey(p, q);
                int privateKey = KeyBLL.createPrivateKey(p, q);
                string privateKeyStr = this.EncryptMd5(privateKey.ToString());
                int id = 0;
                List<object> listKey = KeyBLL.getAllKey();
                id = listKey.Count + 1;
                //MessageBox.Show($"Khóa bí mật của bạn là: {privateKey}. Hãy ghi nhớ khóa này");
                bunifuSnackbar1.Show(this, $"Tạo chữ ký thành công. Khóa bí mật của bạn là: {privateKey}. Hãy ghi nhớ khóa này", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                MessageBox.Show($"Khóa công khai: {publicKey}");
                MessageBox.Show($"Khóa bí mật MD5: {privateKeyStr}");
            }
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
    }
}
