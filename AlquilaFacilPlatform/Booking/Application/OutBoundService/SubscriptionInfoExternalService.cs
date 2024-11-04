using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Interfaces.ACL;

namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public class SubscriptionInfoExternalService(ISubscriptionContextFacade subscriptionContextFacade) : ISubscriptionInfoExternalService
{
    public async Task<Subscription?> GetUserSubscriptionAsync(int userId)
    {
        return await subscriptionContextFacade.GetUserSubscriptionAsync(userId);
    }

    public bool IsUserSubscribed(int userId)
    {
        return subscriptionContextFacade.IsUserSubscribed(userId);
    }
}