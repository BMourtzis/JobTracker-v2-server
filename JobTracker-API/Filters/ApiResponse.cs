using System;

namespace JobTracker_API.Filters
{
    internal class ApiResponse
    {
        private Exception exception;

        public ApiResponse(Exception exception)
        {
            this.exception = exception;
        }
    }
}