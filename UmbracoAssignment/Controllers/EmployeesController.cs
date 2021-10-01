using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPoco;
using Umbraco.Web.Mvc;
using UmbracoAssignment.CustomDatabase.Entities;
using UmbracoAssignment.Helper;
using UmbracoAssignment.Models;

namespace UmbracoAssignment.Controllers
{
    public class EmployeesController : SurfaceController
    {
        [HttpGet]
        public ActionResult Index()
        {
            IDatabase db = new Database("umbracoDbDSN");
            List<Employees> employees = db.Fetch<Employees>("select * from Employees");
            return PartialView("~/Views/Partials/EmployeesTable.cshtml",employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("~/Views/Partials/CreateFormEmployee.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployeePost(EmployeeModel employeeModel)
        {
            IDatabase db = new Database("umbracoDbDSN");
            if (ModelState.IsValid)
            {
                Employees employee = EntityModelConverter.ConvertEmployeModelToEmployee(employeeModel);
                if (employee.DepartmentId == 1)
                {
                    employee.DepartmentId = 1;
                    employee.DepartmentName = "IT";
                }
                else
                {
                    employee.DepartmentId = 2;
                    employee.DepartmentName = "DevOps";
                }
                db.Insert<Employees>(employee);
                return RedirectToUmbracoPage(1079);
            }

            return RedirectToUmbracoPage(1079);
        }
        [HttpGet]
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            IDatabase db = new Database("umbracoDbDSN");
            Employees employee = db.SingleById<Employees>(id);
            EmployeeModel employeeModel = EntityModelConverter.ConvertEmployeToEmployeeModel(employee);
            return PartialView("~/Views/Partials/EditEmployeeForm.cshtml", employeeModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditEmployee(int id, EmployeeModel employeeModel)
        {
            IDatabase db = new Database("umbracoDbDSN");
            Employees employee = EntityModelConverter.ConvertEmployeModelToEmployee(employeeModel);
            if (employee.DepartmentId == 1)
            {
                employee.DepartmentId = 1;
                employee.DepartmentName = "IT";
            }
            else
            {
                employee.DepartmentId = 2;
                employee.DepartmentName = "DevOps";
            }
            db.Update(employee);
            return RedirectToUmbracoPage(1079);

        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
