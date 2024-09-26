namespace AlquilaFacilPlatform.Booking.Application.OutBoundService;

public interface IReservationLocalExternalService
{
    Task<bool> LocalReservationExists(int reservationId);
}