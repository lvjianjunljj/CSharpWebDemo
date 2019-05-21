namespace CSharpWebAPIApplication
{
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Owin.Security.ActiveDirectory;
    using Owin;
    using System.Web.Configuration;
    public partial class Startup
    {
        // The necessary class for Owin to implement the auth based on AAD
        // doc link: https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-v1-dotnet-webapi
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = WebConfigurationManager.AppSettings["ida:Tenant"],
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudience = WebConfigurationManager.AppSettings["ida:Audience"]
                    }
                });
        }
    }
}