using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MC.WebApi.Filters
{
    /// <summary>
    /// Validation filter with fluidValidation
    /// </summary>
    public class ValidationFilterAttribute : IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ModelState.IsValid)
            {
                return;
            }

            var validationFailures = new List<ValidationFailure>();
            foreach (string keys in filterContext.ModelState.Keys)
            {
                var errors = filterContext.ModelState[keys];
                validationFailures.AddRange(errors.Errors.Select(error =>
                    new ValidationFailure(keys, error.ErrorMessage)));
            }

            throw new NotImplementedException("Validation expectation error");
            //throw new ValidationExceptionError(validationFailures);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            //Do nothing
        }
    }
}
