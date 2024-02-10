using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscriber.Core.Dto;
using Subscriber.Core.Response;
using Subscriber.DAL;
using Subscriber.Services;

namespace Subscriber.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController : ControllerBase
    {
        readonly ISubscriberAndCardService _subscriberService;
        public SubscriberController(ISubscriberAndCardService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponseGeneral<bool>>> Add([FromBody] SubscriberDto subscriberDTO)
        {
            BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();

             response = await _subscriberService.AddSubscriber(subscriberDTO);
            if (response.succsed == false)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<BaseResponseGeneral<CardDto>>> Login([FromBody] LoginDto login)
        {
            BaseResponseGeneral<CardDto> response = new BaseResponseGeneral<CardDto>();

              response = await _subscriberService.Login(login.Password,login.Email);
            if (response.succsed == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseGeneral<ClassResponse>>> GetCardById(int id)
        {
            BaseResponseGeneral<ClassResponse> response = new BaseResponseGeneral<ClassResponse>();
              response = await _subscriberService.GetCardById(id);
            if (response.succsed == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


    }
}

