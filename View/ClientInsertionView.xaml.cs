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
//
using System.Diagnostics;
//firebase
using Firebase.Database;
using Firebase.Database.Query;

namespace scale.View
{
    /// <summary>
    /// Interaction logic for ClientInsertionView.xaml
    /// </summary>
    public partial class ClientInsertionView : Window
    {
        public ClientInsertionView()
        {
            InitializeComponent();

            // Show the client id - read only
            clientIdTxt.Text = Client.IdGenerator();
        }

        public ClientInsertionView(object obj)
        {
            InitializeComponent();

            Client changedClient = (Client)obj;

            clientIdTxt.Text = changedClient.ID;
            clientNameTxt.Text = changedClient.Name;
            clientPhoneTxt.Text = changedClient.Phone;
            addressTxt.Text = changedClient.Address;
            noteTxt.Text = changedClient.Note;

            // change the content of the button if we are prompt to edition view
            applyBtn.Content = "Sửa";
        }

        private void load(object sender, RoutedEventArgs e)
        {
            clientIdTxt.IsEnabled = false;
        }

        private async void apply(object sender, RoutedEventArgs e)
        {
            if ((string)applyBtn.Content == "Sửa")
            {
                Client changedClient = new Client();

                changedClient.ID = clientIdTxt.Text;
                changedClient.Name = clientNameTxt.Text;
                changedClient.Phone = clientPhoneTxt.Text;
                changedClient.Address = addressTxt.Text;
                changedClient.Note = noteTxt.Text;

                // update client data in database
                MineQuery.UpdateClient(changedClient);
            }
            else if((string)applyBtn.Content == "Thêm")
            {
                if(!string.IsNullOrEmpty(clientNameTxt.Text))
                {
                    Client newClient = new Client();

                    newClient.ID = clientIdTxt.Text;
                    newClient.Name = clientNameTxt.Text;
                    newClient.Phone = clientPhoneTxt.Text;
                    newClient.Address = addressTxt.Text;
                    newClient.Note = noteTxt.Text;

                    int rowChanged = MineQuery.CreateClient(newClient);

                    // firebase
                    var firebase = new FirebaseClient("https://canda-61897-default-rtdb.asia-southeast1.firebasedatabase.app/");
                    await firebase
                      .Child("KhachHang")
                      .PostAsync(newClient);

                    // debugging
                    Trace.WriteLine($"ClientInsertionView - Create new client - row changed: {rowChanged}");
                }
            }    

            // collapse the view
            clientInsertionView.Close();
        }
    }
}
