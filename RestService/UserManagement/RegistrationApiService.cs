using Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.UserManagement
{
    public class RegistrationApiService : IRegistrationApiService
    {
        public RegistrationApiService()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public bool CheckUserName(string userName)
        {
            //call rest api to check username from server
            return true;
        }





        /// <summary>
        /// 
        /// </summary>
        public bool Register(UserInput input)
        {
            //call rest api to register user with input parameter from server
            return true;
        }




    }
}
