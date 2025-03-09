using InternalPubSub.Models;

namespace InternalPubSub.Contracts;

internal interface IPublisher
{
    Task Publish(Message message);
}