using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View(new InputViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(InputViewModel model)
        {
            string input = model.Input;

            int totalSum = 0;

            List<string> inputs = input.Split().ToList();

            for (int i = 0; i < inputs.Count; i+=3)
            {
                string currentInput = inputs[i];
                string sign = inputs[i+1];
                string nextInput = inputs[i+2];

                int num = int.Parse(currentInput);
                int nextNum = int.Parse(nextInput);

                int sum = 0;

                switch(sign)
                {
                    case "+":
                        sum += num + nextNum;
                        break;
                    case "-":
                        sum += num - nextNum;
                        break;
                    case "/":
                        sum += num / nextNum;
                        break;
                    case "X":
                        sum += num * nextNum;
                        break;
                }

                totalSum += sum;
            }
            
            model.Sum = totalSum.ToString();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}