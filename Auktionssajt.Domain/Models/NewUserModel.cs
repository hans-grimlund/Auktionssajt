namespace Auktionssajt.Domain.Models
{
    public class NewUserModel(string? username = null, string? password = null)
    {
        public string Username { get; set; } = username ?? string.Empty;
        public string Password { get; set; } = password ?? string.Empty;

    }
}