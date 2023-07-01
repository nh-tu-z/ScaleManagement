using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale.ViewModel
{
    public class ConfigurationViewModel
    {
        public PortSettingsViewModel PortSettings { get; set; } = new PortSettingsViewModel();
    }

    public class PortSettingsViewModel : BaseViewModel
    {
        public ObservableCollection<string> AvaliablePorts { get; set; } = new ObservableCollection<string>();

        private string _selectedComPort;
        public string SelectedCOMPort
        {
            get => _selectedComPort;
            set => RaisePropertyChanged(ref _selectedComPort, value);
        }
    }
}
