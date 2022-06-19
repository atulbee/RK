using System.Diagnostics;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure;
using CreativeTim.Argon.DotNetCore.Free.Infrastructure.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using CreativeTim.Argon.DotNetCore.Free.Models;
using CreativeTim.Argon.DotNetCore.Free.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

using System.Linq;
using System;
using Microsoft.Extensions.Configuration;

namespace CreativeTim.Argon.DotNetCore.Free.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private db dbContext;
        public class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Contact { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
        [TempData]
        public string StatusMessage { get; set; }

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            dbContext = new db(configuration);
        }

        [HttpGet("/admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/icons")]
        public IActionResult Icons()
        {
            return View();
        }
        [HttpGet("/addnumbers")]
        public IActionResult AddNumbers()
        {
            return View();
        }
        [HttpPost("/addnumbers")]
        public async Task<IActionResult> AddNumbers(AddPhoneNumberViewModel addPhoneNumberViewModel)
        {
            var x = await dbContext.InsertCN(addPhoneNumberViewModel);
            //     var x = await dbContext.GetOpCl();
            if (addPhoneNumberViewModel != null)
            {
                return View(addPhoneNumberViewModel);
            }
            else
            {
                addPhoneNumberViewModel = new AddPhoneNumberViewModel();
                return View(addPhoneNumberViewModel);
            }
        }

        [HttpGet("/createquotation")]
        public IActionResult CreateQuotation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetCustomers()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                List<Customer> customerData = new List<Customer>() {
                new Customer{
                    Contact="Test",
                    DateOfBirth=DateTime.Now,
                    Email="aa@aa.com",
                    FirstName="a",
                    LastName="b",
                    Id=1
                },new Customer{
                    Contact="Test",
                    DateOfBirth=DateTime.Now,
                    Email="aa@aa.com",
                    FirstName="a",
                    LastName="b",
                    Id=1
                },new Customer{
                    Contact="Test",
                    DateOfBirth=DateTime.Now,
                    Email="aa@aa.com",
                    FirstName="a",
                    LastName="b",
                    Id=1
                }

                };
                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("/addopcl/{id?}")]
        public async Task<IActionResult> AddOpCl(int? id)
        {
            AddOpClViewModel addOpClViewModel = new AddOpClViewModel();
            if (id != null)
            {
                tblOpCl tbl = (await dbContext.GetOpCl(Convert.ToInt32(id))).FirstOrDefault();
                addOpClViewModel.id = tbl.id;
                addOpClViewModel.jd = tbl.jd.ToString();
                addOpClViewModel.oCID = tbl.timeslot.ToString();
                addOpClViewModel.c = tbl.cl;
                addOpClViewModel.o = tbl.op;
                addOpClViewModel.o = tbl.op;
                addOpClViewModel.isSpecial = tbl.isSpecial;
            }
            return View(addOpClViewModel);

        }
        [HttpPost("/addopcl/{id?}")]
        public async Task<IActionResult> AddOpCl(AddOpClViewModel addOpClViewModel)
        {

            var x = await dbContext.InsertOpCl(addOpClViewModel);
            //     var x = await dbContext.GetOpCl();
            if (addOpClViewModel != null)
            {
                return View(addOpClViewModel);
            }
            else
            {
                addOpClViewModel = new AddOpClViewModel();
                return View(addOpClViewModel);
            }
        }
        [HttpPost("/opcldelete")]
        public async Task<IActionResult> OpClDelete(string id)
        {
            var data = await dbContext.OpClDelete(id);
            //     var x = await dbContext.GetOpCl();

            return Json(new { data = data }); ;
        }
        [HttpPost("/opclapprove")]
        public async Task<IActionResult> OpClApprove(string id)
        {
            var data = await dbContext.OpClApprove(id);
            //     var x = await dbContext.GetOpCl();

            return Json(new { data = data }); ;
        }
        [HttpPost("/lnapprove")]
        public async Task<IActionResult> LNApprove(string id)
        {
            var data = await dbContext.LNApprove(id);
            return Json(new { data = data }); ;
        }
        [HttpPost("/loaddata")]
        public async Task<IActionResult> LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = await dbContext.GetOpCl(); ;
                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Name == searchValue);
                //}

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.OrderByDescending(c=>c.publish_date).Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpGet("/viewopcl/{id?}")]
        public async Task<IActionResult> ViewOpClose(int? id)
        {
            AddOpClViewModel addOpClViewModel = new AddOpClViewModel();
            if (id != null)
            {
                tblOpCl tbl = (await dbContext.GetOpCl(Convert.ToInt32(id))).FirstOrDefault();
                addOpClViewModel.id = tbl.id;
                addOpClViewModel.jd = tbl.jd.ToString();
                addOpClViewModel.oCID = tbl.timeslot.ToString();
                addOpClViewModel.c = tbl.cl;
                addOpClViewModel.o = tbl.op;
                addOpClViewModel.o = tbl.op;
                addOpClViewModel.isSpecial = tbl.isSpecial;
            }
            return View(addOpClViewModel);

        }

        [HttpPost("/loadviewopcldata")]
        public async Task<IActionResult> LoadOpClData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = await dbContext.GetOpCl(); ;
                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Name == searchValue);
                //}

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.OrderByDescending(c => c.publish_date).Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost("/loadcndata")]
        public async Task<IActionResult> LoadCNData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = await dbContext.GetCN(); ;
                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Name == searchValue);
                //}

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("/addluckynumber")]
        public IActionResult AddLuckyNumber()
        {

            AddDailyLuckyViewModel addDailyLuckyViewModel = new AddDailyLuckyViewModel();
                return View(addDailyLuckyViewModel);
            
        }
        //[HttpPost("/addluckynumber")]
        //public async  Task<IActionResult> AddLuckyNumber(string id, string luckyNumberType , string luckyNumber ,string date)
        //{
        //    if (id != null)
        //    {
        //        AddDailyLuckyViewModel addDailyLuckyViewModel = new AddDailyLuckyViewModel();
        //        addDailyLuckyViewModel.id = Convert.ToInt32(id);
        //        addDailyLuckyViewModel.oCID = (luckyNumberType);
        //        addDailyLuckyViewModel.o = Convert.ToInt32(luckyNumber);
        //        addDailyLuckyViewModel.dateTime = Convert.ToDateTime(date);
        //        addDailyLuckyViewModel.crud = "Update";
        //        //var x = await dbContext.InsertLuckyNumbers(addDailyLuckyViewModel);
        //        return View(addDailyLuckyViewModel);
        //    }
        //    else
        //    {
        //        AddDailyLuckyViewModel addDailyLuckyViewModel = new AddDailyLuckyViewModel();
        //        return View(addDailyLuckyViewModel);
        //    }
        //}
        [HttpPost("/addluckynumber")]
        public async Task<IActionResult> AddLuckyNumber(AddDailyLuckyViewModel addDailyLuckyViewModel,string lnEdit,string lnHd,string AddUpdateLN)
        {
            if (lnEdit != null)
            {
                List<tblLuckyNumber> tbl = await dbContext.GetLN(Convert.ToInt32(lnHd));
                var tblFirst = tbl.FirstOrDefault();
                if (tblFirst != null)
                {
                    addDailyLuckyViewModel = new AddDailyLuckyViewModel();
                    addDailyLuckyViewModel.id = Convert.ToInt32(tblFirst.id);
                    addDailyLuckyViewModel.oCID = (tblFirst.LuckyNumberType);
                    addDailyLuckyViewModel.o = (tblFirst.LuckyNumber);
                    addDailyLuckyViewModel.dateTime = (tblFirst.date);
                    addDailyLuckyViewModel.crud = "Update";
                }
                return View(addDailyLuckyViewModel);
            }else if (AddUpdateLN != null)
            {
                //addDailyLuckyViewModel = new AddDailyLuckyViewModel();
                addDailyLuckyViewModel.crud = "Insert";
                var x = await dbContext.InsertLuckyNumbers(addDailyLuckyViewModel);
                return View(addDailyLuckyViewModel);
            }
            else
            {
                 addDailyLuckyViewModel = new AddDailyLuckyViewModel();
                return View(addDailyLuckyViewModel);
            }
        }
        [HttpPost("/loadlndata")]
        public async Task<IActionResult> LoadLNData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = await dbContext.GetLN(0, searchValue); 
                //Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Name == searchValue);
                //}

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.OrderByDescending(c=>c.date).Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("/maps")]
        public IActionResult Maps()
        {
            return View();
        }

        [ImportModelState]
        [HttpGet("/profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return View(new ProfileViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName
            });
        }

        [ExportModelState]
        [HttpPost("/profile")]
        public async Task<IActionResult> UpdateProfile(
            [FromForm]
            ProfileViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Profile));
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, input.Email);
                if (!setEmailResult.Succeeded)
                {
                    foreach (var error in setEmailResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // Model state might not be valid anymore if we weren't able to change the e-mail address
            // so we need to check for that before proceeding
            if (ModelState.IsValid)
            {
                if (input.FullName != user.FullName)
                {
                    // If we receive an empty string, set a null full name instead
                    user.FullName = string.IsNullOrWhiteSpace(input.FullName) ? null : input.FullName;
                }

                await _userManager.UpdateAsync(user);

                await _signInManager.RefreshSignInAsync(user);

                StatusMessage = "Your profile has been updated";
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet("/tables")]
        public IActionResult Tables()
        {
            return View();
        }

        [HttpGet("/upgrade")]
        public IActionResult Upgrade()
        {
            return View();
        }

        [HttpGet("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/status-code")]
        public IActionResult StatusCodeHandler(int code)
        {
            ViewBag.StatusCode = code;
            ViewBag.StatusCodeDescription = ReasonPhrases.GetReasonPhrase(code);
            ViewBag.OriginalUrl = null;


            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                ViewBag.OriginalUrl =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }

            if (code == 404)
            {
                return View("Status404");
            }

            return View("Status4xx");
        }
    }
}
