using PlayerView.Model;
using PlayerView.ViewModels.Commands;
using System;
using System.IO;
using System.Windows.Input;

namespace PlayerView.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private DateModel date;
        private string _synchronizedText;
        private bool _isFoundFile = false;

        public StartCommand SetBoolCommand { get; private set; }

        public string SynchronizedText
        {
            get => _synchronizedText;
            set
            {
                _synchronizedText = value;
                if (IsFoundFile = File.Exists(_synchronizedText))
                {
                    date.MusicPath = _synchronizedText;
                }
                OnPropertyChanged(nameof(SynchronizedText));
            }
        }

        public void SetBool()
        {
            date.IsStartPlay = IsFoundFile;
        }

        public bool IsFoundFile
        {
            get { return _isFoundFile; }
            set
            {
                _isFoundFile = value;
                OnPropertyChanged(nameof(IsFoundFile));
            }
        }


        public MainWindowViewModel()
        {
            date = new DateModel();
            SetBoolCommand = new StartCommand(SetBool);
        }
    }
}