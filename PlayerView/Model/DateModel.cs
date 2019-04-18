using PlayerView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PlayerView.Model 
{
    public class DateModel : BaseViewModel
    {
        private string musicPath;
        private bool _startBtn;
        private bool _stopBtn;
        private double _sliderVal;

        public MediaElement mediaElement;

        public long val = 0;


        public DateModel()
        {
            musicPath = @"A:\Project\eminem_-_celebrity_(zaycev.net).mp3";
            mediaElement = new MediaElement();
            mediaElement.Source = new Uri(MusicPath);
            mediaElement.UnloadedBehavior = new MediaState();
        }

        public string MusicPath
        {
            get => musicPath;//A:\Project\eminem_-_celebrity_(zaycev.net).mp3
            set
            {
                musicPath = value;
                //mediaElement = new MediaElement();
                //mediaElement.Source = new Uri(MusicPath);
                //mediaElement.UnloadedBehavior = new MediaState();
            }
        }
        public double SliderVal
        {
            get => _sliderVal;
            set
            {
                _sliderVal = value;
            }
        }

             

        public bool StartBtn
        {
            get => _startBtn;
            set
            {
                _startBtn = value;
            }
        }
        public bool StopBtn
        {
            get => _stopBtn;
            set
            {
                _stopBtn = value;
            }
        }
        public void Init()
        {
            if (!string.IsNullOrWhiteSpace(MusicPath) && File.Exists(MusicPath))
            {
                if (StartBtn)
                    PlayMusic();
                else if (StopBtn)
                    StopMusic();
            }
        }


        private void PlayMusic()
        {
            mediaElement.Play();

            OnPropertyChanged(nameof(mediaElement.Position));
        }

        private void StopMusic()
        {
            mediaElement.Stop();
        }
    }
}
