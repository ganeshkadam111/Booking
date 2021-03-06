﻿using HotelBooking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Filters
{
    public class ExecuteCustomErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // Avoid 'action parameter missing' exceptions by simply returning an error response
            if (filterContext.Exception.TargetSite.DeclaringType == typeof(ActionDescriptor) &&
                filterContext.Exception.TargetSite.Name == "ExtractParameterFromDictionary")
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            //if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    return;
            //}

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary(model),
                    TempData = filterContext.Controller.TempData
                };
            }

            // log the error by using your own method
            Log.Error(filterContext.Exception.Message, filterContext.Exception);

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}