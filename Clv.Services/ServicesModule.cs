using Microsoft.Extensions.DependencyInjection;
using Clv.Services.Authenticate;
using Clv.Services.FileManager;



namespace Clv.Services
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IFileManagerService, FileManagerService>();
         
        }
    }
}
