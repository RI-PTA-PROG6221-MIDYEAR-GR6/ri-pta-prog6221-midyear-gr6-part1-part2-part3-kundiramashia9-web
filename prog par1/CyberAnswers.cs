using System;

namespace CyberGuardBot
{
    public static class CyberAnswers
    {
        public static void GetResponse(string choice)
        {
            Console.Clear();

            // Header
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('═', 70));
            Console.WriteLine("  📚  CYBERSECURITY KNOWLEDGE BASE");
            Console.WriteLine(new string('═', 70));
            Console.ResetColor();

            switch (choice)
            {
                case "1":
                    DisplayTopic(
                        "🔐 PASSWORD SECURITY",
                        ConsoleColor.Green,
                        new string[] {
                            "Password security is the practice of creating and managing",
                            "strong passwords to protect your digital identity and accounts."
                        },
                        new string[] {
                            "✓ Use 12+ character passwords with mixed characters",
                            "✓ Never reuse passwords across different websites",
                            "✓ Enable Two-Factor Authentication (2FA) whenever possible",
                            "✓ Use a reputable password manager",
                            "✓ Change passwords if you suspect a breach"
                        },
                        new string[] {
                            "✗ Using personal info like birthdays or pet names",
                            "✗ Writing passwords on sticky notes",
                            "✗ Sharing passwords with others",
                            "✗ Using common passwords like '123456' or 'password'"
                        }
                    );
                    break;

                case "2":
                    DisplayTopic(
                        "🎣 PHISHING ATTACKS",
                        ConsoleColor.Red,
                        new string[] {
                            "Phishing is a cybercrime where attackers trick you into",
                            "revealing sensitive information through fake communications."
                        },
                        new string[] {
                            "✓ Check sender email addresses carefully",
                            "✓ Hover over links before clicking to see the real URL",
                            "✓ Look for spelling and grammar errors",
                            "✓ Be suspicious of urgent or threatening language",
                            "✓ Verify requests through official channels"
                        },
                        new string[] {
                            "✗ Clicking on links in suspicious emails",
                            "✗ Downloading attachments from unknown senders",
                            "✗ Entering credentials on unverified websites",
                            "✗ Responding to requests for personal information"
                        }
                    );
                    break;

                case "3":
                    DisplayTopic(
                        "🔑 MULTI-FACTOR AUTHENTICATION",
                        ConsoleColor.Cyan,
                        new string[] {
                            "MFA adds extra layers of security by requiring multiple",
                            "verification methods to access your accounts."
                        },
                        new string[] {
                            "✓ Enable MFA on all accounts that support it",
                            "✓ Use authenticator apps instead of SMS when possible",
                            "✓ Store backup codes in a secure location",
                            "✓ Use biometrics (fingerprint/face) when available",
                            "✓ Review active sessions regularly"
                        },
                        new string[] {
                            "✗ Using SMS verification as your only MFA method",
                            "✗ Sharing verification codes with others",
                            "✗ Ignoring MFA setup prompts",
                            "✗ Using the same verification method everywhere"
                        }
                    );
                    break;

                case "4":
                    DisplayTopic(
                        "🧠 SOCIAL ENGINEERING",
                        ConsoleColor.Magenta,
                        new string[] {
                            "Social engineering manipulates human psychology to",
                            "gain unauthorized access to information or systems."
                        },
                        new string[] {
                            "✓ Verify the identity of anyone requesting information",
                            "✓ Be skeptical of unsolicited requests",
                            "✓ Follow security protocols and procedures",
                            "✓ Report suspicious behavior immediately",
                            "✓ Use the 'trust but verify' approach"
                        },
                        new string[] {
                            "✗ Sharing information without verifying identity",
                            "✗ Letting strangers follow you into secure areas",
                            "✗ Falling for emotional manipulation tactics",
                            "✗ Bypassing security protocols for convenience"
                        }
                    );
                    break;

                case "5":
                    DisplayTopic(
                        "🦠 MALWARE PROTECTION",
                        ConsoleColor.DarkRed,
                        new string[] {
                            "Malware is malicious software designed to damage or",
                            "gain unauthorized access to your computer system."
                        },
                        new string[] {
                            "✓ Install reliable antivirus/anti-malware software",
                            "✓ Keep your operating system and apps updated",
                            "✓ Download software only from official sources",
                            "✓ Be cautious with email attachments and links",
                            "✓ Regular backup important files"
                        },
                        new string[] {
                            "✗ Ignoring software update notifications",
                            "✗ Downloading pirated or cracked software",
                            "✗ Disabling your antivirus protection",
                            "✗ Opening suspicious email attachments"
                        }
                    );
                    break;

                case "6":
                    DisplayTopic(
                        "🛡️ ONLINE PRIVACY",
                        ConsoleColor.Blue,
                        new string[] {
                            "Online privacy involves controlling what personal",
                            "information you share and who can access it."
                        },
                        new string[] {
                            "✓ Review privacy settings on all social media",
                            "✓ Use VPNs on public Wi-Fi networks",
                            "✓ Be mindful of what you share online",
                            "✓ Use privacy-focused browsers and search engines",
                            "✓ Regularly clear cookies and browsing history"
                        },
                        new string[] {
                            "✗ Oversharing personal information publicly",
                            "✗ Using the same password across multiple sites",
                            "✗ Accepting all cookies without review",
                            "✗ Using public Wi-Fi without protection"
                        }
                    );
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  ❌ Invalid selection. Please try again.");
                    Console.ResetColor();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n" + new string('─', 70));
            Console.WriteLine("  Press any key to return to the menu...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void DisplayTopic(string title, ConsoleColor color, string[] description, string[] dos, string[] donts)
        {
            // Title
            Console.ForegroundColor = color;
            Console.WriteLine($"\n  {title}");
            Console.WriteLine(new string('─', 70));
            Console.ResetColor();

            // Description
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n  📖 OVERVIEW");
            Console.ResetColor();
            foreach (string line in description)
            {
                Console.WriteLine($"     {line}");
            }

            // Do's
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  ✅ BEST PRACTICES");
            Console.ResetColor();
            foreach (string item in dos)
            {
                Console.WriteLine($"     {item}");
            }

            // Don'ts
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  ❌ COMMON MISTAKES");
            Console.ResetColor();
            foreach (string item in donts)
            {
                Console.WriteLine($"     {item}");
            }

            Console.WriteLine();
        }
    }
}