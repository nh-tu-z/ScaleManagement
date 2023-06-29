using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scale.Model.Entity;

namespace scale.Model
{
    public class MatHangDataModel : ObservableCollection<SanPham>
    {
        public MatHangDataModel()
        {

        }

        public MatHangDataModel(IEnumerable<SanPham> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<SanPham> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
