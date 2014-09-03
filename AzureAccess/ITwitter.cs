using System.Collections.Generic;

namespace AzureAccess
{
    public interface ITwitter
    {
        List<string> GetLatestMessages(Hashtag hashtag);
    }
}