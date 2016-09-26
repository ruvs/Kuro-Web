using System;
using Nexus.ParticipantLibrary.Middleware.Configuration;

namespace Nexus.Web.Configuration
{
    public class ParticipantLibraryAppSettings : IAppSettings
    {
        public string CorsOrigins { get; set; }

        public string ConnectionString_ParticipantLibrary_Read { get; set; }

        public string ConnectionString_ParticipantLibrary_Write { get; set; }
        public string IncludeErrorDetailPolicy { get; set; }
    }
}
