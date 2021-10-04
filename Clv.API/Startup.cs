using System.IO;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NLog;
using Clv.Core.EFContext;
using Clv.Core.Factory;
using Clv.Core.Repositories.Base;
using Clv.Core.Repositories.Interfaces;
using Clv.Core.Uow;
using Clv.Models.Configuration;
using Clv.Services;
using System.Reflection;
using System;
using Clv.Utilities.logManager;
using Clv.API.Extensions;
using Clv.Utilities.Hashing;
using Microsoft.Extensions.FileProviders;
using Clv.Services.UserProfile;
using Clv.Services.Pod;
using Clv.Services.Authenticate;
using Clv.Services.Quiz;
using Clv.Services.Assignment;
using Clv.Services.Subject;
using Clv.Services.LearningStyle;
using Clv.Services.Attendance;
using Clv.Services.Notes;
using Clv.Services.Parent_Services;
using Clv.Services.SpecialNeed_Service;
using Clv.Services.GradeLevel_Service;
using Clv.Services.Student_Service;

namespace Clv.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllersWithViews();
            ServicesModule.Register(services);
            services.Configure<ConnectionSettings>(Configuration.GetSection("ConnectionStrings"));
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDatabaseContext, Core.EFContext.DatabaseContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserProfile, UserProfile>();
            services.AddScoped<IPodService, PodService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ILearningService, LearningService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<INotesService, NotesService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<ISpecialNeedService, SpecialNeedService>();
            services.AddScoped<IGradeLevelService, GradeLevelService>();
            services.AddScoped<IStudentService, StudentService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clv Development", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                        }
                       },
                       new string[] { }
                     }
                   });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });



            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {

            #region ForEmail

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new
            //    PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Templete")),
            //    RequestPath = new PathString("/Templete")
            //});

            #endregion

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clv");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.ConfigureExceptionHandler(logger);

            }
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clv");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
