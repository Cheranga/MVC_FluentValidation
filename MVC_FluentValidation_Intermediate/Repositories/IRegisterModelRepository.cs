using MVC_FluentValidation_Intermediate.Models;

namespace MVC_FluentValidation_Intermediate.Repositories
{
    public interface IRegisterModelRepository
    {
        RegisterModel GetUserProfileByUserName(string userName);
    }
}