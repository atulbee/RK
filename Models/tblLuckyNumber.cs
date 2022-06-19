using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class tblLuckyNumber
    {
        [Key]
        public int id { get; set; }

        public string LuckyNumberType { get; set; }

        public string LuckyNumber { get; set; }

        public DateTime date { get; set; }

        public bool status { get; set; }

    }
}
