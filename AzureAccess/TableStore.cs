using System;
using ApiLayer;
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

        public bool Add(Hashtag sourceHashTag, Hashtag foundHashtag)
        {
            var hashTagRow = new HashtagEntity
            {
                PartitionKey = sourceHashTag.Name,
                RowKey = foundHashtag.Name,

                HashtagName = foundHashtag.Name
            };
            Console.WriteLine("Saving to table {0} HashtagEntity\n\tPartitionKey:{1}\n\tRowKey:{2}", _table.Name, hashTagRow.PartitionKey, hashTagRow.RowKey);

            var operation = TableOperation.InsertOrReplace(hashTagRow);
            _table.Execute(operation);

            return true;
        }

        public const string TableName = "RelatedTags";
    }
}