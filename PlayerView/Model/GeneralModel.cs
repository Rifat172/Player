using System.Windows.Media;

namespace PlayerView.Model
{
    public struct GeneralModel
    {

        public string MusicPath { get; set; }
        public string LastTime { get; set; }
        public string NowTime { get; set; }
        public bool IsFileFound { get; set; }
        public double SliderVal { get; set; }
        public MediaPlayer Player { get; set; }
        
    }
}
