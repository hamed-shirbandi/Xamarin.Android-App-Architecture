using Common.Models.Users;

namespace RestService.UserManagement
{
    public interface IRegistrationApiService
    {
        bool CheckUserName(string userName);
        bool Register(UserInput input);
    }
}