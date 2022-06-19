using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class AddDailyLuckyViewModel
    {
        public int id { get; set; }
        public string o { get; set; }
        public DateTime dateTime { get; set; }
        public string oCID { get; set; }
        public string crud { get; set; }
        public OCModel oCModel { get; set; }
        public IEnumerable<OCModel> oCModels
        {
            get
            {
                return new List<OCModel>() {
                    new OCModel
                            {
                                id=1,
                                name="Open"
                            },
                            new OCModel
                            {
                                id=2,
                                name="Close"
                            },
                            new OCModel
                            {
                                id=3,
                                name="Jodi"
                            },
                            new OCModel
                            {
                                id=4,
                                name="Paan"
                            }
                    };
            }
            set { }
        }
    }
}
