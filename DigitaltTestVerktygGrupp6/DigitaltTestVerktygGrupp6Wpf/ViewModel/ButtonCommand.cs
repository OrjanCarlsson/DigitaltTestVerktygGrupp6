using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace DigitaltTestVerktygGrupp6Wpf.ViewModel
{
    class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event Action<string> Call;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Call.Invoke(parameter as string);
        }
    }
}
