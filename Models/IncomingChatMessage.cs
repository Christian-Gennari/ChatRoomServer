using System;

namespace ChatRoomServer.Models;

public class IncomingChatMessage
{
  public string User { get; set; } = "";
  public string Text { get; set; } = "";
}
