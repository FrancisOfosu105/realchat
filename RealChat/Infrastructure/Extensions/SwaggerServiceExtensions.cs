using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RealChat.Infrastructure.Extensions
{
      public static class SwaggerServiceExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hubtel Finance API Documentation",
                    Version = "v1",
                    Description = "Hubtel Finance API Documentation",
                    TermsOfService = new Uri("https://hubtel.com/legal/terms/"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Francis Ofosu Afriyie",
                        Email = "afriyie@hubtel.com",
                        Url = new Uri("https://developers.hubtel.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Hubtel License",
                        Url = new Uri("https://hubtel.com/legal/privacy-policy/")
                    }
                });

                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "PrivateKey"
                            },
                            Scheme = "oauth2",
                            Type = SecuritySchemeType.ApiKey, 
                            In = ParameterLocation.Header,
                            Name = "PrivateKey",
                        },
                        new List<string>()
                    }
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityDefinition("PrivateKey", new OpenApiSecurityScheme
                {
                    Description =
                        "Private Authorization header using the PrivateKey scheme. Example: \"Authorization: PrivateKey {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(security);
            });

            return services;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwagger(o => { o.RouteTemplate = "docs/{documentName}/docs.json"; });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/v1/docs.json", "Hubtel Business Info API Documentation");
                c.DocumentTitle = "Hubtel Finance API";
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.InjectJavascript("/swagger-ui/custom.js");
                c.RoutePrefix = "docs";
                c.DocExpansion(DocExpansion.List);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.EnableValidator(null);
                c.DefaultModelsExpandDepth(-1);
                c.ShowExtensions();
            });

            return app;
        }
    }
    }