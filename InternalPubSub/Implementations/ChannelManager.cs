using System.Threading.Channels;
using InternalPubSub.Contracts;
using InternalPubSub.Models;

namespace InternalPubSub.Implementations;

internal class ChannelManager : IPublisher, ISubscriber
{
    private readonly Channel<Message> _channel;

    public ChannelManager()
    {
        _channel = Channel.CreateBounded<Message>(
            new BoundedChannelOptions(100_000_000)
            {
                SingleWriter = true,
                SingleReader = false,
                AllowSynchronousContinuations = false,
                FullMode = BoundedChannelFullMode.Wait
            });
    }

    public async Task Publish(Message message) 
        => await _channel.Writer.WriteAsync(message);

    public async Task<Message> Subscribe() 
        => await _channel.Reader.ReadAsync();
}