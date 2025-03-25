using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTimeProject.Core;
using MyTimeProject.Core.DTOs;
using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Repoitories;
using MyTimeProject.Core.Services;
using NLog;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTimeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PresencesController : ControllerBase

    {
        private readonly IPresenceService _presenceService;
        private readonly IMapper _mapper;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public PresencesController(IPresenceService presenceService, IMapper mapper)
        {
            _presenceService = presenceService;
            _mapper = mapper;
        }


        // GET: api/<PresencesController>
        [HttpGet]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> GetAsync()
        {
            logger.Info("Get");
            var presencesDto = _mapper.Map<IEnumerable<PresenceDto>>(await _presenceService.GetAllAsync());
            return Ok(presencesDto);

        }

        // GET api/<PresencesController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> GetAsync(int id)
        {
            logger.Info("GetById");
            var presence = _mapper.Map<PresenceDto>(await _presenceService.GetByIdAsync(id));
            return Ok(presence);
        }
        // GET api/<PresencesController>/5
        [HttpGet("user/{userId}")]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> GetByUserIdAsync(User user)
        {
            logger.Info("GetByUserId");
            return Ok(_mapper.Map<IEnumerable<PresenceDto>>(await _presenceService.GetAllByUserIdAsync(user.Id)));

        }

        [HttpGet("date/{date}")]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> GetByDateAsync(DateOnly date)
        {
            logger.Info("GetByDate");
            return Ok(_mapper.Map<IEnumerable<PresenceDto>>(await _presenceService.GetAllByDateAsync(date)));
        }

        // POST api/<PresencesController>
        [HttpPost]

        public async Task<ActionResult> PostAsync([FromBody] PresenceDto presence)
        {
            logger.Info("Post");
            await _presenceService.AddAsync(_mapper.Map<Presence>(presence));
            return Ok(presence);
        }

        // PUT api/<PresencesController>/5
        [HttpPut]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> PutAsync([FromBody] PresenceDto presence, int id)
        {
            logger.Info("Put");
            var pres = await _presenceService.GetByIdAsync(id);
            if (pres != null)
            {
                pres.TimeOfStart = presence.TimeOfStart;
                pres.TimeOfEnd = presence.TimeOfEnd;
                pres.UserId = presence.UserId;
                pres.Date = presence.Date;
                pres.Approval = presence.ApprovalDto;
                await _presenceService.Update(pres);
                return Ok(presence);
            }
            logger.Error("user undefind");
            return BadRequest();

        }

        // DELETE api/<PresencesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            logger.Info("Delete");
            var prev = await _presenceService.GetByIdAsync(id);
            await _presenceService.Remove(id);
            return Ok(_mapper.Map<PresenceDto>(prev));
        }
    }
}
