using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AzureAccess;

namespace TaskProcessor
{
    public class HashtagProcessor
    {
        private readonly IQueue _queue;
        private readonly ITableStore _tableStore;
        private readonly ITwitter _twitter;

        public HashtagProcessor(IQueue queue, ITableStore tableStore, ITwitter twitter)
        {
            _queue = queue;
            _tableStore = tableStore;
            _twitter = twitter;
        }

        public void GetRecentHashtags()
        {
            var hashTag = _queue.Dequeue();

            var messages = _twitter.GetLatestMessages(hashTag);

            var hashtags = new List<Hashtag>();
            foreach (var message in messages)
            {
                hashtags.AddRange(message.Split(' ').Where(word => word.StartsWith("#")).Select(tag => new Hashtag { Name = tag }));
            }

            foreach (var relatedHashtags in hashtags.Distinct())
            {
                _tableStore.Add(relatedHashtags);
            }
        }
    }
}