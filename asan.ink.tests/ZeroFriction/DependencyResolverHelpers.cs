using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace asan.ink.tests.ZeroFriction
{
    public class DependencyResolverHelpers
    {
        public static T GetService<T>()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                 .UseStartup<Startup>()
                 .Build();

            using (var serviceScope = webHost.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var scopedService = services.GetRequiredService<T>();
                    return scopedService;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            };
        }

    }
}
