using System;
using System.Configuration;
using APIRestTest.Core;
using APIRestTest.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace APIRestTest
{
    public partial class Startup
	{
		public void ConfigureOAuth(IAppBuilder app)
        {
            System.Console.WriteLine("SI ENTRO!!!!!!!!");
            System.Console.WriteLine("SI ENTRO1!!!!!!!!");
            System.Console.WriteLine("SI ENTRO2!!!!!!!!");
            System.Console.WriteLine("SI ENTRO3!!!!!!!!");

            var issuer = ConfigurationManager.AppSettings["issuer"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

            app.CreatePerOwinContext(() => new ProjectContext());
            app.CreatePerOwinContext(() => new BookUserManager());


            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }
            });



            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer)
            });
        }
	}
}