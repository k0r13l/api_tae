using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiTAE.Controllers
{
    public class CaracteristicaController : Controller
    {
        // GET: CaracteristicaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CaracteristicaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaracteristicaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaracteristicaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CaracteristicaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaracteristicaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CaracteristicaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaracteristicaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
