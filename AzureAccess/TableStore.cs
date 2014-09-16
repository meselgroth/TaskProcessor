using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureAccess
{
    public class TableStore : ITableStore
    {
        private readonly CloudTable _table;

        public TableStore(CloudTable table)
        {
            _table = table;
        }

        public bool Add(Hashtag hashtag)
        {
            var hashTagRow = new HashtagEntity
            {
                PartitionKey = "",
                RowKey = hashtag.Name,

                HashtagName = hashtag.Name
            };

            var operation = TableOperation.InsertOrReplace(hashTagRow);
            _table.Execute(operation);

            return true;
        }

        public const string TableName = "RelatedTags";
    }
}