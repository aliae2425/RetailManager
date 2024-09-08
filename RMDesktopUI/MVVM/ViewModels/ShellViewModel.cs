using Caliburn.Micro;
using RMDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMDesktopUI.MVVM.ViewModels
{
    internal class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private SalesViewModel _salesVM;
        private IEventAggregator _events;
        public ShellViewModel(SalesViewModel SalesVM, IEventAggregator events)
        {
            _events = events;
            _salesVM = SalesVM;

            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }



        Task IHandle<LogOnEvent>.HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            try
            {
                ActivateItemAsync(_salesVM);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
