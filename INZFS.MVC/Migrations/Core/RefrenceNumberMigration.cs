using INZFS.MVC.Models.Core;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace INZFS.MVC.Migrations.Core
{
    public class RefrenceNumberMigration : DataMigration
    {
        public readonly IContentDefinitionManager _contentDefinitionManager;
        public RefrenceNumberMigration(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinition("RefrenceNumber", type => type
               .Creatable()
               .Listable()
               .WithPart(nameof(RefrenceNumberPart))
           );

            return 1;
        }
    }
}