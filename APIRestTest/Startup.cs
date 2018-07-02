using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// using APIRestTest.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Owin;
using APIRestTest;

[assembly: OwinStartup(typeof(Startup))]
namespace APIRestTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}