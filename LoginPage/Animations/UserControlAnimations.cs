using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace LoginPage.Animations
{
    public static class UserControlAnimations
    {
        public static async Task SlideAndFadeInFromRight(this UserControl userControl, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, userControl.ActualWidth);

            sb.AddFadeIn(seconds);

            sb.Begin(userControl);

            userControl.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000)).ConfigureAwait(false);
        }

        public static async Task SlideAndFadeOutToLeft(this UserControl userControl, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, userControl.ActualWidth);

            sb.AddFadeOut(seconds);

            sb.Begin(userControl);

            userControl.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000)).ConfigureAwait(false);
        }
    }
}
