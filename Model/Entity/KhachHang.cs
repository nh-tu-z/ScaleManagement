using scale.Interfaces;
using scale.SQLQuery;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scale.CommandText;

namespace scale.Model
{
    public class KhachHang
    {
        // constant of class
        // TODO - may need a better format creation i.e. automatically create SP[XXXX]
        public const string ID_NUM_PLACEHOLDER = "00000";
        public const string PRODUCT_PREFIX = "KH";
        public const int ERROR = -1;

        public virtual string ID { get; set; }
        public virtual string Name { get; set; }   
        public virtual string SDT { get; set; }
        public virtual string DiaChi { get; set; }
        public virtual string GhiChu { get; set; }

        // static function
        // Product Id generator for adding a new product to db
        public static string IdGenerator(IDbService dbService)
        {
            // initialization for client id
            string clientId = PRODUCT_PREFIX;

            // get the lastest value of product id in db and then parse it into int type
            // then + 1 in order to add a new prodcut back into dbo.SanPham
            int nextNum = RefineNumFromClientID(dbService.QuerySingleOrDefault<string>(KhachHangCommand.GetLastKhachHangID)) + 1;

            clientId += nextNum.ToString(ID_NUM_PLACEHOLDER);
            // debugging
            Trace.WriteLine($"Client.IdGenerator() - client id = {clientId}");

            return clientId;
        }

        // private function - used inside the class
        // helper function - filter out the number from string product id (dbo.SanPham)
        private static int RefineNumFromClientID(string stringClientId)
        {
            if (!string.IsNullOrEmpty(stringClientId))
            {
                // follow convention of db - the product id has the concept SP[XXXX]
                if (stringClientId.StartsWith(PRODUCT_PREFIX))
                {
                    return int.Parse(stringClientId.Substring(2, ID_NUM_PLACEHOLDER.Length));
                }
            }
            return ERROR;
        }
    }
}
