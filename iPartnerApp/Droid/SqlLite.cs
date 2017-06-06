using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(iPartnerApp.Droid.SqlLite))]

namespace iPartnerApp.Droid
{
    public class SqlLite : ISqlLite
    {
        public SQLiteConnection GetDataBase()
        {
            var sqliteFilename = "iParthnerDb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}