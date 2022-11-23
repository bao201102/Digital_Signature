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
        public frm_Verify()
        {
            InitializeComponent();
        }

        private void frm_Verify_Load(object sender, EventArgs e)
        {
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
                else
                {
                    item.Cells[11].Value = "Đã xác thực";
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (true)
            {
                bunifuSnackbar1.Show(this, "Bạn đã xác thực văn bản thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
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
