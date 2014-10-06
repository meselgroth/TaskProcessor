using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ApiLayer;
using AzureAccess;

namespace TaskProcessor
{
    public class HashtagProcessor
    {
        private readonly ITableStore _tableStore;
        private readonly ITwitter _twitter;

        public HashtagProcessor(ITableStore tableStore, ITwitter twitter)
        {
            _tableStore = tableStore;
            _twitter = twitter;
        }

        public void AddRecentHashtagsToTable(Hashtag sourceHashTag)
        {
            var messages = _twitter.GetLatestMessages(sourceHashTag);

            var foundHashtags = new List<Hashtag>();
            foreach (var message in messages)
            {
                foundHashtags.AddRange(message.Split(' ').Where(word => word.StartsWith("#")).Select(tag => new Hashtag { Name = tag.Substring(1, tag.Length - 1) }));
            }

            foreach (var foundHashtag in foundHashtags.Distinct())
            {
                _tableStore.Add(sourceHashTag, foundHashtag);
            }
        }
    }
}