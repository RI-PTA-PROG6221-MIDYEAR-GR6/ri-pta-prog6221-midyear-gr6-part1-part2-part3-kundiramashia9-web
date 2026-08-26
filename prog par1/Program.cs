using System;
using System.Threading;

namespace ChatbotBot
{
    class Chatbot
    {
        static void Main(string[] args)
        {
            Console.Title = "Chatbot - Cybersecurity Awareness Bot";
            Console.SetWindowSize(120, 50);

            DisplayLogo();
            Thread.Sleep(1500);

            Console.Clear();
            TypeWriter("Welcome to Chatbot - Your Personal Cybersecurity Assistant\n", ConsoleColor.Cyan);
            TypeWriter("================================================================\n", ConsoleColor.DarkCyan);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nWhat is your name ");
            Console.ResetColor();
            string name = Console.ReadLine();

            // Fix CS8600: Check for null and assign default
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "User";
            }

            Console.Clear();
            TypeWriter($"Hello, {name}. I am Chatbot, your cybersecurity companion\n", ConsoleColor.Green);
            TypeWriter("I am here to have a real conversation with you about staying safe online\n", ConsoleColor.White);
            TypeWriter("You can ask me about anything related to cybersecurity\n", ConsoleColor.White);
            TypeWriter("\nYou can ask me things like\n", ConsoleColor.Yellow);
            TypeWriter("  What is phishing\n", ConsoleColor.Cyan);
            TypeWriter("  How do I create a strong password\n", ConsoleColor.Cyan);
            TypeWriter("  Tell me about malware\n", ConsoleColor.Cyan);
            TypeWriter("  What is social engineering\n", ConsoleColor.Cyan);
            TypeWriter("  How can I protect my privacy online\n", ConsoleColor.Cyan);
            TypeWriter("  What is 2FA\n", ConsoleColor.Cyan);
            TypeWriter("  Help me with general tips\n", ConsoleColor.Cyan);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Type your questions or 'exit' to quit");
            Console.WriteLine("Type 'menu' to see all topics");
            Console.ResetColor();

            ChatbotEngine.StartChat(name);
        }

        private static void DisplayLogo()
        {
            Console.Clear();
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

        private static void TypeWriter(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.ResetColor();
        }
    }
}