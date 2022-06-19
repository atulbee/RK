using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class AddOpClViewModel
    {
        public int? id { get; set; }
        public int o { get; set; }
        public int c { get; set; }
        public string oCID { get; set; }
        public string jd { get; set; }
        public bool isSpecial { get; set; }
        public OCSlots Slot { get; set; }
        public List<tblOpCl> _tblOpCl { get; set; }
        public IEnumerable<OCSlots> Slots
        {
            get
            {
                return new List<OCSlots>() {
                    new OCSlots
                            {
                                id="11:15 AM -- 12:15 PM",
                                name="11:15 AM -- 12:15 PM"
                            },
                            new OCSlots
                            {
                                id="04:30 PM -- 06:50 PM",
                                name="04:30 PM -- 06:50 PM"
                            },
                            new OCSlots
                            {
                                id="10:30 PM -- 11:30 PM",
                                name="10:30 PM -- 11:30 PM"
                            }
                    };
            }
            set { }
        }
    }
}
