using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index(int id)
        {
            ConvertArrayToObj<Regist> cato = new ConvertArrayToObj<Regist>();
            byte[] array = HttpContext.Session.Get("regist");
            Regist rg = cato.DoConvert(array);
            MsgClass mc = new MsgClass();

            if (id == 1)
            {
                InsDao idao = new InsDao();
                if (idao.DoInsert(rg)==0)
                {
                    mc.Msg = "new registration is done";
                }
            }

            ViewData["msg"] = mc;
            
            return View();
        }
    }
}