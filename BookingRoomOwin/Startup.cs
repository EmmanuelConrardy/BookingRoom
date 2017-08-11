using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using System.Web.Http;
using BookingRoomApi;
using System.Web.Http.Dispatcher;

namespace BookingRoomOwin
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Services.Replace(typeof(IAssembliesResolver), new Resolver());
            config.Services.Replace(typeof(IHttpControllerActivator),
                            new ControllerActivator(new DefaultHttpControllerActivator()));
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);
        }
    }
}
