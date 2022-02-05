//using Microsoft.AspNetCore.Mvc.ApiExplorer;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;

//namespace Filmstudion.Server
//{
//    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
//    {
//        readonly IApiVersionDescriptionProvider provider;

//        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

//        public void Configure(SwaggerGenOptions options)
//        {
//            foreach (var desc in provider.ApiVersionDescriptions)
//            {
//                options.SwaggerDoc(
//                    desc.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo()
//                    {
//                        Title = $"Filmstudio api {desc.ApiVersion}",
//                        Version = desc.ApiVersion.ToString()
//                    });
//            }

//            options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
//            {
//                Description = "jwt authorization header using the bearer scheme. \r\n\r\n " +
//               "enter 'bearer' [space] and then your token in the text input below.\r\n\r\n" +
//               "example: \"bearer 12345abcdef\"",
//                Name = "authorization",
//                In = ParameterLocation.Header,
//                Type = SecuritySchemeType.ApiKey,
//                Scheme = "bearer"
//            });

//            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
//            {
//                {
//                    new OpenApiSecurityScheme
//                    {
//                        Reference = new OpenApiReference
//                        {
//                            Type = ReferenceType.SecurityScheme,
//                            Id = "bearer"
//                        },
//                        Scheme = "oauth2",
//                        Name =  "bearer",
//                        In = ParameterLocation.Header,


//                    },
//                    new List<string>()
//                }
//            });

//            var xmlcommentfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//            var cmlcommentsfullpath = Path.Combine(AppContext.BaseDirectory, xmlcommentfile);
//            options.IncludeXmlComments(cmlcommentsfullpath);
//        }
//    }
//}
