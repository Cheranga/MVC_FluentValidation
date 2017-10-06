using System.Collections.Generic;
using System.Linq;
using MVC_FluentValidation_Intermediate.Models;

namespace MVC_FluentValidation_Intermediate.Repositories
{
    class RegisterModelRepository : IRegisterModelRepository
    {
        private List<RegisterModel> _profiles;

        public RegisterModelRepository()
        {
            _profiles = new List<RegisterModel>
            {
                new RegisterModel {UserName = "Cheranga", Password = "123456", ConfirmPassword = "123456"},
                new RegisterModel {UserName = "Bodhi", Password = "654321", ConfirmPassword = "654321"}
            };
        }

        public RegisterModel GetUserProfileByUserName(string userName)
        {
            var profile = _profiles.FirstOrDefault(model => model.UserName.Equals(userName));
            return profile;
        }
    }
}