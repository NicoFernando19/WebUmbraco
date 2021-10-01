using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPoco;
using Umbraco.Web.Mvc;
using UmbracoAssignment.CustomDatabase.Entities;

namespace UmbracoAssignment.Controllers
{
    public class DepartmentsController : SurfaceController
    {
        [HttpGet]
        // GET: Departments
        public ActionResult Index()
        {
            IDatabase db = new Database("umbracoDbDSN");
            IEnumerable<Department> departments = db.Fetch<Department>("select * from Department");
            return PartialView("~/Views/Partials/DepartmentsTable.cshtml", departments);
        }
    }
}