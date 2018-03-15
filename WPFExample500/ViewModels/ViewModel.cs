using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFExample500.Models;

namespace WPFExample500.ViewModels
{
    public class ViewModel //: PropChanged
    {
        public List<object> GenderList = SQLDatabase.GetSQLList("select PK_Gender from GenderTable");
        public List<object> HaircolorList = SQLDatabase.GetSQLList("select PK_Haircolor from HaircolorTable");
        public List<object> CityList = SQLDatabase.GetSQLList("select PK_City from PostalCodeTable");
        public List<object> SexualityList = SQLDatabase.GetSQLList("select PK_Sexual_Pref from Sexual_PrefTable");



        public UserModel UserModel { get; set; }

        public ViewModel()
        {
            UserData();
            //string table = $"UserTable, LoginTable";
            //string query = $"select FK_Username, Password, PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable";
            //DataTable dt = SQLDatabase.GetSQLData(table, query);

            //UserModel = new UserModel
            //{
            //    FK_Username = dt.Rows[0]["FK_Username"].ToString(),
            //    Password = dt.Rows[0]["Password"].ToString(),
            //    Profilename = dt.Rows[0]["PK_Profilename"].ToString(),
            //    Email = dt.Rows[0]["Email"].ToString(),
            //    Gender = dt.Rows[0]["FK_Gender"].ToString(),
            //    Haircolor = dt.Rows[0]["FK_Haircolor"].ToString(),
            //    Picture = dt.Rows[0]["Job"].ToString()
            //};
        }


        void UserData()
        {
            string table = $"UserTable, LoginTable";
            //            string query = $"select FK_Username, Password, PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable";
            string query = $"select * from UserTable, LoginTable";

            DataTable dt = SQLDatabase.GetSQLData(table, query);

            UserModel = new UserModel
            {
                FK_Username = dt.Rows[0]["FK_Username"].ToString(),
                Password = dt.Rows[0]["Password"].ToString(),
                Profilename = dt.Rows[0]["PK_Profilename"].ToString(),
                PostalCode = dt.Rows[0]["FK_City"].ToString(),
                Email = dt.Rows[0]["Email"].ToString(),
                Gender = dt.Rows[0]["FK_Gender"].ToString(),
                Sexuality = dt.Rows[0]["FK_Sexual_Pref"].ToString(),
                Haircolor = dt.Rows[0]["FK_Haircolor"].ToString(),
                WeightKg = (int)dt.Rows[0]["WeightKg"],
                HeightCm = (int)dt.Rows[0]["HeightCm"],
                Birthday = (DateTime)dt.Rows[0]["Birthday"],
                Picture = dt.Rows[0]["ImagePath"].ToString()

            };


        }

        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string Imagepath = $@"C:\Images\{UserModel.FK_Username}\{Path.GetFileName(op.FileName)}";

                //if (File.Exists("Imagepath"))

                //{ }
                //else
                { 
                Directory.CreateDirectory($@"C:\Images\{UserModel.FK_Username}\");
                File.Copy(op.FileName, Imagepath, true);
                UserModel.Picture = Imagepath;

                }
            }
        }


        public void UpdateSQL()
        {
            MessageBox.Show($"Userdata for {UserModel.FK_Username} updated!");            
            string query = $"IF EXISTS (SELECT '{UserModel.FK_Username}' FROM dbo.LoginTable) UPDATE dbo.LoginTable SET Password = '{UserModel.Password}' WHERE PK_Username = '{UserModel.FK_Username}'";

            SQLDatabase.SetSQL(query);
            query = $"IF EXISTS (SELECT '{UserModel.FK_Username}' FROM dbo.LoginTable) UPDATE dbo.UserTable SET " +
                $"PK_Profilename = '{UserModel.Profilename}' , Email = '{UserModel.Email}' , FK_Gender = '{UserModel.Gender}', FK_Sexual_Pref = '{UserModel.Sexuality}', FK_City = '{UserModel.PostalCode}', " +
                $"HeightCm = {UserModel.HeightCm}, WeightKg = {UserModel.WeightKg},  Birthday = '{UserModel.Birthday.ToString("yyyy-MM-dd")}', ImagePath = '{UserModel.Picture}' " +
                $"WHERE FK_Username = '{UserModel.FK_Username}'";
            SQLDatabase.SetSQL(query);
        }


        //public void InsertSQL()
        //{
        //    //MessageBox.Show(Viemmodel.FK_Username);
        //    string query;
        //    query = $"IF EXISTS (SELECT '{UserModel.FK_Username}' FROM dbo.LoginTable) UPDATE dbo.LoginTable SET Password = '{UserModel.Password}' WHERE PK_Username = '{UserModel.FK_Username}'";
        //    SQLDatabase.SetSQL(query);
        //    query = $"IF EXISTS (SELECT '{UserModel.FK_Username}' FROM dbo.LoginTable) UPDATE dbo.UserTable " +
        //        $"SET PK_Profilename = '{UserModel.Profilename}' , Email = '{UserModel.Email}' , FK_Gender = '{UserModel.Gender}', FK_Sexual_Pref = '{UserModel.Sexuality}' " +
        //        $"FK_City = '{UserModel.PostalCode}' " +
        //        $"WHERE FK_Username = '{UserModel.FK_Username}'";
        //    SQLDatabase.SetSQL(query);

        //}

    }
}
