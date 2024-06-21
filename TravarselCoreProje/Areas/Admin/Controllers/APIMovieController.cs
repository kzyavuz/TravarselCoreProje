using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravarselCoreProje.Areas.Admin.Models;

namespace TravarselCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class APIMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieModel> apiMovieModels = new List<ApiMovieModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "2d944aebe1msh82c43daf136aa12p1a6cfajsnefc63df84d8d" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovieModels = JsonConvert.DeserializeObject<List<ApiMovieModel>>(body);
                
                return View(apiMovieModels);
            }
        }
    }
}
