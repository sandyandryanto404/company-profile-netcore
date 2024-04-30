/**
 * This file is part of the Sandy Andryanto Company Profile Website.
 *
 * @author     Sandy Andryanto <sandy.andryanto404@gmail.com>
 * @copyright  2024
 *
 * For the full copyright and license information,
 * please view the LICENSE.md file that was distributed
 * with this source code.
 */

using backend.Models;
using backend.Models.Services;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace backend
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
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
                options
                .UseNpgsql(Configuration.GetConnectionString("MainContext"))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging()
           );
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            app.UseRouting();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Uploads")),
                RequestPath = "/Uploads"
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
