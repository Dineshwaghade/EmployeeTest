using EmployeeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTest.Controllers
{
    public class HomeController : Controller
    {
        DataContext1 db = new DataContext1();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Designation = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            lst.Add(new SelectListItem() { Text = "Daily Wages", Value = "Daily Wages" });
            ViewBag.Category = new SelectList(lst, "Text", "Value");


            var data = db.EmployeeMaster.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult index(FormCollection form)
        {
            string category = form["cat"].ToString();
            string desg = form["desg"].ToString();
            ViewBag.Designation = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            lst.Add(new SelectListItem() { Text = "Daily Wages", Value = "Daily Wages" });
            ViewBag.Category = new SelectList(lst, "Text", "Value");
            var data =new List<Employee>();
            if(!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(desg))
            {
                int desg_id = Convert.ToInt32(desg);
                data = db.EmployeeMaster.Where(x => x.Employee_category == category && x.Designation_Id== desg_id).ToList();
            }
            else if (!string.IsNullOrEmpty(category))
            {
                 data = db.EmployeeMaster.Where(x => x.Employee_category == category).ToList();
            }
            else if(!string.IsNullOrEmpty(desg))
            {
                int desg_id = Convert.ToInt32(desg);
                data = db.EmployeeMaster.Where(x => x.Designation_Id == desg_id).ToList();
            }
            else
            {
                data = db.EmployeeMaster.ToList();
            }
            return View(data);
        }
        public ActionResult AddDesignation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDesignation(Designation model)
        {
            if(ModelState.IsValid)
            {
                db.DesignationMaster.Add(model);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult RegisterEmployee()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            lst.Add(new SelectListItem() { Text = "Daily Wages", Value = "Daily Wages" });

            ViewBag.Category = new SelectList(lst, "Text", "Value");

            ViewBag.Designation = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");
            return View();
        }
        [HttpPost]
        public ActionResult RegisterEmployee(Employee model)
        {
            ViewBag.Designation = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Regular", Value = "Regular" });
            lst.Add(new SelectListItem() { Text = "Daily Wages", Value = "Daily Wages" });

            ViewBag.Category = new SelectList(lst,"Text","Value");
            if (ModelState.IsValid)
            {
                db.EmployeeMaster.Add(model);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult EditEmploye(int id)
        {
            ViewBag.Designation = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");
            var data = db.EmployeeMaster.Find(id);
            if(data!=null)
            {
                return View(data);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult EditEmploye(int id,Employee model)
        {
            ViewBag.Designation = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");

            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult DeleteEmployee(int id)
        {
            var data = db.EmployeeMaster.Find(id);
            if(data!=null)
            {
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult AddAttendance()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "A", Value = "A" });
            lst.Add(new SelectListItem() { Text = "P", Value = "P" });
            lst.Add(new SelectListItem() { Text = "L", Value = "L" });

            ViewBag.Attendance= new SelectList(lst, "Text", "Value");

            return View();
        }
        [HttpPost]
        public ActionResult AddAttendance(EmployeeAttendance model)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "A", Value = "A" });
            lst.Add(new SelectListItem() { Text = "P", Value = "P" });
            lst.Add(new SelectListItem() { Text = "L", Value = "L" });

            ViewBag.Attendance = new SelectList(lst, "Text", "Value");


            if (ModelState.IsValid)
            {
                db.EmployeeAttendance.Add(model);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult AttendanceByDate()
        {
            //   ViewBag.Att = new SelectList(db.DesignationMaster.ToList(), "Designation_Id", "Designation_Desc");
            ViewModel model = new ViewModel();
            model.EmployeeAttendanceList = db.EmployeeAttendance.ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult AttendanceByDate(ViewModel model,FormCollection form)
        {
            if(model.Date!=null)
            {
                //model.EmployeeAttendanceList = (from s in db.EmployeeAttendance
                //                                orderby s.Date
                //                                select s).ToList();
                model.EmployeeAttendanceList = db.EmployeeAttendance.Where(x => x.Date == model.Date).ToList();
                return View(model);
            }
            else if(model.EmployeeId>0)
            {
                model.EmployeeAttendanceList = db.EmployeeAttendance.Where(x => x.Employee_Id == model.EmployeeId).ToList();
                return View(model);
            }
            else
            {
                ViewBag.noRecord = true;
                model.EmployeeAttendanceList = db.EmployeeAttendance.ToList();
            }
            return View(model);
        }
    }
}