using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace NinjectExample
{
    /* Class implementing NinjectModule has to be public */
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
           Bind<IServer>().To<ServerTwo>();
        }
    }
}
