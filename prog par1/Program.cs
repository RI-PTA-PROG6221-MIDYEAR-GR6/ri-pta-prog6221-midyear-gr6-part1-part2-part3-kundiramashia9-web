using System;

namespace CyberGuardBot
{
    class CyberGuard
    {
        static void Main(string[] args)
        {
            Console.Title = "CyberGuard - Cybersecurity Awareness Bot";
            Console.SetWindowSize(100, 40);

            // Display new modern logo
            DisplayLogo();

            // Welcome message
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('═', 60));
            Console.WriteLine("  🌟  CYBERGUARD AWARENESS BOT");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();

            // Get user name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  👋 What's your name? ");
            Console.ResetColor();
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Cyber Learner";
            }

            // Welcome user
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('═', 60));
            Console.WriteLine($"  👋 Welcome, {name}!");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  I'm CyberGuard, your personal cybersecurity awareness");
            Console.WriteLine("  assistant. I'll help you learn about staying safe online.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  🚀 Ready to start your cybersecurity journey?");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();

            TopicMenu.ShowMenu(name);
        }

        private static void DisplayLogo()
        {
            Console.Clear();

            // Simple clean logo with colors
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════╗
    ║                                                          ║");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗         ║");
            Console.WriteLine(@"    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗        ║");
            Console.WriteLine(@"    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝        ║");
            Console.WriteLine(@"    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗        ║");
            Console.WriteLine(@"    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║        ║");
            Console.WriteLine(@"    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝        ║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"    ║                                                          ║");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"    ║          ███████╗███████╗ ██████╗██╗   ██╗             ║");
            Console.WriteLine(@"    ║          ██╔════╝██╔════╝██╔════╝╚██╗ ██╔╝             ║");
            Console.WriteLine(@"    ║          ███████╗█████╗  ██║      ╚████╔╝              ║");
            Console.WriteLine(@"    ║          ╚════██║██╔══╝  ██║       ╚██╔╝               ║");
            Console.WriteLine(@"    ║          ███████║███████╗╚██████╗   ██║                ║");
            Console.WriteLine(@"    ║          ╚══════╝╚══════╝ ╚═════╝   ╚═╝                ║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"    ║                                                          ║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"    ║              🔐  KNOWLEDGE IS YOUR BEST DEFENSE  🔐      ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"    ║                                                          ║");
            Console.WriteLine(@"    ╚══════════════════════════════════════════════════════════╝");

            Console.ResetColor();
        }
    }
}