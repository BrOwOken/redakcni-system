using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RedakcniSystem.Data
{
    public class ViewRenderService
    {
        private IServiceProvider _serviceProvider;
        private ITempDataProvider _tempDataProvider;
        private IRazorViewEngine _razorViewEngine;

        public ViewRenderService(IServiceProvider serviceProvider,
            ITempDataProvider dataProvider, IRazorViewEngine engine)
        {
            _serviceProvider = serviceProvider;
            _tempDataProvider = dataProvider;
            _razorViewEngine = engine;
        }
        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var HttpContext = new DefaultHttpContext()
            {
                RequestServices = _serviceProvider,
            };
            var actionContext = new ActionContext(HttpContext, new RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());
            using (var writer = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

                if(viewResult == null)
                {
                    Console.WriteLine("View not found");
                }
                var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                    new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                {
                    Model = model
                };

                //var viewContext = new ViewContext(actionContext, viewResult.View, viewData, new TempDataDictionary(actionContext.HttpContext, _tempDataProvider));
                return writer.ToString();
            }
            return "";
        }
    }
}
