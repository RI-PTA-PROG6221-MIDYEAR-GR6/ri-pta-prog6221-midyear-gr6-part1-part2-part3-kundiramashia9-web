using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChatbotBot
{
    class ChatbotEngine
    {
        private static Random random = new Random();
        private static string userName = string.Empty;
        private static Dictionary<string, string> responseKeywords = new Dictionary<string, string>();
        private static List<string> conversationHistory = new List<string>();
        private static Dictionary<string, List<string>> greetingResponses = new Dictionary<string, List<string>>();
        private static Dictionary<string, List<string>> farewellResponses = new Dictionary<string, List<string>>();

        public static void StartChat(string name)
        {
            userName = name;
            InitializeKeywords();
            InitializeGreetings();
            InitializeFarewells();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n{userName}: ");
                Console.ResetColor();
                string userInput = Console.ReadLine();

                // Fix CS8600: Check for null
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: I did not catch that. Could you please say something");
                    Console.ResetColor();
                    continue;
                }

                // Store conversation history
                conversationHistory.Add(userInput);
                string lowerInput = userInput.ToLower();

                // Check for exit commands
                if (IsFarewell(lowerInput))
                {
                    Goodbye();
                    break;
                }

                // Check for menu command
                if (lowerInput == "menu" || lowerInput == "topics")
                {
                    ShowTopicMenu();
                    continue;
                }

                // Check for greetings
                if (IsGreeting(lowerInput))
                {
                    string response = GetGreetingResponse();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Chatbot: ");
                    Console.ResetColor();
                    TypeWriter(response, ConsoleColor.White);
                    continue;
                }

                // Generate response for questions and statements
                string responses = GenerateResponse(userInput);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Chatbot: ");
                Console.ResetColor();
                TypeWriter(responses, ConsoleColor.White);
            }
        }

        private static void InitializeKeywords()
        {
            // Map keywords to topic IDs
            responseKeywords["password"] = "1";
            responseKeywords["passphrase"] = "1";
            responseKeywords["pwd"] = "1";
            responseKeywords["login"] = "1";
            responseKeywords["credentials"] = "1";
            responseKeywords["strong password"] = "1";
            responseKeywords["create password"] = "1";

            responseKeywords["phish"] = "2";
            responseKeywords["scam"] = "2";
            responseKeywords["fraud"] = "2";
            responseKeywords["deception"] = "2";
            responseKeywords["spoof"] = "2";
            responseKeywords["fake email"] = "2";

            responseKeywords["2fa"] = "3";
            responseKeywords["two factor"] = "3";
            responseKeywords["multi factor"] = "3";
            responseKeywords["mfa"] = "3";
            responseKeywords["authenticator"] = "3";
            responseKeywords["verification"] = "3";
            responseKeywords["second factor"] = "3";

            responseKeywords["social engineering"] = "4";
            responseKeywords["manipulation"] = "4";
            responseKeywords["impersonation"] = "4";
            responseKeywords["psychological"] = "4";
            responseKeywords["pretext"] = "4";

            responseKeywords["malware"] = "5";
            responseKeywords["virus"] = "5";
            responseKeywords["worm"] = "5";
            responseKeywords["trojan"] = "5";
            responseKeywords["ransomware"] = "5";
            responseKeywords["spyware"] = "5";
            responseKeywords["antivirus"] = "5";

            responseKeywords["privacy"] = "6";
            responseKeywords["private"] = "6";
            responseKeywords["vpn"] = "6";
            responseKeywords["tracking"] = "6";
            responseKeywords["cookie"] = "6";
            responseKeywords["browser"] = "6";
            responseKeywords["data"] = "6";
            responseKeywords["information"] = "6";

            responseKeywords["tip"] = "tips";
            responseKeywords["advice"] = "tips";
            responseKeywords["suggestion"] = "tips";
            responseKeywords["recommendation"] = "tips";
            responseKeywords["best practice"] = "tips";
            responseKeywords["secure"] = "tips";
            responseKeywords["protect"] = "tips";
            responseKeywords["defend"] = "tips";
            responseKeywords["hack"] = "tips";
            responseKeywords["breach"] = "tips";
            responseKeywords["safe"] = "tips";
            responseKeywords["security"] = "tips";
        }

        private static void InitializeGreetings()
        {
            greetingResponses["hello"] = new List<string>
            {
                $"Hello {userName}. How can I help you today",
                $"Hi {userName}. What cybersecurity topic would you like to learn about",
                $"Hey there {userName}. How are you doing today",
                $"Greetings {userName}. Ready to learn about cybersecurity",
                $"Hello {userName}. It is great to see you. What can I assist you with"
            };

            greetingResponses["morning"] = new List<string>
            {
                $"Good morning {userName}. How can I help you start your day safely online",
                $"Good morning. Ready to learn about cybersecurity, {userName}"
            };

            greetingResponses["afternoon"] = new List<string>
            {
                $"Good afternoon {userName}. How can I assist you with cybersecurity today",
                $"Good afternoon. What would you like to know about staying safe online, {userName}"
            };

            greetingResponses["evening"] = new List<string>
            {
                $"Good evening {userName}. How can I help you protect your digital life",
                $"Good evening. What cybersecurity topic interests you today, {userName}"
            };

            greetingResponses["how are you"] = new List<string>
            {
                $"I am doing well, {userName}. Thank you for asking. How can I help you today",
                $"I am great {userName}. Always happy to talk about cybersecurity. What can I do for you"
            };

            greetingResponses["whats up"] = new List<string>
            {
                $"Not much {userName}. Just here to help you stay safe online. What can I assist you with",
                $"Hey {userName}. Ready to learn about cybersecurity. What is on your mind"
            };
        }

        private static void InitializeFarewells()
        {
            farewellResponses["bye"] = new List<string>
            {
                $"Goodbye {userName}. Stay safe online",
                $"Bye {userName}. Remember to keep your passwords strong and your software updated",
                $"See you later {userName}. Stay vigilant out there"
            };

            farewellResponses["exit"] = new List<string>
            {
                $"Take care {userName}. Stay secure",
                $"Until next time {userName}. Keep learning about cybersecurity"
            };

            farewellResponses["goodbye"] = new List<string>
            {
                $"Goodbye {userName}. It was great talking to you. Stay safe",
                $"Farewell {userName}. Remember, cybersecurity starts with you"
            };
        }

        private static bool IsGreeting(string input)
        {
            string[] greetings = { "hello", "hi", "hey", "greetings", "howdy", "good morning",
                                  "good afternoon", "good evening", "whats up", "how are you",
                                  "how are things", "good day", "yo" };

            foreach (string greeting in greetings)
            {
                if (input.Contains(greeting))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsFarewell(string input)
        {
            string[] farewells = { "exit", "quit", "goodbye", "bye", "see you", "later",
                                  "take care", "farewell", "good night" };

            foreach (string farewell in farewells)
            {
                if (input.Contains(farewell))
                {
                    return true;
                }
            }
            return false;
        }

        private static string GetGreetingResponse()
        {
            if (conversationHistory.Count == 0)
            {
                return greetingResponses["hello"][random.Next(greetingResponses["hello"].Count)];
            }

            string input = conversationHistory[conversationHistory.Count - 1].ToLower();

            if (input.Contains("good morning"))
            {
                return greetingResponses["morning"][random.Next(greetingResponses["morning"].Count)];
            }
            else if (input.Contains("good afternoon"))
            {
                return greetingResponses["afternoon"][random.Next(greetingResponses["afternoon"].Count)];
            }
            else if (input.Contains("good evening"))
            {
                return greetingResponses["evening"][random.Next(greetingResponses["evening"].Count)];
            }
            else if (input.Contains("how are you") || input.Contains("how are things"))
            {
                return greetingResponses["how are you"][random.Next(greetingResponses["how are you"].Count)];
            }
            else if (input.Contains("whats up") || input.Contains("what's up"))
            {
                return greetingResponses["whats up"][random.Next(greetingResponses["whats up"].Count)];
            }
            else
            {
                return greetingResponses["hello"][random.Next(greetingResponses["hello"].Count)];
            }
        }

        private static string GetFarewellResponse()
        {
            if (conversationHistory.Count == 0)
            {
                return farewellResponses["bye"][random.Next(farewellResponses["bye"].Count)];
            }

            string input = conversationHistory[conversationHistory.Count - 1].ToLower();

            if (input.Contains("exit"))
            {
                return farewellResponses["exit"][random.Next(farewellResponses["exit"].Count)];
            }
            else if (input.Contains("goodbye") || input.Contains("bye") || input.Contains("farewell"))
            {
                return farewellResponses["goodbye"][random.Next(farewellResponses["goodbye"].Count)];
            }
            else
            {
                return farewellResponses["bye"][random.Next(farewellResponses["bye"].Count)];
            }
        }

        private static string GenerateResponse(string input)
        {
            string lowerInput = input.ToLower();

            // Check for help
            if (lowerInput.Contains("help") || lowerInput.Contains("what can you do") ||
                lowerInput.Contains("capabilities") || lowerInput.Contains("can you") ||
                lowerInput.Contains("how to use") || lowerInput.Contains("instructions"))
            {
                return GetHelpMessage();
            }

            // Check for questions about specific topics
            foreach (var keyword in responseKeywords)
            {
                if (lowerInput.Contains(keyword.Key))
                {
                    string topicId = keyword.Value;
                    if (topicId == "tips")
                    {
                        return GetGeneralTips();
                    }
                    else
                    {
                        int topicNumber;
                        if (int.TryParse(topicId, out topicNumber))
                        {
                            return GetTopicResponse(topicNumber);
                        }
                    }
                }
            }

            // If input contains a question but we don't have specific topic match
            if (lowerInput.Contains("?") || lowerInput.Contains("what") || lowerInput.Contains("how") ||
                lowerInput.Contains("why") || lowerInput.Contains("when") || lowerInput.Contains("where") ||
                lowerInput.Contains("who") || lowerInput.Contains("which") || lowerInput.Contains("can") ||
                lowerInput.Contains("does") || lowerInput.Contains("is") || lowerInput.Contains("are") ||
                lowerInput.Contains("do") || lowerInput.Contains("did") || lowerInput.Contains("will"))
            {
                return GetGeneralAnswer(input);
            }

            // Check for statements that might be seeking information
            if (lowerInput.Contains("tell me") || lowerInput.Contains("explain") ||
                lowerInput.Contains("describe") || lowerInput.Contains("define") ||
                lowerInput.Contains("what is") || lowerInput.Contains("how to"))
            {
                return GetGeneralAnswer(input);
            }

            // Default response
            return GetDefaultResponse();
        }

        private static string GetTopicResponse(int topicNumber)
        {
            string response = CyberAnswers.GetInteractiveResponse(topicNumber.ToString());

            string[] intros = {
                "Great question. Let me share what I know about this topic",
                "I am glad you asked about this. Here is what you should know",
                "That is an important topic. Here is my advice",
                "Let me explain this cybersecurity concept for you"
            };

            return $"{intros[random.Next(intros.Length)]}\n\n{response}";
        }

        private static string GetHelpMessage()
        {
            return @"I can help you with various cybersecurity topics

Password Security - How to create and manage strong passwords
Phishing Attacks - How to spot and avoid phishing scams
Multi-Factor Authentication - Adding extra layers of security
Social Engineering - Understanding psychological manipulation
Malware Protection - Defending against malicious software
Online Privacy - Protecting your personal information

You can ask me questions naturally, like
  How do I create a strong password
  What is phishing and how do I avoid it
  Tell me about 2FA
  How can I protect my privacy online

Type 'menu' to see all topics in a detailed format
Type 'exit' or 'goodbye' to end our conversation

What would you like to know more about";
        }

        private static string GetGeneralTips()
        {
            string[] tips = {
                @"Top 5 Cybersecurity Tips
1. Use unique, strong passwords for each account (12+ characters with mix of letters, numbers, symbols)
2. Enable 2FA/MFA on all accounts that support it
3. Keep your software and operating system updated
4. Think before you click - verify links and attachments
5. Use a VPN on public Wi-Fi networks

Remember: Cybersecurity is a habit, not a one-time action",

                @"Essential Security Practices
- Regular backups: Keep copies of important files offline
- Use a password manager to generate and store secure passwords
- Enable automatic updates on all your devices
- Use privacy-focused browsers and search engines
- Be skeptical of unsolicited requests for personal information

Your digital safety is in your hands",

                @"Cybersecurity Checklist
- Use 2FA everywhere possible
- Create unique passwords for each account
- Keep all software updated
- Think before clicking links
- Use antivirus/anti-malware software
- Backup important files regularly
- Monitor your accounts for suspicious activity
- Use a VPN on public networks

Stay vigilant, stay secure"
            };
            return tips[random.Next(tips.Length)];
        }

        private static string GetGeneralAnswer(string input)
        {
            // Try to provide a helpful response based on keywords in the question
            string[] securityTerms = { "security", "protect", "safe", "secure", "defense", "protection" };
            string[] commonTerms = { "cyber", "online", "internet", "digital", "computer", "network" };

            foreach (string term in securityTerms)
            {
                if (input.ToLower().Contains(term))
                {
                    return GetGeneralTips();
                }
            }

            foreach (string term in commonTerms)
            {
                if (input.ToLower().Contains(term))
                {
                    return @"Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks. 
These attacks are usually aimed at accessing, changing, or destroying sensitive information, 
extorting money from users, or interrupting normal business processes

Effective cybersecurity requires
- Strong passwords and authentication methods
- Regular software updates and patches
- Awareness of common threats like phishing and malware
- Good privacy practices online
- Regular backups of important data

Would you like to know more about any specific aspect of cybersecurity";
                }
            }

            // Generic response for other questions
            return @"That is a great question. While I specialize in cybersecurity topics, 
I can tell you that staying safe online involves multiple layers of protection

Some key areas to focus on include
- Creating strong, unique passwords for each account
- Being aware of phishing attempts and suspicious emails
- Keeping your software and devices updated
- Using multi-factor authentication when available
- Being cautious about what personal information you share online

Is there a specific cybersecurity topic you would like to learn more about";
        }

        private static string GetDefaultResponse()
        {
            string[] defaults = {
                "I am not sure about that. Could you rephrase your question. I am here to help with cybersecurity topics like passwords, phishing, and online safety",
                "That is an interesting question. I specialize in cybersecurity awareness. Try asking me about passwords, phishing, 2FA, malware, or privacy",
                "I did not quite understand that. Feel free to ask me about specific cybersecurity topics, or type 'help' to see what I can do",
                "I am still learning. Could you ask your question differently. I am great at answering cybersecurity-related questions",
                "I am not sure I fully understand. Try asking something like 'How do I create a strong password' or 'What is phishing'",
                "Could you please clarify your question. I am here to help with cybersecurity topics",
                "I want to help you, but I need a bit more context. Are you asking about passwords, phishing, malware, or something else"
            };
            return defaults[random.Next(defaults.Length)];
        }

        private static void ShowTopicMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================================================");
            Console.WriteLine("  CYBERSECURITY TOPICS MENU");
            Console.WriteLine("========================================================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  --------------------------------------------------------------");
            Console.WriteLine("  |                                                            |");
            Console.WriteLine("  |  Password Security                                        |");
            Console.WriteLine("  |  Phishing Attacks                                        |");
            Console.WriteLine("  |  Multi-Factor Authentication                              |");
            Console.WriteLine("  |  Social Engineering                                      |");
            Console.WriteLine("  |  Malware Protection                                      |");
            Console.WriteLine("  |  Online Privacy                                          |");
            Console.WriteLine("  |                                                            |");
            Console.WriteLine("  --------------------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nJust ask me about any topic naturally");
            Console.WriteLine("For example: 'Tell me about phishing' or 'How do I create a strong password'");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Press any key to continue chatting...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void TypeWriter(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(6);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void Goodbye()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================================================");
            Console.WriteLine("  GOODBYE");
            Console.WriteLine("========================================================================");
            Console.ResetColor();

            string farewell = GetFarewellResponse();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  {farewell}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Stay safe. Stay secure. Stay vigilant");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  Keep learning about cybersecurity");
            Console.WriteLine("  Knowledge is your best defense");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Press any key to exit...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}