namespace Our.Umbraco.BootEasy.Extensions
{
    using System.Collections.Generic;

    using Our.Umbraco.BootEasy.Interfaces;

    using global::Umbraco.Core;

    /// <summary>
    /// The plugin manager extensions.
    /// </summary>
    internal static class PluginManagerExtensions
    {
        /// <summary>
        /// Finds all boot registrars
        /// </summary>
        /// <param name="resolver">
        /// The plugin manager.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        internal static IEnumerable<System.Type> ResolveBootRegistrars(this PluginManager resolver)
        {
            return resolver.ResolveTypes<IBootRegistrar>();
        }
    }
}
