using FluentMigrator;
using Nop.Core.Domain.Customers;

namespace Nop.Data.Migrations.Customers
{
    [NopMigration("2024-11-07 08:57:00", "Customer AlterTableMigration", UpdateMigrationType.Localization, MigrationProcessType.Update)]
    public class CustomerAlterTableMigration : Migration
    {        
        public override void Up()
        {
            var customerTableName = nameof(Customer);
            var gstNumberColumnName = nameof(Customer.GSTNumber);
            if (!Schema.Table(customerTableName).Column(gstNumberColumnName).Exists())
            {
                Alter.Table(customerTableName)
                    .AddColumn(gstNumberColumnName).AsString().Nullable();
            }
        }
        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
