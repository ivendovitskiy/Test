using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TestCoreApp.Data;
using TestCoreApp.Models;
using TestCoreApp.Services.Navigation;
using TestCoreApp.Utilities;

namespace TestCoreApp.ViewModels.Protocols
{
    public class ProtocolsViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService navigator;
        private readonly TestDbContext context;

        private ProtocolsViewModel()
        {
            ProtocolSearchFieldsMutators = new List<SearchFieldMutator<Protocol, ProtocolSearchModel>>
            {
                new SearchFieldMutator<Protocol, ProtocolSearchModel>
                (
                    search => !string.IsNullOrEmpty(search.SearchField),
                    (protocols, search) => protocols.Where( p => p.Id == int.Parse(search.SearchField))
                )
            };
        }

        public ProtocolsViewModel(IFrameNavigationService navigator, TestDbContext context) : this()
        {
            this.navigator = navigator;
            this.context = context;
        }

        private void LoadProtocols()
        {
            context.Protocols.Local.Clear();

            context.Protocols.Load();
        }

        public List<SearchFieldMutator<Protocol, ProtocolSearchModel>> ProtocolSearchFieldsMutators { get; set; }

        private ObservableCollection<Protocol> protocols;
        public ObservableCollection<Protocol> Protocols
        {
            get => protocols;
            set => Notify(ref protocols, value);
        }
    }
}
