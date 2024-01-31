using Auktionssajt.Domain.Models;

namespace Auktionssajt.Domain;

public class LoginResponse
{
    public Status Status { get; set; }
    public string Token { get; set; }
    
    public LoginResponse(Status? status = null, string? token = null)
    {
        Status = status ?? Status.None;
        Token = token ?? string.Empty;
    }

    public LoginResponse()
    {
        Token ??= string.Empty;
    }
}
