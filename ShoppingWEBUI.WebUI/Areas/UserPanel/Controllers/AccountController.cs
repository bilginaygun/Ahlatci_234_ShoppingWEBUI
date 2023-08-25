using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using ShoppingWEBUI.Core.DTO;

namespace ShoppingWEBUI.WebUI.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class AccountController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }


        [HttpGet("/User/Register")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/Account/UserRegister")]

       
        public async Task<ActionResult> LoginAsync(LoginDTO loginDTO)
        {
            var url = "http://localhost:5183/Login";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(loginDTO);
            request.AddBody(body,"application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);
            var responseObject = restResponse.Content;
            return RedirectToAction("Index", "Home");



        }

    }
}
