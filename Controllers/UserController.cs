using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.API.Model;
using Users.API.Repository;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get() {
            var users = await _repository.GetAllUsers();
            foreach(var user in users) {
                user.Password = "";
            }
            return users.Any() ? Ok(users) : NoContent();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "employee,manager")]
        public async Task<IActionResult> Get(int id) {
            var user = await _repository.GetById(id);
            user.Password = "";
            return user != null ? Ok(user) : NotFound("Usuário não encontrado!");
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Post(User user)
        {
            user.setPasswordHash();
            _repository.CreateUser(user);
            return await _repository.SaveChangesAsync() ? Ok("Usuário adicionado com sucesso") : BadRequest("Erro ao salvar usuário!");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Put(User user, int id)
        {
            User userFounded = await _repository.GetById(id);
            if(userFounded == null) return NotFound("Usuário não encontrado!");

            userFounded.Name = user.Name;
            userFounded.Email = user.Email;
            userFounded.Role = user.Role;

            _repository.UpdateUser(userFounded);
            return await _repository.SaveChangesAsync() ? Ok("Usuário atualizado com sucesso!") : BadRequest("Erro ao atualizar usuário!");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Delete(int id)
        {
            var userFounded = await _repository.GetById(id);
            if(userFounded == null) return NotFound("Usuário não encontrado!");
            _repository.DeleteUser(userFounded);
            return await _repository.SaveChangesAsync() ? Ok("Usuário removido com sucesso") : BadRequest("Erro ao tentar remover usuário!");
        }
    }
}