using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Model
{
    class OutputSheet
    {
        public string SheetID { get; set; }
        public string TruckNumber { get; set; }
        public string Client { get; set; }
        public string WeightIn { get; set; }
        public string WeightOut { get; set; }
        public string MerchandiseWeight { get; set; }
        public string Exchange { get; set; }
        public string UnitPrice { get; set; }
        public string Price { get; set; }
        public string Ship { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Note { get; set; }
    }
}
