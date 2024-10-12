using System.Configuration;
using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Locals.Domain.Repositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Locals.Infraestructure.Persistence.EFC.Repositories;

public class LocalRepository(AppDbContext context) : BaseRepository<Local>(context), ILocalRepository
{

    public HashSet<string> GetAllDistrictsAsync()
    {

        var placeInfo = context.Set<Local>().Select(x => " " + x.Place.City + ", " +  x.Place.Country).Distinct();
        var districtsInfo = context.Set<Local>().Select(x => x.StreetAddress).ToList();
        var districts = new HashSet<string>();
        foreach (var place in placeInfo)
        {
            foreach (var district in districtsInfo)
            {
                var districtName = district.Split(",")[0];
                districts.Add(districtName + "," + place);
            }
        }

        return districts;
    }

}
