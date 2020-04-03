using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgilProjektarbete
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : Controller
    {
        ApplicationContext dbContext;
        UserManager<User> userManager;
        IMapper mapper;
       

        public AccountController(ApplicationContext dbContext, UserManager<User> userManager, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
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

        public Result Test()
        {
            return new Result { Success = true};
        }
    }
}