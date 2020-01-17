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
                    search => int.TryParse(search.SearchField, out _),
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

        public string SearchString
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var query = context.Protocols.Include(p => p.Devices).AsNoTracking().AsQueryable();

                    foreach(var searchFieldMutator in ProtocolSearchFieldsMutators)
                    {
                        query = searchFieldMutator.Apply(new ProtocolSearchModel { SearchField = value, SearchInClosed = true }, query);
                    }

                    ProtocolsSearchResult = query.ToList();
                }
            }
        }

        private List<Protocol> protocolsSearchResult;
        public List<Protocol> ProtocolsSearchResult
        {
            get => protocolsSearchResult;
            set => Notify(ref protocolsSearchResult, value);
        } 

        private ObservableCollection<Protocol> protocols;
        public ObservableCollection<Protocol> Protocols
        {
            get => protocols;
            set => Notify(ref protocols, value);
        }
    }
}
