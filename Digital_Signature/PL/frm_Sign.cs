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
            Random rd = new Random();
            int p = 0;
            int q = 0;
            //Sinh ngẫu nhiên p, q thuoc so nguyen to
            do
            {
                p = rd.Next(0, 99);
            } while (!CheckPrimeNum(p));

            do
            {
                q = rd.Next(0, 99);
            } while (!CheckPrimeNum(q) || q == p);

            if (p != q)
            {
                //Sinh khóa bí mật và khóa công khai
                int privateKey = createPrivateKey(p, q);
                int publicKey = createPublicKey(p, q);

                MessageBox.Show($"q: {q}. Hãy ghi nhớ khóa này");
                MessageBox.Show($"p: {p}. Hãy ghi nhớ khóa này");
                MessageBox.Show($"Khóa bí mật của bạn là: {privateKey}. Hãy ghi nhớ khóa này");
                bunifuSnackbar1.Show(this, $"Tạo chữ ký thành công. Khóa bí mật của bạn là: {privateKey}. Hãy ghi nhớ khóa này", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                MessageBox.Show($"Khóa công khai: {publicKey}");
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

        private bool CheckPrimeNum(int num)
        {
            int i;
            for (i = 2; i <= num - 1; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            if (i == num)
            {
                return true;
            }
            return false;
        }

        //Hàm tạo khóa bí mật
        private static int createPrivateKey(int p, int q)
        {
            int phi = (p - 1) * (q - 1);
            List<int> ucln = new List<int>();

            int pri = 0;
            for (int i = 2; i < phi; i++)
            {
                if (USCLN(phi, i) == 1)
                {
                    ucln.Add(i);
                }
            }

            Random rd = new Random();
            int temp = rd.Next(0, ucln.Count - 1);
            pri = ucln[temp];
            return pri;
        }

        //Hàm tạo khóa công khai
        private static int createPublicKey(int p, int q)
        {
            // r = pri * x + phi * y
            int phi = (p - 1) * (q - 1);
            int pri = createPrivateKey(p, q);
            List<double> ri = new List<double>() { phi, pri };
            List<double> qi = new List<double>() { 0, 0 };
            List<double> yi = new List<double>() { 1, 0 };
            List<double> xi = new List<double>() { 0, 1 };

            for (int i = 0; ; i++)
            {
                int j = i + 1;

                qi.Add(Math.Floor(ri[i] / ri[j]));
                ri.Add(ri[i] % ri[j]);
                yi.Add(yi[i] - (qi[j + 1] * yi[j]));
                if (ri[j + 1] == 0)
                {
                    break;
                }
            }

            for (int i = 2; i < ri.Count - 1; i++)
            {
                xi.Add((ri[i] - phi * yi[i]) / pri);
            }

            int result = (int)xi[xi.Count - 1];

            if (result < 0)
            {
                result += phi;
            }

            return result;
        }

        private static int USCLN(int a, int b)
        {
            if (b == 0) return a;
            return USCLN(b, a % b);
        }

    }
}
