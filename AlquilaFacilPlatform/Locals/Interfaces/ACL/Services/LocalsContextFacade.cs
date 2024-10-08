using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Locals.Domain.Services;

namespace AlquilaFacilPlatform.Locals.Interfaces.ACL.Services;

public class LocalsContextFacade(ILocalCommandService localCommandService, ILocalQueryService localQueryService) : ILocalsContextFacade
{
    public async Task<int> CreateLocal(string district, string street, string localType, string country, string city, 
                int price, string photoUrl, string descriptionMessage, int localCategoryId, int userId, string features,int capacity)
    {
        var createLocalCommand = new CreateLocalCommand(district, street, localType, country, city, price, photoUrl, descriptionMessage ,localCategoryId, userId,features,capacity);
        var local = await localCommandService.Handle(createLocalCommand);
        return local?.Id ?? 0;
    }

    public async Task<bool> LocalExists(int localId)
    {
        var query = new GetLocalByIdQuery(localId);
        var local = await localQueryService.Handle(query);
        if (local == null)
        {
            throw new Exception("Local not found");
        }

        return true;
    }
}