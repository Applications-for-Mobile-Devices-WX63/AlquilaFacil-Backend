using AlquilaFacilPlatform.Booking.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Booking.Domain.Model.Queries;

namespace AlquilaFacilPlatform.Booking.Domain.Services;

public interface IReservationQueryService
{
    Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(GetReservationsByUserId query);
    Task<IEnumerable<Reservation>>GetReservationByStartDateAsync(GetReservationByStartDate query);
    Task<IEnumerable<Reservation>> GetReservationByEndDateAsync(GetReservationByEndDate query);
}