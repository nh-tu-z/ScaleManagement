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
        public MatHangDataModel ProductDataGridItems { get; set; } = new MatHangDataModel();
        public KhachHangDataModel ClientDataGridItems { get; set; } = new KhachHangDataModel();
        public DonGiaDataModel UnitPriceDataGridItems { get; set; } = new DonGiaDataModel();
        public KhachHangNameDataModel KhachHangNames { get; set; } = new KhachHangNameDataModel();
        public TenHangDataModel TenHang { get; set; } = new TenHangDataModel();
    }
}
