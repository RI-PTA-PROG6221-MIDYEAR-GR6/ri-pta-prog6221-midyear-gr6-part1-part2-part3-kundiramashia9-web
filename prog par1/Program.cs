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

            // Logo with colors
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"_____    ____   ____        ____   _________________       _____          _____   _________________ ");
            Console.WriteLine(@"  ___|\    \  |    | |    |  ____|\   \ /                 \ ___|\     \    ____|\    \ /                 \");
            Console.WriteLine(@" /    /\    \ |    | |    | /    /\    \\______     ______/|    |\     \  /     /\    \\______     ______/");
            Console.WriteLine(@"|    |  |    ||    |_|    ||    |  |    |  \( /    /  )/   |    | |     |/     /  \    \  \( /    /  )/   ");
            Console.WriteLine(@"|    |  |____||    .-.    ||    |__|    |   ' |   |   '    |    | /_ _ /|     |    |    |  ' |   |   '    ");
            Console.WriteLine(@"|    |   ____ |    | |    ||    .--.    |     |   |        |    |\    \ |     |    |    |    |   |        ");
            Console.WriteLine(@"|    |  |    ||    | |    ||    |  |    |    /   //        |    | |    ||\     \  /    /|   /   //        ");
            Console.WriteLine(@"|\ ___\/    /||____| |____||____|  |____|   /___//         |____|/____/|| \_____\/____/ |  /___//         ");
            Console.WriteLine(@"| |   /____/ ||    | |    ||    |  |    |  |`   |          |    /     || \ |    ||    | / |`   |          ");
            Console.WriteLine(@" \|___|    | /|____| |____||____|  |____|  |____|          |____|_____|/  \|____||____|/  |____|          ");
            Console.WriteLine(@"   \( |____|/   \(     )/    \(      )/      \(              \(    )/        \(    )/       \(            ");
            Console.WriteLine(@"    '   )/       '     '      '      '        '               '    '          '    '         '            ");
            Console.WriteLine(@"        '                                                                                                 ");

            Console.ResetColor();
        }
    }
}