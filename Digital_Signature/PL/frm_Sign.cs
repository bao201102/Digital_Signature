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
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Signature
{
    public partial class frm_Sign : Form
    {
        int p = 0;
        int q = 0;
        int publicKey = 0;
        string privateKeyMD5 = "";
        int privateKey = 0;
        int n = 0;
        int user_id;
        KeyDTO keyUserCreated = new KeyDTO();
        List<StudentCipherDTO> listStudentSigned = new List<StudentCipherDTO>();
        List<StudentPlainDTO> listStudentPlainSigned = new List<StudentPlainDTO>();
        List<KeyDTO> listKeyUserCreated = new List<KeyDTO>();

        public frm_Sign(int id)
        {
            InitializeComponent();
            //btnSign.Enabled = false;
            //txtName.Enabled = false;
            //cbGender.Enabled = false;
            //dateBirth.Enabled = false;
            //txtYear.Enabled = false;
            //txtEmail.Enabled = false;
            //txtBorn.Enabled = false;
            //txtPhone.Enabled = false;
            //cbReligion.Enabled = false;
            user_id = id;
            listStudentSigned = StudentCipherBLL.getStudentsSigned(id);
            listStudentPlainSigned = StudentPlainBLL.getStudentsSigned(id);
            //listKeyUserCreated = KeyBLL.getKeyUser(id);
        }

        private void frm_Sign_Load(object sender, EventArgs e)
        {
            if (listStudentSigned.Count > 0)
            {
                btnCreateSig.Enabled = false;
                btnSign.Enabled = false;
                gridviewConfirm.DataSource = listStudentPlainSigned;
                gridviewConfirm.Columns[0].Visible = false;
                gridviewConfirm.Columns[1].HeaderText = "Họ và tên";
                gridviewConfirm.Columns[2].HeaderText = "Giới tính";
                gridviewConfirm.Columns[3].HeaderText = "Ngày sinh";
                gridviewConfirm.Columns[4].HeaderText = "Năm tốt nghiệp";
                gridviewConfirm.Columns[5].HeaderText = "Email";
                gridviewConfirm.Columns[6].HeaderText = "Nơi sinh";
                gridviewConfirm.Columns[7].HeaderText = "SDT";
                gridviewConfirm.Columns[8].HeaderText = "Dân tộc";
                gridviewConfirm.Columns[9].Visible = false;
                gridviewConfirm.Columns[10].Visible = false;
                txtName.Text = listStudentPlainSigned[0].name;
                cbGender.Text = listStudentPlainSigned[0].sex;
                dateBirth.Value = listStudentPlainSigned[0].birthday;
                txtYear.Text = listStudentPlainSigned[0].graduation_year;
                txtEmail.Text = listStudentPlainSigned[0].email;
                txtBorn.Text = listStudentPlainSigned[0].place_of_birth;
                txtPhone.Text = listStudentPlainSigned[0].phone;
                cbReligion.Text = listStudentPlainSigned[0].religion;
                txtName.Enabled = false;
                cbGender.Enabled = false;
                dateBirth.Enabled = false;
                txtYear.Enabled = false;
                txtEmail.Enabled = false;
                txtBorn.Enabled = false;
                txtPhone.Enabled = false;
                cbReligion.Enabled = false;
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (KeyBLL.getKeyUser(user_id) == -1)
            {
                bunifuSnackbar1.Show(this, "Vui lòng tạo khóa trước khi kí!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                if (true)
                {
                    Messbox messBox = new Messbox();
                    bool result = messBox.ShowMess();
                    if (result == true)
                    {
                        string fullName = txtName.Text;
                        string gender = cbGender.Text;
                        DateTime birth = dateBirth.Value;
                        string graYear = txtYear.Text;
                        string email = txtEmail.Text;
                        string birthPlace = txtBorn.Text;
                        string phone = txtPhone.Text;
                        string ethic = cbReligion.Text;
                        string[] infoArr = { fullName, gender, birth.ToString(), graYear, email, birthPlace, phone, ethic };
                        //Valiate tham số nhập vào

                        //string[] infoArr1 = infoArr;
                        string[] resultSignArr = new string[infoArr.Length];
                        int count = 0;
                        //Validate thông tin nhập vào
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
                                for (int j = 0; j < infoArr[i].Length; j++)
                                {
                                    if (j < infoArr[i].Length - 1)
                                    {
                                        hex += (int)infoArr[i][j] + " ";
                                    }
                                    else if (j == infoArr[i].Length - 1)
                                    {
                                        hex += (int)infoArr[i][j];
                                    }
                                }
                                infoHex[i] = hex;
                            }
                            for (int i = 0; i < infoHex.Length; i++)
                            {
                                MessageBox.Show("Văn bản trước khi kí: " + infoHex[i]);
                            }
                            for (int i = 0; i < infoHex.Length; i++)
                            {
                                string resultSign = Sign(infoHex[i], p, q, privateKey);
                                resultSignArr[i] = resultSign;
                            }

                            for (int i = 0; i < resultSignArr.Length; i++)
                            {
                                MessageBox.Show("Kết quả kí: " + resultSignArr[i].ToString());
                            }

                            List<object> listStudentCipher = StudentCipherBLL.getAllStudent();
                            int id = listStudentCipher.Count + 1;
                            StudentCipherDTO studentCipher = new StudentCipherDTO(id, resultSignArr[0], resultSignArr[1], birth, resultSignArr[2], resultSignArr[3], resultSignArr[4], resultSignArr[5], resultSignArr[6], user_id, 0);
                            StudentPlainDTO studentPlain = new StudentPlainDTO(id, infoArr[0], infoArr[1], birth, infoArr[2], infoArr[3], infoArr[4], infoArr[5], infoArr[6], user_id, 0);
                            bool resultAdd = StudentCipherBLL.addNewStudent(studentCipher);
                            bool resultAddPlain = StudentPlainBLL.addNewStudent(studentPlain);
                            if (resultAdd == true && resultAddPlain == true)
                            {
                                bunifuSnackbar1.Show(this, "Bạn đã ký văn bản thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                            }
                            else
                            {
                                bunifuSnackbar1.Show(this, "Có lỗi xảy ra", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                            }

                        }
                        else
                        {
                            bunifuSnackbar1.Show(this, "Vui lòng nhập đủ thông tin", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        }
                    }
                    else
                    {
                        bunifuSnackbar1.Show(this, "Không tìm thấy khóa bí mật. Vui lòng thử lại", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
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

            if (KeyBLL.getKeyUser(user_id) > -1)
            {
                bunifuSnackbar1.Show(this, "Vui lòng không tạo khóa 2 lần", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                //Nếu người dùng nhập đầy đủ thông tin => Hiển thị lên Gridview + Tạo khóa
                string fullName = txtName.Text;
                string gender = cbGender.Text;
                DateTime birth = dateBirth.Value;
                string graYear = txtYear.Text;
                string email = txtEmail.Text;
                string birthPlace = txtBorn.Text;
                string phone = txtPhone.Text;
                string ethic = cbReligion.Text;
                string[] infoArr = { fullName, gender, birth.ToString(), graYear, email, birthPlace, phone, ethic };
                int count = 0;
                //Validate thông tin nhập vào
                for (int i = 0; i < infoArr.Length; i++)
                {
                    if (infoArr[i] != "")
                    {
                        count++;
                    }
                }
                if (count == infoArr.Length)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Họ và tên");
                    dataTable.Columns.Add("Giới tính");
                    dataTable.Columns.Add("Ngày sinh");
                    dataTable.Columns.Add("Năm tốt nghiệp");
                    dataTable.Columns.Add("Email");
                    dataTable.Columns.Add("Nơi sinh");
                    dataTable.Columns.Add("SDT");
                    dataTable.Columns.Add("Dân tộc");
                    gridviewConfirm.DataSource = dataTable;
                    dataTable.Rows.Add(txtName.Text, cbGender.Text, birth.ToString(), txtYear.Text, txtEmail.Text, txtBorn.Text, txtPhone.Text, cbReligion.Text);
                    gridviewConfirm.DataSource = dataTable;
                    gridviewConfirm.Columns[0].HeaderText = "Họ và tên";
                    gridviewConfirm.Columns[1].HeaderText = "Giới tính";
                    gridviewConfirm.Columns[2].HeaderText = "Ngày sinh";
                    gridviewConfirm.Columns[3].HeaderText = "Năm tốt nghiệp";
                    gridviewConfirm.Columns[4].HeaderText = "Email";
                    gridviewConfirm.Columns[5].HeaderText = "Nơi sinh";
                    gridviewConfirm.Columns[6].HeaderText = "SDT";
                    gridviewConfirm.Columns[7].HeaderText = "Dân tộc";

                    Random rd = new Random();
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
                        MessageBox.Show($"p: {p}");
                        MessageBox.Show($"q: {q}");
                        //Sinh khóa bí mật và khóa công khai
                        privateKey = createPrivateKey(p, q);
                        publicKey = createPublicKey(p, q);
                        privateKeyMD5 = EncryptMd5(privateKey.ToString());
                        MessageBox.Show($"Khóa bí mật của bạn là: {privateKey}. Hãy ghi nhớ khóa này");
                        List<KeyDTO> listKey = KeyBLL.getAllKey();
                        int id = listKey.Count + 1;
                        int n = p * q;
                        KeyDTO newKey = new KeyDTO(id, privateKeyMD5, publicKey, n, user_id);
                        bool resultAdd = KeyBLL.addNewKey(newKey);
                        int keyUser = KeyBLL.getKeyUser(user_id);
                        bool resultAddSignUser = UserBLL.AddSignUser(keyUser, id);

                        if (resultAdd == true && resultAddSignUser == true)
                        {
                            MessageBox.Show("Thêm thành công");
                            for (int i = 0; i < listKey.Count; i++)
                            {
                                MessageBox.Show(listKey[i].ToString());
                            }
                            bunifuSnackbar1.Show(this, $"Tạo chữ ký thành công. Khóa bí mật của bạn là: {privateKey}. Hãy ghi nhớ khóa này", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                            MessageBox.Show($"Khóa công khai: {publicKey}");
                        }
                        else
                        {
                            bunifuSnackbar1.Show(this, "Có lỗi xảy ra", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        }
                    }

                }
                else
                {
                    bunifuSnackbar1.Show(this, "Vui lòng nhập đủ thông tin", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                }

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
            int pri = Convert.ToInt32(createPrivateKey(p, q));
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

            //if (result < 0)
            //{
            //    result += phi;
            //}

            return result;
        }

        private static string Sign(string s, int p, int q, int pri)
        {
            string[] M = s.Split(' ');
            int n = q * p;
            string result = "";
            for (int i = 0; i < M.Length; i++)
            {
                int num = Convert.ToInt32(M[i]);
                if (M[i] != M[M.Length - 1])
                {
                    result += (power(Convert.ToInt32(M[i]), pri, n).ToString() + " ");
                }
                else
                {
                    result += (power(Convert.ToInt32(M[i]), pri, n));
                }
            }
            return result;
        }

        private static int USCLN(int a, int b)
        {
            if (b == 0) return a;
            return USCLN(b, a % b);
        }

        private static double power(int a, int b, int mod)
        {
            int result = 1;
            while (b > 0)
            {
                if ((b & 1) != 0)
                {
                    a = a % mod;
                    result = (result * a) % mod;
                    result = result % mod;
                }
                b = b >> 1;
                a = a % mod;
                a = (a * a) % mod;
                a = a % mod;
            }
            return result;
        }
    }
}
