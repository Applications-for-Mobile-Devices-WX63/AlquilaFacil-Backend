using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Domain.Model.Queries;

namespace AlquilaFacilPlatform.Locals.Domain.Services;

public interface ILocalQueryService
{
    Task<IEnumerable<Local>> Handle(GetAllLocalsQuery query);
    Task<Local?> Handle(GetLocalByIdQuery query);
   HashSet<string> Handle(GetAllLocalDistrictsQuery query);


}