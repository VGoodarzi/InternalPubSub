using InternalPubSub.Contracts;
using InternalPubSub.Implementations;
using InternalPubSub.Models;

namespace InternalPubSub.Decorators;

internal class PublishStatsDecorator(IPublisher publisher, ChannelStats stats) : IPublisher
{
    public async Task Publish(Message message)
    {
        await publisher.Publish(message);

        stats.PublishMessage();
    }
}