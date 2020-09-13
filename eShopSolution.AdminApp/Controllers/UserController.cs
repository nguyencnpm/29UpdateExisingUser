using System.Threading.Tasks;
using eShopSolution.AdminApp.Services;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace eShopSolution.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyWord, int pageIndex=1, int pageSize = 10)
        {
            var secsion = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                BearerToken = secsion,
                KeyWord = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var data = await _userApiClient.GetUsersPagings(request);

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userApiClient.RegisterUser(request);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

    }
}
