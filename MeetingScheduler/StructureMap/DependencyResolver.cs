using StructureMap;
using System;
using System.Web.Http.Dependencies;

namespace MeetingScheduler.StructureMap
{
    public class DependencyResolver : DependencyScope, IDependencyResolver
    {
        private readonly IContainer container;
        public DependencyResolver(IContainer container) : base(container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.GetNestedContainer();
            return new DependencyResolver(child);
        }
    }
}