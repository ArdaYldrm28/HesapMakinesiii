using Microsoft.AspNetCore.Mvc;
using HesapMakinesiii.Models;
using System.Collections.Generic;
using HesapMakinesiii.Helpers;
using System;

namespace HesapMakinesiii.Controllers
{
    public class CalculatorController : Controller
    {
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
                double result = 0;

                switch (model.Operation)
                {
                    case "Add":
                        result = model.Number1 + model.Number2;
                        break;
                    case "Subtract":
                        result = model.Number1 - model.Number2;
                        break;
                    case "Multiply":
                        result = model.Number1 * model.Number2;
                        break;
                    case "Divide":
                        if (model.Number2 != 0)
                        {
                            result = model.Number1 / model.Number2;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Cannot divide by zero.");
                        }
                        break;
                }

                model.Result = result;
            }


            return View(model);
        }
    }
}
