using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

namespace iasalesmk.infrastructure.Services;
public class OpenAIService : IOpenAIService
{
    //private readonly ChatClient _chatClient;

    public OpenAIService()
    {
        // System.ClientModel.ApiKeyCredential credential = new(Constants.OpenAIConstants.AzureKey);
        // AzureOpenAIClient azureClient = new(new Uri(Constants.OpenAIConstants.AzureEndpoint), credential);
        // _chatClient = chatClient;
        // _chatClient = azureClient.GetChatClient(Constants.OpenAIConstants.OpenAIModel);
        //ChatClient chatClient = azureClient.GetChatClient("Sales-Supermercado");

    }

    public async Task<ChatCompletion> GetCompletion(string prompt)
    {
        System.ClientModel.ApiKeyCredential credential = new(Constants.OpenAIConstants.AzureKey);
        AzureOpenAIClient azureClient = new(new Uri(Constants.OpenAIConstants.AzureEndpoint), credential);
        ChatClient chatClient = azureClient.GetChatClient(Constants.OpenAIConstants.OpenAIModel);

        ChatCompletion completion = chatClient.CompleteChat(
            new ChatMessage[]{
                new SystemChatMessage("Eres un asistente de ventas par el supermercado merkano. Responde de manera concisa y educada. \n\nEn la primera interacción siempre contesta de esta manera : Estas comunicado con la IA del supermercado MERKANO, ¿En que te puedo ayudar?\n\nLos productos que se venden son los siguientes: 001,Aguardiente botella, 30000 002 Tequila jimador botella, 40000.\n\nLos productos solicitados te llegaran por código y la cantidad separados por el carácter coma.  Te doy un ejemplo: 001,3 \n\nDebes responder a la solicitud anterior de productos en una lista por ejemplo para la petición 001,3 debes responde así: Aguardiente botella, cantidad 3, valor por unidad $30.000 costo total $90.000\n\nUna vez  enviada la anterior repuesta, pregunta ¿Desa confirmar su pedido? responda Si o No\n\nSi te responden Si, pregunta, ¿A que dirección desea que le enviemos su pedido?.\n\nCuando te den la dirección, respondes lo siguiente: ¡Gracias por proporcionar la dirección! Confirmo que su pedido ha sido procesado y se enviará a la dirección indicada. El total de su compra es de $ pesos, puedes pagar en efectivo o datafono. limítate a dar solo esta repuesta no agregues mas información.\n\nSi responden No, respondes lo siguiente:  Fue un placer atenderte!!! Tal vez luego!! un saludo cordial MERKNO\n"),
                new UserChatMessage(prompt)
            }
        );
        return completion;
    }
}
