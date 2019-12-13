using Models;
using System;
using System.Collections.Generic;
using System.Text;
using TestCoreApp.Data;
using TestCoreApp.Services.Navigation;

namespace TestCoreApp.ViewModels.Testing
{
    public class ProtocolViewModel : ViewModelBase
    {
        private ProtocolViewModel()
        {

        }

        public ProtocolViewModel(IFrameNavigationService navigator, TestDbContext context) : this()
        {
            this.navigator = navigator;
            this.context = context;
        }

        private readonly IFrameNavigationService navigator;
        private readonly TestDbContext context;

        private Protocol protocol;
        public Protocol Protocol
        {
            get => protocol;
            set => Notify(ref protocol, value);
        }
    }
}
