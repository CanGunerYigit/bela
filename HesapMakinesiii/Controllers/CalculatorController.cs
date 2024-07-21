using Microsoft.AspNetCore.Mvc;
using HesapMakinesiii.Models;
using System;

namespace HesapMakinesiii.Controllers
{
    [Route("[controller]/[action]")]
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = _calculatorService.PerformCalculation(model.Number1, model.Number2, model.Operation);
                }
                catch (DivideByZeroException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }   

            return View(model);
        }
    }
}