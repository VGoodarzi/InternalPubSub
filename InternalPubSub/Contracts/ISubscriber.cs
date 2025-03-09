using InternalPubSub.Models;

namespace InternalPubSub.Contracts;

internal interface ISubscriber
{
    Task<Message> Subscribe();
}