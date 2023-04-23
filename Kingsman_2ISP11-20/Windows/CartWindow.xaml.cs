using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Kingsman_2ISP11_20.Windows
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetListService();
            
        }
        private void GetListService()
        {
           ObservableCollection<DataBase.Service> lastCart = new ObservableCollection<DataBase.Service>(ClassHelper.CartServiceClass.ServiceCart);
            LvCartService.ItemsSource = lastCart;
        }

        private void BtnRomoveToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service;
            ClassHelper.CartServiceClass.ServiceCart.Remove(service);

            GetListService();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }
    }
}
