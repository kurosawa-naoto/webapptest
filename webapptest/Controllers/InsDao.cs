using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class InsDao
    {
        public int DoInsert(Regist rg)
        {
            int result = 0;
            string connectStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", DaoStr.server, DaoStr.db, DaoStr.user, DaoStr.pass);
            string tbl = "regist_user";

            try
            {
                MySqlConnection connect = new MySqlConnection(connectStr);
                MySqlCommand command
                    = new MySqlCommand("insert into " + tbl + " (name,gender,birth,birth_kj,tell,mail,create_date,update_date) values (@name,@gender,@birth,@birth_kj,@tell,@mail,@create_date,@update_date)", connect);
                command.Parameters.Add(new MySqlParameter("name", rg.Name));
                command.Parameters.Add(new MySqlParameter("gender", rg.Gender));
                command.Parameters.Add(new MySqlParameter("birth", rg.Birth));
                command.Parameters.Add(new MySqlParameter("birth_kj", rg.Birth_kj));
                command.Parameters.Add(new MySqlParameter("tell", rg.Tell));
                command.Parameters.Add(new MySqlParameter("mail", rg.Mail));
                command.Parameters.Add(new MySqlParameter("create_date", rg.CreateDate));
                command.Parameters.Add(new MySqlParameter("update_date", rg.UpdateDate));
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception e)
            {
                result = 1;
                Console.WriteLine("error:" + e.Message);
            }

            return result;
        }
    }
}
