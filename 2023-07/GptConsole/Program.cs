using System.Text;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

List<ChatMessage> messages = new()
{
    //new ChatMessage(ChatMessageRole.System, "Odpovídej stručně v bodech.")
};

Console.WriteLine("Ptejte se:");
while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    string question = Console.ReadLine();
    Console.ResetColor();
    messages.Add(new ChatMessage(ChatMessageRole.User, question));

    var ai = new OpenAIAPI(new APIAuthentication("API KEY", "org-XXX"));

    ChatRequest request = new ChatRequest
    {
        user = "Holec",
        Model = Model.GPT4_32k_Context,
        Messages = messages.Skip(messages.Count - 4).ToList(),
        Temperature = 0.7,
        MaxTokens = 500
    };

    IAsyncEnumerable<ChatResult> response = ai.Chat.StreamChatEnumerableAsync(request);

    StringBuilder sb = new();
    await foreach (ChatResult item in response)
    {
        string delta = item.Choices.FirstOrDefault().Delta.Content;
        Console.Write(delta);
        sb.Append(delta);
    }
    messages.Add(new ChatMessage(ChatMessageRole.Assistant, sb.ToString()));
    Console.WriteLine();
}