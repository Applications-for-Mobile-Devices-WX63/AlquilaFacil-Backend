using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.ACL;

public interface ISubscriptionContextFacade
{
    Task<Subscription?> GetUserSubscriptionAsync(int userId);
    bool IsUserSubscribed(int userId);
}