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
using Microsoft.AspNetCore.Hosting;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opt => {
                        var sp = opt.ApplicationServices;
                        using (var scope = sp.CreateScope())
                        {
                            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
                            Seeder seed = new Seeder(dbContext);
                            seed.run();
                        }
                    });
                });
    }
}
