using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreApplication.Models;

namespace MvcCoreApplication.Controllers
{
    public class JobController : Controller
    {
        HumanResourceDbContext context = new HumanResourceDbContext();
        public ViewResult Index()
        {
            var jobs = context.Jobs.ToList();
            ViewBag.jobList = jobs;
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Job j1)
        {
            context.Jobs.Add(j1);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Job jb = context.Jobs.Where(x => x.JobId == id).SingleOrDefault();
            
            return View(jb);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Job jb = context.Jobs.Find(id);
            return View(jb);
        }
        [HttpPost]
        public ActionResult Delete(int id, Job j1)
        {
            var jb = context.Jobs.Where(x => x.JobId == id).SingleOrDefault();
            context.Jobs.Remove(jb);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var jb = context.Jobs.Where(x => x.JobId == id).SingleOrDefault();
            return View(jb);

        }
        [HttpPost]
        public ActionResult Edit( Job j1)
        {
            var jb = context.Jobs.Where(x => x.JobId == j1.JobId).SingleOrDefault();
            context.Entry(jb).CurrentValues.SetValues(j1);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}