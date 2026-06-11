using System;
using System.Collections.Generic;

namespace Codara.Application
{
    public interface IServiceResolver
    {
        T Resolve<T>() where T : class;
        bool TryResolve<T>(out T service) where T : class;
    }

    public sealed class ServiceRegistry : IServiceResolver
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public void Register<T>(T service) where T : class
        {
            services[typeof(T)] = service ?? throw new ArgumentNullException(nameof(service));
        }

        public T Resolve<T>() where T : class
        {
            if (TryResolve<T>(out var service))
            {
                return service;
            }

            throw new InvalidOperationException($"Service is not registered: {typeof(T).FullName}");
        }

        public bool TryResolve<T>(out T service) where T : class
        {
            if (services.TryGetValue(typeof(T), out var value))
            {
                service = (T)value;
                return true;
            }

            service = null;
            return false;
        }
    }
}

