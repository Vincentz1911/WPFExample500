using System.Windows;
using System.Windows.Controls;
using WPFExample500.ViewModels;

namespace WPFExample500.Views
{
    public partial class LoginPage : Page
    {
        ViewModel vm = new ViewModel();
        public LoginPage()
        {
            InitializeComponent();
            //GridPassword.DataContext = vm.UserModel;
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            vm.Login(Logintxt.Text, Passtxt.Password);
        }
    }
}
