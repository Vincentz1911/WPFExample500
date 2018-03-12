using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WPFExample500.ViewModels
{
    public class SQLDatabase
    {
        public static DataTable GetSQLData(string table, string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(table);
            adp.Fill(dt);

            return dt;
        }

        public static List<object> GetSQLList(string query)
        {
            List<object> list = new List<object>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            con.Open();


            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            list.Add(reader.GetValue(i));
                        }
                    }
                }
            }
            con.Close();
            return list;
        }


        public static void SetSQL(string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            con.Open();

            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}
