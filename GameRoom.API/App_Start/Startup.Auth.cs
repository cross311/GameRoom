using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;
using GameRoom.API.Providers;
using GameRoom.API.Models;

namespace GameRoom.API
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true,
                AccessTokenProvider = new t()
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            app.UseFacebookAuthentication(
                appId: "1503312323274248",
                appSecret: "564b49d59fdfa6c19f57b3dc08094552");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }

    class t : AuthenticationTokenProvider
    {
        private readonly IDictionary<string, string> _Tokens; 

        public t()
        {
            OnCreate = Create;
            OnReceive = Receive;
            _Tokens = new Dictionary<string, string>();
        }

        private void Receive(AuthenticationTokenReceiveContext authenticationTokenReceiveContext)
        {
            string ticket;
            if (_Tokens.TryGetValue(authenticationTokenReceiveContext.Token, out ticket))
            {
                authenticationTokenReceiveContext.DeserializeTicket(ticket);
            }
        }

        private void Create(AuthenticationTokenCreateContext authenticationTokenCreateContext)
        {
            authenticationTokenCreateContext.SetToken(Guid.NewGuid().ToString("n") + Guid.NewGuid().ToString("n"));
            _Tokens[authenticationTokenCreateContext.Token] = authenticationTokenCreateContext.SerializeTicket();
        }
    }
}
