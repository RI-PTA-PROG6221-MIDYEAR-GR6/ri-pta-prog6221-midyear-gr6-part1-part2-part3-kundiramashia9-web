using System;
using System.Text;

namespace ChatbotBot
{
    public static class CyberAnswers
    {
        public static void GetResponse(string choice)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('=', 70));
            Console.WriteLine("  CYBERSECURITY KNOWLEDGE BASE");
            Console.WriteLine(new string('=', 70));
            Console.ResetColor();

            switch (choice)
            {
                case "1":
                    DisplayTopic(
                        "PASSWORD SECURITY",
                        ConsoleColor.Green,
                        new string[] {
                            "Password security is the practice of creating and managing",
                            "strong passwords to protect your digital identity and accounts"
                        },
                        new string[] {
                            "Use 12+ character passwords with mixed characters",
                            "Never reuse passwords across different websites",
                            "Enable Two-Factor Authentication (2FA) whenever possible",
                            "Use a reputable password manager",
                            "Change passwords if you suspect a breach"
                        },
                        new string[] {
                            "Using personal info like birthdays or pet names",
                            "Writing passwords on sticky notes",
                            "Sharing passwords with others",
                            "Using common passwords like '123456' or 'password'"
                        }
                    );
                    break;

                case "2":
                    DisplayTopic(
                        "PHISHING ATTACKS",
                        ConsoleColor.Red,
                        new string[] {
                            "Phishing is a cybercrime where attackers trick you into",
                            "revealing sensitive information through fake communications"
                        },
                        new string[] {
                            "Check sender email addresses carefully",
                            "Hover over links before clicking to see the real URL",
                            "Look for spelling and grammar errors",
                            "Be suspicious of urgent or threatening language",
                            "Verify requests through official channels"
                        },
                        new string[] {
                            "Clicking on links in suspicious emails",
                            "Downloading attachments from unknown senders",
                            "Entering credentials on unverified websites",
                            "Responding to requests for personal information"
                        }
                    );
                    break;

                case "3":
                    DisplayTopic(
                        "MULTI-FACTOR AUTHENTICATION",
                        ConsoleColor.Cyan,
                        new string[] {
                            "MFA adds extra layers of security by requiring multiple",
                            "verification methods to access your accounts"
                        },
                        new string[] {
                            "Enable MFA on all accounts that support it",
                            "Use authenticator apps instead of SMS when possible",
                            "Store backup codes in a secure location",
                            "Use biometrics (fingerprint/face) when available",
                            "Review active sessions regularly"
                        },
                        new string[] {
                            "Using SMS verification as your only MFA method",
                            "Sharing verification codes with others",
                            "Ignoring MFA setup prompts",
                            "Using the same verification method everywhere"
                        }
                    );
                    break;

                case "4":
                    DisplayTopic(
                        "SOCIAL ENGINEERING",
                        ConsoleColor.Magenta,
                        new string[] {
                            "Social engineering manipulates human psychology to",
                            "gain unauthorized access to information or systems"
                        },
                        new string[] {
                            "Verify the identity of anyone requesting information",
                            "Be skeptical of unsolicited requests",
                            "Follow security protocols and procedures",
                            "Report suspicious behavior immediately",
                            "Use the 'trust but verify' approach"
                        },
                        new string[] {
                            "Sharing information without verifying identity",
                            "Letting strangers follow you into secure areas",
                            "Falling for emotional manipulation tactics",
                            "Bypassing security protocols for convenience"
                        }
                    );
                    break;

                case "5":
                    DisplayTopic(
                        "MALWARE PROTECTION",
                        ConsoleColor.DarkRed,
                        new string[] {
                            "Malware is malicious software designed to damage or",
                            "gain unauthorized access to your computer system"
                        },
                        new string[] {
                            "Install reliable antivirus/anti-malware software",
                            "Keep your operating system and apps updated",
                            "Download software only from official sources",
                            "Be cautious with email attachments and links",
                            "Regular backup important files"
                        },
                        new string[] {
                            "Ignoring software update notifications",
                            "Downloading pirated or cracked software",
                            "Disabling your antivirus protection",
                            "Opening suspicious email attachments"
                        }
                    );
                    break;

                case "6":
                    DisplayTopic(
                        "ONLINE PRIVACY",
                        ConsoleColor.Blue,
                        new string[] {
                            "Online privacy involves controlling what personal",
                            "information you share and who can access it"
                        },
                        new string[] {
                            "Review privacy settings on all social media",
                            "Use VPNs on public Wi-Fi networks",
                            "Be mindful of what you share online",
                            "Use privacy-focused browsers and search engines",
                            "Regularly clear cookies and browsing history"
                        },
                        new string[] {
                            "Oversharing personal information publicly",
                            "Using the same password across multiple sites",
                            "Accepting all cookies without review",
                            "Using public Wi-Fi without protection"
                        }
                    );
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  Invalid selection. Please try again");
                    Console.ResetColor();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n" + new string('-', 70));
            Console.WriteLine("Press any key to return to the menu...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static string GetInteractiveResponse(string choice)
        {
            var sb = new StringBuilder();

            switch (choice)
            {
                case "1":
                    sb.AppendLine("PASSWORD SECURITY");
                    sb.AppendLine("---------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("Creating and managing strong passwords is crucial for protecting your digital identity");
                    sb.AppendLine();
                    sb.AppendLine("Best Practices");
                    sb.AppendLine("  - Use 12+ character passwords with mixed letters, numbers, and symbols");
                    sb.AppendLine("  - Never reuse passwords across different websites");
                    sb.AppendLine("  - Enable Two-Factor Authentication (2FA) whenever possible");
                    sb.AppendLine("  - Use a reputable password manager");
                    sb.AppendLine("  - Change passwords if you suspect a breach");
                    sb.AppendLine();
                    sb.AppendLine("Common Mistakes");
                    sb.AppendLine("  - Using personal info like birthdays or pet names");
                    sb.AppendLine("  - Writing passwords on sticky notes");
                    sb.AppendLine("  - Sharing passwords with others");
                    sb.AppendLine("  - Using common passwords like '123456' or 'password'");
                    break;

                case "2":
                    sb.AppendLine("PHISHING ATTACKS");
                    sb.AppendLine("---------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("Phishing is a cybercrime where attackers trick you into revealing sensitive information");
                    sb.AppendLine();
                    sb.AppendLine("Best Practices");
                    sb.AppendLine("  - Check sender email addresses carefully");
                    sb.AppendLine("  - Hover over links before clicking to see the real URL");
                    sb.AppendLine("  - Look for spelling and grammar errors");
                    sb.AppendLine("  - Be suspicious of urgent or threatening language");
                    sb.AppendLine("  - Verify requests through official channels");
                    sb.AppendLine();
                    sb.AppendLine("Common Mistakes");
                    sb.AppendLine("  - Clicking on links in suspicious emails");
                    sb.AppendLine("  - Downloading attachments from unknown senders");
                    sb.AppendLine("  - Entering credentials on unverified websites");
                    sb.AppendLine("  - Responding to requests for personal information");
                    break;

                case "3":
                    sb.AppendLine("MULTI-FACTOR AUTHENTICATION");
                    sb.AppendLine("---------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("MFA adds extra layers of security by requiring multiple verification methods");
                    sb.AppendLine();
                    sb.AppendLine("Best Practices");
                    sb.AppendLine("  - Enable MFA on all accounts that support it");
                    sb.AppendLine("  - Use authenticator apps instead of SMS when possible");
                    sb.AppendLine("  - Store backup codes in a secure location");
                    sb.AppendLine("  - Use biometrics (fingerprint/face) when available");
                    sb.AppendLine("  - Review active sessions regularly");
                    sb.AppendLine();
                    sb.AppendLine("Common Mistakes");
                    sb.AppendLine("  - Using SMS verification as your only MFA method");
                    sb.AppendLine("  - Sharing verification codes with others");
                    sb.AppendLine("  - Ignoring MFA setup prompts");
                    sb.AppendLine("  - Using the same verification method everywhere");
                    break;

                case "4":
                    sb.AppendLine("SOCIAL ENGINEERING");
                    sb.AppendLine("---------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("Social engineering manipulates human psychology to gain unauthorized access");
                    sb.AppendLine();
                    sb.AppendLine("Best Practices");
                    sb.AppendLine("  - Verify the identity of anyone requesting information");
                    sb.AppendLine("  - Be skeptical of unsolicited requests");
                    sb.AppendLine("  - Follow security protocols and procedures");
                    sb.AppendLine("  - Report suspicious behavior immediately");
                    sb.AppendLine("  - Use the 'trust but verify' approach");
                    sb.AppendLine();
                    sb.AppendLine("Common Mistakes");
                    sb.AppendLine("  - Sharing information without verifying identity");
                    sb.AppendLine("  - Letting strangers follow you into secure areas");
                    sb.AppendLine("  - Falling for emotional manipulation tactics");
                    sb.AppendLine("  - Bypassing security protocols for convenience");
                    break;

                case "5":
                    sb.AppendLine("MALWARE PROTECTION");
                    sb.AppendLine("---------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("Malware is malicious software designed to damage or gain unauthorized access");
                    sb.AppendLine();
                    sb.AppendLine("Best Practices");
                    sb.AppendLine("  - Install reliable antivirus/anti-malware software");
                    sb.AppendLine("  - Keep your operating system and apps updated");
                    sb.AppendLine("  - Download software only from official sources");
                    sb.AppendLine("  - Be cautious with email attachments and links");
                    sb.AppendLine("  - Regular backup important files");
                    sb.AppendLine();
                    sb.AppendLine("Common Mistakes");
                    sb.AppendLine("  - Ignoring software update notifications");
                    sb.AppendLine("  - Downloading pirated or cracked software");
                    sb.AppendLine("  - Disabling your antivirus protection");
                    sb.AppendLine("  - Opening suspicious email attachments");
                    break;

                case "6":
                    sb.AppendLine("ONLINE PRIVACY");
                    sb.AppendLine("---------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("Online privacy involves controlling what personal information you share");
                    sb.AppendLine();
                    sb.AppendLine("Best Practices");
                    sb.AppendLine("  - Review privacy settings on all social media");
                    sb.AppendLine("  - Use VPNs on public Wi-Fi networks");
                    sb.AppendLine("  - Be mindful of what you share online");
                    sb.AppendLine("  - Use privacy-focused browsers and search engines");
                    sb.AppendLine("  - Regularly clear cookies and browsing history");
                    sb.AppendLine();
                    sb.AppendLine("Common Mistakes");
                    sb.AppendLine("  - Oversharing personal information publicly");
                    sb.AppendLine("  - Using the same password across multiple sites");
                    sb.AppendLine("  - Accepting all cookies without review");
                    sb.AppendLine("  - Using public Wi-Fi without protection");
                    break;

                default:
                    sb.AppendLine("I can help you with various cybersecurity topics");
                    sb.AppendLine("Please ask about passwords, phishing, 2FA, social engineering, malware, or privacy");
                    break;
            }

            return sb.ToString();
        }

        private static void DisplayTopic(string title, ConsoleColor color, string[] description, string[] dos, string[] donts)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n  {title}");
            Console.WriteLine(new string('-', 70));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n  OVERVIEW");
            Console.ResetColor();
            foreach (string line in description)
            {
                Console.WriteLine($"     {line}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  BEST PRACTICES");
            Console.ResetColor();
            foreach (string item in dos)
            {
                Console.WriteLine($"     {item}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  COMMON MISTAKES");
            Console.ResetColor();
            foreach (string item in donts)
            {
                Console.WriteLine($"     {item}");
            }

            Console.WriteLine();
        }
    }
}