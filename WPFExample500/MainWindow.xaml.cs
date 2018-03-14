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



            //List<object> Gender = SQLDatabase.GetSQLList("select PK_Gender from GenderTable");
            //CBGender.ItemsSource = Gender;
            //List<object> Haircolor = SQLDatabase.GetSQLList("select PK_Haircolor from HaircolorTable");
            //CBHaircolor.ItemsSource = Haircolor;
            //List<object> PostalCode = SQLDatabase.GetSQLList("select PK_City from PostalCodeTable");
            //CBPostalCode.ItemsSource = PostalCode;

            //viewModel = new ViewModel();

            //viewModel.UserModel.FK_Username;

        }


        private void BtnClickP0(object sender, RoutedEventArgs e) { Main.Content = null; }
        private void BtnClickP1(object sender, RoutedEventArgs e) { Main.Content = new Views.SearchPage(); }
        private void BtnClickP2(object sender, RoutedEventArgs e) { Main.Content = new Views.MessagesPage(); }
        private void BtnClickP3(object sender, RoutedEventArgs e) { Main.Content = new Views.ProfilePage(); }
        private void BtnClickP4(object sender, RoutedEventArgs e) { Main.Content = new Views.LoginPage(); }
        private void BtnClickP5(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }






    }
}
