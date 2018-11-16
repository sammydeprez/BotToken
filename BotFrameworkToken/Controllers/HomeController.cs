using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BotFrameworkToken.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;

namespace BotFrameworkToken.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyConfig> config;

        public HomeController(IOptions<MyConfig> config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StartConversation()
        {
            DirectLineAuthenticationResponse directLineAuthenticationResponse = new DirectLineAuthenticationResponse();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", config.Value.BotDirectLineSecret);

                HttpResponseMessage response = httpClient.PostAsync("https://directline.botframework.com/v3/directline/conversations", null).Result;
                directLineAuthenticationResponse = DirectLineAuthenticationResponse.FromJson(response.Content.ReadAsStringAsync().Result);
            }
            return new JsonResult(directLineAuthenticationResponse);
        }

    }
}
