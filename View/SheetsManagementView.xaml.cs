using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//
using scale.ViewModelWrapper;
using scale.SQLQuery;
//
using System.Diagnostics;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for SheetsManagementView.xaml
    /// </summary>
    public partial class SheetsManagementView : Window
    {
        private readonly MainViewModel viewModel = new MainViewModel();
        public SheetsManagementView()
        {
            InitializeComponent();

            // data is added to DataContext to be shown in table
            viewModel.OutputSheetDataGridItems = MineQuery.GetOutputSheets();
            this.DataContext = viewModel;
        }

        private void dateTimePickerTo_CalendarClosed(object sender, RoutedEventArgs e)
        {
            // TODO - validate that the FROM day need to be less than the TO day

            DateTime fromDate = (DateTime)dateTimePickerFrom.SelectedDate;
            DateTime toDate = (DateTime)dateTimePickerTo.SelectedDate;

            mainDataGrid.ItemsSource = null;
            mainDataGrid.ItemsSource = MineQuery.GetOutputSheetForDays(fromDate, toDate);
        }

        // one combo box and 2 date time pickers take over "the output sheet for day(s)" behaviour
        // + if combo box is unchecked, just date time FROM is enabled in order to choose list of output sheet for specific day
        // + in another hand, if combo box is checked, date on date time FROM picker must be choosen first, then the date time TO will be enabled
        private void dateTimePickerFrom_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if((bool)dateCbx.IsChecked)
            {
                if(dateTimePickerFrom.SelectedDate.HasValue)
                {
                    dateTimePickerTo.IsEnabled = true;
                }
            }
            else
            {
                DateTime fromDate = (DateTime)dateTimePickerFrom.SelectedDate;
                Trace.WriteLine($"Date Time From: {fromDate.Date.ToString("d")}");

                // refresh data in datagrid
                mainDataGrid.ItemsSource = null;
                mainDataGrid.ItemsSource = MineQuery.GetOutputSheetForSpecificDay(fromDate);
            }
        }

        private void dateCbx_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void dateCbx_Unchecked(object sender, RoutedEventArgs e)
        {
            dateTimePickerTo.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dateTimePickerTo.IsEnabled = false;
        }
    }
}
