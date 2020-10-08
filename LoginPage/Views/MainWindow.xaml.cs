using LoginPage.ViewModels;
using System.Windows;

namespace LoginPage.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoginControlViewModel _loginControlViewModel;
        private readonly IMainContentViewModel _mainContentViewModel;
        public MainWindow()
        {
            _loginControlViewModel = new LoginControlViewModel();
            _mainContentViewModel = new MainContentViewModel(_loginControlViewModel);

            InitializeComponent();

            DataContext = new MainWindowViewModel(this, _mainContentViewModel);
        }
    }
}
