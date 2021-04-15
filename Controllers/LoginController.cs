using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPOC.Models;
using MVCPOC.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MVCPOC.Controllers
{
    public class LoginController : Controller
    {
        IApplicantTypeRepository _applicantTypeRepository = null;
        IApplicantRepository applicantRepository = null;// { get; set; }
        public LoginController(IApplicantTypeRepository iAppTypeRepo, IApplicantRepository appRepo)
        {
            _applicantTypeRepository = iAppTypeRepo;
            applicantRepository = appRepo;

        }
        public IActionResult Index()
        {
            List<SelectListItem> listItems = _applicantTypeRepository.GetAllApplicantType().Select(p => new SelectListItem
            { Text = p.TypeName, Value = p.Id.ToString() }).ToList();
            SelectListItem firstItem = new SelectListItem();
            firstItem.Text = "-Select-";
            
            listItems.Insert(0, firstItem);
            ViewBag.TypeId = listItems;
            return View();
        }
        [HttpPost]
        public IActionResult Authorise(Applicant app)
        {
            List<SelectListItem> listItems = _applicantTypeRepository.GetAllApplicantType().Select(p => new SelectListItem
            { Text = p.TypeName, Value = p.Id.ToString() }).ToList();
            SelectListItem firstItem = new SelectListItem();
            firstItem.Text = "-Select-";

            listItems.Insert(0, firstItem);
            listItems.Find(s => s.Value == app.TypeId.ToString()).Selected = true;
            ViewBag.TypeId = listItems;
            //if (ModelState.IsValid)
            //{
                Applicant applicant = applicantRepository.GetApplicant(app);
                ApplicantType appType = _applicantTypeRepository.GetApplicantTypeById((int)applicant.TypeId);

                if (applicant != null)
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, applicant.FirstName +" " +applicant.LastName),
                    new Claim(ClaimTypes.Role,appType.TypeName),
                    new Claim(ClaimTypes.Email,applicant.BusinessEmail)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
               return RedirectToAction("Index", "Home");
            }
                else
                {
                    TempData["errorMessage"] = "Invalid credentials.";
                    return View("Index", applicant);
                }
           // }
          //  ModelState.AddModelError("UserName", "please enter username");
           // return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
