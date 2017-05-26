using Common.Models.Users;
using DataAccess.DbContext;
using DataAccess.Domain;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Users
{
    public class UserDataService : IUserDataService
    {
        private readonly MainContext _con;
        private readonly TableQuery<User> _users;



        public UserDataService(string dbPath)
        {
            _con = new MainContext(dbPath);
            _users = _con.Table<User>();
        }





        /// <summary>
        /// 
        /// </summary>
        public void Create(UserInput input)
        {
            var user = new User
            {
                UserName = input.UserName,
                Name = input.Name,
                Family = input.Family,
            };

            _con.Insert(user);
        }





        /// <summary>
        /// 
        /// </summary>
        public void DeleteAll()
        {
            _con.DeleteAll<User>();
        }




        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> SearchName(string name)
        {
            var users = _users.Where(u => u.Name.Contains(name));
            return users.Select(u => u.Name).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<UserOutput> Search(string term)
        {
            return _users.Where(u => u.Name.Contains(term))
             .Select(u => new UserOutput
             {
                 Id = u.Id,
                 UserName = u.UserName,
                 DisplayName = u.Name + " " + u.Family,

             }).ToList();
        }


    }
}
