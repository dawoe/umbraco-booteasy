namespace Our.Umbraco.BootEasy
{
    using Our.Umbraco.BootEasy.Extensions;
    using Our.Umbraco.BootEasy.ObjectResolvers;

    using global::Umbraco.Core;

    /// <summary>
    /// The boot manager, responsible for registering all events and application configuration on startup
    /// </summary>
    public class BootStrapper : ApplicationEventHandler
    {
        /// <summary>
        /// Overridable method to execute when the ApplicationContext is created and other static objects that require initialization have been setup
        /// </summary>
        /// <param name="umbracoApplication"/><param name="applicationContext"/>
        protected override void ApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // resolve all boot registrars
            BootRegistrarResolver.Current = new BootRegistrarResolver(PluginManager.Current.ResolveBootRegistrars());

            // register all boot registrars for initialized event
            BootRegistrarResolver.Current.InitializedRegistrars.ForEach(x => x.Register());
        }

        /// <summary>
        /// Overridable method to execute when All resolvers have been initialized but resolution is not frozen so they can be modified in this method
        /// </summary>
        /// <param name="umbracoApplication"/><param name="applicationContext"/>
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // register all boot registrars for starting event
            BootRegistrarResolver.Current.StartingRegistrars.ForEach(x => x.Register());
        }

        /// <summary>
        /// Overridable method to execute when Bootup is completed, this allows you to perform any other bootup logic required for the application.
        ///             Resolution is frozen so now they can be used to resolve instances.
        /// </summary>
        /// <param name="umbracoApplication"/><param name="applicationContext"/>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // register all boot registrars for started event
            BootRegistrarResolver.Current.StartedRegistrars.ForEach(
                x => x.Register());
        }
    }
}
