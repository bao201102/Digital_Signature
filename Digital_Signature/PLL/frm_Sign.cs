using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                string fullName = txtName.Text;
                string gender = cbGender.Text;
                string graYear = txtYear.Text;
                string email = txtEmail.Text;
                string birthPlace = txtBorn.Text;
                string phone = txtPhone.Text;
                string ethic = cbReligion.Text;

                string[] infoArr = { fullName, gender, graYear, email, birthPlace, phone, ethic };
                int count = 0;
                for(int i = 0; i < infoArr.Length; i++)
                {
                    if (infoArr[i] != "")
                    {
                        count++;
                    }
                }
                string[] infoHex = new string[infoArr.Length];
                if(count == infoArr.Length)
                {
                    for (int i = 0; i < infoArr.Length; i++)
                    {
                        string hex = "";
                        foreach(int item in infoArr[i])
                        {
                            hex += item + " ";
                        }
                        infoHex[i] = hex;
                    }
                    for(int i = 0; i < infoHex.Length; i++)
                    {
                        MessageBox.Show(infoHex[i]);
                    }
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Vui lòng nhập đủ thông tin", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                }

                //bunifuSnackbar1.Show(this, "Bạn đã ký văn bản thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
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
