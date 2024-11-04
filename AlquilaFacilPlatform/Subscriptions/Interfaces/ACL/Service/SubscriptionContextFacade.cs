using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Queries;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.ACL.Service;

public class SubscriptionContextFacade(ISubscriptionQueryServices subscriptionQueryServices) : ISubscriptionContextFacade
{
    public async Task<Subscription?> GetUserSubscriptionAsync(int userId)
    {
        var query = new GetSubscriptionByUserIdQuery(userId);
        return await subscriptionQueryServices.Handle(query);
    }

    public bool IsUserSubscribed(int userId)
    {
        var subscription = GetUserSubscriptionAsync(userId).Result;
        if (subscription == null)
        {
            throw new Exception("Subscription not found");
        }
        return subscription.SubscriptionStatusId == (int)ESubscriptionStatus.Active;
    }
}