using LAB2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LAB2.Controllers
{
    public class TodoController : Controller
    {
        static List<TaskModel> tasks = new List<TaskModel>
        {
            new TaskModel { Id = 1, TaskName = "Ôn tập HTML" },
            new TaskModel { Id = 2, TaskName = "Ôn tập CSS" }
        };

        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string taskName)
        {
            int newId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(new TaskModel { Id = newId, TaskName = taskName });
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(int id, string taskName)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.TaskName = taskName;
            }
            return RedirectToAction("Index");
        }

        // 💥 Delete Action
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}
