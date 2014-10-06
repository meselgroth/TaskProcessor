namespace AzureAccess
{
    public interface IQueue
    {
        HashtagEntity Dequeue();
    }
}
