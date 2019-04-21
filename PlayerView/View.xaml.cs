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
        double val = 0;
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
            val = slider.Value;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            viewModel.ClosePlayer();
        }
        
        private void SliderMy_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.ChangePosition(val);
            viewModel.Start();
        }

        private void SliderMy_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.IsSliderActiv = true;
        }

    }
}
