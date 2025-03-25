using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTimeProject.Core.DTOs;
using MyTimeProject.Core.Entities;
using MyTimeProject.Core.Services;
using NLog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTimeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApprovalsController : ControllerBase
    {
        private readonly IApprovalsService _approvalsService;
        private readonly IMapper _mapper;
        

        public ApprovalsController(IApprovalsService approvalsService, IMapper mapper)
        {
            _approvalsService = approvalsService;
            _mapper = mapper;
        }


        // GET: api/<ApprovalsController>
        [HttpGet]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> GetAsync()
        {
            
            return Ok(_mapper.Map<IEnumerable<ApprovalsDto>>(await _approvalsService.GetAllAsync()));
        }

        // GET api/<ApprovalsController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<ApprovalsDto>(await _approvalsService.GetByIdAsync(id)));
        }

        // POST api/<ApprovalsController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ApprovalsDto approvalsDto)
        {
            
            await _approvalsService.AddAsync(_mapper.Map<Approvals>(approvalsDto));
            return Ok(approvalsDto);
        }

        // PUT api/<ApprovalsController>/5
        [HttpPut]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> PutAsync([FromBody] ApprovalsDto approvals)
        {
            await _approvalsService.UpdateAsync(_mapper.Map<Approvals>(approvals));
            return Ok(approvals);
        }

        // DELETE api/<ApprovalsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "ManagerRole")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
           
            var approvals = await _approvalsService.GetByIdAsync(id);
            await _approvalsService.RemoveAsync(id);
            return Ok(_mapper.Map<ApprovalsDto>(approvals));
        }
    }
}
