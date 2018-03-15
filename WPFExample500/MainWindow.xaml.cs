using System.Windows;
using WPFExample500.ViewModels;

namespace WPFExample500
{
    public partial class MainWindow : Window
    {
        public ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnClickP0(object sender, RoutedEventArgs e) { Main.Content = null; }
        private void BtnClickP1(object sender, RoutedEventArgs e) { Main.Content = new Views.SearchPage(); }
        private void BtnClickP2(object sender, RoutedEventArgs e) { Main.Content = new Views.MessagesPage(); }
        private void BtnClickP3(object sender, RoutedEventArgs e) { Main.Content = new Views.ProfilePage(); }
        private void BtnClickP4(object sender, RoutedEventArgs e) { Main.Content = new Views.LoginPage(); }
        private void BtnClickP5(object sender, RoutedEventArgs e) { Application.Current.Shutdown(); }
    }
}
