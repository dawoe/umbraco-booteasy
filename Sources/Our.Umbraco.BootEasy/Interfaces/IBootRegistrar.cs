namespace Our.Umbraco.BootEasy.Interfaces
{
    /// <summary>
    /// The BootRegistrar interface.
    /// </summary>
    internal interface IBootRegistrar
    {
        /// <summary>
        /// Gets the sort order.
        /// </summary>
        int SortOrder { get; }

        /// <summary>
        /// Gets the boot type.
        /// </summary>
        Enums.BootType BootType { get; }

        /// <summary>
        /// The register method
        /// </summary>
        void Register();
    }
}
