using LoginPage.Animations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LoginPage.Views
{
    public class BaseControl : UserControl
    {
        public UserControlAnimation ControlLoadAnimation { get; set; } = UserControlAnimation.SlideAndFadeInFromRight;
        public UserControlAnimation ControlUnloadAnimation { get; set; } = UserControlAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.9f;

        public BaseControl()
        {
            if (ControlLoadAnimation == UserControlAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loded;
        }

        private async void BasePage_Loded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (ControlLoadAnimation == UserControlAnimation.None)
                return;


            switch (ControlLoadAnimation)
            {
                case UserControlAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
            }

        }

        public async Task AnimateOut()
        {
            if (ControlUnloadAnimation == UserControlAnimation.None)
                return;


            switch (ControlUnloadAnimation)
            {
                case UserControlAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds);
                    break;
            }

        }
    }
}
