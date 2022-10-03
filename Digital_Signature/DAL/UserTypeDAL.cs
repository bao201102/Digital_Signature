using System;
using AutoMapper;
using Digital_Signature.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DAL
{
    internal class UserTypeDAL
    {
        public static UserTypeDTO GetUserType(int userTypeId)
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            tbl_usertype query = (from usType in db_RSAEntities.tbl_usertype
                                  where usType.user_type_id == userTypeId
                                  select usType).SingleOrDefault();

            if (query != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_usertype, UserTypeDTO>());
                var mapper = new Mapper(config);
                UserTypeDTO userType = mapper.Map<UserTypeDTO>(query);

                return userType;
            }
            else
            {
                return null;
            }
        }
    }
}