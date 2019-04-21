using PlayerView.Model;
using PlayerView.ViewModels.Commands;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
//A:\Project\e.mp3
namespace PlayerView.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private GeneralModel date;
        private FileInfo inf;
        private TimeSpan time;

        public MyCommand StartCommand { get; private set; }
        public MyCommand PauseCommand { get; private set; }
        public MyCommand SliderCommand { get; private set; }

        public MainViewModel()
        {
            date = new GeneralModel();
            date.Player = new MediaElement();

            date.LastTime = "LastTime: ";
            date.NowTime = "NowTime: ";
            date.SliderMaxVal = 1;

            date.Timer = new DispatcherTimer();
            date.Timer.Interval = TimeSpan.FromSeconds(0.1);
            date.Timer.Tick += Timer_Tick;

            date.Player.LoadedBehavior = MediaState.Manual;
            date.Player.UnloadedBehavior = MediaState.Manual;


            StartCommand = new MyCommand(Start);
            PauseCommand = new MyCommand(Pause);
        }

        public void ChangTime(double value)
        {
            date.Player.Pause();
            date.Player.Position = TimeSpan.FromSeconds(value);
            date.Player.Play();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NowTime = date.Player.Position.ToString(@"mm\:ss");
            SliderValue = date.Player.Position.TotalSeconds;
        }

        public double MaxSliderValue
        {
            get { return date.SliderMaxVal; }
            set
            {
                date.SliderMaxVal = value;
                OnPropertyChanged(nameof(MaxSliderValue));
            }
        }
        public string SynchronizedText
        {//в get можно прописать date.musicpath
            set
            {
                if (File.Exists(value))
                {
                    inf = new FileInfo(value);
                    if (inf.Extension == ".mp3")
                    {
                        date.IsFileFound = true;
                        date.Player.Source = new Uri(value);
                    }
                }
                OnPropertyChanged(nameof(SynchronizedText));
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
                OnPropertyChanged(nameof(NowTime));
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

        private void Start()
        {
            if (date.IsFileFound)
            {
                date.Player.Play();
                date.Timer.Start();
                SetLastTime();
                SetSliderMaxVal();
            }
        }

        private void Pause()
        {
            if (date.IsFileFound)
            {
                date.Player.Pause();
                date.Timer.Stop();
            }
        }
        public void ClosePlayer()
        {
            date.Player.Stop();
            date.Timer.Stop();
            date.Player.Close();
        }

        private void SetLastTime()
        {//A:\Project\e.mp3

            while (!date.Player.NaturalDuration.HasTimeSpan) ;

            time = date.Player.NaturalDuration.TimeSpan;

            LastTime = string.Format("LastTime: " + time.ToString());
        }

        private void SetSliderMaxVal()
        {
            MaxSliderValue = date.Player.NaturalDuration.TimeSpan.TotalSeconds;
        }
    }
}
//SliderValue = date.Player.Position.TotalSeconds;

//A:\Project\e.mp3