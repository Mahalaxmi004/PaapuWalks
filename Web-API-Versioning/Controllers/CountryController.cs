using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.Models.DTO;

namespace Web_API_Versioning.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountryController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetV1()
        {
            var countriesDomain = CountriesData.Get();

            //map domain to dto
            var CountriesDto = new List<CountryDtoV1>();
            foreach (var country in countriesDomain)
            {
                CountriesDto.Add(new CountryDtoV1
                {
                    Id = country.Id,
                    Name = country.Name

                });
            }

            return Ok(CountriesDto);
        }
        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetV2()
        {
            var countriesDomain = CountriesData.Get();

            //map domain to dto
            var CountriesDto = new List<CountryDtoV2>();
            foreach (var country in countriesDomain)
            {
                CountriesDto.Add(new CountryDtoV2
                {
                    Id = country.Id,
                    CountryName = country.Name

                });
            }

            return Ok(CountriesDto);
        }
    }
}
