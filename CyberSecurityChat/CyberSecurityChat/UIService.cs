using System;
using System.Threading;

namespace CyberSecurityChat.Services
{
    public class UIService
    {
        private const int TypingDelay = 15; // Faster for better flow
        private readonly Random _random = new Random();

        public void DisplayAnimatedLogo()
        {
            Console.Clear();

            string[] logo = {
                @"╔═══════════════════════════════════════════════════════════════════════════════════════╗",
                @"║                                                                                       ║",
                @"║    ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗ ██████╗██╗   ██╗██████╗           ║",
                @"║   ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝╚██╗ ██╔╝██╔══██╗          ║",
                @"║   ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗██║      ╚████╔╝ ██████╔╝          ║",
                @"║   ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██║       ╚██╔╝  ██╔══██╗          ║",
                @"║   ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║╚██████╗   ██║   ██████╔╝          ║",
                @"║    ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝   ╚═╝   ╚═════╝           ║",
                @"║                                                                                       ║",
                @"║              🛡️ ADVANCED CYBERSECURITY BOT 🛡️                                        ║",
                @"║           Unlimited knowledge - Ask me anything about security!                       ║",
                @"║                                                                                       ║",
                @"╚═══════════════════════════════════════════════════════════════════════════════════════╝"
            };

            ConsoleColor[] colors = {
                ConsoleColor.Cyan,
                ConsoleColor.Green,
                ConsoleColor.Yellow,
                ConsoleColor.Magenta,
                ConsoleColor.Cyan
            };

            for (int i = 0; i < logo.Length; i++)
            {
                Console.ForegroundColor = colors[i % colors.Length];
                Console.WriteLine(logo[i]);
                Thread.Sleep(80);
            }

            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public void DisplayTextGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  🚀 Welcome to the ADVANCED Cybersecurity Bot!                                ║");
            Console.WriteLine("║  💡 I have UNLIMITED knowledge about online safety!                          ║");
            Console.WriteLine("║  🎯 Ask me anything - from passwords to advanced security!                   ║");
            Console.WriteLine("║  😂 Jokes, facts, and wisdom - all in one place!                             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public void DisplayWelcomeMessage(string userName, string nickname)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  🦸 Welcome, {userName}! You are now a {nickname}!                            ║");
            Console.WriteLine($"║  🌟 I have answers to INFINITE cybersecurity questions!                      ║");
            Console.WriteLine($"║  💪 Let's level up your security knowledge!                                  ║");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Thread.Sleep(500);
        }

        public void DisplayResponse(string response, string category = null)
        {
            if (!string.IsNullOrEmpty(category))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n┌─ [{category}] ─────────────────────────────────────────────────────────");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n🤖 Bot: ");
            Console.ResetColor();

            foreach (char c in response)
            {
                Console.Write(c);
                if (c == '.' || c == '!' || c == '?')
                {
                    Thread.Sleep(200);
                }
                else if (c == ',' || c == ';')
                {
                    Thread.Sleep(75);
                }
                else if (c == ':' && _random.Next(5) == 0)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    Thread.Sleep(TypingDelay);
                }
            }
            Console.WriteLine("\n");
        }

        public void DisplayUserMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\n👤 You: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public void DisplaySeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();
        }

        public void DisplayHelpSection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  🎯 UNLIMITED SECURITY KNOWLEDGE - ASK ME ANYTHING!                        ║");
            Console.WriteLine("║                                                                               ║");
            Console.WriteLine("║  🔐 Passwords & 2FA       🎣 Phishing & Scams                               ║");
            Console.WriteLine("║  🌐 Safe Browsing         🔒 Data Privacy & Tracking                        ║");
            Console.WriteLine("║  🛡️ General Security      🧠 Social Engineering                            ║");
            Console.WriteLine("║  😂 Jokes & Fun Facts     💡 Advanced Security Topics                       ║");
            Console.WriteLine("║                                                                               ║");
            Console.WriteLine("║  💬 Try asking:                                                             ║");
            Console.WriteLine("║  • 'How do I create a strong password?'                                     ║");
            Console.WriteLine("║  • 'What is phishing and how to spot it?'                                   ║");
            Console.WriteLine("║  • 'How to browse safely on public Wi-Fi?'                                  ║");
            Console.WriteLine("║  • 'Tell me a cybersecurity joke!'                                          ║");
            Console.WriteLine("║  • 'Give me a fun fact about hacking!'                                      ║");
            Console.WriteLine("║  • 'What is social engineering?'                                             ║");
            Console.WriteLine("║                                                                               ║");
            Console.WriteLine("║  🔥 Type 'exit' or 'quit' to end the conversation                            ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        public void DisplayFarewell(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  🎉 Farewell, {userName}! You're now a Cybersecurity Master!               ║");
            Console.WriteLine($"║  📚 You learned so much today! Keep exploring security topics!              ║");
            Console.WriteLine("║  🛡️ Remember: Knowledge is the best defense against cyber threats!         ║");
            Console.WriteLine("║  💪 Keep learning, keep growing, keep protecting yourself online!           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n🌟 Thank you for using the Advanced Cybersecurity Bot!");
            Console.WriteLine("🔄 Come back anytime to learn more!");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}