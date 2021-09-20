using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace A_Star_Algorithm_Virtualization.ViewModels
{
    public class RCommand : ICommand
    {
        #region RelayFields
        readonly Action<object> exec;
        readonly Predicate<object> canExec;
        #endregion

        #region RelayConstructors
        public RCommand(Action<object> exec)
            : this(exec, null)
        {

        }

        public RCommand(Action<object> exec, Predicate<object> canExec)
        {
            this.exec = exec ?? throw new ArgumentNullException("exec");
            this.canExec = canExec;
        }
        #endregion

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region ICommand RelayMembers
        [DebuggerStepThrough]
        public bool CanExecute(object param)
        {
            return canExec == null || canExec(param);
        }

        public void Execute(object param)
        {
            exec(param);
        }
        #endregion
    }
}
