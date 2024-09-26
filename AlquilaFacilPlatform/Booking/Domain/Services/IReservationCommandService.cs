using AlquilaFacilPlatform.Booking.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Booking.Domain.Services;

public interface IReservationCommandService
{
    Task<Booking.Domain.Model.Aggregates.Reservation> Handle(CreateReservationCommand reservation);
    Task<Booking.Domain.Model.Aggregates.Reservation> Handle(UpdateReservationDateCommand reservation);
    Task<Booking.Domain.Model.Aggregates.Reservation> Handle(DeleteReservationCommand reservation);
}