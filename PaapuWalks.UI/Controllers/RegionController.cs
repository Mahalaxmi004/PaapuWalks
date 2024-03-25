using Microsoft.AspNetCore.Mvc;
using PaapuWalks.UI.Models;
using PaapuWalks.UI.Models.DTO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PaapuWalks.UI.Controllers
{
    public class RegionController : Controller
    {
        public IHttpClientFactory _HttpClientFactory;
        public RegionController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }



        public async Task<IActionResult> Index()
        {
            List<RegionDto> Response = new List<RegionDto>();
            try
            {
                //get all regions from webapi we will be injecting http client in pg.cs
                var client = _HttpClientFactory.CreateClient();

                var HttpResponseMessage = await client.GetAsync("https://localhost:7230/api/Region");

                //ensuresuccess.. is an built in http client method

                HttpResponseMessage.EnsureSuccessStatusCode();

                Response.AddRange(await HttpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());



            }
            catch (Exception ex)
            {


            }


            return View(Response);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel addRegionViewModel)
        {
            var client = _HttpClientFactory.CreateClient();
            var HttpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7230/api/Region"),
                Content = new StringContent(JsonSerializer.Serialize(addRegionViewModel), Encoding.UTF8, "application/json")

            };
            var HttpResponseMessage = await client.SendAsync(HttpRequestMessage);
            HttpResponseMessage.EnsureSuccessStatusCode();

            var response = await HttpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();
            if (response != null)
            {

                return RedirectToAction("Index", "Region");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _HttpClientFactory.CreateClient();
            var httpresponsemessage = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7230/api/Region/{id.ToString()}");
            
            if(httpresponsemessage != null)
            {
                return View(httpresponsemessage);
            }
            
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto regionDto)
        {
            var client = _HttpClientFactory.CreateClient();
            var HttpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7230/api/Region/{regionDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json")
            };
            var httpResponseMessage = await client.SendAsync(HttpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();
            if (response != null)
            {

                return RedirectToAction("Index", "Region");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _HttpClientFactory.CreateClient();
            var httpresponsemessage = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7230/api/Region/{id.ToString()}");

            if (httpresponsemessage != null)
            {
                return View(httpresponsemessage);
            }

            return View(null);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto regionDto)
        {
            var client = _HttpClientFactory.CreateClient();
            var HttpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:7230/api/Region/{regionDto.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(regionDto),Encoding.UTF8, "application/json")


            };

            var httpResponseMessage = await client.SendAsync(HttpRequest);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();
            if (response != null)
            {
                return RedirectToAction("Index", "Region");
            }
            return View(null);
        }
    }
}

