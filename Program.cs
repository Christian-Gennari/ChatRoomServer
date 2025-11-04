using ChatRoomServer.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

int nextId = 0;
List<ChatMessage> messages = [];

app.MapGet("/", () => "ChatRoom server is running");

app.MapPost("/messages", (IncomingChatMessage dataTransferObject) =>
{
  var message = new ChatMessage
  {
    Id = nextId++,
    User = dataTransferObject.User,
    Text = dataTransferObject.Text,
    TimeSent = DateTime.UtcNow
  };

  messages.Add(message);

  return Results.Ok(message);
});

app.MapGet("/messages", (int? after) =>
{
  if (after is null)
    return Results.Ok(messages);

  var newerMessages = messages
      .Where(m => m.Id > after)
      .ToList();

  return Results.Ok(newerMessages);
});

app.Run();
