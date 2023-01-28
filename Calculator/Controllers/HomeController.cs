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

            bool isValid = true;

            while(isValid)
            {
                string currentInput = inputs[0];
                string sign = inputs[1];
                string nextInput = inputs[2];

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

                inputs.RemoveRange(0, 3);
                inputs.Insert(0, sum.ToString());

                if (inputs.Count() < 3)
                {
                    totalSum += sum;
                    break;
                }
            }
            

            model.Sum = totalSum.ToString() + " ";

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}