using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PaapuWalks.Models.Domain;
using PaapuWalks.Models.DTO;
using PaapuWalks.Repositories;

namespace PaapuWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var IdentityUser = new IdentityUser { 
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };
            var IdentityResult = await _userManager.CreateAsync(IdentityUser,registerRequestDto.Password);
            if(IdentityResult.Succeeded)
            {
                //Add roles to this User
                if(registerRequestDto.Roles != null)
                {
                    IdentityResult = await _userManager.AddToRolesAsync(IdentityUser, registerRequestDto.Roles);

                    if (IdentityResult.Succeeded)
                    {
                        return Ok("User registered successfully");
                    }
                }
            }

            return BadRequest("Something went wrong");
                
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.UserName);

            if(user != null)
            {
                var CheckPassResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (CheckPassResult)
                {
                    // get roles for user

                    var roles = await _userManager.GetRolesAsync(user);

                    if(roles != null)
                    {
                        //create token
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JWTToken = jwtToken
                        };

                        return Ok(response);
                    }
                    
                    

                    
                }
            }

            
           

            return BadRequest("UserName is incorrect");

        }
    }
}
