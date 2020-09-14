using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DesafioApi2.Host.Middleware
{
    public class JsonExceptionMiddleware
    {
        private IWebHostEnvironment environment;

        public JsonExceptionMiddleware(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            object error;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            var x = ex;

            if (ex == null) return;
            if (x != null)
            {
                error = new
                {
                    ex.Message,
                    ExceptionMessage = ex.Message,
                    ExceptionType = ex.GetType().ToString()
                };
            }
            else
            {
                error = new
                {
                    ex.Message,
                    ExceptionMessage = ex.Message,
                    ExceptionType = ex.GetType().ToString()
                };
            }

            context.Response.ContentType = "application/json";

            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, error);
                await writer.FlushAsync();
            }
        }
    }
}
