namespace CSharp.OAuth.Server.Areas.Idsr4.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SignInViewModel
    {
        public SignInViewModel() { }

        public SignInViewModel(string returnUrl) 
        {
            ReturnUrl = returnUrl;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberLogin { get; set; }

    }
}
