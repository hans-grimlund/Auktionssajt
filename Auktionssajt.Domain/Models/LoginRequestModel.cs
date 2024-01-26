namespace Auktionssajt.Domain;

public class LoginRequestModel(string? username = null, string? password = null)
{
    public string Username { get; set; } = username ?? string.Empty;
    public string Password { get; set; } = password ?? string.Empty;
}
