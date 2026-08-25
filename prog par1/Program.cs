
using System;

namespace CyberGuardBot
{
    class CyberGuard
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
   ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
  ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
  ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝
  ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
  ╚██████╗   ██║   ██████╔╝███████╗██║  ██║
   ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝

        ██████╗ ██╗   ██╗ █████╗ ██████╗ ██████╗ 
       ██╔════╝ ██║   ██║██╔══██╗██╔══██╗██╔══██╗
       ██║  ███╗██║   ██║███████║██████╔╝██║  ██║
       ██║   ██║██║   ██║██╔══██║██╔══██╗██║  ██║
       ╚██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝
        ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ 

              🔐 CYBERSECURITY AWARENESS BOT 🔐
");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("======================================");
            Console.WriteLine("        CYBERGUARD AWARENESS BOT");
            Console.WriteLine("======================================");
            Console.ResetColor();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("\nHello " + name + "!");
            Console.WriteLine("I am CyberGuard, your Cybersecurity Awareness Assistant.");

            TopicMenu.ShowMenu(name);
        }
    }
}
