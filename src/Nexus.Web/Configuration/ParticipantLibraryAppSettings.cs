using System;
using Nexus.ParticipantLibrary.Middleware.Configuration;

namespace Nexus.Web.Configuration
{
    public class ParticipantLibraryAppSettings : IAppSettings
    {
        public string CorsOrigins { get; set; }
    }
}
