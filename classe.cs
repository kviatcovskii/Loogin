using System;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WebApplication11.classe))]

namespace WebApplication11
{
    public class classe
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Autentencicao/Login")
            }
            );
            AntiForgeryConfig.UniqueClaimTypeIdentifier = "login";
        }
    }
}
