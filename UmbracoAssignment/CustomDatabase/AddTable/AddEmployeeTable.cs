using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Migrations;
using UmbracoAssignment.CustomDatabase.Entities;
using Umbraco.Core.Logging;

namespace UmbracoAssignment.CustomDatabase.AddTable
{
    public class AddEmployeeTable : MigrationBase
    {
        public AddEmployeeTable(IMigrationContext context) : base(context)
        {
        }

        public override void Migrate()
        {

            Logger.Debug<AddEmployeeTable>("Running migration {MigrationStep}", "AddEmployeeTable");

            // Lots of methods available in the MigrationBase class - discover with this.
            if (TableExists("Employees") == false)
            {
                Create.Table<Employees>().Do();
            }
            else
            {
                Logger.Debug<AddEmployeeTable>("The database table {DbTable} already exists, skipping", "Employee");
            }
        }
    }
}