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
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                return db.SaveChanges() > 0 ? true : false;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
 
        public static List<object> getAllStudent()
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            List<object> list = new List<object>();

            var query = from skey in db_RSAEntities.tbl_student_cipher
                        select new
                        {
                            skey.stu_id,
                            skey.name,
                            skey.sex,
                            skey.birthday,
                            skey.graduation_year,
                            skey.email,
                            skey.place_of_birth,
                            skey.phone,
                            skey.religion,
                            skey.user_id,
                            skey.status
                        };

            foreach (var item in query)
            {
                list.Add(item);
            }
            return list;
        }

        public static List<StudentCipherDTO> getStudentsSigned(int userId)
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();

            var stu_ciphers = from skey in db_RSAEntities.tbl_student_cipher
                        where skey.user_id == userId
                        select skey;

            List<StudentCipherDTO> stuCipherDTOs = new List<StudentCipherDTO>();
            foreach (tbl_student_cipher stu_cipher in stu_ciphers)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_student_cipher, StudentCipherDTO>());
                var mapper = new Mapper(config);
                StudentCipherDTO studentCipher = mapper.Map<StudentCipherDTO>(stu_cipher);
                stuCipherDTOs.Add(studentCipher);
            }
            return stuCipherDTOs;
        }
    }
}
