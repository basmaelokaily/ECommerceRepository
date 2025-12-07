using Domain.Entities.IdentityModule;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Services.Abstraction.Contracts;
using Shared.Dtos.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations.AuthenticationService
{
    public class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
    {
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            //if there is a user under this email
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) throw new UnAuthorizedException($"Email {loginDto.Email} is not valid");
            //check if the password is correct
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result) throw new UnAuthorizedException();
            //return user and create token
            return new UserResultDto(
                user.DisplayName,
                user.Email,
                "this will be the token"
            );
        }

        public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User()
            {
                Email = registerDto.Email,
                DisplayName = registerDto.DisplayName,
                UserName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(error => error.Description).ToList();
                throw new ValidationException(errors);
            }
            return new UserResultDto(
                registerDto.DisplayName,
                registerDto.Email,
                "this will be the token"
            );
        }
    }
}
