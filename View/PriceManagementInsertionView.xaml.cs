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
using scale.SQLQuery;
using scale.Model;
// debugging
using System.Diagnostics;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for PriceManagementInsertionView.xaml
    /// </summary>
    // TODO - change the name of the class because the function of class is not only insertion,
    // it is also used for editing 
    public partial class PriceManagementInsertionView : Window
    {
        public PriceManagementInsertionView()
        {
            InitializeComponent();

            // Show the product id in dbo.DonGia within dbo.SanPham
            productIDCbx.ItemsSource = MineQuery.GetAvailableProductID();
        }

        // TODO - don't know why constructor does not allow input UnitPrice as a parameter directly
        public PriceManagementInsertionView(object obj)
        {
            InitializeComponent();

            // populate data
            var selectedUnitPrice = (DonGia)obj;

            productIDCbx.ItemsSource = new List<string>() { selectedUnitPrice.SanPhamID };
            productIDCbx.SelectedItem = selectedUnitPrice.SanPhamID;

            exchangeTxtBox.Text = selectedUnitPrice.TyTrong.ToString();
            priceTxtBox.Text = selectedUnitPrice.Gia.ToString();
            noteForPriceTxtBox.Text = selectedUnitPrice.GhiChu;

            // change the button content
            applyBtn.Content = "Sửa";
        }

        private void load(object sender, RoutedEventArgs e)
        {
        }

        private void addPriceManagementToDB(object sender, RoutedEventArgs e)
        {
            if ((string)applyBtn.Content == "Sửa")
            {
                UnitPrice newUnitPrice = new UnitPrice();
                newUnitPrice.ProductID = productIDCbx.SelectedItem.ToString();
                newUnitPrice.Proportion = exchangeTxtBox.Text;
                newUnitPrice.Price = priceTxtBox.Text;
                newUnitPrice.Note = noteForPriceTxtBox.Text;

                // update data into database
                int rowChanged = MineQuery.UpdateUnitPrice(newUnitPrice);

                // debugging
                Trace.WriteLine($"PriceManagementInsertionView - Update Unit Price - row changed: {rowChanged}");
            }
            else if ((string)applyBtn.Content == "Thêm")
            {
                // TODO - do a sanity check if there is an accidentally hitting the button

                UnitPrice newUnitPrice = new UnitPrice();
                newUnitPrice.ProductID = productIDCbx.SelectedItem.ToString();
                newUnitPrice.Proportion = exchangeTxtBox.Text;
                newUnitPrice.Price = priceTxtBox.Text;
                newUnitPrice.Note = noteForPriceTxtBox.Text;

                // create new instance
                int rowChanged = MineQuery.CreateUnitPrice(newUnitPrice);

                // debugging
                Trace.WriteLine($"PriceManagementInsertionView - Create Unit Price - row changed: {rowChanged}");
            }

            // collapse the view 
            priceMangementInsertionView.Close();
        }
    }
}
