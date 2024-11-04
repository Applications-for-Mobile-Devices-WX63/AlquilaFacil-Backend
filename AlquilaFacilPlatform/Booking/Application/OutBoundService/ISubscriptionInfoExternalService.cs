using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public interface ISubscriptionInfoExternalService
{
    Task<Subscription?> GetUserSubscriptionAsync(int userId);
    bool IsUserSubscribed(int userId);
}