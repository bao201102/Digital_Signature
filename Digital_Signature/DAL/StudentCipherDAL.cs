using AutoMapper;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Signature.DAL
{
    internal class StudentCipherDAL
    {
        //Thêm sinh viên vào CSDL
        public static bool addNewStudent(StudentCipherDTO studentCipher)
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentCipherDTO, tbl_student_cipher>());
            var mapper = new Mapper(config);
            tbl_student_cipher student = mapper.Map<tbl_student_cipher>(studentCipher);
            db_RSAEntities.tbl_student_cipher.Add(student);
            return db_RSAEntities.SaveChanges() > 0 ? true : false;
        }
        //Lấy tất cả sinh viên từ CSDL
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
        //Lấy ra học sinh đã ký
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
