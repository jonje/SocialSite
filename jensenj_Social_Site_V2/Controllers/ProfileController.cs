using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using jensenj_Social_Site_V2.Models;

namespace jensenj_Social_Site_V2.Controllers
{
    public class ProfileController : Controller
    {
        private Profile profile = new Profile
        {
            Name = "Jonathan Jensen",
            Layout = "~/Views/Shared/Layouts/_AlternateTemplate.cshtml",
            Description = "I am a programmer and really like computers in all their entirety.",
            BookList = new ArrayList
            {
                {"Devil May Cry"},
                {"Dresden Files"}
            },

            MovieList = new ArrayList
            {
                {"Iron Man"},
                {"Hackers"}
            },

            FoodList = new ArrayList
            {
                {"Cheese Burgers"},
                {"Enchelada"}
            }
        };
        
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            if (Session["Layout"] == null)
            {
                Session["Layout"] = profile.Layout;    
                
            }

            return View("Index", profile);
        }

        public ActionResult Gallery()
        {
            if (Session["Layout"] == null)
            {
                Session["Layout"] = profile.Layout;
                
            }

            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Pics"));
            List<FileInfo> paths = directory.GetFiles().ToList();
            ViewData["Paths"] = paths;
            return View();
        }

        [HttpGet]
        public ActionResult ChangeLayout()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Server.MapPath("~/Views/Shared/Layouts"));
            var list = directoryInfo.GetFiles().ToList();
            List<ListItem> itemsList = new List<ListItem>();
            int count = 1;
            foreach (FileInfo file in list)
            {
                itemsList.Add(new ListItem{Text = file.ToString()});
            }

            ViewData["LayoutTypes"] = itemsList;
            return View("ChangeLayoutForm");
        }

        [HttpPost]
        public ActionResult ChangeLayout(string layout)
        {
            Session["Layout"] = "~/Views/Shared/Layouts/" + Request["LayoutTypes"];
            return View("Index", profile);
        }

    }
}
