using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Interfaces.ACL;

namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public class ReservationLocalExternalService(ILocalsContextFacade localsContextFacade) : IReservationLocalExternalService
{
    public Task<bool> LocalReservationExists(int reservationId)
    {
        return localsContextFacade.LocalExists(reservationId);
    }

    public async Task<IEnumerable<Local?>> GetLocalsByUserId(int userId)
    {
        return await localsContextFacade.GetLocalsByUserId(userId);
    }
}