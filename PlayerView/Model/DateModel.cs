using PlayerView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace PlayerView.Model
{
    public class DateModel
    {
        private string musicPath;
        private bool _startBtn;
        private bool _stopBtn;

        public string MusicPath
        {
            get => musicPath;//A:\Project\eminem_-_celebrity_(zaycev.net).mp3
            set
            {
                musicPath = value;
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
            MessageBox.Show(String.Format("Нажата кнопка PlayBtn start={0} stop={1}", StartBtn, StopBtn));
        }

        private void StopMusic()
        {
            MessageBox.Show(String.Format("Нажата кнопка StopBtn start={0} stop={1}", StartBtn, StopBtn));
        }
    }
}
