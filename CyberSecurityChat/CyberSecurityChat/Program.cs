using System;
using CyberSecurityChat.Services;

namespace CyberSecurityChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "🛡️ Advanced Cybersecurity Bot";
            try { Console.SetWindowSize(140, 50); } catch { }

            var uiService = new UIService();
            var chatService = new ChatService();

            uiService.DisplayAnimatedLogo();
            uiService.DisplayTextGreeting();

            var userName = chatService.GetUserName();
            chatService.StartChat(userName);
            uiService.DisplayFarewell(userName);
        }
    }
}