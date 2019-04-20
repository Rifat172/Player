using PlayerView.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace PlayerView
{
    /// <summary>
    /// Логика взаимодействия для View.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
        }
    }
}
