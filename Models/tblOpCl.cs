using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class tblOpCl
    {
        [Key]
        public int id { get; set; }

        public int op { get; set; }

        public int cl { get; set; }

        public int jd { get; set; }

        public bool publish_status { get; set; }

        public DateTime publish_date { get; set; }

        public string timeslot { get; set; }

        public int dayseq { get; set; }
        public bool isSpecial { get; set; }

    }
}
