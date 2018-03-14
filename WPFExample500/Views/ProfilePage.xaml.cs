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
        public ViewModel viewModel;

        public ProfilePage()
        {
            InitializeComponent();

            viewModel = new ViewModel();
            GridUser.DataContext = viewModel.UserModel;
            CBGender.ItemsSource = viewModel.GenderList;
            CBHaircolor.ItemsSource = viewModel.HaircolorList;
            CBPostalCode.ItemsSource = viewModel.CityList;
            CBSexuality.ItemsSource = viewModel.SexualityList;
        }

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            viewModel.UpdateSQL();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //string f = UserModel.FK_Username;
                string Imagepath = $@"C:\Images\1234.jpg";
                //string filename = { Binding = "" };
                File.Copy(op.FileName, Imagepath);


                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));

            }
        }
    }
}
