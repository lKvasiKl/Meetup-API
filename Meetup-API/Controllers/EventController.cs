using AutoMapper;
using Business.Models;
using Business.Policies;
using Business.Servises.IServices;
using Meetup_API.Models.Request;
using Meetup_API.Models.Responce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meetup_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = Policy.ForAdminOnly)]
        public async Task<IActionResult> CreateAsync([FromBody] EventRequest eventRequest)
        {
            var eventModel = _mapper.Map<EventRequest, EventModel>(eventRequest);
            await _eventService.CreateAsync(eventModel);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var eventsModel = await _eventService.GetAllAsync();
            var responce = _mapper.Map<List<EventModel>, List<EventResponce>>(eventsModel);

            return Ok(responce);
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var eventModel = await _eventService.GetByIdAsync(id);
            var responce = _mapper.Map<EventModel, EventResponce>(eventModel);

            return Ok(responce);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = Policy.ForAdminOnly)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] EventRequest eventRequest)
        {
            var eventModel = _mapper.Map<EventRequest, EventModel>(eventRequest);
            await _eventService.UpdateAsync(id, eventModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = Policy.ForAdminOnly)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _eventService.DeleteAsync(id);

            return Ok();
        }
    }
}
