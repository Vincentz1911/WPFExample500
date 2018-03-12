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
    public class ViewModel
    {
        public UserModel UserModel { get; set; }
        //public DataTable dt { get; set; }

        public ViewModel()
        {
            DataTable dt = SQLDatabase.GetSQLData("UserTable, LoginTable", "select FK_Username, Password, PK_Profilename, Email, FK_Gender, FK_Haircolor, Job from UserTable, LoginTable");
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

        public void Update(string str)
        {
            UserModel.Picture = str;
        }


        public void UpdateSQL()
        {
            MessageBox.Show(UserModel.FK_Username);

            string query = $"insert into LoginTable values({UserModel.FK_Username}, {UserModel.Password})";
            SQLDatabase.SetSQL(query);
            query = $"insert into UserTable values({UserModel.FK_Username} , {UserModel.Profilename},  1000, 'Mand', {UserModel.Email}, 'Danish','1972-11-22', 169, 84, 'pack://application:,,,/Resources/Image.jpg', GETDATE(), Null, 'No Homo', 'blond')";
            SQLDatabase.SetSQL(query);

        }
    }
}
