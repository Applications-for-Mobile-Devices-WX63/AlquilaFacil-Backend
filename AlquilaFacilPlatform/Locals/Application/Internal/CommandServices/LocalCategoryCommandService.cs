using AlquilaFacilPlatform.Locals.Domain.Model.Commands;
using AlquilaFacilPlatform.Locals.Domain.Model.Entities;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Locals.Domain.Repositories;
using AlquilaFacilPlatform.Locals.Domain.Services;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Locals.Application.Internal.CommandServices;

public class LocalCategoryCommandService(ILocalCategoryRepository localCategoryRepository, IUnitOfWork unitOfWork) : ILocalCategoryCommandService
{
    
    public async Task Handle(SeedLocalCategoriesCommand command)
    {
        foreach ( EALocalCategoryTypes type in Enum.GetValues(typeof(EALocalCategoryTypes)))
        {
            if (await localCategoryRepository.ExistsLocalCategory(type)) continue;
            var localCategory = new LocalCategory(type.ToString());
            await localCategoryRepository.AddAsync(localCategory);
        }
        await unitOfWork.CompleteAsync();
    }
}