using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Model
{
    public class KhachHangDataModel : ObservableCollection<KhachHang>
    {
        public KhachHangDataModel() 
        {
            
        }

        public KhachHangDataModel(IEnumerable<KhachHang> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<KhachHang> items)
        {
            foreach (KhachHang item in items)
            {
                Add(item);
            }
        }
    }
}
