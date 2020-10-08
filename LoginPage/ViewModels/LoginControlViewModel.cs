using System.Text.RegularExpressions;

namespace LoginPage.ViewModels
{
    public class LoginControlViewModel : ViewModelBase, ILoginControlViewModel
    {
        private readonly static Regex _emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        private string _emailInput = string.Empty;
        private bool _isEmailValid = true;
        private bool _errorOccured = false;

        public double LoginButtonClickScale { get; set; } = 0.2d;
        public double LoginInputFormScale { get; set; } = 0.7d;

        public bool ErrorOccured
        {
            get => _errorOccured;
            set => SetField(ref _errorOccured, value, nameof(ErrorOccured));
        }

        public bool IsEmailValid
        {
            get => _isEmailValid;
            set => SetField(ref _isEmailValid, value, nameof(IsEmailValid));
        }

        public string EmailInput
        {
            get => _emailInput;
            set
            {
                if (!EmailIsValid(value))
                { }
                _emailInput = value;
                SetField(ref _emailInput, value, nameof(EmailInput));
            }
        }

        public LoginControlViewModel()
        {
        }

        private bool EmailIsValid(string value)
        {
            if (string.IsNullOrEmpty(value) || _emailRegex.IsMatch(value))
            {
                IsEmailValid = true;
                return true;
            }

            IsEmailValid = false;

            return false;
        }
    }
}
