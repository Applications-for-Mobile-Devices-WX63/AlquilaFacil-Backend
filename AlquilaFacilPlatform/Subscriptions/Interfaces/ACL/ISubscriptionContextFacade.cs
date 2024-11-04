using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.ACL;

public interface ISubscriptionContextFacade
{
    Task<IEnumerable<Subscription>> GetSubscriptionByUsersId(List<int> usersId);
    bool IsUserSubscribed(int userId);
}