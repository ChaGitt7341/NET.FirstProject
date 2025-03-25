using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTimeProject.Core;
using MyTimeProject.Core.DTOs;
using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Services;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTimeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ManagerRole")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService=userService;
            _mapper=mapper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(_mapper.Map<IEnumerable<UserDto>>(await _userService.GetAllAsync()));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<UserDto>(await _userService.GetByIdAsync(id)));
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserDto user)
        {
           await _userService.AddAsync(_mapper.Map<User>(user));
            return Ok(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task<ActionResult> PutAsync( [FromBody] UserDto user)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(user));
            return Ok( user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var user=await _userService.GetByIdAsync(id);
           await _userService.RemoveAsync(id);
            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
