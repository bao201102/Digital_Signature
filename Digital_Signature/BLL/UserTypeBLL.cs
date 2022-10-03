using System;
using Digital_Signature.DTO;
using Digital_Signature.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.BLL
{
    internal class UserTypeBLL
    {
        public static UserTypeDTO GetUserTypeDTO(int userTypeId)
        {
            return UserTypeDAL.GetUserType(userTypeId);
        }
    }
}