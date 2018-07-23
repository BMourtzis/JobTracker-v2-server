using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace JobTracker_API.Filters
{
    public class ErrorHandlingFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HandleExceptionAsync(context);
            context.ExceptionHandled = true;
        }

        private static void HandleExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;

            // if internal register in sentry
            SetExceptionResult(context, exception, HttpStatusCode.InternalServerError);
        }

        private static void SetExceptionResult(ExceptionContext context, Exception exception, HttpStatusCode code)
        {
            context.Result = new JsonResult(new ApiResponse(exception))
            {
                StatusCode = (int)code
            };
        }
    }
}
