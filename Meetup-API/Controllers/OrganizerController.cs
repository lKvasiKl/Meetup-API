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
    [Authorize(Roles = Policy.ForAdminOnly)]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerService _organizerService;
        private readonly IMapper _mapper;

        public OrganizerController(IOrganizerService organizerService, IMapper mapper)
        {
            _organizerService = organizerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrganizerRequest organizerRequest)
        {
            var organizerModel = _mapper.Map<OrganizerRequest, OrganizerModel>(organizerRequest);
            await _organizerService.CreateAsync(organizerModel);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var organizersModel = await _organizerService.GetAllAsync();
            var response = _mapper.Map<List<OrganizerModel>, List<OrganizerResponce>>(organizersModel);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var organizerModel = await _organizerService.GetByIdAsync(id);
            var response = _mapper.Map<OrganizerModel, OrganizerResponce>(organizerModel);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] OrganizerRequest organizerRequest)
        {
            var organizerModel = _mapper.Map<OrganizerRequest, OrganizerModel>(organizerRequest);
            await _organizerService.UpdateAsync(id, organizerModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _organizerService.DeleteAsync(id);

            return Ok();
        }
    }
}
