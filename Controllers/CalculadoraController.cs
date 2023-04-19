using DemoBTW.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBTW.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enter(CalculadoraViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    
                }
                catch (Exception)
                {
                    
                }
            }
            
            return View(model);
        }

    }
}
