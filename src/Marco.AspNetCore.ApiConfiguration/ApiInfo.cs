using System.Collections.Generic;

namespace Marco.AspNetCore.ApiConfiguration
{
    public class ApiInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultVersion { get; set; }
        public IDictionary<string, string> VersionIngDescriptions { get; set; }
    }
}