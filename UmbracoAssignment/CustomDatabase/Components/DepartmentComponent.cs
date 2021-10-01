using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Migrations;
using Umbraco.Core.Migrations.Upgrade;
using Umbraco.Core.Scoping;
using Umbraco.Core.Services;
using UmbracoAssignment.CustomDatabase.AddTable;

namespace UmbracoAssignment.CustomDatabase.Components
{
    public class DepartmentComponent : IComponent
    {
        private IScopeProvider _scopeProvider;
        private IMigrationBuilder _migrationBuilder;
        private IKeyValueService _keyValueService;
        private ILogger _logger;

        public DepartmentComponent(IScopeProvider scopeProvider, IMigrationBuilder migrationBuilder, IKeyValueService keyValueService, ILogger logger)
        {
            _scopeProvider = scopeProvider;
            _migrationBuilder = migrationBuilder;
            _keyValueService = keyValueService;
            _logger = logger;
        }

        public void Initialize()
        {
            // Create a migration plan for a specific project/feature
            // We can then track that latest migration state/step for this project/feature
            var migrationPlanDepartment = new MigrationPlan("Department");

            // This is the steps we need to take
            // Each step in the migration adds a unique value
            migrationPlanDepartment.From(string.Empty)
                .To<AddDepartmentTable>("department-db");

            // Go and upgrade our site (Will check if it needs to do the work or not)
            // Based on the current/latest step
            //var upgraderForDepartment = new Upgrader(migrationPlanDepartment);
            //upgraderForDepartment.Execute(_scopeProvider, _migrationBuilder, _keyValueService, _logger);
            var upgrader = new Upgrader(migrationPlanDepartment);
            upgrader.Execute(_scopeProvider, _migrationBuilder, _keyValueService, _logger);
        }

        public void Terminate()
        {
        }
    }
}