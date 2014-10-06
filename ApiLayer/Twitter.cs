using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Enum;

namespace ApiLayer
{
    public class Twitter : ITwitter
    {
        public Twitter()
        {
            TwitterCredentials.SetCredentials("558524769-aNkKH5YFEwICCkiYuEE39L7TMZ1EKWiqbNtVUyBe", "pf36JfR63nAVtnuj0cnVyXpPW8SzRLHwMt0se7xVCesSp", "X12Fd1N27go8dzqbGAhgKFKKV", "bKwKj8v6k6kMsH19jV7UXkq75S3BdbXAeDopI4GzuDiTc1TtHw");
        }

        public IEnumerable<string> GetLatestMessages(Hashtag hashtag)
        {
            var tweets = Search.SearchTweets(hashtag.Name);

            return tweets.Select(t => t.Text);
        }
    }
}