using Bunifu.UI.WinForms;
using Digital_Signature.BLL;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Digital_Signature.PL
{
    public partial class Messbox : Form
    {
        bool result;
        public Messbox()
        {
            InitializeComponent();
        }

        public bool ShowMess()
        {
            this.ShowDialog();
            return result;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string privateKey = txtPrivateKey.Text;
            string privateKeyMD5 = EncryptMd5(privateKey);
            List<object> listKey = KeyBLL.getAllKey();
            for(int i = 0; i < listKey.Count; i++)
            {
                KeyDTO key = (KeyDTO)listKey[i];
                if(key.private_key == privateKeyMD5)
                {
                    result = true;
                    this.Close();
                    break;
                }else
                {
                    result = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
