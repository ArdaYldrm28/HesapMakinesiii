using HesapMakinesiii.Data;
using HesapMakinesiii.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly CalculatorDbContext _context;

    public HomeController(CalculatorDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new CalculatorModel
        {
            History = _context.Calculations
                              .OrderByDescending(c => c.Timestamp)
                              .Select(c => $"{c.Expression} = {c.Result} at {c.Timestamp:yyyy-MM-dd HH:mm:ss}")
                              .ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Index(CalculatorModel model)
    {
        if (ModelState.IsValid)
        {
            double result = 0;
            string expression = "";

            switch (model.Operation)
            {
                case "Add":
                    result = model.Number1 + model.Number2;
                    expression = $"{model.Number1} + {model.Number2}";
                    break;
                case "Subtract":
                    result = model.Number1 - model.Number2;
                    expression = $"{model.Number1} - {model.Number2}";
                    break;
                case "Multiply":
                    result = model.Number1 * model.Number2;
                    expression = $"{model.Number1} * {model.Number2}";
                    break;
                case "Divide":
                    if (model.Number2 != 0)
                    {
                        result = model.Number1 / model.Number2;
                        expression = $"{model.Number1} / {model.Number2}";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cannot divide by zero.");
                    }
                    break;
            }

            model.Result = result;

            if (ModelState.IsValid)
            {
                var calculation = new Calculation
                {
                    Expression = expression,
                    Result = result,
                    Timestamp = DateTime.Now
                };

                _context.Calculations.Add(calculation);
                _context.SaveChanges();

                model.History = _context.Calculations
                                      .OrderByDescending(c => c.Timestamp)
                                      .Select(c => $"{c.Expression} = {c.Result} at {c.Timestamp:yyyy-MM-dd HH:mm:ss}")
                                      .ToList();
            }
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> SaveCalculation([FromBody] CalculationDto calculationDto)
    {
        if (calculationDto == null)
        {
            return BadRequest();
        }

        var calculation = new Calculation
        {
            Expression = calculationDto.Expression,
            Result = calculationDto.Result,
            Timestamp = DateTime.Now
        };

        _context.Calculations.Add(calculation);
        await _context.SaveChangesAsync();

        return Ok();
    }
}

