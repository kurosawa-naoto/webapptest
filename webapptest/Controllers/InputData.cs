using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class InputData
    {
        private string name;
        private string gender;
        private string year;
        private string month;
        private string day;
        private string tell;
        private string mail;

        public InputData(HttpRequest Request)
        {
            this.name = Request.Form["name"];
            this.gender = Request.Form["gender"];
            this.year = Request.Form["year"];
            this.month = Request.Form["month"];
            this.day = Request.Form["day"];
            this.tell = Request.Form["tell"];
            this.mail = Request.Form["mail"];
        }

        public string Name { get => name; }
        public string Gender { get => gender; }
        public string Year { get => year; }
        public string Month { get => month; }
        public string Day { get => day; }
        public string Tell { get => tell; }
        public string Mail { get => mail; }

        public int DoCheckInput(Dictionary<string, string> errList)
        {
            int result = 0;

            if (name == null)
            {
                errList.Add("nameErr", "type in your name");
                result++;
            }

            if (gender == null)
            {
                errList.Add("genderErr", "select your gender");
                result++;
            }

            if (year == null)
            {
                errList.Add("yearErr", "select your year of birth");
                result++;
            }

            if (month == null)
            {
                errList.Add("monthErr", "select your month of birth");
                result++;
            }

            if (day == null)
            {
                errList.Add("dayErr", "select your day of birth");
                result++;
            }

            if (tell == null)
            {
                errList.Add("tellErr", "type in your phonenumber");
                result++;
            }

            if (mail == null)
            {
                errList.Add("mailErr", "type in your mailaddress");
                result++;
            }
            return result;
        }

        public int DoCheckDetailsOfDate(Dictionary<string, string> errList)
        {
            int result = 0;
            int intYear = int.Parse(year);
            int intMonth = int.Parse(month);
            int intDay = int.Parse(day);
            int[] lastday = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 29 };
            int indexday;

            if ((intMonth == 2) && (intYear % 4 == 0 || intYear % 100 == 0 && intYear % 400 != 0))
            {
                indexday = 12;
            }
            else
            {
                indexday = intMonth - 1;
            }

            if (intDay > lastday[indexday])
            {
                result++;
                errList.Add("dateErr", "invalid date");
            }

            return result;
        }
    }

}
