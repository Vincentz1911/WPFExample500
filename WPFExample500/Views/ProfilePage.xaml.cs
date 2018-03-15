using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        ViewModel vm = new ViewModel();

        public ProfilePage()
        {
            InitializeComponent();

            GridUser.DataContext = vm.UserModel;
            CBGender.ItemsSource = vm.GenderList;
            CBHaircolor.ItemsSource = vm.HaircolorList;
            CBPostalCode.ItemsSource = vm.CityList;
            CBSexuality.ItemsSource = vm.SexualityList;
        }

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            vm.UpdateSQL();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.LoadImage();
        }
    }
}
