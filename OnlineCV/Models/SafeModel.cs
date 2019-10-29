using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCV.Models
{
    public class SafeModel
    {
        public bool Open { get; set; } = false;

        public string[] Productnumbers = new string[]
        {
            "1234",
            "2345",
            "3456",
            "4567",
            "5678",
            "6789"
        };

        public List<string> NotFound { get; set; } = new List<string>();
    }
}
