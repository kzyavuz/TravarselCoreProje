using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Visiter/")]
    [Authorize(Policy = "AdminPolicy")]
    public class VisiterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisiterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:55319/api/Visiter");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisiterModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateVisiter")]
        [HttpGet]
        public IActionResult CreateVisiter()
        {
            return View();
        }

        [Route("CreateVisiter")]
        [HttpPost]
        public async Task<IActionResult> CreateVisiter(VisiterModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:55319/api/Visiter", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteVisiter/{id}")]
        public async Task<IActionResult> DeleteVisiter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.DeleteAsync($"http://localhost:55319/api/Visiter/{id}");
            if (resposeMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateVisiter/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVisiter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposeMessage = await client.GetAsync($"http://localhost:55319/api/Visiter/{id}");
            if (resposeMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisiterModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateVisiter/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateVisiter(VisiterModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var resposeMessage = await client.PutAsync("http://localhost:55319/api/Visiter", content);
            if (resposeMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
