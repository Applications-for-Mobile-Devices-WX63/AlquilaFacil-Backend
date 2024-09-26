namespace AlquilaFacilPlatform.Locals.Interfaces.REST.Resources;

public record UpdateLocalResource(string District, string Street, string LocalType, string Country, string City, 
    int Price, string PhotoUrl, string DescriptionMessage, int LocalCategoryId, int UserId);