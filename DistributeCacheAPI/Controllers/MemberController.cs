using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistributeCacheAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;

        private readonly IMemberRepository _memberRepository;


        public MemberController(ILogger<MemberController> logger, IMemberRepository memberRepository)
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
