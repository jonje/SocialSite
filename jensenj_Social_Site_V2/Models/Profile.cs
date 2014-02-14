using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jensenj_Social_Site_V2.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Layout { get; set; }
        public string Description { get; set; }
        public ArrayList BookList = new ArrayList();
        public ArrayList MovieList = new ArrayList();
        public ArrayList FoodList = new ArrayList();

    }
}