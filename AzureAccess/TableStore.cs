using System;
using System.Collections.Generic;

namespace AzureAccess
{
    public class TableStore : ITableStore
    {
        private readonly IDictionary<Tuple<string, string>, Hashtag> _table;

        public TableStore(IDictionary<Tuple<string, string>, Hashtag> table)
        {
            _table = table;
        }

        public bool Add(Hashtag hashtag)
        {
            var partRowKey = Tuple.Create("RecentTags", hashtag.Name);
            _table[partRowKey] = hashtag;
            return true;
        }
    }
}