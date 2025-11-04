using System;

namespace ChatRoomServer.Models;

public class ChatMessage
{
  public int Id { get; set; }
  public string User { get; set; } = "";
  public string Text { get; set; } = "";
  public DateTime TimeSent { get; set; } = DateTime.UtcNow;
}
