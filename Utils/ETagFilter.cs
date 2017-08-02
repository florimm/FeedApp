using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FeedApp.Utils
{
    public class ETagAttribute : Attribute, IActionFilter
    {
        private readonly int[] _statusCodes;

        public ETagAttribute(params int[] statusCodes)
        {
            _statusCodes = statusCodes;
            if (statusCodes.Length == 0) _statusCodes = new[] { 200 };
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Method == "GET")
            {
                if (_statusCodes.Contains(context.HttpContext.Response.StatusCode))
                {
                    string token;
                    using (var ms = new MemoryStream())
                    {
                        using (var writer = new BsonDataWriter(ms))
                        {
                            var serializer = new JsonSerializer();
                            serializer.Serialize(writer, context.Result);
                            token = GetETag(ms.ToArray());
                        }
                    }

                    if (context.HttpContext.Request.Headers.Keys.Contains("If-None-Match") && context.HttpContext.Request.Headers["If-None-Match"].ToString() == token)
                    {
                        context.Result = new StatusCodeResult(304);
                    }
                    context.HttpContext.Response.Headers.Add("ETag", new[] { token });
                }
            }
        }
        private static string GetETag(byte[] bytes)
        {
            var checksum = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(checksum, 0, checksum.Length);
        }
    }
}
