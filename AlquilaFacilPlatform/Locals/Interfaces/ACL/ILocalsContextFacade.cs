namespace AlquilaFacilPlatform.Locals.Interfaces.ACL;

public interface ILocalsContextFacade
{
    Task<int> CreateLocal(string district, string street, string localType, string country, string city,
        int price, string photoUrl, string descriptionMessage, int localCategoryId, int userId,string features,int capacity);

    Task<bool> LocalExists(int localId);
}