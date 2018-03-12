using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using WPFExample500.Models;
using WPFExample500.ViewModels;

namespace WPFExample500
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<object> Gender = SQLDatabase.GetSQLList("select PK_Gender from GenderTable");
            CBGender.ItemsSource = Gender;
            List<object> Haircolor = SQLDatabase.GetSQLList("select PK_Haircolor from HaircolorTable");
            CBHaircolor.ItemsSource = Haircolor;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UserModel.Username = Username.Text;

            //MessageBox.Show(UserModel.Username);

            ViewModel viewModel = new ViewModel();
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
                string Imagepath = $@"C:\Images\1234.jpg";
                //string filename = { Binding = "" };
                File.Copy(op.FileName, Imagepath);
                

                //imgPhoto.Source = new BitmapImage(new Uri(op.FileName));

            }
        }

    }
}
