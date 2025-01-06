using FluentMigrator;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Localization;
using Nop.Web.Framework.Extensions;

namespace Nop.Web.Framework.Migrations.Common
{
    [NopMigration("2024-10-19 11:14:00", "DeleteHint LocalizationResourceMigration", UpdateMigrationType.Localization, MigrationProcessType.Update)]
    public class DeleteHintLocalizationResourceMigration : MigrationBase
    {
        #region Method

        public override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //do not use DI, because it produces exception on the installation process
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var (languageId, _) = this.GetLanguageData();

            #region Delete locales

            localizationService.DeleteLocaleResourceEndWithPrefixAsync(".hint", languageId);

            #endregion
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
        #endregion
    }
}
