using System.ComponentModel;
using System.Reflection;
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
            var field = type.GetType().GetField(type.ToString());
            if (field != null)
            {
                var attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute))!;
                {
                    var attributeDescription = attribute.Description;
                    string photoUrl;
            
                    if (type == EALocalCategoryTypes.BeachHouse)
                    {
                        photoUrl = "https://tse4.mm.bing.net/th?id=OIP.N62R-B5j13QHIL9OhcdJ1wHaHa&pid=Api&P=0&h=180";
                    }
                    else if (type == EALocalCategoryTypes.LandscapeHouse)
                    {
                        photoUrl = "https://cdn-icons-png.flaticon.com/512/74/74951.png";
                    }
                    else if (type == EALocalCategoryTypes.CityHouse)
                    {
                        photoUrl = "https://tse1.mm.bing.net/th?id=OIP.LnALBZ2Bu7Mnw46vjKeMYAHaHa&pid=Api&P=0&h=180";
                    }
                    else if (type == EALocalCategoryTypes.ElegantRoom)
                    {
                        photoUrl = "https://cdn3.iconfinder.com/data/icons/beauty-cosmetics-1-line/128/beauty-salon_beauty_salon_barbershop_glamour-512.png";
                    }
                    else
                    {
                        throw new Exception("Invalid local category type");
                    }
            
                    var localCategory = new LocalCategory(attributeDescription, photoUrl);
                    await localCategoryRepository.AddAsync(localCategory);
                }
            }
        }
        await unitOfWork.CompleteAsync();
    }
}
