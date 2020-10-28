using System;
using System.Collections.Generic;

namespace Game.GamePlay
{
    class GameServices
    {
        /// <summary>
        /// currently registered services.
        /// </summary>
        static readonly Dictionary<string, object> services = new Dictionary<string, object>();

        /// <summary>
        /// Gets the service instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type of the service to lookup.</typeparam>
        /// <returns>The service instance.</returns>
        public static T Get<T>()
        {
            var key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                throw new InvalidOperationException();
            }

            return (T)services[key];
        }

        /// <summary>
        /// Registers the service with the current service locator.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        /// <param name="service">Service instance.</param>
        public static void Register<T>(T service)
        {
            string key = typeof(T).Name;
            if (services.ContainsKey(key))
            {
                return;
            }

            services.Add(key, service);
        }

        /// <summary>
        /// Unregisters the service from the current service locator.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        internal static void Unregister<T>()
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                return;
            }

            services.Remove(key);
        }
    }
}
