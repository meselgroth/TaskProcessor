using System.Collections.Generic;

namespace ApiLayer
{
    public interface ITwitter
    {
        IEnumerable<string> GetLatestMessages(Hashtag hashtag);
    }
}