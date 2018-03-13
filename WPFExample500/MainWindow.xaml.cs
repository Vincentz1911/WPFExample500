using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;

using WPFExample500.ViewModels;

namespace WPFExample500
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            List<object> Gender = SQLDatabase.GetSQLList("select PK_Gender from GenderTable");
            CBGender.ItemsSource = Gender;
            List<object> Haircolor = SQLDatabase.GetSQLList("select PK_Haircolor from HaircolorTable");
            CBHaircolor.ItemsSource = Haircolor;

            viewModel = new ViewModel();
            GridUser.DataContext = viewModel;

            //viewModel.UserModel.FK_Username;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UserModel.Username = Username.Text;

            //MessageBox.Show(UserModel.Username);
            //MessageBox.Show(UserModel.FK_Username);
            viewModel.UpdateSQL(txtUsername.Text, txtPassword.Text, txtProfilename.Text);
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
