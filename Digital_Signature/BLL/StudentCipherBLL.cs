using Digital_Signature.DAL;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.BLL
{
    internal class StudentCipherBLL
    {
        public static bool addNewStudent(StudentCipherDTO studentCipher)
        {
            return StudentCipherDAL.addNewStudent(studentCipher);
        }
        public static List<object> getAllStudent()
        {
            return StudentCipherDAL.getAllStudent();
        }
    }
}
