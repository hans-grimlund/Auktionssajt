namespace Auktionssajt.Api;

public interface IErrorhandler
{
    void LogError(Exception ex);
}
