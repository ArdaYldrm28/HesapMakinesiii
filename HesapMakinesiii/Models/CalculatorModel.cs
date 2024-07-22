using System.ComponentModel.DataAnnotations;

namespace HesapMakinesiii.Models
{
    public class CalculatorModel
    {
        [Required]
        public double Number1 { get; set; }
        [Required]
        public double Number2 { get; set; }
        [Required]
        public string Operation { get; set; }
        public double Result { get; set; }

    }
}
