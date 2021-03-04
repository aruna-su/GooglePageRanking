using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleHelper;


namespace WebApplication2.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtSearchUrl, string txtSearchString)
        {
            try
            {
                string result = GoogleHelpers.GetPosition(new Uri(txtSearchUrl), txtSearchString).ToString();
                return View(model: result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
                
        }
    }
}