using FluentMigrator;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Extensions;

namespace Nop.Web.Framework.Migrations.Orders
{
    [NopMigration("2024-11-16 09:58:15", "OrderSettings Migration", UpdateMigrationType.Localization, MigrationProcessType.Update)]
    public class OrderSettingsMigration :Migration
    {
        public override void Up()
        {
            if (!DataSettingsManager.IsDatabaseInstalled())
                return;

            var settingService = EngineContext.Current.Resolve<ISettingService>();

            var orderSetting = settingService.LoadSettingAsync<OrderSettings>().Result;
            orderSetting.AFMGSTNumber = "24AHNPP2261N1ZX";
            orderSetting.AFMMobileNumber = "9925081581";
            orderSetting.AFMAddress = "Sabari Dham, Nr. Hariyant Imaging Center, Kakara Par By Pass Road, Vyara, Gujarat 394650";
            orderSetting.AFMFullName = "Harish J Prajapati";
            orderSetting.AFMState = "Gujarat";
            orderSetting.AFMStateCode = "24";
            orderSetting.PaymentStatus = "Pending|Paid|Refunded";
            orderSetting.GstRate = 18;
            orderSetting.CustomerRequired = true;

            settingService.SaveSettingAsync(orderSetting, settings => settings.AFMGSTNumber).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.AFMMobileNumber).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.AFMAddress).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.AFMFullName).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.AFMState).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.AFMStateCode).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.PaymentStatus).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.GstRate).Wait();
            settingService.SaveSettingAsync(orderSetting, settings => settings.CustomerRequired).Wait();

            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();

            var (languageId, _) = this.GetLanguageData();

            #region Add or update locales
            localizationService.AddOrUpdateLocaleResource(new Dictionary<string, string>
            {
                ["Admin.Orders.AddNew"] = "Add new order",
                ["Admin.Order.Info"] = "Order Info",
                ["Admin.Order.Added"] = "The new order has been added successfully.",
                ["Admin.Order.Updated"] = "The order has been updated successfully.",
                ["Pdf.BillingInformation"] = "Details Of Receiver (Billed To)",
                ["Pdf.ShippingInformation"] = "Details Of Consignee (Shipped To)",
                ["Pdf.Shipping"] = "Add @ CGST 9% ",
                ["Pdf.Tax"] = "Add @ SGST 9% ",
                ["Pdf.OrderDate"] = "Invoice Date",
                ["Pdf.Order"]="Invoice No",
                ["Pdf.Address.PaymentMethod"]="GSTIN",
                ["Pdf.Address.ShippingMethod"] = "GSTIN",
                ["Pdf.Product.Name"] = "Product Name",
                ["Admin.Order.Customers.Required"] = "Customer is reuired.",
                ["Admin.Catalog.Products.Fields.Sku"] ="HSN No",
                ["Pdf.Product.Sku"] ="HSN No",

            }, languageId);

            #endregion
        }

        /// <summary>Collects the DOWN migration expressions</summary>
        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
