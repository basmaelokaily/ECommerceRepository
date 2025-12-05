using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using System.Net;

namespace ECommerce.Factories
{
    public class ApiResponseFactory
    {
        //context > modelState => dictionary <string, ModelEntry>
        //string => key, name of parameter
        //modelStateDictionary => objects, errors
        public static IActionResult CustomValidationErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.Where(error => error.Value.Errors.Any())
                .Select(error => new ValidationError
                {
                    Field = error.Key,
                    Errors = error.Value.Errors.Select(e => e.ErrorMessage)
                });
            //create a custom response
            var response = new ValidationErrorResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                ErrorMessage = "Validation Failed",
                Errors = errors
            };
            return new BadRequestObjectResult(response);
        }
    }
}
