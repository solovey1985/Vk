using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor;
namespace Vk.DTO.Services
{
    public static class ServiceFactory
    {
        private static WindsorContainer _container = new WindsorContainer(new XmlInterpreter());

        public static T GetService<T>(){return _container.Resolve<T>();
        }
    }
}
