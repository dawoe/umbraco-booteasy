namespace Our.Umbraco.BootEasy.BootRegistrars
{
    using Our.Umbraco.BootEasy.Enums;
    using Our.Umbraco.BootEasy.Interfaces;

    /// <summary>
    /// The application started boot registrar base class
    /// </summary>
    public abstract class ApplicationStartedBootRegistrar : IBootRegistrar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationStartedBootRegistrar"/> class.
        /// </summary>
        protected ApplicationStartedBootRegistrar()
        {
            this.SortOrder = 0;
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public virtual int SortOrder { get; set; }

        /// <summary>
        /// Gets the boot type.
        /// </summary>
        BootType IBootRegistrar.BootType
        {
            get
            {
                return BootType.Started;
            }
        }

        /// <summary>
        /// Register method that will be called during application startup
        /// </summary>
        public abstract void Register();
    }
}
