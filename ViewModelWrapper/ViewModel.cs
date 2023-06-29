using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using scale.Model;

namespace scale.ViewModelWrapper
{
    class ViewModel 
    {
        public IEnumerable<OutputSheet> OutputSheetDataGridItems { get; set; }
        public IEnumerable<Product> ProductDataGridItems { get; set; }
        public KhachHangDataModel ClientDataGridItems { get; set; } = new KhachHangDataModel();
        public IEnumerable<UnitPrice> UnitPriceDataGridItems { get; set; }
        public KhachHangNameDataModel KhachHangNames { get; set; } = new KhachHangNameDataModel();

    }
}
