using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MstwoData;
using MstwoData.Logger;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mstwo.svc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string ConnectionString = "Server=sqldata,1433;Initial Catalog=VZBASE;User ID=sa;Password=Passw0rd";
            //Application context registration            
            System.Console.WriteLine(Configuration.GetConnectionString("SqlConnection"));
            DButilities.ConnectionString = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<DBContext>(Option =>
             Option.UseSqlServer(Configuration.GetConnectionString("SqlConnection")), ServiceLifetime.Singleton);

            //Service Registration
            services.AddControllers();
            services.AddCorsPolicy("EnableCORS");
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;
            }).AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema API", Version = "v1" });
            });


            services.AddSingleton<ILoggerManager, LoggerManager>();

           
            #region Serives
            services.AddScoped<IRepository, Repository>();          
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Global Exception Handler
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = (c) => {
                    var exception = c.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exception.Error.GetType().Name switch
                    {
                        "ArgumentException" => HttpStatusCode.BadRequest,
                        _ => HttpStatusCode.ServiceUnavailable
                    };
                    c.Response.StatusCode = (int)statusCode;
                    var content = Encoding.UTF8.GetBytes($"Error [{exception.Error.Message}]");
                    c.Response.Body.WriteAsync(content, 0, content.Length);
                    return Task.CompletedTask;
                }
            });

            app.UseHttpsRedirection();

            var swaggeroptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggeroptions);
            app.UseSwagger(option => { option.RouteTemplate = swaggeroptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggeroptions.UIEndpoint, swaggeroptions.Description);
            });

            app.UseRouting();

            app.UseCors("EnableCORS");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
    public static class ServiceExtensions
    {
        public static void AddCorsPolicy(this IServiceCollection serviceCollection, string corsPolicyName)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
