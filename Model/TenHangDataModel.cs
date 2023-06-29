using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Model
{
    public class TenHangDataModel : ObservableCollection<string>
    {
        public TenHangDataModel()
        {

        }

        public TenHangDataModel(IEnumerable<string> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }
}
