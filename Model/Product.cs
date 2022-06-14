using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// model
using scale.SQLQuery;
// debugging
using System.Diagnostics;

namespace scale.Model
{
    class Product
    {
        // constant of class
        // TODO - may need a better format creation i.e. automatically create SP[XXXX]
        public const string ID_NUM_PLACEHOLDER = "00000";
        public const string PRODUCT_PREFIX = "SP";
        public const int ERROR = -1;

        // getter and setter
        public string ID { get; set; }
        public string Name 
        {
            get { return name;  }
            set 
            {
                if ( !string.IsNullOrEmpty(value) )
                {
                    name = value;
                }
                else
                {
                    name = "N/A";
                }
            }
        }
        public string Note { get; set; }

        // static function
        // Product Id generator for adding a new product to db
        public static string IdGenerator()
        {
            // initialization for product id
            string productId = PRODUCT_PREFIX;

            // get the lastest value of product id in db and then parse it into int type
            // then + 1 in order to add a new prodcut back into dbo.SanPham
            int nextNum = RefineNumFromProductID(MineQuery.GetLastProductIDFromProductTable()) + 1;

            productId += nextNum.ToString(ID_NUM_PLACEHOLDER);
            // debugging
            Trace.WriteLine($"Product.idGenerator() - product id = {productId}");

            return productId;
        }

        // private function - used inside the class
        // helper function - filter out the number from string product id (dbo.SanPham)
        private static int RefineNumFromProductID(string stringProductId)
        {
            if (!string.IsNullOrEmpty(stringProductId))
            {
                // follow convention of db - the product id has the concept SP[XXXX]
                if(stringProductId.StartsWith(PRODUCT_PREFIX))
                {
                    return int.Parse(stringProductId.Substring(2, ID_NUM_PLACEHOLDER.Length));
                }
            }
            return ERROR;
        }

        // private var
        private string name;
    }
}
