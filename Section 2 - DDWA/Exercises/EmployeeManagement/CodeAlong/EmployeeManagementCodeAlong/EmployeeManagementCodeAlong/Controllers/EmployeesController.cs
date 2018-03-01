using EmployeeManagementCodeAlong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementCodeAlong.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<EmployeeListViewModel> model = from employee in EmployeeRepository.GetAll()
                                                join department in DepartmentRepository.GetAll()
                                                on employee.DepartmentId equals department.DepartmentId
                                                select new EmployeeListViewModel
                                                {
                                                    Name = employee.FirstName + " " + employee.LastName,
                                                    Deparment = department.DepartmentName,
                                                    Phone = employee.Phone,
                                                    EmployeeID = employee.EmployeeId
                                                };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();

            model.Departments = (from department in DepartmentRepository.GetAll()
                                 select new SelectListItem()
                                 {
                                     Text = department.DepartmentName,
                                     Value = department.DepartmentId.ToString()
                                 }).ToList();
           
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model)
        {

            if (ModelState.IsValid)
            {
                Employee employee = new Employee();

                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.DepartmentId = model.DepartmentId;

                EmployeeRepository.Add(employee);

                return RedirectToAction("List");
            }
            else
            {
                model.Departments = (from department in DepartmentRepository.GetAll()
                                     select new SelectListItem()
                                     {
                                         Text = department.DepartmentName,
                                         Value = department.DepartmentId.ToString()
                                     }).ToList();

                return View(model);
            }
        }
    }
}