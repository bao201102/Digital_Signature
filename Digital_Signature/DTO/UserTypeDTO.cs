using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DTO
{
    internal class UserTypeDTO
    {
        private int _user_type_id;
        public int user_type_id
        {
            get { return _user_type_id; }
            set { _user_type_id = value; }
        }

        private string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }


        public UserTypeDTO(int user_type_id_, string type_)
        {
            this.user_type_id = user_type_id_;
            this.type = type_;
        }

        public UserTypeDTO()
        {
            this.user_type_id = 0;
            this.type = "";
        }
    }
}