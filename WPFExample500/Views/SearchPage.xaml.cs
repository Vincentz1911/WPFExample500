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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFExample500.ViewModels;

namespace WPFExample500.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        ViewModel vm = new ViewModel();

        public SearchPage()
        {
            InitializeComponent();
            GridSearch.DataContext = vm.UserModel.UserDataTable;

        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            vm.FindUsers();
        }
    }
}
