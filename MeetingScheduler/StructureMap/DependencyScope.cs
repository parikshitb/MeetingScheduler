using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MeetingScheduler.StructureMap
{
    public class DependencyScope : IDependencyScope
    {
        private readonly IContainer container;
        public DependencyScope(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentException();
            }
            this.container = container;
        }
        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return container.TryGetInstance(serviceType);
            }
            return container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.GetAllInstances(serviceType).Cast<object>();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }
}