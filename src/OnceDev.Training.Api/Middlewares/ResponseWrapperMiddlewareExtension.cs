using Microsoft.AspNetCore.Builder;
using OnceDev.Training.Api.Middlewares;

namespace OnceDev.Training.Api
{
    public static class ResponseWrapperMiddlewareExtension
    {

        public static IApplicationBuilder UseResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseWrapperMiddleware>();
        }

    }
}
