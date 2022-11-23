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
        public static bool addNewKey(KeyDTO newKey)
        {
            db_RSAEntities db = new db_RSAEntities();

            var query = (from x in db.tbl_key select x).Count();
            newKey.sig_id = query + 1;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<KeyDTO, tbl_key>());
            var mapper = new Mapper(config);
            tbl_key key = mapper.Map<tbl_key>(newKey);
            db.tbl_key.Add(key);

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

        public static List<KeyDTO> getAllKey()
        {
            db_RSAEntities db = new db_RSAEntities();
            List<KeyDTO> listKey = new List<KeyDTO>();
            var query = from qkey in db.tbl_key
                        select qkey;

            foreach (tbl_key item in query)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_key, KeyDTO>());
                var mapper = new Mapper(config);
                KeyDTO key = mapper.Map<KeyDTO>(item);
                listKey.Add(key);
            }
            return listKey;
        }

        public static KeyDTO getKeyByUserId(int user_id)
        {
            db_RSAEntities db = new db_RSAEntities();

            tbl_key query = (from x in db.tbl_key
                             where x.user_id == user_id
                             select x).SingleOrDefault();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<tbl_key, KeyDTO>());
            var mapper = new Mapper(config);
            KeyDTO Key = mapper.Map<KeyDTO>(query);

            return Key;
        }

        public static int getKeyUser(int userId)
        {
            db_RSAEntities db = new db_RSAEntities();

            var keys = (from key in db.tbl_key
                        where key.user_id.Equals(userId)
                        select key).SingleOrDefault();

            if (keys != null)
            {
                return keys.user_id;
            }
            else
            {
                return -1;
            }
        }
    }
}