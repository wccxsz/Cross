using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cross.WebHost.Dbcontext;
using Microsoft.Extensions.DependencyInjection;

namespace Cross.WebHost.Common
{
    public static class SampleData
    {
        public static async Task<bool> InitCrossDatabaseAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<CrossContext>();
                return await db.Database.EnsureCreatedAsync();
            }
        }
    }
}
