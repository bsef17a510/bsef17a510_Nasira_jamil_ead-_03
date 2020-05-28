using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pharmacy.Models;
namespace pharmacy.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/
        DataClasses1DataContext dc = new DataClasses1DataContext();
        string c = "";
        public ActionResult Index()
        {
            
            c = Request["cat"];
           
            var query = dc.stores.Where(s => s.category == c).ToList();
            return View(query);
          
        }
       
        public ActionResult addnewitem()
        {
            
            string name = Request["nm"];
            string price = Request["p"];
            string cate = Request["c"];
            string date = Request["d"];
           
            store s = new store();
            s.Name = name;
            s.price = Convert.ToInt32(price);
            s.category = cate;
            s.expiryDate = Convert.ToDateTime(date);
            dc.stores.InsertOnSubmit(s);
            dc.SubmitChanges();
            return View();
        }
        public ActionResult edit(int id)
        {
            
            return View(dc.stores.First(c=>c.Id==id));
        }
        public ActionResult editdone(int id)
        {

            var a= dc.stores.First(c => c.Id == id);
            
            a.Name = Request["nm"];
            a.price =Convert.ToInt32(Request["p"]);
            a.expiryDate = Convert.ToDateTime(Request["d"]);
            a.category = Request["c"];
            dc.SubmitChanges();
            return RedirectToAction("index");

        }
        
       
	}
}