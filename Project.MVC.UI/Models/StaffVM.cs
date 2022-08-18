using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.UI.Models
{
    public class StaffVM
    {
        public Staff  Staff { get; set; }
        public List<Staff>Staffs  { get; set; }


    }
}