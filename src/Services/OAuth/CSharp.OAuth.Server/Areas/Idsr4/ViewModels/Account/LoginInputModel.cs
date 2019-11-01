namespace CSharp.OAuth.Server.Areas.Idsr4.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginInputModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email invalid")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool InternalLogin { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}