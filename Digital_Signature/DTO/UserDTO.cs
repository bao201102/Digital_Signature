using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DTO
{
    internal class UserDTO
    {
        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _user_type_id;
        public int user_type_id
        {
            get { return _user_type_id; }
            set { _user_type_id = value; }
        }

        private int _sig_id;
        public int sig_id
        {
            get { return _sig_id; }
            set { _sig_id = value; }
        }


        public UserDTO(int user_id_, string username_, string password_, int user_type_id_, int sig_id_)
        {
            this.user_id = user_id_;
            this.username = username_;
            this.password = password_;
            this.user_type_id = user_type_id_;
            this.sig_id = sig_id_;
        }

        public UserDTO()
        {
            this.user_id = 0;
            this.username = "";
            this.password = "";
            this.user_type_id = 0;
            this.sig_id = 0;
        }

    }
}
