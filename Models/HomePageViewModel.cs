using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class HomePageViewModel
    {
        public LuckyNumberPartialViewModel luckyNunberPartial { get; set; }
        public  OpClPartialViewModel opClPartialViewModel { get; set; }
        public WhatsNumberPartialViewModel whatsNumberPartialView { get; set; }
    }

    public class LuckyNumberPartialViewModel
    {
        public List<tblLuckyNumber> tblLuckyNumbers { get; set; }
    }
    public class OpClPartialViewModel
    {
        public List<tblOpCl> tblOpCls { get; set; }
    }
    public class WhatsNumberPartialViewModel
    {
        public List<CaontactNumbers> tblCaontactNumbers { get; set; }
    }
}
