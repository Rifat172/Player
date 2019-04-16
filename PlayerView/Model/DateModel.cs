using PlayerView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayerView.Model
{
    public class DateModel
    {
        private string musicPath;
        private bool isStartPlay;

        public string MusicPath
        {
            get => musicPath;//A:\Project\eminem_-_celebrity_(zaycev.net).mp3
            set
            {
                musicPath = value;
            }
        }

        public bool IsStartPlay
        {
            get => isStartPlay;
            set
            {
                isStartPlay = value;
            }
        }

        private void Initialization()
        {

        }
    }
}
