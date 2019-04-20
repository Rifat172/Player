using PlayerView.Model;
using PlayerView.ViewModels.Commands;
using System;
using System.IO;
using System.Windows.Media;
//A:\Project\e.mp3
namespace PlayerView.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private GeneralModel date;
        private FileInfo inf;
        private TimeSpan time;

        public MyCommand StartCommand { get; private set; }
        public MyCommand StopCommand { get; private set; }
        public MyCommand CloseApp { get; private set; }

        public MainViewModel()
        {
            date = new GeneralModel();
            date.Player = new MediaPlayer();

            date.LastTime = "LastTime: ";
            date.NowTime = "NowTime: ";
            date.SliderMaxVal = 10;

            StartCommand = new MyCommand(Start);
            StopCommand = new MyCommand(Stop);
            CloseApp = new MyCommand(ClosePlayer);
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
                date.Player.Open(new Uri(date.MusicPath));
                date.Player.Play();
                SetLastTime();
                SetSliderMaxVal();
            }
        }

        public void Stop()
        {
            if (date.IsFileFound)
            {
                date.Player.Stop();
            }
        }
        public void ClosePlayer()
        {
            if (date.IsFileFound)
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
            MaxSliderValue = Math.Round(time.TotalSeconds);
        }
    }
}