using System;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace Mshudx.AspNet.Identity.DocumentDb
{
    /// <summary>
    /// Default services
    /// </summary>
    public class IdentityDocumentDbServices
    {
        public static IServiceCollection GetDefaultServices(Uri endPoint, string authKey, string databaseName, string collectionName, IConfiguration config = null)
        {
            var services = new ServiceCollection();

            services.AddScoped(
                typeof(IUserStore<IdentityUser>),
                sp => new UserStore(endPoint, authKey, databaseName, collectionName));
            services.AddScoped(
                typeof (IRoleStore<IdentityRole>),
                sp => new RoleStore());
            return services;
        }
    }
}