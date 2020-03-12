using EPiServer.Shell;
using EPiServer.Shell.ViewComposition;

namespace EpiExamples.Models.People
{
    [Component]
    public class PeopleTreeComponent : ComponentDefinitionBase
    {

        public PeopleTreeComponent() : base("epi-cms/asset/HierarchicalList")
        {
            base.Title = "People";
            Categories = new[] { "content" };
            PlugInAreas = new[] { PlugInArea.AssetsDefaultGroup, PlugInArea.NavigationDefaultGroup };
            SortOrder = 1000;
            base.Settings.Add(new Setting("repositoryKey", "people"));
            base.Settings.Add(new Setting("noDataMessages", new { single = "This folder does not contain any locations", multiple = "These folders do not contain any locations" }));
        }
    }
}