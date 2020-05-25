using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class LoginDao
    {
        private int id;
        private string pass;

        public LoginDao(int id, string pass)
        {
            this.id = id;
            this.pass = pass;
        }

        public int DoCheck(User user)
        {
            int result = 0;
            string connectStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", DaoStr.server, DaoStr.db, DaoStr.user, DaoStr.pass);
            string tbl = "user.usertbl";
            MySqlDataReader datareader;

            try
            {
                MySqlConnection connect = new MySqlConnection(connectStr);
                MySqlCommand command = new MySqlCommand("select * from " + tbl + " where usertbl.id=@id;", connect);
                command.Parameters.Add(new MySqlParameter("id", id));
                command.Connection.Open();
                datareader = command.ExecuteReader();
                
                if (datareader.Read())
                {
                    command.Connection.Close();
                    command = new MySqlCommand("select * from " + tbl + " where usertbl.id=@id and usertbl.pass=@pass;", connect);
                    command.Parameters.Add(new MySqlParameter("id", id));
                    command.Parameters.Add(new MySqlParameter("pass", pass));
                    command.Connection.Open();
                    datareader = command.ExecuteReader();
                    
                    if (datareader.Read())
                    {
                        user.Id = int.Parse(datareader.GetValue(0).ToString());
                        user.Name = datareader.GetValue(1).ToString();
                        user.Gender = int.Parse(datareader.GetValue(2).ToString());
                        user.Birth = datareader.GetValue(3).ToString();
                    }
                    else
                    {
                        result = 2;
                    }
                }
                else
                {
                    result = 1;
                }
                command.Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error:" + e.Message);
                result = 3;
            }

            return result;
        }
    }
}
