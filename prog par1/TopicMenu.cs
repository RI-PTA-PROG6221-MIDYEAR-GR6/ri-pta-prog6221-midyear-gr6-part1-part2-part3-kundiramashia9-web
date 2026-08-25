using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace CyberGuardBot
{
    class TopicMenu
    {
        public static void ShowMenu(string name)
        {
            while (true)
            {
                Console.WriteLine("\n========== CYBERSECURITY TOPICS ==========");
                Console.WriteLine("1. Password Security");
                Console.WriteLine("2. Phishing");
                Console.WriteLine("3. Multi-Factor Authentication");
                Console.WriteLine("4. Social Engineering");
                Console.WriteLine("5. Malware");
                Console.WriteLine("6. Online Privacy");
                Console.WriteLine("7. Exit");

                Console.Write("\nChoose a topic by entering its number: ");
                string choice = Console.ReadLine();

                if (choice == "7")
                {
                    Console.WriteLine("\nGoodbye " + name + "! Stay safe online. 🔐");
                    break;
                }

                CyberAnswers.GetResponse(choice);
            }
        }
    }
}


