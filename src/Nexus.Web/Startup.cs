using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //app.Map("/api/participant", partLibApp => partLibApp.UseParticipantLibraryCore());

            app.UseStaticFiles();

            app.Run(ctx =>
            {
                ctx.Response.Redirect("/index.html");
                return Task.FromResult(0);
            });

            //var logWriter = new EndorsementCatalogLogger();
            //var claimsPrincipalResolver = new ClaimsPrincipalResolver();

            //BootStrapEndorsementCatalogLibrary(logWriter, claimsPrincipalResolver);
            //BootStrapDocFactory(logWriter);

            //BootStrapApplicabilityQueryEngine(logWriter);
            //BootStrapApplicabilityConfigEngine(logWriter);

            //app.Map("/api/endorsement", endorsementCatalogLibraryApp =>
            //    endorsementCatalogLibraryApp.UseEndorsementCatalogLibraryCore(_catalogLibrary,
            //        logWriter));


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        //private static void BootStrapEndorsementCatalogLibrary(Beazley.EndorsementCatalog.Core.Logging.IEndorsementCatalogLogger logWriter,
        //    Beazley.EndorsementCatalog.Core.Security.IResolveClaimsPrincipal claimsPrincipalResolver)
        //{
        //    _catalogLibrary = EndorsementCatalogConfigure
        //        .Init()
        //        .With(logWriter)
        //        .With(claimsPrincipalResolver)
        //        .DapperPersistence()
        //        .WithConnectionsNamed("ApplicationStore", "ApplicationStore")
        //        .Build();
        //}
    }
}
