using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhatDoesRazorLookLike.Startup))]
namespace WhatDoesRazorLookLike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
