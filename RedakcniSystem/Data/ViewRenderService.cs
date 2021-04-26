using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.JSInterop;

namespace RedakcniSystem.Data
{
    public class ViewRenderService
    {
        private IServiceProvider _serviceProvider;
        private ITempDataProvider _tempDataProvider;
        private IRazorViewEngine _razorViewEngine;

        private IJSRuntime _runtime;



        public ViewRenderService(IServiceProvider provider,
            ITempDataProvider dataProvider, IRazorViewEngine engine, IJSRuntime runtime)
        {
            _serviceProvider = provider;
            _tempDataProvider = dataProvider;
            _razorViewEngine = engine;

            _runtime = runtime;
        }

        public async Task<string> RenderToStringAsync(string viewName, object model)
        {
            var httpContext = new DefaultHttpContext()
            {
                RequestServices = _serviceProvider,
            };

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var writer = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

                if (viewResult == null)
                {
                    Console.WriteLine("Not found " + viewName);
                    return null;
                }

                var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                {
                    Model = model,
                };

                var viewContext = new ViewContext(actionContext, viewResult.View,
                    viewData, new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);

                return writer.ToString();
            }
        }
    }
}
