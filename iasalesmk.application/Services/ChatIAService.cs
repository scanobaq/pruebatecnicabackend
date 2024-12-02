using iasalesmk.infrastructure.Services;
using OpenAI.Chat;

namespace iasalesmk.application.Services;

public class ChatIAService : IChatIAService
{
    private readonly IOpenAIService _openAIService;

    public ChatIAService(IOpenAIService openAIService)
    {
        _openAIService = openAIService;
    }

    public async Task<string> GetCompletion(string prompt)
    {
        ChatCompletion completion = await _openAIService.GetCompletion(prompt);
        return completion.Content[0].Text;
    }

}
