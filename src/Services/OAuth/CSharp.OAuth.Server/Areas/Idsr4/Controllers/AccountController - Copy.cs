//namespace CSharp.OAuth.Server.Areas.Idsr4.Controllers
//{
//    using System;
//    using System.Threading.Tasks;
//    using CSharp.Core.Exceptions;
//    using CSharp.OAuth.Server.Areas.Idsr4.ViewModels;
//    using CSharp.OAuth.Server.IdentityManager;
//    using CSharp.OAuth.Server.Idsr4.Services;
//    using IdentityServer4.Events;
//    using IdentityServer4.Extensions;
//    using IdentityServer4.Services;
//    using Microsoft.AspNetCore.Authentication;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.Extensions.Logging;

//    [Area("Idsr4")]
//    [Route("idsr4/[controller]/[action]")]
//    public class AccountController : Controller
//    {
//        private readonly ILogger<AccountController> _logger;

//        private readonly CSharpSignInManager _signInManager;

//        private readonly IIdentityServerInteractionService _interaction;

//        private readonly IAuthenticationSchemeProvider _schemeProvider;

//        private readonly IEventService _events;

//        private readonly IIdsr4Service _idsr4Service;

//        public AccountController(ILogger<AccountController> logger,
//            CSharpSignInManager signInManager,
//            IIdentityServerInteractionService interaction,
//            IAuthenticationSchemeProvider schemeProvider,
//            IEventService events,
//            IIdsr4Service idsr4Service) 
//        {
//            _logger = logger;

//            _signInManager = signInManager;

//            _idsr4Service = idsr4Service;

//            _interaction = interaction;

//            _schemeProvider = schemeProvider;

//            _events = events;
//        }

//        [HttpGet]
//        public async Task<IActionResult> SignIn(string returnUrl = null)
//        {
//            //var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            
//            return View(new SignInViewModel());
//        }
        
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> SignIn(SignInViewModel model)
//        {
//            if(!ModelState.IsValid) return View(model);

//            if (ModelState.IsValid)
//            {
//                var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

//                if (signInResult.Succeeded)
//                {
//                    var user = await _idsr4Service.FindByUsernameAsync(model.Username);

//                    await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));

//                    AuthenticationProperties props = null;
//                    if (AccountOptions.AllowRememberLogin && model.RememberLogin)
//                    {
//                        props = new AuthenticationProperties
//                        {
//                            IsPersistent = true,
//                            ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
//                        };
//                    };

//                    await _signInManager.SignInAsync(user,props);

//                    if (Url.IsLocalUrl(model.ReturnUrl))
//                    {
//                        return Redirect(model.ReturnUrl);
//                    }
//                    else if (string.IsNullOrEmpty(model.ReturnUrl))
//                    {
//                        return Redirect("~/");
//                    }
//                    else
//                    {
//                        throw new BadRequestException("invalid return URL");
//                    }
//                }

//                await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));

//                ModelState.AddModelError("Username", AccountOptions.InvalidCredentialsErrorMessage);
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> SignOut(string logoutId) 
//        {
//            await _signInManager.SignOutAsync();

//            await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));

//            return Redirect("http://localhost:5050/");
//        }
//    }
//}