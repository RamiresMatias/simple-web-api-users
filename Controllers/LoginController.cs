using Microsoft.AspNetCore.Mvc;
using Users.API.Model;
using Users.API.Repository;
using Users.API.Services;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly IUserRepository _repository;

        public LoginController(IUserRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            var userFounded = await _repository.GetByLogin(user.Email);

            if(userFounded == null) return NotFound("Email ou Senha inválido!");

            var userValid = userFounded.PasswordValid(user.Password);

            if(!userValid) return NotFound("Email ou Senha inválido!");

            var token = TokenService.GenerateToken(userFounded);
            userFounded.Password = "";

            return Ok(new {
                user = userFounded,
                token,
            });
        }
    }
}