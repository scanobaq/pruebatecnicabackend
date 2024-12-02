using OpenAI.Chat;

namespace iasalesmk.infrastructure.Services;
public interface IOpenAIService
{
    Task<ChatCompletion> GetCompletion(string prompt);

}
