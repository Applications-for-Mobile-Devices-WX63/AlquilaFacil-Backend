using AlquilaFacilPlatform.Contacts.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Contacts.Domain.Repositories;

public interface IContactRepository : IBaseRepository<Contact>
{
    IQueryable<Contact> FindContactsByUserIdAsync(int queryPropertyId);

}