using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Marco.AspNetCore.ApiConfiguration
{
    public abstract class ApiBootStrapper
    {
        public IConfiguration Configuration { get; }       
        private string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = PlatformServices.Default.Application.ApplicationName + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }     

        protected ApiBootStrapper(IConfiguration configuration) =>
             Configuration = configuration;     

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);          
            AddSwagger(services);
            AddCustomApiServices(services);
        }
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            app.UseApiVersioning();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                });

            AddCustomMiddlewaresInPipeline(app);
        }

        #region [+] Abstract
        protected abstract ApiInfo ApiInfo { get; }
        protected abstract void AddCustomApiServices(IServiceCollection services);
        protected abstract void AddCustomMiddlewaresInPipeline(IApplicationBuilder app);
        #endregion

        #region [+] Privates
        private void AddSwagger(IServiceCollection services)
        {
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = ApiVersion.Parse(ApiInfo.DefaultVersion);
            });

            services.AddSwaggerGen(
                    options =>
                    {
                        options.AddSecurityDefinition(
                           "Bearer",
                           new ApiKeyScheme()
                           {
                               In = "header",
                               Description = "Please enter your JWT with the prefix Bearer into the field below.",
                               Name = "Authorization",
                               Type = "apiKey"
                           });

                        options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                            {
                                { "Bearer", Enumerable.Empty<string>() }
                            });

                        var apiVersionDescriptionProvider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Where(a => !a.IsDeprecated)
                        .OrderBy(a => a.ApiVersion.MajorVersion).ThenBy(a => a.ApiVersion.MinorVersion))
                            options.SwaggerDoc(description.GroupName, CreateSwaggerInfoForApiVersion(description));


                        options.DescribeAllEnumsAsStrings();

                        options.DescribeAllEnumsAsStrings();
                        options.OperationFilter<SwaggerDefaultValues>();
                        options.IncludeXmlComments(XmlCommentsFilePath);
                    });
        }
        private Info CreateSwaggerInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = ApiInfo.Name,
                Description = ApiInfo.Description,
                Version = description.ApiVersion.ToString()
            };

            if (info.Version.Equals("1.0"))
                info.Description += "<br>Initial version.";
            else
            {
                var versionDescription = ApiInfo.VersionIngDescriptions?[info.Version];
                if (!string.IsNullOrWhiteSpace(versionDescription))
                    info.Description += $"<br>{versionDescription}";
            }

            if (description.IsDeprecated)
                info.Description += "<br><br><span style=\"color: #ff0000;font-weight: bold;\">This version is already deprecated.</span>";

            return info;
        }     
        private Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"{ApiInfo.Name} {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = ApiInfo.Description
            };

            if (description.IsDeprecated)
                info.Description += " Esta versão da API foi depreciada.";

            return info;
        }
        #endregion
    }
}