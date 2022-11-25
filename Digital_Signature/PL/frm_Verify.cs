using System;
using Digital_Signature.BLL;
using Digital_Signature.DTO;
using Digital_Signature.PL;
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
    public partial class frm_Verify : Form
    {
        DigSig digSig;

        public frm_Verify()
        {
            InitializeComponent();
        }

        private void LoadDgv()
        {
            dgvStuList.Columns.Clear();
            List<StudentPlainDTO> stuList = StudentPlainBLL.getStudentAllSigned();
            dgvStuList.DataSource = stuList;

            dgvStuList.Columns[0].Visible = false;
            dgvStuList.Columns[1].HeaderText = "Họ tên";
            dgvStuList.Columns[2].HeaderText = "Giới tính";
            dgvStuList.Columns[3].HeaderText = "Ngày sinh";
            dgvStuList.Columns[4].HeaderText = "Năm tốt nghiệp";
            dgvStuList.Columns[5].HeaderText = "Email";
            dgvStuList.Columns[6].HeaderText = "Nơi sinh";
            dgvStuList.Columns[7].HeaderText = "SĐT";
            dgvStuList.Columns[8].HeaderText = "Tôn giáo";
            dgvStuList.Columns[9].Visible = false;
            dgvStuList.Columns[10].Visible = false;
            dgvStuList.Columns.Add("Column", "Trạng thái");



            foreach (DataGridViewRow item in dgvStuList.Rows)
            {
                if (item.Cells[10].Value.ToString() == "1")
                {
                    item.Cells[11].Value = "Chưa xác thực";
                }
                else if (item.Cells[10].Value.ToString() == "2")
                {
                    item.Cells[11].Value = "Đã xác thực";
                }
            }
        }

        private bool Verify(string[] stuPlain, string[] cipher, int dKey, int n)
        {
            for (int i = 0; i < stuPlain.Length; i++)
            {
                //Verify one of many field
                string result = digSig.Verify(cipher[i].Split(' '), dKey, n);

                //Turn verified number to string
                string verified_text = "";
                foreach (string subItem in result.Split(' '))
                {
                    verified_text += (char)int.Parse(subItem);
                }

                //Check if verified text is not equal plain text
                if (verified_text != stuPlain[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void frm_Verify_Load(object sender, EventArgs e)
        {
            LoadDgv();
            digSig = new DigSig();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            int status = int.Parse(dgvStuList.SelectedRows[0].Cells[10].Value.ToString());
            if (status == 1)
            {
                int user_id = int.Parse(dgvStuList.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show(user_id.ToString());
                StudentPlainDTO stuPlain = StudentPlainBLL.getStudentSigned(user_id);
                StudentCipherDTO stuCipher = StudentCipherBLL.getStudentsSigned(user_id);
                KeyDTO key = KeyBLL.getKeyByUserId(user_id);

                bool result = Verify(stuPlain.ToString().Split(','), stuCipher.ToString().Split(','), key.public_key, key.n);
                if (result)
                {
                    stuPlain.status = 2;
                    StudentPlainBLL.updateStuStatus(stuPlain);
                    LoadDgv();
                    bunifuSnackbar1.Show(this, "Bạn đã xác thực thông tin sinh viên thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Xác thực thất bại", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
            }
            else
            {
                bunifuSnackbar1.Show(this, "Thông tin sinh viên này đã được xác thực", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information);
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
