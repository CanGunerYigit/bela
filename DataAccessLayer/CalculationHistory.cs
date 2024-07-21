using System;
using System.ComponentModel.DataAnnotations;

namespace HesapMakinesiii.Data
{
    public class CalculationHistory
    {
        [Key]
        public int Id { get; set; }
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public string Operation { get; set; }
        public double Result { get; set; }
            
    }
}
