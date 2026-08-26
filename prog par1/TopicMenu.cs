using System;

namespace CyberGuardBot
{
    class TopicMenu
    {
        public static void ShowMenu(string name)
        {
            while (true)
            {
                Console.Clear();

                // Header
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(new string('═', 60));
                Console.WriteLine("  🛡️  CYBERSECURITY TOPICS");
                Console.WriteLine(new string('═', 60));
                Console.ResetColor();

                // Menu options in a cleaner format
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n  ┌─────────────────────────────────────────────┐");
                Console.WriteLine("  │                                             │");
                Console.WriteLine("  │  1.  🔐  Password Security                  │");
                Console.WriteLine("  │  2.  🎣  Phishing                          │");
                Console.WriteLine("  │  3.  🔑  Multi-Factor Authentication        │");
                Console.WriteLine("  │  4.  🧠  Social Engineering                │");
                Console.WriteLine("  │  5.  🦠  Malware                           │");
                Console.WriteLine("  │  6.  🛡️  Online Privacy                    │");
                Console.WriteLine("  │  7.  🚪  Exit                              │");
                Console.WriteLine("  │                                             │");
                Console.WriteLine("  └─────────────────────────────────────────────┘");
                Console.ResetColor();

                // User prompt
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n  👤 {name}, enter your choice (1-7): ");
                Console.ResetColor();
                string choice = Console.ReadLine();

                // Validation
                if (string.IsNullOrWhiteSpace(choice))
                {
                    ShowError("Invalid input. Please enter a number.");
                    continue;
                }

                if (choice == "7")
                {
                    DisplayExitMessage(name);
                    break;
                }

                if (!int.TryParse(choice, out int choiceNumber) || choiceNumber < 1 || choiceNumber > 7)
                {
                    ShowError("Invalid choice. Please enter a number between 1-7.");
                    continue;
                }

                CyberAnswers.GetResponse(choice);
            }
        }

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  ❌ {message}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void DisplayExitMessage(string name)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', 60));
            Console.WriteLine("  👋  GOODBYE!");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  Thank you for learning with us, {name}!");
            Console.WriteLine("  Remember: Cybersecurity starts with YOU.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  🔐 Stay safe. Stay secure. Stay vigilant.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n" + new string('─', 60));
            Console.WriteLine("  Press any key to exit...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}using System;

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