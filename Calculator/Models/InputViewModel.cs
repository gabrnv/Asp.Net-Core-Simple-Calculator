using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class InputViewModel
    {
        [Required]
        public string Input { get; set; }
    }
}
