using System.Configuration;
using System.Web;
using EPiServer.Web;

namespace EpiExamples.Helpers
{
    public class MainSiteSwitchHelper
    {
        private static string MainSiteName { get; }

        static MainSiteSwitchHelper()
        {
            var mainSiteString = ConfigurationManager.AppSettings["MainSiteName"];
            if (string.IsNullOrEmpty(mainSiteString))
            {
                mainSiteString = "Main Site";
            }

            MainSiteName = mainSiteString;
        }
        public static bool IsMainSite => HttpContext.Current != null && (HttpContext.Current.Request.Url.Host.Contains(MainSiteHostName) || IsMainSiteByDefinition());

        private static string MainSiteHostName
        {
            get
            {
                var hostName = ConfigurationManager.AppSettings["MainSiteHostName"];
                if (string.IsNullOrEmpty(hostName))
                {
                    hostName = "mainsite";
                }

                return hostName;
            }
        }

        private static bool IsMainSiteByDefinition()
        {
            return MainSiteName.Contains(SiteDefinition.Current.Name);
        }
    }
}