using Application_Layer.DTO;
using RepositoryLayer.Data_Models;

namespace Application_Layer.BussinesLogicInterface
{
    public interface IloginService
    {
        Task< AuthResult> Login(UserLoginRequestDto model);
    }
}
