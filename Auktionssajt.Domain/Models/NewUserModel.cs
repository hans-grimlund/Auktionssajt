namespace Auktionssajt.Domain.Models
{
    public class NewUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public NewUserModel(string? username = null, string? password = null)
        {
            Username = username ?? string.Empty;
            Password = password ?? string.Empty;
        }

        public NewUserModel()
        {
            Username ??= string.Empty;
            Password ??= string.Empty;
        }
    }
}