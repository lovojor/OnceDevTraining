using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnceDev.Training.Api.Middlewares
{
    public class ResponseWrapperMiddleware
    {

        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Stream originalBody = httpContext.Response.Body;

            try
            {
                using (var memStream = new MemoryStream())
                {
                    httpContext.Response.Body = memStream;

                    await _next(httpContext);

                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();

                    ResponseWrap<String> wrap = new ResponseWrap<String>(responseBody);

                    var fullRs = JsonSerializer.Serialize(wrap);

                    // convert string to stream
                    byte[] byteArray = Encoding.UTF8.GetBytes(fullRs);
                    //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
                    using (var fullRsMemStream = new MemoryStream(byteArray))
                    {
                        fullRsMemStream.Position = 0;
                        httpContext.Response.ContentLength = byteArray.Length;
                        await fullRsMemStream.CopyToAsync(originalBody);
                    }
                }

            }
            finally
            {
                httpContext.Response.Body = originalBody;
            }

        }

    }
}
