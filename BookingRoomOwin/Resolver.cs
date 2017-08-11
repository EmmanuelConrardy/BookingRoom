using BookingRoomApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace BookingRoomOwin
{
    public class Resolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            return base.GetAssemblies().Union(this.GetControllersAssembly()).ToArray();
        }

        private IEnumerable<Assembly> GetControllersAssembly()
        {
            yield return typeof(RoomController).Assembly;
        }
    }
}
