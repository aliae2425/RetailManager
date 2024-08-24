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
        private LoginViewModel _loginVM;
        private SalesViewModel _salesVM;
        private IEventAggregator _events;
        private SimpleContainer _container;
        public ShellViewModel(SalesViewModel SalesVM, IEventAggregator events, SimpleContainer container)
        {
            _events = events;
            _salesVM = SalesVM;
            _container = container;

            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
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
