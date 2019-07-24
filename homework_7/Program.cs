using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace homework
{
    class Program
    {
        public static List<string> SQLcommandsList = new List<string>();
        public static void Program_base()
        {


            string connectionString = ConfigurationManager.ConnectionStrings["Data_connection"].ConnectionString;
            var random = new Random();
            for (int i = 0; i < 20; i++)
            {
                Employee emp = new Employee(i, "Name" + random.Next(10), "SurName" + random.Next(10),random.Next(3));

                var sql = String.Format("INSERT INTO People (Name, SurName, Department) " +
                                        "VALUES ('{0}', '{1}', '{2}')",
                                        emp.Name,
                                        emp.SurName,
                                        emp.Dep_Id_emp);

                SQLcommandsList.Add(sql);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                }

            }

        }
    }
}

