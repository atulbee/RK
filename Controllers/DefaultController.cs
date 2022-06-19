using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    public class DefaultController : Controller
    {
        private db dbContext;
        public DefaultController(IConfiguration configuration)
        {
            dbContext = new db(configuration);
        }
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.luckyNunberPartial = new LuckyNumberPartialViewModel();
            homePageViewModel.opClPartialViewModel = new OpClPartialViewModel();
            homePageViewModel.whatsNumberPartialView = new WhatsNumberPartialViewModel();
            homePageViewModel.luckyNunberPartial.tblLuckyNumbers = await dbContext.GetLNToday();
            homePageViewModel.opClPartialViewModel.tblOpCls = await dbContext.GetOPCLToday();
            homePageViewModel.whatsNumberPartialView.tblCaontactNumbers = await dbContext.GetCN();
            return View(homePageViewModel);
        }
        [HttpGet("/jodichart")]
        public async Task<IActionResult> JodiChart()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.opClPartialViewModel = new OpClPartialViewModel();
            homePageViewModel.opClPartialViewModel.tblOpCls = await dbContext.GetOPCLHistory();
            return View(homePageViewModel);
        }
        [HttpGet("/pannelchart")]
        public async Task<IActionResult> PanelChart()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.opClPartialViewModel = new OpClPartialViewModel();
            homePageViewModel.opClPartialViewModel.tblOpCls = await dbContext.GetOPCLHistory();
            return View(homePageViewModel);
        }
        [HttpGet("/all")]
        public async Task<IActionResult> all220()
        {
            
            return View();
        }
    }
}
