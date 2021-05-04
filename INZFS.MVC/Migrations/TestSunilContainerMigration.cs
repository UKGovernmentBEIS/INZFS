using INZFS.MVC.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INZFS.MVC.Migrations
{
    public class TestSunilContainerMigration : DataMigration
    {
        public readonly IContentDefinitionManager _contentDefinitionManager;
        public TestSunilContainerMigration(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("INZFSApplicationContainer", type => type
            .Creatable()
            .Listable()
            .WithPart("BagPart", "BagPart", builder => builder
                .WithDisplayName("INZFS Application")
                .WithDescription("INZFSApplication description")
                .MergeSettings<BagPartSettings>(x => x.ContainedContentTypes = new string[] { "ProjectSummaryPart", "ProjectDetailsPart", "OrgFundingPart" }))
        );

            return 1;
        }
    }

    /*
    public class TestSunilBagPartMigration : DataMigration
    {
        public readonly IContentDefinitionManager _contentDefinitionManager;
        public TestSunilBagPartMigration(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("TestSunilBagPart", type => type
               .Creatable()
               .Listable()
               .WithPart(nameof(TestSunilBagPart))
           );

            return 1;
        }
    }

    public class TestSunilBagPart : ContentPart
    {
        public string Firstname { get; set; }
        public string Laststname { get; set; }
    }
    */
}
