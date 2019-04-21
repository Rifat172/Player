using System.Windows.Controls;
using System.Windows.Threading;

namespace PlayerView.Model
{
    public struct GeneralModel
    {
        
        public string LastTime { get; set; }
        public string NowTime { get; set; }
        public bool IsFileFound { get; set; }
        public double SliderVal { get; set; }
        public double SliderMaxVal { get; set; }
        public MediaElement Player { get; set; }
        public DispatcherTimer Timer { get; set; }

    }
}
