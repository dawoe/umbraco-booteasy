# BootEasy for Umbraco

## Introduction

BootEasy is a small framework to help hooking in to the Umbraco startup events.

Instead of implementing a class that inherits from Umbraco.Core.ApplicationEventHandler and hooking into the different startup events, with BootEasy you will implement a class inherting one of the base classes provided by BootEasy to hook in to these events.

There are 3 classes that you can inherit from :

- ApplicationInitializedBootRegistrar : will execute during the initialized event.
- ApplicationStartingBootRegistrar : will execute during the starting event.
- ApplicationStartedBootRegistrar : will execute during the started event

When implementing these classes you need to override the Register method. This is where you will implement the logic that needs to be executed. Optionally you can also override the SortOrder property to control the order that the registrars will be executed in the corresponding event.

The idea behind the package is that you don't repeat yourself. The registrars can be copied between projects or ideally packaged so you don't need to write the same code in each project.

Let's have a look at simple examples on setting the default controller for Umbraco

## ApplicationEventHandler example

```C#
public class BootManager : Umbraco.Code.ApplicationEventHandler
{
    protected override void ApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        // hande initialize event here
    }
       
    protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
    {
        // handle starting event here
		   
		// set the default render mvc controller, all documenttypes with no specific route hijacking will use this controller
        // we do this so we can donut output cache all pages by page and user
        DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(DefaultController));
    }
       
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext
	{
        // handle started event here
    }
}
```

## BootEasy example

```C#
public class DefaultControllerRegistrar : Our.Umbraco.BootEasy.BootRegistrars.ApplicationStartingBootRegistrar
{

    public override int SortOrder
    {
        get
        {
            return 1;
        }
    }

    public override void Register()
    {
        // set the default render mvc controller, all documenttypes with no specific route hijacking will use this controller
        // we do this so we can donut output cache all pages by page and user
        DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(DefaultController));
    }
}
```

## Need more control

TODO add example on how to override application events




