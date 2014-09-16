using Microsoft.WindowsAzure.Storage.Table;

namespace AzureAccess
{
    public class HashtagEntity : TableEntity
    {
        public string HashtagName { get; set; }
    }
}