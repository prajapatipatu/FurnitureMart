using FluentMigrator;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Localization;
using Nop.Web.Framework.Extensions;

namespace Nop.Web.Framework.Migrations.Customers
{
    [NopMigration("2024-11-07 09:05:00", "Customer LocalizationResourceMigration", UpdateMigrationType.Localization, MigrationProcessType.Update)]
    public class CustomerLocalizationResourceMigration : Migration
    {
        public override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            //do not use DI, because it produces exception on the installation process
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var (languageId, _) = this.GetLanguageData();

            #region Add or update locales
            localizationService.AddOrUpdateLocaleResource(new Dictionary<string, string>
            {
                ["Admin.Customers.Customers.Fields.GSTNumber"] = "GST Number",
                ["Admin.Customers.Customers.Fields.StateProvince"] = "State",
                ["Admin.Customers.Customers.Fields.ZipPostalCode"] = "Zip code",
                ["Admin.Customers.Customers.Fields.ZipPostalCode.Required"] = "Zip code is required.",
                ["Account.Fields.StateProvince.Required"] = "State is required.",
                ["Admin.Customers.Customers.Fields.FirstName.Required"] = "First name is required."

            }, languageId);

            #endregion
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
