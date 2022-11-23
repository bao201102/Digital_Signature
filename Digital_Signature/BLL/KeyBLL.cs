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
        //  Tạo khóa và add vào CSDL
        //  Dùng phương thức chonSoNgauNhien để tạo ra hai số p, q;
        //  Tính  int n = p * q;
        //  Tạo khóa bí mật: Dùng phương thức createPrivateKey(p,q) 
        //  Tạo khóa công khai: Dùng phương thức createPublicKey(p,q)
        //  Tạo khóa mới để thêm vào CSDL: lấy n, private_key, public_key ở trên
        //  KeyDTO nkey = new KeyDTO(sig_id, private_key, public_key, n);
        //  KeyBLL.AddNewKey(nkey);
        //  => Thêm khóa vào CSDL thành công
        //=======================//
        //  Muốn lấy ra khóa dùng phương thức getKeyById
        //=======================//
        public static bool addNewKey(KeyDTO nkey)
        {
            return KeyDAL.addNewKey(nkey);
        }

        public static List<KeyDTO> getAllKey()
        {
            return KeyDAL.getAllKey();
        }

        public static KeyDTO getKeyByUserId(int user_id)
        {
            return KeyDAL.getKeyByUserId(user_id);
        }

        //Lấy ra khóa mà người dùng đã tạo
        public static int getKeyUser(int userId)
        {
            return KeyDAL.getKeyUser(userId);
        }
    }
}