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
using scale.Model;
using scale.SQLQuery;
// debugging
using System.Diagnostics;
using scale.Model.Entity;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for MerchandiseInsertionView.xaml
    /// </summary>
    public partial class MerchandiseInsertionView : Window
    {
        public MerchandiseInsertionView()
        {
            InitializeComponent();

            // Show the product id - read only
            productIDTxtBox.Text = Product.IdGenerator();
        }

        public MerchandiseInsertionView(object obj)
        {
            InitializeComponent();

            var product = (SanPham)obj;
            productIDTxtBox.Text = product.ID;
            productNameTxtBox.Text = product.Name;
            noteForProductTxtBox.Text = product.GhiChu;

            // change the button content
            applyBtn.Content = "Sửa";
        }

        private void load(object sender, RoutedEventArgs e)
        {
            // Set properties for control
            productIDTxtBox.IsReadOnly = true;
        }

        private void addProductToDB(object sender, RoutedEventArgs e)
        {
            if((string)applyBtn.Content == "Thêm")
            {
                // do a sanity check if there is an accidentally hitting the button
                if (!string.IsNullOrEmpty(productNameTxtBox.Text))
                {
                    Product newProduct = new Product();
                    newProduct.ID = productIDTxtBox.Text;
                    newProduct.Name = productNameTxtBox.Text;
                    newProduct.Note = noteForProductTxtBox.Text;

                    MineQuery.CreateProduct(newProduct);
                }
            }    
            else if((string)applyBtn.Content == "Sửa")
            {
                // TODO - do a sanity check if there is an accidentally hitting the button

                Product changedProduct = new Product();
                changedProduct.ID = productIDTxtBox.Text;
                changedProduct.Name = productNameTxtBox.Text;
                changedProduct.Note = noteForProductTxtBox.Text;

                // create new instance
                int rowChanged = MineQuery.UpdateProduct(changedProduct);

                // debugging
                Trace.WriteLine($"PriceManagementInsertionView - Update Product - row changed: {rowChanged}");
            }

            // collapse the view 
            merchandiseInsertionView.Close();
        }
    }
}
