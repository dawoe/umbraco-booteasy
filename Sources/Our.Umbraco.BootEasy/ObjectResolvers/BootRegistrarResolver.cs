namespace Our.Umbraco.BootEasy.ObjectResolvers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    

    using Our.Umbraco.BootEasy.Enums;
    using Our.Umbraco.BootEasy.Interfaces;

    using global::Umbraco.Core.ObjectResolution;

    /// <summary>
    /// The boot registrar resolver.
    /// </summary>
    internal class BootRegistrarResolver : ManyObjectsResolverBase<BootRegistrarResolver, IBootRegistrar>
    {
        /// <summary>
        /// The registrars.
        /// </summary>
        private List<IBootRegistrar> registrars = new List<IBootRegistrar>(); 

        /// <summary>
        /// Initializes a new instance of the <see cref="BootRegistrarResolver"/> class.
        /// </summary>
        /// <param name="bootRegistrarTypes">
        /// The boot registrar types.
        /// </param>
        internal BootRegistrarResolver(IEnumerable<Type> bootRegistrarTypes)
            : base(bootRegistrarTypes, ObjectLifetimeScope.Application)
        {
            this.registrars = bootRegistrarTypes.Select(parser => (IBootRegistrar)Activator.CreateInstance(parser)).ToList();
        }

        /// <summary>
        /// Gets the started registrars.
        /// </summary>
        internal List<IBootRegistrar> StartedRegistrars
        {
            get
            {
               return this.Values.Where(x => x.BootType == BootType.Started).OrderBy(x => x.SortOrder).ToList();
            }
        }

        /// <summary>
        /// Gets the starting registrars.
        /// </summary>
        internal List<IBootRegistrar> StartingRegistrars
        {
            get
            {
                return this.registrars.Where(x => x.BootType == BootType.Starting).OrderBy(x => x.SortOrder).ToList();
            }
        }

        /// <summary>
        /// Gets the initialized registrars.
        /// </summary>
        internal List<IBootRegistrar> InitializedRegistrars
        {
            get
            {
                return this.registrars.Where(x => x.BootType == BootType.Initialized).OrderBy(x => x.SortOrder).ToList();
            }
        }
    }
}
