using DietAndTreatmentScanner.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DietAndTreatmentScanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly TreatmentRepository _treatmentRepository;

        // Initialize repository in constructor
        public HomeController()
        {
            _treatmentRepository = new TreatmentRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDietScheduleActivitiesList(long appId, string date)
        {
            try
            {
                if (!DateTime.TryParse(date, out DateTime parsedDate))
                {
                    return Json(new { error = "Invalid date format" }, JsonRequestBehavior.AllowGet);
                }

                var result = _treatmentRepository.GetDietScheduleActivitiesList(appId, parsedDate);

                if (result == null || !result.Any())
                {
                    return Json(new { message = "No data found" }, JsonRequestBehavior.AllowGet);
                }

                return Json(result, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                return Json(new { error = "An error occurred: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetPatientSchedule(long appId, string date)
        {
            try
            {
                if (!DateTime.TryParse(date, out DateTime parsedDate))
                {
                    return Json(new { error = "Invalid date format" }, JsonRequestBehavior.AllowGet);
                }

                var result = _treatmentRepository.GetPatientSchedule(appId, parsedDate);

                if (result == null || !result.Any())
                {
                    return Json(new { message = "No schedule found" }, JsonRequestBehavior.AllowGet);
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
