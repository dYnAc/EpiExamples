using System;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace EpiExamples.Models.People
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class PeopleRootInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var contentRootService = context.Locate.Advanced.GetInstance<ContentRootService>();

            // We create a folder at the root level called People 
            contentRootService.Register<ContentFolder>("People", new Guid("c41959cf-efc1-4e5f-b79d-78d3b8e5af14"), ContentReference.RootPage);
        }

        public void Uninitialize(InitializationEngine context)
        {

        }
    }
}