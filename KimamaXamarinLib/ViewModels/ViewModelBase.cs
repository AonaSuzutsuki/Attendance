using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KimamaXamarinLib.ViewModels
{
    public class ViewModelBase : BindableBase
    {

        protected readonly INavigation nav;

        public ViewModelBase(INavigation nav)
        {
            this.nav = nav;
        }

        public static AsyncReactiveCommand CreateAsyncReactiveCommand(Func<Task> func)
        {
            var command = new AsyncReactiveCommand();
            command.Subscribe(func);
            return command;
        }
    }
}
