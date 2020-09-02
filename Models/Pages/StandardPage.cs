using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using EpiExamples.Attributes;

namespace EpiExamples.Models.Pages
{
    /// <summary>
    /// Used for the pages mainly consisting of manually created content such as text, images, and blocks
    /// </summary>
    [SiteContentType(GUID = "9CCC8A41-5C8C-4BE0-8E73-520FF3DE8267")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-standard.png")]
    public class StandardPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 310)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 320)]
        public virtual ContentArea MainContentArea { get; set; }

        [MainSiteSwitch] // Property only used in main site
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 330)]
        [CultureSpecific]
        public virtual string SubTitle { get; set; }
    }
}
