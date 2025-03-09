namespace InternalPubSub.Implementations;

internal class ChannelStats
{
    private long _subscribedMessages;
    private long _publishedMessages;
    private long QueuedMessages => _publishedMessages - _subscribedMessages;

    public void PublishMessage() => _publishedMessages++;
    public void SubscribeMessage() => _subscribedMessages++;

    public void Print()
    {
        Console.WriteLine();
        Console.WriteLine("########### Current Stats ###########");
        Console.WriteLine("Published Messages  : {0}", _publishedMessages);
        Console.WriteLine("Subscribed Messages : {0}", _subscribedMessages);
        Console.WriteLine("Queued Messages     : {0}", QueuedMessages);
        Console.WriteLine();
    }
}