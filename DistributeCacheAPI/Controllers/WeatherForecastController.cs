using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DistributeCacheAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMemberRepository _memberRepository;

     
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return _memberRepository.GetById(id);
        }
    }
}