using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpRaven;
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
            var ravenClient = new RavenClient("https://b3c1b74d6d3c415c871b5a2d03267c2c@sentry.io/1248085");
            ravenClient.Capture(new SharpRaven.Data.SentryEvent(exception)) ;
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
