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

        public static bool updateStuStatus(StudentPlainDTO studentPlain)
        {
            db_RSAEntities db = new db_RSAEntities();
            tbl_student_plain query = db.tbl_student_plain.Where(x => x.stu_id.Equals(studentPlain.stu_id)).Single();
            query.status = studentPlain.status;

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

        public static List<StudentPlainDTO> getAllStudentSigned()
        {
            db_RSAEntities db = new db_RSAEntities();

            var query = from x in db.tbl_student_plain
                        select x;

            List<StudentPlainDTO> list = new List<StudentPlainDTO>();
            foreach (tbl_student_plain item in query)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_student_plain, StudentPlainDTO>());
                var mapper = new Mapper(config);
                StudentPlainDTO studentPlain = mapper.Map<StudentPlainDTO>(item);
                list.Add(studentPlain);
            }
            
            return list;
        }

        public static StudentPlainDTO getStudentSigned(int userId)
        {
            db_RSAEntities db = new db_RSAEntities();

            tbl_student_plain query = (from x in db.tbl_student_plain
                                       where x.user_id == userId
                                       select x).SingleOrDefault();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_student_plain, StudentPlainDTO>());
            var mapper = new Mapper(config);
            StudentPlainDTO studentPlain = mapper.Map<StudentPlainDTO>(query);

            return studentPlain;
        }
    }
}
