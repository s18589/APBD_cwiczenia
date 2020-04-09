using Cwiczenia3.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia3.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IStudentDbService service)
        {
            string sciezka = httpContext.Request.Path;
            string querystring = httpContext.Request?.QueryString.ToString();
            string metoda = httpContext.Request.Method.ToString();
            string bodyString = "";

            using(StreamReader reader = 
                new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyString = await reader.ReadToEndAsync();
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(sciezka);
            stringBuilder.Append(querystring + " ");
            stringBuilder.Append(metoda + " ");
            stringBuilder.Append(bodyString + " ");
            stringBuilder.Append(DateTime.Now);

            StreamWriter streamWriter;

            if (!File.Exists("logs.txt"))
            {
                streamWriter = new StreamWriter("logs.txt");
            }
            else
            {
                streamWriter = File.AppendText("logs.txt");
            }
            streamWriter.WriteLine(stringBuilder.ToString());
            streamWriter.Close();

            await _next(httpContext);
        }
    }
}
