using ApiLayer;

namespace AzureAccess
{
    public interface ITableStore
    {
        bool Add(Hashtag sourceHashTag, Hashtag foundHashtag);
    }
}