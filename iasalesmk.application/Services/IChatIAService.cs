namespace iasalesmk.application.Services;

public interface IChatIAService
{
    Task<string> GetCompletion(string prompt);

}
