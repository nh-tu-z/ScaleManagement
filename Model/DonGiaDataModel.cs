using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Model
{
    public class DonGiaDataModel : ObservableCollection<DonGia>
    {
        public DonGiaDataModel()
        {

        }

        public DonGiaDataModel(IEnumerable<DonGia> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<DonGia> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
