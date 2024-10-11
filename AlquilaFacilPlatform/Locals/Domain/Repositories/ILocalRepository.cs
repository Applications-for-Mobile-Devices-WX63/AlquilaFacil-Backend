using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Domain.Model.ValueObjects;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Locals.Domain.Repositories;

public interface ILocalRepository : IBaseRepository<Local>
{
   HashSet<string> GetAllDistrictsAsync();
}