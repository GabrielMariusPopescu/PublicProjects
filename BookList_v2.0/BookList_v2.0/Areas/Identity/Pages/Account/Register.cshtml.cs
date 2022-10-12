using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.Helpers;
using BookList_v2._0.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList_v2._0.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Street Address")]
            public string StreetAddress { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string State { get; set; }

            [Required]
            [Display(Name = "Postal Code")]
            public string PostalCode { get; set; }

            [Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            public Guid? CompanyId { get; set; }

            public string Role { get; set; }

            public IEnumerable<SelectListItem> Companies { get; set; }

            public IEnumerable<SelectListItem> Roles { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            Input = new InputModel()
            {
                Companies = unitOfWork.CompanyRepository.GetAll().Select(company => new SelectListItem
                {
                    Text = company.Name,
                    Value = company.Id.ToString()
                }),
                Roles = roleManager.Roles
                    .Where(role => !role.Name.Equals(Constants.INDIVIDUAL_USER))
                    .Select(role => role.Name)
                    .Select(role => new SelectListItem
                    {
                        Text = role,
                        Value = role
                    })

            };
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (!ModelState.IsValid)
                return Page();

            var user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email,
                CompanyId = Input.CompanyId,
                StreetAddress = Input.StreetAddress,
                City = Input.City,
                State = Input.State,
                PostalCode = Input.PostalCode,
                Name = Input.Name,
                PhoneNumber = Input.PhoneNumber,
                Role = Input.Role
            };

            var result = await userManager.CreateAsync(user, Input.Password);
            if (result.Succeeded)
            {
                logger.LogInformation("User created a new account with password.");

                if (!await roleManager.RoleExistsAsync(Constants.ADMINISTRATOR))
                {
                    await roleManager.CreateAsync(new IdentityRole(Constants.ADMINISTRATOR));
                }
                if (!await roleManager.RoleExistsAsync(Constants.EMPLOYEE))
                {
                    await roleManager.CreateAsync(new IdentityRole(Constants.EMPLOYEE));
                }
                if (!await roleManager.RoleExistsAsync(Constants.COMPANY_USER))
                {
                    await roleManager.CreateAsync(new IdentityRole(Constants.COMPANY_USER));
                }
                if (!await roleManager.RoleExistsAsync(Constants.INDIVIDUAL_USER))
                {
                    await roleManager.CreateAsync(new IdentityRole(Constants.INDIVIDUAL_USER));
                }

                if (user.Role == null)
                {
                    await userManager.AddToRoleAsync(user, Constants.INDIVIDUAL_USER);
                }
                else
                {
                    if (user.CompanyId != Guid.NewGuid())
                    {
                        await userManager.AddToRoleAsync(user, Constants.COMPANY_USER);
                    }
                    await userManager.AddToRoleAsync(user, user.Role);
                }


                //var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //var callbackUrl = Url.Page("/Account/ConfirmEmail", null, new { area = "Identity", userId = user.Id, code, returnUrl }, Request.Scheme);

                //await emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");



                if (userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                }
                else
                {
                    if (user.Role == null)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        //admin is registering a new user
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
