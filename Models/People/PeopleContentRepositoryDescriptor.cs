using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell;

namespace EpiExamples.Models.People
{
    [ServiceConfiguration(typeof(IContentRepositoryDescriptor))]
    public class PeopleContentRepositoryDescriptor : ContentRepositoryDescriptorBase
    {

        private readonly ContentReference _root;

        public PeopleContentRepositoryDescriptor(ContentRootService contentRootService)
        {
            _root = contentRootService.Get("People");
        }

        public override string Key => "people";

        public override string Name => "People";

        public override IEnumerable<ContentReference> Roots => new[] { _root };

        public override IEnumerable<Type> ContainedTypes => new[] { typeof(PersonContent), typeof(ContentFolder) };

        public override IEnumerable<Type> CreatableTypes => new[] { typeof(PersonContent), typeof(ContentFolder) };

        public override IEnumerable<Type> LinkableTypes => new[] { typeof(PersonContent), };

        public override IEnumerable<Type> MainNavigationTypes => new[] { typeof(ContentFolder), };

    }
}