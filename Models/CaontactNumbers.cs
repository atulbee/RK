using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class CaontactNumbers
    {
        [Key]
        public int id { get; set; }

        public string number1 { get; set; }

        public string number2 { get; set; }

        public bool status { get; set; }

    }
}
