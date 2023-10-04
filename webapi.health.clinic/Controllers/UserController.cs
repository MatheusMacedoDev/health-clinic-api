﻿using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;
using webapi.health.clinic.ViewModels;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //[Authorize(Roles = "Administrador")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel data)
        {
            try
            {
                _userRepository.Register(data);

                return StatusCode(201, data);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet] 
        public IActionResult ListAll()
        {
            try
            {
                List<User> users = _userRepository.ListAll();

                return Ok(users);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userRepository.Delete(id);

                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
