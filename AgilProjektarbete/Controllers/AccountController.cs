using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgilProjektarbete
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : Controller
    {
        ApplicationContext applicationContext;
        UserManager<User> userManager;
        IMapper mapper;

        public AccountController(UserManager<User> userManager, IMapper mapper, ApplicationContext applicationContext)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.applicationContext = applicationContext;
        }
        
        [Route("register")]
        [HttpPost]
        public async ValueTask<Result> Register([FromBody]RegistrationFormModel model)
        {
            var result = new Result { Success = true};
            var parsedModel = new RegistrationModel();

            if (String.IsNullOrEmpty(model.Role))
            {
                result.Success = false;
                result.ErrorMessages.Add("You have to select a role");
                return result;
            }

            try
            {
                parsedModel.FirstName = model.FirstName;
                parsedModel.LastName = model.LastName;
                parsedModel.Email = model.Email;
                parsedModel.Address = model.Address;
                parsedModel.ZipCode = int.Parse(model.ZipCode);
                parsedModel.Password = model.Password;
                parsedModel.ConfirmPassword = model.ConfirmPassword;
                parsedModel.Role = (Role)Enum.Parse(typeof(Role), model.Role);
            }
            catch (Exception ex)
            {
                result.ErrorMessages.Add(ex.Message);
                result.Success = false;
                return result;
            }

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.ErrorMessages.Add("Modelstate is not valid");
                return result;      
            }

            try
            {
                var user = mapper.Map<User>(parsedModel);

                var userResult = await userManager.CreateAsync(user, parsedModel.Password);
                if (!userResult.Succeeded)
                {
                    foreach (var error in userResult.Errors)
                    {
                        result.ErrorMessages.Add(error.Description);
                    }
                    result.Success = false;
                    return result;
                }
                await userManager.AddToRoleAsync(user, parsedModel.Role.ToString());
            }
            catch (Exception ex)
            {

                result.ErrorMessages.Add(ex.Message);
                result.Success = false;
                return result;
            }

            return result;
        }

        [Route("login")]
        [HttpPost]
        public async ValueTask<Result> Login(LoginFormModel model)
        {
            var result = new Result { Success = true };
            var parsedModel = new LoginModel();
            try
            {
                parsedModel.Email = model.Email;
                parsedModel.Password = model.Password;
                parsedModel.RememberMe = model.RememberMe;
            }
            catch (Exception ex)
            {
                result.ErrorMessages.Add(ex.Message);
                result.Success = false;
                return result;
            }

            if (!ModelState.IsValid)
            {                
                result.ErrorMessages.Add("Modelstate is not valid");
                result.Success = false;
                return result;
            }

            var user = await userManager.FindByEmailAsync(parsedModel.Email);
            if (user != null &&
                await userManager.CheckPasswordAsync(user, parsedModel.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity));
            } else
            {
                result.Success = false;
                result.ErrorMessages.Add("Invalid username or password");
                return result;
            }
                
            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("test")]
        public IEnumerable<Object> Test()
        {
            var result = applicationContext.Users.ToList();
            return result;
        }
    }
}