using AutoMapper;
using Demo.AuthJwt.Data.Models;
using Demo.AuthJwt.Data.Repositories.Interfaces;
using Demo.AuthJwt.Dto;
using Demo.AuthJwt.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.AuthJwt.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserRepository userRepository, IJwtTokenManager tokenManager, IMapper mapper)
    : ControllerBase
{
    [HttpPost("Signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignUp(NewUserDto user)
    {
        try
        {
            var dbUser = mapper.Map<User>(user);

            await userRepository.Create(dbUser);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }

        return Ok();
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login(LoginUserDto user)
    {
        User? dbUser;
        try
        {
            dbUser = await userRepository.GetByEmail(user.Email);
            if (dbUser == null) return NotFound();
            if (dbUser.Password.DecryptString() != user.Password) return Unauthorized();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }

        var token = tokenManager.Authenticate(dbUser.FullName);

        return Ok(token);
    }
}