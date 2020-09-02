using EpiExamples.Models.Blocks;
using EpiExamples.Models.Pages;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace EpiExamples.Business.Initialization
{
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class ExtendedTinyMceInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
            // Do nothing
        }

        public void Uninitialize(InitializationEngine context)
        {
            // Do nothing
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                // Add content CSS to the default settings.
                config.Default()
                    .ContentCss("/static/css/editor.css");

                // This will clone the default settings object and extend it by
                // limiting the block formats for the MainBody property of an ArticlePage.
                config.For<ArticlePage>(t => t.MainBody)
                    .BlockFormats("Paragraph=p;Header 1=h1;Header 2=h2;Header 3=h3");

                // Passing a second argument to For<> will clone the given settings object
                // instead of the default one and extend it with some basic toolbar commands.
                config.For<EditorialBlock>(t => t.MainBody, config.Empty())
                    .AddEpiserverSupport()
                    .DisableMenubar()
                    .Toolbar("bold italic underline strikethrough");

                // Add js and iframe capabilities to default settings.
                var jsConfigurationSettings = config.Default().Clone()
                    .AddSetting("valid_children", "+body[style],+div[span],+a[div|i]") // Allow body with style property, div with span inner elements and anchor with div or i inner elements
                    .AddSetting("allow_html_in_named_anchor", "true") // If allows or not html in a named anchor
                    .AddSetting("allow_script_urls", "true") // If it allows scripts urls, this is needed to enable js content
                    .AddSetting("extended_valid_elements", // List of valid elements in the editor, this includes scritps (for js), iframe, and several others. What you send inside the [] are the allowed inner elements for that tag 
                        "script[language|type|src],iframe[src|alt|title|width|height|align|name|style],picture,source[srcset|media],a[id|href|target|onclick|class],span[*],div[*]")
                    .AddPlugin(
                        "epi-link epi-image-editor epi-dnd-processor epi-personalized-content print preview searchreplace autolink directionality visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor " +
                        " imagetools colorpicker textpattern help code") // A lot of epi features, it is not related to enable js or iframes
                    .Toolbar(
                        "formatselect styleselect | bold italic underline strikethrough subscript superscript | epi-personalized-content | removeformat | fullscreen preview | code"
                        , "") // Three parameter for first second and third row
                    .Menubar("edit insert view tools") // Menu bar elements
                    .BlockFormats("Paragraph=p;Heading 2=h2;Heading 3=h3;Heading 4=h4;Heading 5=h5;Heading 6=h6"); // Formats

                // Set new configuration to standard page main body property
                config.For<StandardPage>(m => m.MainBody, jsConfigurationSettings);
            });
        }
    }
}