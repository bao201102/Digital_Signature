using AutoMapper;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Signature.DAL
{
    internal class StudentCipherDAL
    {
        public static bool addNewStudent(StudentCipherDTO studentCipher)
        {
            db_RSAEntities db = new db_RSAEntities();

            var query = (from x in db.tbl_student_cipher select x).Count();
            studentCipher.stu_id = query + 1;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentCipherDTO, tbl_student_cipher>());
            var mapper = new Mapper(config);
            tbl_student_cipher student = mapper.Map<tbl_student_cipher>(studentCipher);
            db.tbl_student_cipher.Add(student);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static StudentCipherDTO getStudentsSigned(int userId)
        {
            db_RSAEntities db = new db_RSAEntities();

            tbl_student_cipher query = (from x in db.tbl_student_cipher
                                             where x.user_id == userId
                                             select x).SingleOrDefault();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_student_cipher, StudentCipherDTO>());
            var mapper = new Mapper(config);
            StudentCipherDTO studentCipher = mapper.Map<StudentCipherDTO>(query);

            return studentCipher;
        }
    }
}
