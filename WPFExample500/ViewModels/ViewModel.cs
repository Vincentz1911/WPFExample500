using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFExample500.Models;
using WPFExample500.Views;

namespace WPFExample500.ViewModels
{
    public class ViewModel
    {
        public List<object> GenderList = SQLDatabase.GetSQLList("select PK_Gender from GenderTable");
        public List<object> HaircolorList = SQLDatabase.GetSQLList("select PK_Haircolor from HaircolorTable");
        public List<object> CityList = SQLDatabase.GetSQLList("select PK_City from PostalCodeTable");
        public List<object> SexualityList = SQLDatabase.GetSQLList("select PK_Sexual_Pref from Sexual_PrefTable");
        
        public static string Username = "";

        public UserModel UserModel { get; set; }

        public ViewModel()
        {
            UserData();
            //FindUsers();
        }


        void UserData()
        {
            string table = $"UserTable, LoginTable";
            string query = $"select * from UserTable, LoginTable"; //where FK_Username='{Username}'

            DataTable dt = SQLDatabase.GetSQLData(table, query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserModel = new UserModel
                {
                    FK_Username = dt.Rows[i]["FK_Username"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    Profilename = dt.Rows[i]["PK_Profilename"].ToString(),
                    PostalCode = dt.Rows[i]["FK_City"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Gender = dt.Rows[i]["FK_Gender"].ToString(),
                    Sexuality = dt.Rows[i]["FK_Sexual_Pref"].ToString(),
                    Haircolor = dt.Rows[i]["FK_Haircolor"].ToString(),
                    Birthday = (DateTime)dt.Rows[i]["Birthday"],
                    Picture = dt.Rows[i]["ImagePath"].ToString(),
                    WeightKg = (int)dt.Rows[i]["WeightKg"],
                    HeightCm = (int)dt.Rows[i]["HeightCm"]
                };
            }

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
                Directory.CreateDirectory($@"C:\Images\{UserModel.FK_Username}\");
                File.Copy(op.FileName, Imagepath, true);
                UserModel.Picture = Imagepath;
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


        public void FindUsers()
        {
            UserModel = new UserModel();

            string table = "UserTable";
            string query = $"select * from UserTable where PK_Profilename like '%{UserModel.Profilename}%'";

            UserModel.UserDataTable = SQLDatabase.GetSQLData(table, query);

            //string table = $"UserTable, LoginTable";
            //string query = $"select * from UserTable, LoginTable";

            //DataTable dt = SQLDatabase.GetSQLData(table, query);

            int i = 5;

        }




        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        //private void CreateUser(object sender, EventArgs e)
        //{
        //    MD5 md5Hash = MD5.Create();
        //    string hash = GetMd5Hash(md5Hash, LoginPage.Passwordtxt.Text);

        //    // Check if user already exists.
        //    string SQLGet = $"select 1 from BrugerLogin where Loginnavn = '{Brugernavn.Text}';";
        //    if (SQLDatabase.SQLGetList(SQLGet).Length > 0)
        //    {
        //        MessageBox.Show("Brugernavn optaget!");
        //        return;
        //    }

        //    // Else create user with password.
        //    string SQLSend = $"insert into BrugerLogin values ('{Brugernavn.Text}', '{hash}')";
        //    SQLDatabase.SQLkommandoSet(SQLSend);

        //    MessageBox.Show("Bruger Oprettet!");
        //}

        public void Login(string Username, string Password)
        {
            //MD5 md5Hash = MD5.Create();
            //string hash = GetMd5Hash(md5Hash, Brugerpassword.Text);

            string query = $"select 1 from LoginTable where PK_Username = '{Username}' and [Password] = '{Password}';";


            if (SQLDatabase.GetSQLList(query).Count <= 0)
            {
                MessageBox.Show("Login failed!");
                return;
            }

            MessageBox.Show("Login success!!");

            UserModel.FK_Username = Username;

            //LoginBox.Visible = false;
            //MainMenu.Visible = true;

        }

    }
}
