using Common.Models.Users;
using System.Collections.Generic;


namespace DataService.Users
{
    public interface IUserDataService
    {
        void Create(UserInput input);
        void DeleteAll();
        IEnumerable<string> SearchName(string name);
        IEnumerable<UserOutput> Search(string term);
    }
}
