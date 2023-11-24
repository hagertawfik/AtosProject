using Application_Layer.BussinesLogicInterface;
using Application_Layer.DTO;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Data_Models;

namespace Application_Layer.BussinesLogic
{
    public class RegisterSevice : IRegisterService
    {

        private readonly UserManager<Student> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
      
        public RegisterSevice(UserManager<Student> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            

        }

        public async Task<AuthResult> Registeration(StudentRegistrationRequestDto model)
        {
            // if email already exist
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return   new AuthResult() { message = "Email already Exist", Result = false } ;

            Student user = new Student()
            {

                Email = model.Email,
                UserName = model.Username,
                Stname = model.Stname,
                Gender = model.Gender,
                IsActive = true
            };
            var createUserResult = await _userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                return   new AuthResult() { message = "User creation failed! Please check user details and try again.", Result = false } ;


            if (await _roleManager.RoleExistsAsync("student"))
                await _userManager.AddToRoleAsync(user, "student");

            return  new AuthResult() { message = "User created successfully!", Result = true } ;
        }
    }
}
