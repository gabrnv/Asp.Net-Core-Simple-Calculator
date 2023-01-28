using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class InputViewModel
    {
        public InputViewModel()
        {
            Sum = "";
        }

        [Required]
        public string Input { get; set; }
        [Required]
        public string Sum { get; set; }

    }
}
