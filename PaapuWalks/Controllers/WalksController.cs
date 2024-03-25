using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaapuWalks.Data;
using PaapuWalks.Models.Domain;
using PaapuWalks.Models.DTO;
using PaapuWalks.Repositories;

namespace PaapuWalks.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly PaapuWalksDbContext _dbcontext;
        private readonly IWalkRepository _walkrepository;
        private readonly IMapper _mapper;
        public WalksController(PaapuWalksDbContext dbcontext,IWalkRepository walkRepository, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _walkrepository= walkRepository;
            _mapper= mapper;
        }


        //create new walk
        [HttpPost]
        public async Task<IActionResult> Created([FromBody] CreateWalkDto createWalkDto)
        {
            var walkdomain = _mapper.Map<Walk>(createWalkDto);
           walkdomain = await _walkrepository.CreateWalkAsync(walkdomain);

            



            return Ok(_mapper.Map<WalkDto>(walkdomain));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WalkDomain = await _walkrepository.GetAllWalksAsync();
            var k = _mapper.Map<List<WalkDto>>(WalkDomain);

            //create an exception 

            //throw new Exception("This is a new exception");

            return Ok(k);
        }

        [HttpGet]
        [Route("{id:guid}")]


        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var WalkDomainModel = await _walkrepository.GetByIdAsync(id);
            return Ok(_mapper.Map<WalkDto>(WalkDomainModel));

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WalkDto walkDto)
        {
            var walkDomainModel  = _mapper.Map<Walk>(walkDto);
            walkDomainModel = await _walkrepository.UpdateWalkAsync(id, walkDomainModel);

            var WalkDto = _mapper.Map<WalkDto>(walkDomainModel);
            return Ok(WalkDto);


        }


    }
}
