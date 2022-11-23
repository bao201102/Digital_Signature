using Digital_Signature.BLL;
using Digital_Signature.DTO;
using Digital_Signature.PL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel.Configuration;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Signature
{
    public partial class frm_Sign : Form
    {
        int user_id;
        DigSig digSig;

        public frm_Sign(int id)
        {
            InitializeComponent();
            lblStatus.Hide();
            user_id = id;
            cbGender.SelectedIndex = 0;
            cbReligion.SelectedIndex = 0;
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

        private void Sign(int eKey)
        {
            Hashtable strInfoList = new Hashtable();
            Hashtable decInfoList = new Hashtable();
            Hashtable cipherInfoList = new Hashtable();

            //Get all control text in panel
            foreach (Control item in infoPanel.Controls)
            {
                if (item.Name.Substring(0, 3) == "txt")
                {
                    var inputItem = (Bunifu.UI.WinForms.BunifuTextBox)item;
                    if (inputItem.Text == "")
                    {
                        bunifuSnackbar1.Show(this, "Vui lòng nhập đủ thông tin", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        break;
                    }
                    else
                    {
                        strInfoList.Add(inputItem.Name, inputItem.Text.ToString());
                    }
                }
                else if (item.Name.Substring(0, 2) == "cb")
                {
                    var inputItem = (Bunifu.UI.WinForms.BunifuDropdown)item;
                    strInfoList.Add(inputItem.Name, inputItem.Text.ToString());
                }
            }

            //Convert string info list to decimal info list
            foreach (DictionaryEntry item in strInfoList)
            {
                string dec = "";
                for (int i = 0; i < item.Value.ToString().Length; i++)
                {
                    if (i < item.Value.ToString().Length - 1)
                    {
                        dec += (int)item.Value.ToString()[i] + " ";
                    }
                    else if (i == item.Value.ToString().Length - 1)
                    {
                        dec += (int)item.Value.ToString()[i];
                    }
                }
                decInfoList.Add(item.Key, dec);
            }

            //Sign the document
            foreach (DictionaryEntry item in decInfoList)
            {
                cipherInfoList.Add(item.Key, digSig.Sign(item.Value.ToString().Split(' '), eKey, KeyBLL.getKeyByUserId(user_id).n));
            }

            StudentPlainDTO studentPlain = new StudentPlainDTO(0, strInfoList["txtName"].ToString(), strInfoList["cbGender"].ToString(), dateBirth.Value, strInfoList["txtYear"].ToString(), strInfoList["txtEmail"].ToString(), strInfoList["txtBorn"].ToString(), strInfoList["txtPhone"].ToString(), strInfoList["cbReligion"].ToString(), user_id, 1);
            bool resultAddPlain = StudentPlainBLL.addNewStudent(studentPlain);

            StudentCipherDTO studentCipher = new StudentCipherDTO(0, cipherInfoList["txtName"].ToString(), cipherInfoList["cbGender"].ToString(), dateBirth.Value, cipherInfoList["txtYear"].ToString(), cipherInfoList["txtEmail"].ToString(), cipherInfoList["txtBorn"].ToString(), cipherInfoList["txtPhone"].ToString(), cipherInfoList["cbReligion"].ToString(), user_id, 1);
            bool resultAddCipher = StudentCipherBLL.addNewStudent(studentCipher);

            if (resultAddCipher == true && resultAddPlain == true)
            {
                bunifuSnackbar1.Show(this, "Bạn đã ký văn bản thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            }
            else
            {
                bunifuSnackbar1.Show(this, "Có lỗi xảy ra", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
        }

        private void frm_Sign_Load(object sender, EventArgs e)
        {
            StudentPlainDTO student = StudentPlainBLL.getStudentSigned(user_id);
            if (student != null)
            {
                txtName.Text = student.name;
                cbGender.Text = student.sex;
                dateBirth.Value = student.birthday;
                txtYear.Text = student.graduation_year;
                txtEmail.Text = student.email;
                txtBorn.Text = student.place_of_birth;
                txtPhone.Text = student.phone;
                cbReligion.Text = student.religion;
                txtName.Enabled = false;
                cbGender.Enabled = false;
                dateBirth.Enabled = false;
                txtYear.Enabled = false;
                txtEmail.Enabled = false;
                txtBorn.Enabled = false;
                txtPhone.Enabled = false;
                cbReligion.Enabled = false;
                lblStatus.Show();
            }
            digSig = new DigSig();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            StudentPlainDTO student = StudentPlainBLL.getStudentSigned(user_id);
            if (student == null)
            {
                if (KeyBLL.getKeyUser(user_id) < 0)
                {
                    bunifuSnackbar1.Show(this, "Vui lòng tạo khóa trước khi kí!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                }
                else
                {
                    string privateKeyMD5 = EncryptMd5(txtPrivateKey.Text.ToString());

                    if (privateKeyMD5 == KeyBLL.getKeyByUserId(user_id).private_key)
                    {
                        Sign(int.Parse(txtPrivateKey.Text.ToString()));
                    }
                    else
                    {
                        bunifuSnackbar1.Show(this, "Khóa bí mật không đúng. Vui lòng thử lại!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                }
            }
            else
            {
                bunifuSnackbar1.Show(this, "Bạn đã thực hiện ký văn bản từ trước!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
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
            if (KeyBLL.getKeyUser(user_id) > -1)
            {
                bunifuSnackbar1.Show(this, "Bạn đã có khóa", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                digSig.GenerateKey();

                string privateKeyMD5 = EncryptMd5(digSig.DKey.ToString());

                KeyDTO newKey = new KeyDTO(0, privateKeyMD5, digSig.EKey, digSig.N, user_id);
                bool resultAdd = KeyBLL.addNewKey(newKey);

                bool resultAddSignUser = UserBLL.AddSignUser(user_id, KeyBLL.getKeyByUserId(user_id).sig_id);

                if (resultAdd == true && resultAddSignUser == true)
                {
                    bunifuSnackbar1.Show(this, $"Tạo chữ ký thành công. Khóa bí mật của bạn là: {digSig.DKey}. Hãy ghi nhớ khóa này", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Có lỗi xảy ra", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                }
            }
        }
    }
}
