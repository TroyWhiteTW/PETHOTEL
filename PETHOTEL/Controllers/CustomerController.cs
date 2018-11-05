using PETHOTEL.entity;
using PETHOTEL.Models;
using System.Linq;
using System.Web.Mvc;

namespace PETHOTEL.Controllers
{

    public class CustomerController : Controller
    {
        Entities db = new Entities();
        // GET: Customer
        public ActionResult Index()
        {
            

            return View();
        }




        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerViewModel VM)
        {
            
            VM.create();

            return View("ck");
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult Login(LoginViewModel lv)
        {

            Entities en = new Entities();
            Customer ma = new Customer();
            
          //  ma  = en.Customer.FirstOrDefault(x => x.c_id == lv.c_id);
            var query = (from o in db.Customer where o.c_account == lv.c_account && o.c_password == lv.c_password select o).Count();
            if (query == 1)
            {
                Session["customer"] = lv.c_account;

                lv.c_id = db.Customer.FirstOrDefault(x => x.c_account == lv.c_account).c_id;

                Order r = new Order();
                //r = db.Order.FirstOrDefault(x => x.c_id == lv.c_id);
                //r = db.Order.LastOrDefault(x => x.c_id == lv.c_id);
                Session["Room"] = lv.c_id;
                

                return RedirectToAction("home", "Home");
            }


            return RedirectToAction("Login");  //登入失敗




            //Entities db = new Entities();
            //var v = db.Customer.Where(a => a.c_account == lv.c_account).FirstOrDefault();
            //if (v != null)
            //{

            //    Session["customer"] = lv.c_account;
            //    return RedirectToAction("home", "Home");

            //}
            //return View();

        }
        [HttpGet]
        public ActionResult Logout()
        {

            Session["Customer"] = "";

            return RedirectToAction("Login", "Customer");
            //return RedirectToAction("Login", "Account");
        }

    }
        
}