using CrmTest.Data.ApplicationIdentityData;
using CrmTest.Data.CrmData;
using CrmTest.Data.CrmData.Entities;
using CrmTest.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Security.Claims;

namespace CrmTest.Services
{
    public class AddUserService
    {
        private readonly EmailService _emailService;
        private readonly ILogger<AddUserService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;      
        private readonly EmployeesRepository _employeesRepository;

        public AddUserService(
            UserManager<ApplicationUser> userManager,           
            EmployeesRepository employeesRepository, 
            ILogger<AddUserService> logger,
            EmailService emailService) 
        {
            _emailService = emailService;
            _logger = logger;
            _userManager = userManager;           
            _employeesRepository = employeesRepository;
        }

        public async Task AddUserAsync(EmployeeModel model)
        {           
            var user = new ApplicationUser() { Email = model.Email, UserName = model.Email } ;
                    
            var result = await _userManager.CreateAsync(user);

            var password = GeneratePassword();

            if (result.Succeeded)
            {                
                await _userManager.AddPasswordAsync(user, password);

                model.UserId = user.Id;

                var newEmployeeId = await _employeesRepository.AddEmployeeAsync(model);

                await _userManager.AddClaimAsync(user, new Claim("EmployeeId", newEmployeeId.ToString()));
            }

            _emailService.SendEmailAsync(model.Email, "password", $"Hi {model.FullName}!\nYou password is: {password}");
        }   

        private string GeneratePassword()
        {
            int length = 10;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            string password = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
    }
}
