using PlayerView.Model;
using PlayerView.ViewModels.Commands;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
//A:\Project\eminem_-_celebrity_(zaycev.net).mp3
namespace PlayerView.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private GeneralModel date;
        private FileInfo inf;
        private TimeSpan time;

        public MyCommand StartCommand { get; private set; }
        public MyCommand StopCommand { get; private set; }

        public MainWindowViewModel()
        {
            date = new GeneralModel();
            date.Player = new MediaPlayer();

            date.LastTime = "LastTime: ";
            date.NowTime = "Now: ";

            StartCommand = new MyCommand(Start);
            StopCommand = new MyCommand(Stop);
        }

        public string SynchronizedText
        {
            get => date.MusicPath;
            set
            {
                if (File.Exists(value))
                {
                    inf = new FileInfo(value);
                    if (inf.Extension == ".mp3")
                    {
                        date.IsFileFound = true;
                        date.MusicPath = value;
                    }
                }
                OnPropertyChanged(nameof(SynchronizedText));
            }
        }

        public double SliderValue
        {
            get => date.SliderVal;
            set
            {
                if (value != date.SliderVal)
                {
                    date.SliderVal = value;
                    OnPropertyChanged(nameof(SliderValue));
                }
            }
        }

        public void Start()
        {
            if (date.IsFileFound)
            {
                date.Player.Open(new Uri(date.MusicPath));
                date.Player.Play();
                AudoiPlay();
                Thread thread = new Thread(new ThreadStart(ChangeTime));
                thread.Start();
            }
        }

        public void Stop()
        {
            if (date.IsFileFound)
            {
                date.Player.Stop();
            }
        }

        public string LastTime
        {
            get => date.LastTime;
            set
            {
                date.LastTime = value;
                OnPropertyChanged(nameof(LastTime));
            }
        }
        public string NowTime
        {
            get => date.NowTime;
            set
            {
                date.NowTime = value;
                OnPropertyChanged(nameof(LastTime));
            }
        }
        private void ChangeTime()
        {
            while (date.Player.Position <= time)
            {
                NowTime = string.Format("NowTime: " + date.Player.Position);
            }
        }

        private void AudoiPlay()
        {//A:\Project\eminem_-_celebrity_(zaycev.net).mp3
            
            do
            {
                if (date.Player.NaturalDuration.HasTimeSpan)
                {
                    time = date.Player.NaturalDuration.TimeSpan;
                    break;
                }
            } while (true);
            LastTime = string.Format("LastTime: " + time.ToString());
        }
    }
}