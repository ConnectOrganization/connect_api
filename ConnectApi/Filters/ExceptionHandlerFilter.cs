using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NLog;
using System.Linq;

namespace ConnectApi.Filters
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        private static readonly Logger Logger = LogManager.GetLogger("Logging");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                var exception = context.Exception;
                var statusCode = HttpStatusCode.InternalServerError;
                string content;

                if (exception is Validation.Exceptions.ValidationException)
                {
                    var errorList = (exception as Validation.Exceptions.ValidationException).ValidationResults.Select(m => new { m.MemberNames, m.ErrorMessage })
                                 .ToList();
                    content = JsonConvert.SerializeObject(errorList);
                    statusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    content = FormatExceptionMessage("System Exception.");
                    var errorMessage =
                        $"{DateTime.Now:yyyy-MM-dd:HH:mm:ss}{Environment.NewLine}" +
                        $"Exception caught: {exception.GetType().Name}{Environment.NewLine}" +
                        $"Message: {GetExceptionFullMessage(exception)}{Environment.NewLine}" +
                        $"Stacktrace: {exception.StackTrace}";
                    Logger.Error(errorMessage);
                }
                context.Result = ExceptionResponse(content, statusCode);
            }
            base.OnException(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exceptionMessage"></param>
        /// <returns></returns>
        private string FormatExceptionMessage(string exceptionMessage)
        {
            return JsonConvert.SerializeObject(new { error = exceptionMessage });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionFullMessage(Exception ex)
        {
            var result = "";
            var prefix = "";
            while (ex != null)
            {
                result = result + prefix + ex.Message;
                ex = ex.InnerException;
                prefix = prefix + Environment.NewLine + "    ";
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        private ContentResult ExceptionResponse(string content, HttpStatusCode statusCode)
        {
            return new ContentResult
            {
                Content = content,
                ContentType = "application/json",
                StatusCode = (int)statusCode
            };
        }
    }
}