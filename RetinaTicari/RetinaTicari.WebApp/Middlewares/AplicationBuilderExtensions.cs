using Microsoft.Extensions.FileProviders;
using System.Net.NetworkInformation;

namespace RetinaTicari.WebApp.Middlewares
{
    public static class AplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var option = new StaticFileOptions();
            option.RequestPath = "/node_modules";
            option.FileProvider = provider;
            app.UseStaticFiles(option);
            return app;
        }
    }
}
