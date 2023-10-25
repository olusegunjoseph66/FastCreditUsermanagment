using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Text.Json.Serialization;
using System.Text.Json;
using KissLog;
using KissLog.AspNetCore;
using KissLog.Formatters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using FastCreditCodingChallange.ViewModels.Requests;
using FastCreditCodingChallange.Repository;
using FastCreditCodingChallange.Services;
using FastCreditCodingChallange.DatabaseModels;

namespace FastCreditCodingChallange.Utility
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config, string allowedSpecificOrigins)
        {
            services.AddWebCoreServices(config, allowedSpecificOrigins);
            services.AddSwaggerExtension();
            services.AddSharedInfrastructure(config);
        }

        private static void AddWebCoreServices(this IServiceCollection services, IConfiguration config, string allowedSpecificOrigins)
        {
            services.AddSingleton<RequestValidationAttributeFilter>();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            //Limit model validation error to return just one error message that first occurred
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.AddService<RequestValidationAttributeFilter>();
            });

            services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                options.JsonSerializerOptions.IncludeFields = true;
                options.JsonSerializerOptions.AllowTrailingCommas = false;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCors(options =>
            {
                options.AddPolicy(allowedSpecificOrigins, builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });

            });
            //Web Api services needed
            string connectionString = config.GetConnectionString("FastCreditConnection");
            services.AddDbContext<FastCreditDbContext>(options =>  options.UseSqlServer(connectionString));
          

            #region Register Data Repository Service
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            #endregion

            #region Register External Services
            //services.AddTransient<IFileService, FileService>();
            //services.AddTransient<IMessagingService, MessagingService>();

            #endregion

            #region Register Application Services
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            #endregion

            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());
            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);
                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });

        }

        private static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //  c.IncludeXmlComments(string.Format(@"{0}Account.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Account Microservice - WebApi",
                    Description = "This Api will be responsible for overall Project.",
                    Contact = new OpenApiContact
                    {
                        Name = "Fast Credit - Account Microservice",
                        Email = "dev@fastcredit.com",
                        Url = new Uri("https://fastcredit.com/contact"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    },
                });
            });
        }

        private static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {

         

            
            return services;
        }
    }
}
