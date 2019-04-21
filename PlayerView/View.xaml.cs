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
        MainViewModel viewModel;
        public View()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            viewModel = (MainViewModel)DataContext;
        }
        
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            slider.SelectionEnd = e.NewValue;
            
            viewModel.ChangTime(slider.Value);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            viewModel.ClosePlayer();

        }
    }
}
