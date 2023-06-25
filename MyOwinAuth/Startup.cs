using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using MyOwinAuth.Provider;

[assembly: OwinStartup(typeof(MyOwinAuth.Startup))]

namespace MyOwinAuth
{
    public partial class Startup
    {

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder appBuilder)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(),
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true // https
            };

            // Enable the application to use bearer tokens to authenticate users
            appBuilder.UseOAuthBearerTokens(OAuthOptions);
            appBuilder.UseOAuthAuthorizationServer(OAuthOptions);
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            //ConfigureAuth(app);
        }

        
    }
}
