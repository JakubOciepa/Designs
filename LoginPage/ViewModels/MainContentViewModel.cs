namespace LoginPage.ViewModels
{
    public class MainContentViewModel : ViewModelBase, IMainContentViewModel
    {
        private readonly ILoginControlViewModel _loginControlViewModel;
        public ILoginControlViewModel LogiControlViewModel
            => _loginControlViewModel;

        public MainContentViewModel(ILoginControlViewModel loginControlViewModel)
        {
            _loginControlViewModel = loginControlViewModel;
        }
    }
}
