using AutoMapper;
using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.DTO.Dtos;
using EmreUgur.BackedProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmreUgur.BackedProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [ApiKey]
    [Authorize()]
    public class BoatsController : ControllerBase
    {
        private readonly IBoatService _boatService;
        private readonly IMapper _mapper;

        public BoatsController(IBoatService boatService, IMapper mapper)
        {
            _boatService = boatService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBoatsByColor([FromQuery] string color)
        {
            return Ok(_mapper.Map<List<BoatListDto>>(await _boatService.GetBoatsByColorAsync(color)));
        }
    }
}
