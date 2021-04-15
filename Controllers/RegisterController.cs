using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCPOC.Repository;
using MVCPOC.Models;

namespace MVCPOC.Controllers
{
    public class RegisterController : Controller
    {
        IApplicantTypeRepository _applicantTypeRepository = null;
        IApplicantRepository applicantRepository = null;// { get; set; }
        public RegisterController(IApplicantTypeRepository iAppTypeRepo,IApplicantRepository appRepo)
        {
             _applicantTypeRepository = iAppTypeRepo;
            applicantRepository = appRepo;
            
        }
        public IActionResult Index(int id)
        {
            List<SelectListItem> listItems = _applicantTypeRepository.GetAllApplicantType().Select(p => new SelectListItem
            { Text = p.TypeName, Value = p.Id.ToString() }).ToList();
            
            listItems.Find(s => s.Value == id.ToString()).Selected = true;
            ViewBag.TypeId = listItems;
            return View();
        }
        [HttpPost]
        public IActionResult Register(Applicant applicant)
        {
            int id = 0;
            if(ModelState.IsValid)
            {
              id=  applicantRepository.CreateApplicant(applicant);
                return RedirectToAction("Activate", new { id = applicant.Id });
            }
            else
            {
                // ModelState.AddModelError(string.Empty, "Please verify your details.");
                List<SelectListItem> listItems = _applicantTypeRepository.GetAllApplicantType().Select(p => new SelectListItem
                { Text = p.TypeName, Value = p.Id.ToString() }).ToList();

                listItems.Find(s => s.Value == applicant.TypeId.ToString()).Selected = true;
                ViewBag.TypeId = listItems;
                return View("Index", applicant);

            }
//return RedirectToAction("Activate", new {id=applicant.Id });
        }
        public IActionResult Activate(int id)
        {
            Applicant applicant = applicantRepository.GetApplicantById(id);
            LoginView lmodel = new LoginView();
            lmodel.Id = applicant.Id;
            return View(lmodel);
        }
        [HttpPost]
        public IActionResult Activate(LoginView  applicantObj)
        {
            if (ModelState.IsValid)
            {
                Applicant applicant = applicantRepository.GetApplicantById(applicantObj.Id);
                applicant.Username = applicantObj.Username;
                applicant.Password = applicantObj.Password;
                applicantRepository.UpdateApplicant(applicant);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View("Activate", applicantObj);
            }
        }
    }
}
