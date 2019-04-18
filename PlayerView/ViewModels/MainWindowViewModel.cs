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

        public MyCommand StartCommand { get; private set; }
        public MyCommand StopCommand { get; private set; }

        private bool startB = false;
        private bool stopB = false;
        private double _sliderValue;

        public string SynchronizedText
        {
            get => _synchronizedText;
            set
            {
                _synchronizedText = value;
                if (File.Exists(_synchronizedText))
                {
                    date.MusicPath = _synchronizedText;
                }
                OnPropertyChanged(nameof(SynchronizedText));
            }
        }

        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                if(value != _sliderValue)
                {
                    _sliderValue = value;
                    date.SliderVal = SliderValue;
                    OnPropertyChanged(nameof(SliderValue));
                }
            }
        }

        public void Start()
        {
            startB = true;
            if (stopB)
            {
                stopB = false;
                date.StopBtn = stopB;
            }
            date.StartBtn = startB;
            date.Init();
        }

        public void Stop()
        {
            stopB = true;
            if (startB)
            {
                startB = false;
                date.StartBtn = startB;
            }
            date.StopBtn = stopB;
            date.Init();
        }

        public MainWindowViewModel()
        {
            date = new DateModel();

            StartCommand = new MyCommand(Start);
            StopCommand = new MyCommand(Stop);
        }
    }
}