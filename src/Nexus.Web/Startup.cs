using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using Nexus.ParticipantLibrary.Middleware.OwinConfiguration;
using Nexus.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Nexus.ParticipantLibrary.Middleware.Configuration;
using Nexus.Web.Configuration;
using Nexus.ParticipantLibrary.Core.Logging;
using Nexus.ParticipantLibrary.Core.Configuration;
using Nexus.ParticipantLibrary.Data._Config;
using Nexus.Web.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]
namespace Nexus.Web
{
    public class Startup
    {
        private static IAmAParticipantLibrary participantLibrary;
        private static ParticipantLibraryAppSettings participantLibraryAppSettings;

        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("MyAppSettings:ParticipantLibrary"));

            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton(Configuration);

            //services.AddDataProtection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            participantLibraryAppSettings = BootStrapParticipantLibraryAppSettings(app);

            var logWriter = new ParticipantLibraryLogger();

            BootStrapParticipantLibrary(logWriter);

            app.UseDeveloperExceptionPage();
            app.UseAppBuilder(appBuilder =>
            {
                // Some components will have dependencies that you need to populate in the IAppBuilder.Properties.
                // Here's one example that maps the data protection infrastructure.
                //appBuilder.SetDataProtectionProvider(app);
                //app.Map("/api/participantLibrary", partLibApp => partLibApp.UseParticipantLibraryCore(BootStrapParticipantLibraryAppSettings(app)));
                appBuilder.Map("/api/participantLibrary", partLibApp => partLibApp.UseParticipantLibraryCore(participantLibraryAppSettings, participantLibrary));
            });

            //app.UseWebApi();// UseStaticFiles();


            app.Run(ctx =>
            {
                //ctx.Response.Redirect("/index.html");
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

        private static ParticipantLibraryAppSettings BootStrapParticipantLibraryAppSettings(IApplicationBuilder app)
        {
            var appSettings = app.ApplicationServices.GetService<IOptions<AppSettings>>();
            participantLibraryAppSettings = new ParticipantLibraryAppSettings()
            {
                CorsOrigins = appSettings.Value.CorsOrigins,
                IncludeErrorDetailPolicy = appSettings.Value.IncludeErrorDetailPolicy,
                ConnectionString_ParticipantLibrary_Read = appSettings.Value.ConnectionString_ParticipantLibrary_Read,
                ConnectionString_ParticipantLibrary_Write = appSettings.Value.ConnectionString_ParticipantLibrary_Write
            };
            return participantLibraryAppSettings;
        }

        private static void BootStrapParticipantLibrary(IParticipantLibraryLogger logWriter)
            //Beazley.EndorsementCatalog.Core.Security.IResolveClaimsPrincipal claimsPrincipalResolver)
        {
            participantLibrary = ParticipantLibraryConfigure
                .Init()
                .With(logWriter)
                .EfPersistence()
                .WithConnectionStrings(participantLibraryAppSettings.ConnectionString_ParticipantLibrary_Read, participantLibraryAppSettings.ConnectionString_ParticipantLibrary_Write)
                //.With(claimsPrincipalResolver)
                .Build();
        }

        private class ParticipantLibraryLogger : IParticipantLibraryLogger
        {
            //private readonly ILogWriter logger = new LogWriter(new LogFormatter());
            private readonly ILogWriter logger = new LogWriter();

            public void Error(string message)
            {
                //logger.Error(EventIds.ENDORSEMENT_API_ERROR_GENERAL, message);
            }
        }

    }
}