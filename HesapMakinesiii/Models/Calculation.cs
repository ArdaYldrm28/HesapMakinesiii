using System;

namespace HesapMakinesiii.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public string Expression { get; set; }
        public decimal Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}