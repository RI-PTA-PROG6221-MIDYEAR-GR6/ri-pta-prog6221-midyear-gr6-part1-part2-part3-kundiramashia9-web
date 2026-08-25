using System;

namespace CyberGuardBot
{
    class CyberAnswers
    {
        public static void GetResponse(string choice)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n========== PASSWORD SECURITY ==========");
                    Console.WriteLine("Use strong and unique passwords for your accounts.");
                    AvoidPasswords();
                    break;

                case "2":
                    Console.WriteLine("\n========== PHISHING ==========");
                    Console.WriteLine("Phishing is when criminals use fake messages or websites to trick people into giving away information.");
                    break;

                case "3":
                    Console.WriteLine("\n========== MULTI-FACTOR AUTHENTICATION ==========");
                    Console.WriteLine("MFA adds an extra layer of protection by requiring more than one method of verification.");
                    break;

                case "4":
                    Console.WriteLine("\n========== SOCIAL ENGINEERING ==========");
                    Console.WriteLine("Social engineering involves manipulating people into revealing confidential information.");
                    break;

                case "5":
                    Console.WriteLine("\n========== MALWARE ==========");
                    Console.WriteLine("Malware is harmful software designed to damage systems or steal information.");
                    break;

                case "6":
                    Console.WriteLine("\n========== ONLINE PRIVACY ==========");
                    Console.WriteLine("Protect your personal information and avoid sharing sensitive details with unknown people online.");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid option. Please choose a number from 1 to 7.");
                    break;
            }

            Console.ResetColor();
        }

        private static void AvoidPasswords()
        {
            Console.WriteLine("Avoid using easy-to-guess information such as your name or birthday.");
        }
    }
}