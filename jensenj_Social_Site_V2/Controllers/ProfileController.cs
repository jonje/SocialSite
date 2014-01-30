using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jensenj_Social_Site_V2.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Pics"));
            List<FileInfo> paths = directory.GetFiles().ToList();
            ViewData["Paths"] = paths;
            return View();
        }

    }
}
