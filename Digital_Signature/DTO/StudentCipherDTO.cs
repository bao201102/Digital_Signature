using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DTO
{
    internal class StudentCipherDTO
    {
        private int _stu_id;
        public int stu_id
        {
            get { return _stu_id; }
            set { _stu_id = value; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _sex;
        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private DateTime _birthday;
        public DateTime birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _graduation_year;
        public string graduation_year
        {
            get { return _graduation_year; }
            set { _graduation_year = value; }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _place_of_birth;
        public string place_of_birth
        {
            get { return _place_of_birth; }
            set { _place_of_birth = value; }
        }

        private string _phone;
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _religion;
        public string religion
        {
            get { return _religion; }
            set { _religion = value; }
        }

        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }


        public StudentCipherDTO(int stu_id_, string name_, string sex_, DateTime birthday_, string graduation_year_, string email_, string place_of_birth_, string phone_, string religion_, int user_id_)
        {
            this.stu_id = stu_id_;
            this.name = name_;
            this.sex = sex_;
            this.birthday = birthday_;
            this.graduation_year = graduation_year_;
            this.email = email_;
            this.place_of_birth = place_of_birth_;
            this.phone = phone_;
            this.religion = religion_;
            this.user_id = user_id_;
        }

        public StudentCipherDTO()
        {
            this.stu_id = 0;
            this.name = "";
            this.sex = "";
            this.birthday = DateTime.Now;
            this.graduation_year = "";
            this.email = "";
            this.place_of_birth = "";
            this.phone = "";
            this.religion = "";
            this.user_id = 0;
        }
    }
}
