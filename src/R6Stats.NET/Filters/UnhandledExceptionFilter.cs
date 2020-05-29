using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using R6Stats.NET.Extensions;
using R6Stats.NET.Models;

namespace R6Stats.NET.Filters
{
    public class UnhandledExceptionFilter : IExceptionFilter
    {
        private Dictionary<Type, HttpStatusCode> _exceptionTypeStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            { typeof(ValidationException), HttpStatusCode.BadRequest },
            { typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized },
            { typeof(ApplicationException), HttpStatusCode.InternalServerError }
        };

        public void OnException(ExceptionContext context)
        {
            var errorModel = new ExceptionErrorModel();
            if (_exceptionTypeStatusCodes.ContainsKey(context.Exception.GetType()))
            {
                context.HttpContext.Response.StatusCode = (int)_exceptionTypeStatusCodes[context.Exception.GetType()];
                errorModel.Message = context.Exception.Message;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorModel.UnhandledException = true;
                errorModel.Message = "An Error has occured";
            }

            errorModel.Exception = context.Exception.GetDeepestMessage();
            context.Result = new ObjectResult(errorModel);
            context.ExceptionHandled = true;
        }
    }
}
