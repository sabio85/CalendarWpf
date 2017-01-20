using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.BL
{
    public class DateValidationResult
    {
        public DateTime Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
