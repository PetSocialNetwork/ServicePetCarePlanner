﻿namespace ServicePetCarePlanner.WebApi.Models.Responses
{
    public record ErrorResponse(string Message, int? HttpStatusCode = null);
}
