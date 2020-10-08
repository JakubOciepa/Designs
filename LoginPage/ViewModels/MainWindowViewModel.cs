using LoginPage.Models;
using System.Windows;
using System.Windows.Input;

namespace LoginPage.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Window _mainWindow;
        private readonly IMainContentViewModel _mainContentViewModel;

        private int _outerMarginSize = 10;
        private int _mainWindowRadius = 10;
        private int _cornerRadius = 6;

        public int ResizeBorder { get; set; } = 6;

        public int TitleHeight { get; set; } = 28;

        public int OuterMargin
        {
            get => _mainWindow.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => SetField(ref _outerMarginSize, value);
        }

        public int CornerRadiu
        {
            get => _cornerRadius;
            set => SetField(ref _cornerRadius, value);
        }

        public int WindowRadius
        {
            get => _mainWindow.WindowState == WindowState.Maximized ? 0 : _mainWindowRadius;
            set => SetField(ref _mainWindowRadius, value);
        }

        public Thickness ResizeBorderThikness => new Thickness(ResizeBorder + OuterMargin);

        public Thickness OuterMarginThikness => new Thickness(OuterMargin);

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public GridLength TitleHeightGridLenght => new GridLength(TitleHeight + ResizeBorder);

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        public MainWindowViewModel(Window window, IMainContentViewModel mainContentViewModel)
        {
            _mainWindow = window;
            _mainContentViewModel = mainContentViewModel;

            _mainWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThikness));
                OnPropertyChanged(nameof(OuterMargin));
                OnPropertyChanged(nameof(OuterMarginThikness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand<Window>(_ => _mainWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand<Window>(_ => _mainWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand<Window>(_ => _mainWindow.Close());
            MenuCommand = new RelayCommand<Window>(_ => SystemCommands.ShowSystemMenu(_mainWindow, GetMousePosition()));
        }

        private Point GetMousePosition()
        {
            var mousePosition = Mouse.GetPosition(_mainWindow);
            return new Point(mousePosition.X + _mainWindow.Left, mousePosition.Y + _mainWindow.Top);
        }
    }
}
