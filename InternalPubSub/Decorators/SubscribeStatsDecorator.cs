using InternalPubSub.Contracts;
using InternalPubSub.Implementations;
using InternalPubSub.Models;

namespace InternalPubSub.Decorators;

internal class SubscribeStatsDecorator(ISubscriber subscriber, ChannelStats stats) : ISubscriber
{
    public async Task<Message> Subscribe()
    {
        var message = await subscriber.Subscribe();

        stats.SubscribeMessage();

        return message;
    }
}