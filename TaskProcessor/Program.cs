using System;
using AzureAccess;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace TaskProcessor
{
    internal class Program
    {
        private const string QueueName = "RecentTagQueue";
        
        private static void Main()
        {
            var host = new JobHost();
            host.RunAndBlock();
        }

        public static void ProcessQueueMessage(
            [QueueTrigger(QueueName)] string hashtag, 
            [Table(TableStore.TableName)]CloudTable table)
        {
            Console.WriteLine("received hashtag:" + hashtag);
            var hashtagProcessor = new HashtagProcessor(new TableStore(table), new Twitter());
            hashtagProcessor.AddRecentHashtagsToTable(new Hashtag { Name = hashtag });
        }

        public static void AddToRecentTagQueue(string hashtag, [Queue(QueueName)]CloudQueue queue, [Table(TableStore.TableName)]CloudTable table)
        {
            queue.CreateIfNotExists();
            table.CreateIfNotExists();

            queue.AddMessage(new CloudQueueMessage(hashtag));
        }
    }
}