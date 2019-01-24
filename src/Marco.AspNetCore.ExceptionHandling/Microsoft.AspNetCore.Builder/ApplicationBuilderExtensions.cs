using Marco.AspNetCore.ExceptionHandling;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMarcoExceptionHandling(this IApplicationBuilder applicationBuilder)
        {
            if (applicationBuilder == null)
                throw new ArgumentNullException(nameof(applicationBuilder));

            applicationBuilder.UseMiddleware<ExceptionMiddleware>();

            return applicationBuilder;
        }
    }
}