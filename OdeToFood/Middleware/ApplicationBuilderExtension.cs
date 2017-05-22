using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace OdeToFood.Middleware
{
    public static class ApplicationBuilderExtension
    {

        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = provider
            };
            app.UseStaticFiles(options);

            return app;
        }

    }
}
