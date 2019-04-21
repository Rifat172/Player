using PlayerView.Model;
using PlayerView.ViewModels.Commands;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Threading;
//A:\Project\e.mp3
namespace PlayerView.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private GeneralModel date;
        private FileInfo inf;

        public bool IsSliderActiv { get; set; }
        public MyCommand StartCommand { get; private set; }
        public MyCommand PauseCommand { get; private set; }


        public MainViewModel()
        {
            date = new GeneralModel();
            date.Player = new MediaElement();

            date.LastTime = string.Empty;
            date.NowTime = string.Empty;
            date.SliderMaxVal = 10;
            date.IsFirstSetVal = true;

            date.Timer = new DispatcherTimer();
            date.Timer.Interval = TimeSpan.FromSeconds(0.1);
            date.Timer.Tick += Timer_Tick;

            date.Player.LoadedBehavior = MediaState.Manual;
            date.Player.UnloadedBehavior = MediaState.Manual;


            StartCommand = new MyCommand(Start);
            PauseCommand = new MyCommand(Pause);
        }

        public void ChangePosition(double value)
        {
            date.Player.Position = TimeSpan.FromSeconds(value);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NowTime = date.Player.Position.ToString(@"mm\:ss");

            if (!IsSliderActiv)
                SliderValue = date.Player.Position.TotalSeconds;

            if (date.Player != null && SliderValue == MaxSliderValue)
            {
                date.Player.Stop();
                date.Timer.Stop();
            }
            if (date.Player != null && date.IsFirstSetVal)
            {
                SetLastTime();
                SetSliderMaxVal();
                date.IsFirstSetVal = false;
            }
        }

        public void Start()
        {
            if (date.Player != null && date.IsFileFound)
            {
                date.Player.Play();
                date.Timer.Start();
                IsSliderActiv = false;
            }
        }

        public void Pause()
        {
            if (date.Player != null && date.IsFileFound)
            {
                date.Player.Pause();
                date.Timer.Stop();
            }
        }
        public void ClosePlayer()
        {
            if (date.Player != null)
            {
                date.Player.Stop();
                date.Player.Close();
            }
            if (date.Timer != null)
                date.Timer.Stop();

        }

        private void SetLastTime()
        {//A:\Project\e.mp3

            while (!date.Player.NaturalDuration.HasTimeSpan) ;

            LastTime = date.Player.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        }

        private void SetSliderMaxVal()
        {
            MaxSliderValue = date.Player.NaturalDuration.TimeSpan.TotalSeconds;
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
                        date.Player.Source = new Uri(value);
                        date.IsFileFound = true;
                    }
                    else
                    {
                        date.IsFileFound = false;
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
        public double MaxSliderValue
        {
            get { return date.SliderMaxVal; }
            set
            {
                date.SliderMaxVal = value;
                OnPropertyChanged(nameof(MaxSliderValue));
            }
        }
    }

}
//SliderValue = date.Player.Position.TotalSeconds;

//A:\Project\e.mp3