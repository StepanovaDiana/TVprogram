using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using TVprogram.Entity.Models;
using TVprogram.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TVprogram.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repository.GetAll();
            return Ok(users);
        }
    }

}