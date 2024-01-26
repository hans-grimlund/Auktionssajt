using Auktionssajt.Domain.Models;

namespace Auktionssajt.Domain;

public class LoginResponse(Status? status = null, string? token = null)
{
    public Status Status { get; set; } = status ?? Status.None;
    public string Token { get; set; } = token ?? string.Empty;
}
