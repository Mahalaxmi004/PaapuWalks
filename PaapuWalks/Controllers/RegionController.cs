using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaapuWalks.Data;
using PaapuWalks.Models.Domain;
using PaapuWalks.Models.DTO;
using PaapuWalks.Repositories;
using System.Text.Json;

namespace PaapuWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //use authorize attribute to lock unauthenticated users
    //[Authorize]
   
    public class RegionController : ControllerBase
    {
        private readonly PaapuWalksDbContext _dbcontext;
        private readonly IRegionRepoistory regionRepoistory;
        private readonly IMapper mapper;
        private readonly ILogger<RegionController> _logger;

        public RegionController(PaapuWalksDbContext dbcontext, IRegionRepoistory regionRepoistory,IMapper mapper,ILogger<RegionController> logger)
        {
            _dbcontext = dbcontext;
            this.regionRepoistory = regionRepoistory;
            this.mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
          

            //_logger.LogInformation("Get All region action method was invoked");


            var regionDomain = await regionRepoistory.GetAllAsync();

            //_logger.LogInformation($"Finish getallregion request with data:{JsonSerializer.Serialize(regionDomain)} ");
            var k = mapper.Map<List<RegionDto>>(regionDomain);



            return Ok(k);
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var k = await regionRepoistory.GetByIdAsync(id);

            if(k == null)
            {
                return NotFound();
            }

            return Ok(k);
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto createRegionDto)
        {
            _logger.LogInformation("Create Region method was invoked");
           var region = mapper.Map<Region>(createRegionDto);

          region = await  regionRepoistory.CreateAsync(region);

            var regionDto = mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

            //return Ok("created");
        }


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            var region = mapper.Map<Region>(updateRegionDto);
            //    new Region
            //{
            //    Name = updateRegionDto.Name,
            //    Code = updateRegionDto.Code
            //};

            var regionDomain = await regionRepoistory.UpdateAsync(id,region);

            var RegionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(RegionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await regionRepoistory.DeleteAsync(id);


            return Ok("Deleted Successfully");
        }
    }
}
