using AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Booking.Interfaces.REST.Resources;

public record ReservationDetailsResource(IEnumerable<ReservationResource> Reservations, IEnumerable<SubscriptionResource> UserSubscriptions );