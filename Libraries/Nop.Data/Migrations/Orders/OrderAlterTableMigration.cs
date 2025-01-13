using FluentMigrator;
using Nop.Core.Domain.Orders;

namespace Nop.Data.Migrations.Orders
{
    [NopMigration("2025-01-13 11:43:00", "Order AlterTableMigration", UpdateMigrationType.Localization, MigrationProcessType.Update)]
    public class OrderAlterTableMigration : Migration
    {

        public override void Up()
        {
            var orderTableName = nameof(Order);
            var shippedCountryIdColumnName = nameof(Order.ShippedToCountryId);
            if (!Schema.Table(orderTableName).Column(shippedCountryIdColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(shippedCountryIdColumnName).AsInt32().Nullable();
            }
            var shippedStateIdColumnName = nameof(Order.ShippedToStateId);
            if (!Schema.Table(orderTableName).Column(shippedStateIdColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(shippedStateIdColumnName).AsInt32().Nullable();
            }
            var shippedCityColumnName = nameof(Order.ShippedToCity);
            if (!Schema.Table(orderTableName).Column(shippedCityColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(shippedCityColumnName).AsString(500).Nullable();
            }

            var shippedAddressColumnName = nameof(Order.ShippedToAddress);
            if (!Schema.Table(orderTableName).Column(shippedAddressColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(shippedAddressColumnName).AsString(500).Nullable();
            }

            var shippedZipCodeColumnName = nameof(Order.ShippedToZipCode);
            if (!Schema.Table(orderTableName).Column(shippedZipCodeColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(shippedZipCodeColumnName).AsString(500).Nullable();
            }

            var shippedGSTNumberColumnName = nameof(Order.ShippedToGSTNumber);
            if (!Schema.Table(orderTableName).Column(shippedGSTNumberColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(shippedGSTNumberColumnName).AsString(500).Nullable();
            }

            var transportionModeColumnName = nameof(Order.TransportionMode);
            if (!Schema.Table(orderTableName).Column(transportionModeColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(transportionModeColumnName).AsString(500).Nullable();
            }
            var vehicleNumberColumnName = nameof(Order.VehicleNumber);
            if (!Schema.Table(orderTableName).Column(vehicleNumberColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(vehicleNumberColumnName).AsString(500).Nullable();
            }
            var dateOfSupplyColumnName = nameof(Order.DateOfSupply);
            if (!Schema.Table(orderTableName).Column(dateOfSupplyColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(dateOfSupplyColumnName).AsDateTime2().Nullable();
            }

            var placeOfSupplyColumnName = nameof(Order.PlaceOfSupply);
            if (!Schema.Table(orderTableName).Column(placeOfSupplyColumnName).Exists())
            {
                Alter.Table(orderTableName)
                    .AddColumn(placeOfSupplyColumnName).AsString(500).Nullable();
            }
        }
        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
