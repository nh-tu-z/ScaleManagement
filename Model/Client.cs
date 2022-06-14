using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using scale.SQLQuery;
// debugging
using System.Diagnostics;

namespace scale.Model
{
    class Client
    {
        // constant of class
        // TODO - may need a better format creation i.e. automatically create SP[XXXX]
        public const string ID_NUM_PLACEHOLDER = "00000";
        public const string PRODUCT_PREFIX = "KH";
        public const int ERROR = -1;

        // getter and setter
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        // static function
        // Product Id generator for adding a new product to db
        public static string IdGenerator()
        {
            // initialization for client id
            string clientId = PRODUCT_PREFIX;

            // get the lastest value of product id in db and then parse it into int type
            // then + 1 in order to add a new prodcut back into dbo.SanPham
            int nextNum = RefineNumFromClientID(MineQuery.GetLastClientIDFromClientTable()) + 1;

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
