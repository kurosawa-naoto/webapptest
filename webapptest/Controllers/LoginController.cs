using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            HttpContext.Session.Remove("user");
            return View();
        }

        [HttpPost]
        public IActionResult Check()
        {
            MsgClass mc = new MsgClass();
            string view;

            if (Request.Form["id"].ToString().Length == 0)
            {
                mc.Msg = "type in your id";
            }
            else if (Request.Form["pass"].ToString().Length == 0)
            {
                mc.Msg = "type in your pass";
            }
            else if ((Regex.IsMatch(Request.Form["id"].ToString(), "[0-9]{5}")) == false)
            {
                mc.Msg = "invalid pass";
            }

            if (mc.Msg == null)
            {
                view = "Start";
                User user = new User();
                LoginDao ld = new LoginDao(int.Parse(Request.Form["id"].ToString()), Request.Form["pass"].ToString());
                switch (ld.DoCheck(user))
                {
                    case 1:
                        mc.Msg = "your id does not exist";
                        break;
                    case 2:
                        mc.Msg = "your pass is incorrect";
                        break;
                    case 3:
                        mc.Msg = "system exception occurred";
                        break;
                    default:
                        mc.Msg = "login successful";
                        ConvertObjToArray<User> cvtObjToArr = new ConvertObjToArray<User>();
                        HttpContext.Session.Set("user", cvtObjToArr.DoConvert(user));
                        ViewData["user"] = user;
                        break;
                }
            }
            else
            {
                view = "Login";
            }

            ViewData["msg"] = mc;

            return View(view);
        }
    }
}