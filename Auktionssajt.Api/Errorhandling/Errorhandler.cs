
namespace Auktionssajt.Api;

public class Errorhandler(ILogger<Errorhandler> logger) : IErrorhandler
{
    private readonly ILogger<Errorhandler> _logger = logger;

    public void LogError(Exception ex)
    {
        _logger.LogError(ex.Message);
        _logger.LogInformation(ex.StackTrace);
    }
}
