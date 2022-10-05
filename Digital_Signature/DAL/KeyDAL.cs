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
       
        //Thêm key vào CSDL
        public static bool addNewKey(KeyDTO nkey)
        {
            db_RSAEntities db_RSAEntities = new db_RSAEntities();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<KeyDTO, tbl_key>());
            var mapper = new Mapper(config);
            tbl_key key = mapper.Map<tbl_key>(nkey);
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