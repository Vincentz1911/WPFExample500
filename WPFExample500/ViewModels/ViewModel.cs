using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFExample500.Models;

namespace WPFExample500.ViewModels
{
    public class ViewModel //: PropChanged
    {
        public UserModel UserModel { get; set; }
        //        DataTable dt = SQLDatabase.GetSQLData($"UserTable, LoginTable", "select FK_Username, Password, PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable where PK_Username={Username}");

        //public DataTable dt { get; set; }

        public ViewModel()
        {
            //UserModel = new UserModel();
            string table = $"UserTable, LoginTable";
            string query = $"select FK_Username, Password, PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable";
            DataTable dt = SQLDatabase.GetSQLData(table, query);

            UserModel = new UserModel
            {
                FK_Username = dt.Rows[0]["FK_Username"].ToString(),
                Password = dt.Rows[0]["Password"].ToString(),
                Profilename = dt.Rows[0]["PK_Profilename"].ToString(),
                Email = dt.Rows[0]["Email"].ToString(),
                Gender = dt.Rows[0]["FK_Gender"].ToString(),
                Haircolor = dt.Rows[0]["FK_Haircolor"].ToString(),
                Picture = dt.Rows[0]["Job"].ToString()
            };
        }

        //public void Update(string str)
        //{
        //    UserModel.Picture = str;
        //}

        //        public void UpdateSQL(List<object> SQLList)
        //public void GetSQLUserData(string Username)
        //{
        //    string table = $"UserTable, LoginTable";
        //    string query = $"select FK_Username, Password, PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable where PK_Username like '%{Username}%'";
        //    DataTable dt = SQLDatabase.GetSQLData(table, query);

        //    UserModel = new UserModel
        //    {
        //        FK_Username = dt.Rows[0]["FK_Username"].ToString(),
        //        Password = dt.Rows[0]["Password"].ToString(),
        //        Profilename = dt.Rows[0]["PK_Profilename"].ToString(),
        //        Email = dt.Rows[0]["Email"].ToString(),
        //        Gender = dt.Rows[0]["FK_Gender"].ToString(),
        //        Haircolor = dt.Rows[0]["FK_Haircolor"].ToString(),
        //        Picture = dt.Rows[0]["Job"].ToString()
        //    };


        //}

        public void InsertSQL()
        {
            //MessageBox.Show(Viemmodel.FK_Username);
            string query;
            query = $"IF EXISTS (SELECT '{UserModel.FK_Username}' FROM dbo.LoginTable) UPDATE dbo.LoginTable SET Password = '{Password}' WHERE PK_Username = '{Username}'";
            SQLDatabase.SetSQL(query);
            query = $"IF EXISTS (SELECT '{Username}' FROM dbo.LoginTable) UPDATE dbo.UserTable " +
                $"SET PK_Profilename = '{Profilename}' , Email = '{Email}' , FK_Gender = '{CBGender}' " +

                $"WHERE FK_Username = '{Username}'";
            SQLDatabase.SetSQL(query);



            public void UpdateSQL(string Username, string Password, string Profilename, string Email, string CBGender)
        {
            MessageBox.Show(UserModel.FK_Username);
            string query;
            query = $"IF EXISTS (SELECT '{Username}' FROM dbo.LoginTable) UPDATE dbo.LoginTable SET Password = '{Password}' WHERE PK_Username = '{Username}'";
            SQLDatabase.SetSQL(query);
            query = $"IF EXISTS (SELECT '{Username}' FROM dbo.LoginTable) UPDATE dbo.UserTable " + 
                $"SET PK_Profilename = '{Profilename}' , Email = '{Email}' , FK_Gender = '{CBGender}' " + 
                
                $"WHERE FK_Username = '{Username}'";
            SQLDatabase.SetSQL(query);


            //query = $"insert into LoginTable values('{Username}', '{Password}')";
            //SQLDatabase.SetSQL(query);
            //query = $"insert into UserTable values('{Profilname}', '{Username}',  1000, 'Mand', '{UserModel.Email}', 'Danish','1972-11-22', 169, 84, 'pack://application:,,,/Resources/Image.jpg', GETDATE(), Null, 'No Homo', 'blond')";
            //SQLDatabase.SetSQL(query);
        }

        //public List<object> GetUserList()
        //{

        //    return 
        //}

    }
}
