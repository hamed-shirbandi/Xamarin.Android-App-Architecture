using System.Linq;
using SQLite;
using DataAccess.Domain;

namespace DataAccess.DbContext
{
    public class MainContext : SQLiteConnection
    {
        private SQLiteConnection con;
  
        public MainContext(string dbFullPath) : base(dbFullPath)
        {
            con = new SQLiteConnection(dbFullPath);
        }





        /// <summary>
        /// Create Database Tabales
        /// </summary>
        public void CreateDatabase()
        {
            con.CreateTable<User>();
            con.CreateTable<Category>();
            con.CreateTable<Note>();
            con.CreateTable<History>();
            con.CreateTable<Setting>();
        }






        /// <summary>
        /// Seed Data
        /// </summary>
        public void Seed()
        {
            if (!con.Table<User>().Any())
            {

                var user = new User
                {
                    Name = "hamed"
                };
                con.Insert(user);



                con.Insert(new User
                {
                    Name = "saeed"
                });
            }
        }

    }
}