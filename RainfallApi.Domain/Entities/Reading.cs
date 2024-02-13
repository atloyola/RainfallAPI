using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallApi.Domain.Entities
{
    public class Reading
    {
        public string Date => DateTime.ToString("yyyy-MM-dd");
        public DateTime DateTime { get; set; }
        public string? Measure { get; set; }
        public double Value { get; set; }        
    }
}
