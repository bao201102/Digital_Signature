using Digital_Signature.DAL;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.BLL
{
    class KeyBLL
    {
        public static bool addNewKey(KeyDTO nkey)
        {
            return KeyDAL.addNewKey(nkey);
        }

        public static KeyDTO getKeyByUserId(int user_id)
        {
            return KeyDAL.getKeyByUserId(user_id);
        }

        public static int getKeyUser(int userId)
        {
            return KeyDAL.getKeyUser(userId);
        }
    }
}