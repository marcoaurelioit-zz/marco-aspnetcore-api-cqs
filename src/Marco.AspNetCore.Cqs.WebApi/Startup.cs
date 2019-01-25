using AutoMapper;
using Marco.AspNetCore.ApiConfiguration;
using Marco.AspNetCore.Cqs.Infra.Data.Dapper;
using Marco.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Marco.AspNetCore.Cqs.WebApi
{
    public class Startup : ApiBootStrapper
    {
        protected override ApiInfo ApiInfo => new ApiInfo()
        {
            Name = "Marco Asp Net Core - CQS",
            Description = "API CQS (Command Query Separation).",
            DefaultVersion = "1.0"
        };

        static Startup()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<WebApiAutoMapperProfile>();              
            });
        }

        public Startup(IConfiguration configuration)
           : base(configuration)
        {
        }
      
        [ExcludeFromCodeCoverage]
        protected override void AddCustomApiServices(IServiceCollection services)
        {
            services.AddCustomApplicationServices();        
            services.AddDapper(Configuration.GetSection(nameof(SqlServerReadOnlySettings)).TryGet<SqlServerReadOnlySettings>());
            services.AddMarcoCaching(Configuration.GetSection(nameof(CacheConfiguration)).TryGet<CacheConfiguration>());
        }

        [ExcludeFromCodeCoverage]
        protected override void AddCustomMiddlewaresInPipeline(IApplicationBuilder app)
        {
           
        }
    }
}