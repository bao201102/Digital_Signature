using AutoMapper;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DAL
{
    internal class StudentPlainDAL
    {
        public static bool addNewStudent(StudentPlainDTO studentPlain)
        {
            db_RSAEntities db = new db_RSAEntities();

            var query = (from x in db.tbl_student_plain select x).Count();
            studentPlain.stu_id = query + 1;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentPlainDTO, tbl_student_plain>());
            var mapper = new Mapper(config);
            tbl_student_plain student = mapper.Map<tbl_student_plain>(studentPlain);
            db.tbl_student_plain.Add(student);

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

        //Lấy ra học sinh đã ký
        public static List<StudentPlainDTO> getStudentsSigned(int userId)
        {
            db_RSAEntities db = new db_RSAEntities();
            List<StudentPlainDTO> stuPlainDTOs = new List<StudentPlainDTO>();
            var stu_plains = from skey in db.tbl_student_plain
                              where skey.user_id == userId
                              select skey;
            foreach (tbl_student_plain stu_plain in stu_plains)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_student_plain, StudentPlainDTO>());
                var mapper = new Mapper(config);
                StudentPlainDTO studentPlain = mapper.Map<StudentPlainDTO>(stu_plain);
                stuPlainDTOs.Add(studentPlain);
            }
            return stuPlainDTOs;
        }
    }
}
