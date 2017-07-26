using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Ninject;

namespace NinjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StandardKernel kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                IServer server = kernel.Get<IServer>();
                Dependent dependent = new Dependent(server);
                dependent.DoSomething();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }


    public class Dependent
    {
        private IServer _server;

        public Dependent(IServer server)
        {
            _server = server;
        }

        public void DoSomething()
        {
            _server.Serve();
        }
    }

    public interface IServer
    {
        void Serve();
    }

    public class ServerOne : IServer
    {
        public void Serve()
        {
            Console.WriteLine("Server One Serve");
        }
    }

    public class ServerTwo : IServer
    {
        public void Serve()
        {
            Console.WriteLine("Server Two Serve");
        }
    }
}
