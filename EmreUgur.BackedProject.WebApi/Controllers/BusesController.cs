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
    public class BusesController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly IMapper _mapper;

        public BusesController(IBusService busService, IMapper mapper)
        {
            _busService = busService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusesByColor([FromQuery] string color)
        {
            return Ok(_mapper.Map<List<BusListDto>>(await _busService.GetBusesByColorAsync(color)));
        }
    }
}
