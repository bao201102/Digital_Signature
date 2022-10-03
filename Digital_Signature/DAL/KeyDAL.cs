using AutoMapper;
using Digital_Signature.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.DAL
{
    class KeyDAL
    {
        //Hàm tạo hai số ngầu nhiên
        public static int chonSoNgauNhien()
        {
            Random rd = new Random();
            return rd.Next(11, 101);
        }

        //Hàm kiểm tra nguyên tố
       public static bool kiemTraNguyenTo(int number)
        {
            bool kt = true;
            if (number == 2 || number == 3)
            {
                return kt;
            }
            else
            {
                if (number == 1 || number % 2 == 0 || number % 3 == 0)
                {
                    kt = false;
                }
                else
                {
                    for (int i = 5; i <= Math.Sqrt(number); i = i + 6)
                        if (number % i == 0 || number % (i + 2) == 0)
                        {
                            kt = false;
                            break;
                        }
                }
            }
            return kt;
        }

        //Hàm kiểm tra hai số nguyên tố cùng nhau áp dụng giải thuật Euclid
        public static bool nguyenToCungNhau(int a, int b)
        {
            bool kt;
            int temp;
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            if (a == 1) { kt = true; }
            else kt = false;
            return kt;
        }

        //Hàm tạo khóa bí mật
        public static int createPrivateKey(int p, int q)
        {
            int eA;
            //Tính: n=p*q
            int n = p * q;
            //Tính: phi(n)=(p-1)*(q-1)
            int sophiN = (p - 1) * (q - 1);
            //Tìm eA thỏa mãn điều kiện 1 < eA < phi(n) sao cho Ước số chung lớn nhất gcd(eA ,phi(n)) = 1 
            do
            {
                Random rd = new Random();
                eA = rd.Next(2, sophiN);
            }
            while (!nguyenToCungNhau(eA, sophiN));
            return eA; //eA là Khóa Bí Mật dùng để Ký văn bản.
        }

        //Hàm tạo khóa công khai
        public static int createPublicKey(int p, int q)
        {
            int sophiN, eA, dA;
            //Tính: n=p*q
            int n = p * q;

            //Tính: phi(n)=(p-1)*(q-1)
            sophiN = (p - 1) * (q - 1);
            eA = createPrivateKey(p,q);

            //Tìm dA sao cho dA= eA^(-1) mod phi(n) sử dụng giải thuật Euclide mở rộng:
            dA = 0;
            int i = 2;
            while (((1 + i * sophiN) % eA) != 0 || dA <= 0)
            {
                i++;
                dA = (1 + i * sophiN) / eA;
            }
            return dA; // dA là Khóa Công Khai.
        }

        //Thêm key vào CSDL
        public static bool addNewKey(KeyDTO nkey)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<KeyDTO, tbl_key>());
            var mapper = new Mapper(config);
            tbl_key key = mapper.Map<tbl_key>(nkey);
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            db_RSAEntities.tbl_key.Add(key);
            return db_RSAEntities.SaveChanges() > 0 ? true : false;
        }
        //Lấy ra tất cả khóa trong CSDL
        public static List<object> getAllKey()
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            List<object> list = new List<object>();

            var query = from qkey in db_RSAEntities.tbl_key
                        select new
                        {
                            qkey.sig_id,
                            qkey.private_key,
                            qkey.public_key,
                            qkey.n
                        };

            foreach (var item in query)
            {
                list.Add(item);
            }
            return list;
        }
        //Lấy khóa theo sig_id từ CSDL
        public static List<KeyDTO> getKeyById(int sid)
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            var keys = from id in db_RSAEntities.tbl_key
                            where id.sig_id == sid
                            select id;
            List<KeyDTO> keyDTOs = new List<KeyDTO>();
            foreach (tbl_key ikey in keys)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_key, KeyDTO>());
                var mapper = new Mapper(config);
                KeyDTO khoa = mapper.Map<KeyDTO>(ikey);
                keyDTOs.Add(khoa);
            }
            return keyDTOs;
        }
    }
}