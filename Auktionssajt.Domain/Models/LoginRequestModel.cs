namespace Auktionssajt.Domain;

public class LoginRequestModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginRequestModel(string? username = null, string? password = null)
    {
        Username = username ?? string.Empty;
        Password = password ?? string.Empty;
    }
    
    public LoginRequestModel()
    {
        Username ??= string.Empty;
        Password ??= string.Empty;
    }
}
