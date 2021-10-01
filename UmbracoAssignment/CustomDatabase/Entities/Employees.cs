using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace UmbracoAssignment.CustomDatabase.Entities
{
    [TableName("Employees")]
    [PrimaryKey("Id", AutoIncrement = true)]
    [ExplicitColumns]
    public class Employees
    {
        [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [Length(100)]
        public string Name { get; set; }

        [Column("Email")]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        [Length(50)]
        public string Email { get; set; }

        [Column("DoB")]
        public DateTime DoB { get; set; }
        [Column("DepartmentName")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public string DepartmentName { get; set; }
        [Column("DepartmentId")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public int? DepartmentId { get; set; }
        //public Department department { get; set; }
    }
}