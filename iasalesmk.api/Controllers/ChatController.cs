
using iasalesmk.application.Services;
using Microsoft.AspNetCore.Mvc;

namespace iasalesmk.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatIAService _chatIAService;

    public ChatController(IChatIAService chatIAService)
    {
        _chatIAService = chatIAService;
    }

    [HttpPost]
    public async Task<IActionResult> GetCompletion([FromBody] string prompt)
    {
        string response = await _chatIAService.GetCompletion(prompt);
        return Ok(response);
    }

}
