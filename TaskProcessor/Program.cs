using System;
using System.Collections.Generic;
using AzureAccess;
using Microsoft.Azure.WebJobs;

namespace TaskProcessor
{
    // To learn more about Windows Azure WebJobs start here http://go.microsoft.com/fwlink/?LinkID=320976
    internal class Program
    {
        // Please set the following connectionstring values in app.config
        // AzureWebJobsDashboard and AzureWebJobsStorage
        private static void Main()
        {
            var host = new JobHost();
            host.RunAndBlock();
        }

        public static void ProcessQueueMessage(
            [QueueTrigger("RecentTagQueue")] string hashtag,
            [Table("RelatedTags")] IDictionary<Tuple<string,string>, Hashtag> table)
        {
            var hashtagProcessor = new HashtagProcessor(new TableStore(table), new Twitter());
            hashtagProcessor.GetRecentHashtags(new Hashtag{Name = hashtag});
        }
    }
}