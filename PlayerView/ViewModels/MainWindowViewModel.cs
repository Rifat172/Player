using PlayerView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerView.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        DateModel date;

        private string _synchronizedText;
        public string SynchronizedText
        {
            get => _synchronizedText;
            set
            {
                _synchronizedText = value;
                date.MusicPath = _synchronizedText;
                OnPropertyChanged(nameof(SynchronizedText));
            }
        }

        public MainWindowViewModel()
        {
            date = new DateModel();
        }
    }
}