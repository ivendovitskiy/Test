using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCoreApp.Utilities
{
    public class SearchFieldMutator<TItem, TSearch> : NotifyPropertyChangedBase
    {
        private Predicate<TSearch> condition;
        private QueryMutator<TItem, TSearch> mutator;

        public SearchFieldMutator(Predicate<TSearch> condition, QueryMutator<TItem, TSearch> mutator)
        {
            this.condition = condition;
            this.mutator = mutator;
        }

        public IQueryable<TItem> Apply(TSearch search, IQueryable<TItem> query)
        {
            return Condition(search) ? Mutator(query, search) : query;
        }

        public Predicate<TSearch> Condition
        {
            get => condition;
            set => condition = value;
        }

        public QueryMutator<TItem, TSearch> Mutator
        {
            get => mutator;
            set => mutator = value;
        }
    }
}
