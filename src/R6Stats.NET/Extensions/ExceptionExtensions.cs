using System;
namespace R6Stats.NET.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetDeepestMessage(this Exception ex)
        {
            var exception = ex;
            while (ex.InnerException != null)
            {
                exception = exception.InnerException;
            }

            return exception.Message;
        }
    }
}
