using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class RegistController : Controller
    {
        public IActionResult Index()
        {
            ConvertArrayToObj<User> cvtOjtToArr = new ConvertArrayToObj<User>();
            byte[] array = HttpContext.Session.Get("user");
            if (array == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult DoRegist()
        {
            Dictionary<string, string> errList = new Dictionary<string, string>();
            InputData id = new InputData(Request);

            string view = "";

            if (id.DoCheckInput(errList) == 0)
            {
                if (id.DoCheckDetailsOfDate(errList) == 0)
                {
                    Regist rg = new Regist();
                    RegistData rd = new RegistData();
                    int flg = 1;
                    rd.DoRegistData(id, rg, flg);
                    ConvertObjToArray<Regist> cvtota = new ConvertObjToArray<Regist>();
                    HttpContext.Session.Set("regist", cvtota.DoConvert(rg));
                    ViewData["regist"] = rg;
                    view = "Confirm";
                }
                else
                {
                    view = "Index";

                }
            }
            else
            {
                view = "Index";
            }
            ViewData["errlist"] = errList;
            return View(view);
        }
    }
}