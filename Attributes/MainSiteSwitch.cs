using System;
using System.Web.Mvc;
using EpiExamples.Helpers;

namespace EpiExamples.Attributes
{
    public class MainSiteSwitch : Attribute, IMetadataAware
    {
        public bool AllowEditing => MainSiteSwitchHelper.IsMainSite;

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.ShowForEdit = AllowEditing;
        }
    }
}