using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;


namespace DigitaltTestVerktygGrupp6Student.ViewModel
{
    class Timer : DispatcherTimer
    {
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        private QuizViewmodel viewModel;
        public event Action TimeOver;

        public Timer(int minutes)
        {
            viewModel = QuizViewmodel.Instance;
            Minutes = minutes;
            Tick += new EventHandler(ClockTick);
            Interval = new TimeSpan(10000000);
        }

        private void ClockTick(object sender, EventArgs e)
        {
            if (Minutes == 0 && Seconds == 0)
                TimeOver.Invoke();
            else if (Seconds == 0)
            {
                Seconds = 59;
                Minutes--;
            }
            else
            {
                Seconds--;
            }
            viewModel.OnPropertyChanged("DisplayTimer");
        }
    }
}
