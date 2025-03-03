using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ServicePetCarePlanner.WebApi.Models.Responses;
using ServicePetCarePlanner.Domain.Exceptions;

namespace ServicePetCarePlanner.WebApi.Filters
{
    public class CentralizedExceptionHandlingFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var (message, statusCode) = TryGetUserMessageFromException(context);

            if (message != null && statusCode != 0)
            {
                context.Result = new ObjectResult(new ErrorResponse(message, statusCode))
                {
                    StatusCode = statusCode
                };
                context.ExceptionHandled = true;
            }
        }

        private (string?, int) TryGetUserMessageFromException(ExceptionContext context)
        {
            return context.Exception switch
            {
                RecordNotFoundException => ("Запись не найдена", StatusCodes.Status400BadRequest),
                Exception => ("Неизвестная ошибка!", StatusCodes.Status500InternalServerError),
                _ => (null, 0)
            };
        }
    }
}