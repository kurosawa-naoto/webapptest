using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class RegistData
    {
        public void DoRegistData(InputData id, Regist rd, int flg)
        {
            rd.Name = id.Name;
            rd.Gender = int.Parse(id.Gender);

            ChangeDate cd = new ChangeDate();
            cd.DoChange(id);
            rd.Birth = cd.ParseDate;
            rd.Birth_kj = cd.JpCalender;

            rd.Tell = id.Tell;
            rd.Mail = id.Mail;

            if (flg == 1)
            {
                rd.CreateDate = DateTime.Today;
                rd.UpdateDate = default;
            }
            else
            {
                rd.CreateDate = default;
                rd.UpdateDate = DateTime.Today;
            }
        }
    }
}
