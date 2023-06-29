using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.Model
{
    public class KhachHangPropertyChanged : KhachHang, INotifyPropertyChanged
    {
        private string _ID;
        public override string ID 
        { 
            get { return _ID; } 
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            } 
        }
        public override string Name { get; set; }
        public override string SDT { get; set; }
        public override string DiaChi { get; set; }
        public override string GhiChu { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
