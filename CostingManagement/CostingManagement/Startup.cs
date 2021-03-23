using CostingManagement.Core.Common;
using CostingManagement.Core.Interfaces;
using CostingManagement.Data.DataContext;
using CostingManagement.Data.DbModels.SecuritySchema;
using CostingManagement.Services.Lookup.DiscrepancyStatus;
using CostingManagement.Services.Lookup.PackageType;
using CostingManagement.Services.Lookup.VAT;
using CostingManagement.Services.Security.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Security.Claims;

namespace CostingManagement
{
    public class Startup
    {
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this.WebHostEnvironment = webHostEnvironment;
            this.Configuration = configuration;
        }

        public IWebHostEnvironment WebHostEnvironment
        {
            get;
            private set;
        }

        public IConfiguration Configuration
        {
            get;
            private set;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllersWithViews();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            if (this.Configuration.GetValue<bool>("EnableSwagger"))
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo
                        {
                            Title = $"Costing Management Api Gateway ({this.WebHostEnvironment.EnvironmentName})",
                            Version = "v1"
                        });

                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows()
                        {
                            Password = new OpenApiOAuthFlow()
                            {
                                //TokenUrl = new Uri(jwtSettings.TokenEndpoint),
                            }
                        }
                    });

                    //c.OperationFilter<AuthorizeCheckOperationFilter>();
                    c.CustomSchemaIds(i => i.FullName);
                });
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(this.Configuration["StoreOptions:ConnectionString"]));


            #region Identity
            services.AddAuthorization();
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddTokenProvider("CostingManagement", typeof(DataProtectorTokenProvider<ApplicationUser>));

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                var signingKey = Convert.FromBase64String(Configuration["Jwt:Key"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                };
            });
            #endregion

            #region Services
            services.AddScoped<IResponseDTO, ResponseDTO>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IDiscrepancyStatusService, DiscrepancyStatusService>();
            services.AddScoped<IPackageTypeService, PackageTypeService>();
            services.AddScoped<IVatService, VatService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext appDbContext, IServiceProvider serviceProvider)
        {
            if (env.IsEnvironment("Local"))
            {
                app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseSpa(spa =>
                {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                        //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    }
                });

                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            DataSeedingIntilization.Seed(appDbContext, serviceProvider);


            if (this.Configuration.GetValue<bool>("EnableSwagger"))
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(
                        "../swagger/v1/swagger.json",
                        $"Costing Management v1 ({this.WebHostEnvironment.EnvironmentName})");

                    c.OAuthClientId("test");
                    c.OAuthAppName("Costing Management ApiGateway");
                });
            }
        }
    }
}
