﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlinePoll.Startup))]
namespace OnlinePoll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //ConfigureAuth(app);
        }
    }
}
