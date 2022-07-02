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
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;
        private readonly IMapper _mapper;

        public SpeakerController(ISpeakerService speakerService, IMapper mapper)
        {
            _speakerService = speakerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CretaeAsync([FromBody] SpeakerRequest speakerRequest)
        {
            var speakerModel = _mapper.Map<SpeakerRequest, SpeakerModel>(speakerRequest);
            await _speakerService.CreateAsync(speakerModel);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var speakersModel = await _speakerService.GetAllAsync();
            var responce = _mapper.Map<List<SpeakerModel>, List<SpeakerResponce>>(speakersModel);

            return Ok(responce);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var speakerModel = await _speakerService.GetByIdAsync(id);
            var responce = _mapper.Map<SpeakerModel, SpeakerResponce>(speakerModel);

            return Ok(responce);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] SpeakerRequest speakerRequest)
        {
            var organizerModel = _mapper.Map<SpeakerRequest, SpeakerModel>(speakerRequest);
            await _speakerService.UpdateAsync(id, organizerModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _speakerService.DeleteAsync(id);

            return Ok();
        }
    }
}
