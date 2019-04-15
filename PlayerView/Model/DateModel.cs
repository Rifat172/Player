using PlayerView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerView.Model
{
    public class DateModel : BaseViewModel
    {
        private string musicPath;

        public string MusicPath
        {
            get => musicPath;//A:\Project\eminem_-_celebrity_(zaycev.net).mp3
            set
            {
                musicPath = value;
                OnPropertyChanged(nameof(MusicPath));
            }
        }
    }
}
