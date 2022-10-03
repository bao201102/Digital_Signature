using System;
using AutoMapper;
using Digital_Signature.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DAL
{
    internal class UserDAL
    {
        public static UserDTO GetUser(string username, string password)
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            tbl_user query = (from us in db_RSAEntities.tbl_user
                         where us.username == username && us.password == password
                         select us).SingleOrDefault();

            if (query != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_user, UserDTO>());
                var mapper = new Mapper(config);
                UserDTO user = mapper.Map<UserDTO>(query);

                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
