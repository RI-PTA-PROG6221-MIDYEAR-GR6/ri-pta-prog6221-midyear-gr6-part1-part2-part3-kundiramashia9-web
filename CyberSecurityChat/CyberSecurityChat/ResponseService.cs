using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CyberSecurityChat.Models;

namespace CyberSecurityChat.Services
{
    public class ResponseService
    {
        private readonly List<ChatResponse> _responses;
        private readonly Random _random = new Random();
        private readonly Dictionary<string, string> _contextMemory = new Dictionary<string, string>();
        private string _lastTopic = "General";
        private int _conversationDepth = 0;

        // Advanced synonym mapping
        private readonly Dictionary<string, string[]> _synonymMap = new Dictionary<string, string[]>
        {
            { "password", new[] { "passcode", "pin", "secret", "key", "code" } },
            { "phishing", new[] { "scam", "fraud", "spam", "trick", "deception" } },
            { "secure", new[] { "safe", "protect", "guard", "shield", "defend" } },
            { "hacker", new[] { "attacker", "intruder", "cracker", "threat" } },
            { "virus", new[] { "malware", "trojan", "worm", "ransomware" } },
            { "browser", new[] { "chrome", "firefox", "edge", "safari", "explorer" } },
            { "email", new[] { "message", "mail", "correspondence" } },
            { "data", new[] { "information", "details", "records", "files" } },
            { "privacy", new[] { "confidentiality", "secrecy", "protection" } },
            { "2fa", new[] { "two factor", "multi factor", "mfa", "2 step" } }
        };

        public ResponseService()
        {
            _responses = InitializeAdvancedResponses();
        }

        private List<ChatResponse> InitializeAdvancedResponses()
        {
            return new List<ChatResponse>
            {
                // ============ GREETINGS AND CONVERSATION ============
                new ChatResponse
                {
                    Keywords = new[] { "how are you", "how are u", "how're you", "how you doing" },
                    Synonyms = new[] { "whats up", "sup", "how goes it", "how's it going" },
                    Responses = new[]
                    {
                        "I'm absolutely fantastic! Just helped someone create an unbreakable password! 🔐",
                        "Better than a firewall on payday! How can I help you today? 😊",
                        "Ready to defeat some cyber villains! What's on your mind? 🦸‍♂️",
                        "Full of digital energy! Got any security questions for me? ⚡"
                    },
                    Category = "Greeting",
                    Emoji = "😊",
                    FollowUpQuestions = new[] { "What can you help me with?", "Tell me about security" },
                    RelatedTopics = new Dictionary<string, string[]>
                    {
                        { "next", new[] { "purpose", "capabilities" } }
                    }
                },
                new ChatResponse
                {
                    Keywords = new[] { "purpose", "what do you do", "what can you do" },
                    Synonyms = new[] { "who are you", "what are you", "your role", "your job" },
                    Responses = new[]
                    {
                        "I'm like a digital superhero that teaches cybersecurity in a fun way! 🌟\n\nI can help with:\n• 🔐 Password protection\n• 🎣 Phishing detection\n• 🌐 Safe browsing\n• 🔒 Data privacy\n• 🛡️ General security\n• 😂 Jokes and facts!\n\nWhat would you like to learn about?",
                        "I'm your personal cybersecurity coach with a sense of humor! 🚀\n\nThink of me as:\n• Security teacher\n• Safety advisor\n• Digital guardian\n• Fun fact generator\n\nReady to learn something cool? 💪",
                        "I'm here to make cybersecurity fun and easy! 📚\n\nMy specialties:\n• Breaking down complex security topics\n• Making you laugh while learning\n• Keeping you safe online\n• Sharing awesome facts\n\nLet's get started! 🎯"
                    },
                    Category = "Purpose",
                    Emoji = "🎯",
                    FollowUpQuestions = new[] { "Tell me about password safety", "What is phishing?" },
                    RelatedTopics = new Dictionary<string, string[]>
                    {
                        { "next", new[] { "password", "phishing", "browsing" } }
                    }
                },

                // ============ PASSWORD SAFETY (Advanced) ============
                new ChatResponse
                {
                    Keywords = new[] { "password", "passwords", "strong password", "create password" },
                    Synonyms = new[] { "passcode", "secret", "key", "pin", "login code" },
                    Responses = new[]
                    {
                        "🔐 PASSWORD POWER LEVELS:\n\nLevel 1 (Weak): 'password123' ❌\nLevel 5 (Medium): 'P@ssw0rd!' ⚠️\nLevel 10 (Strong): 'C0mpl3x!S3cur3P@ss' ✅\n\n💡 Pro Tips:\n• 12+ characters minimum\n• Mix: A-Z, a-z, 0-9, symbols\n• Use phrases: 'I love sushi 3 times a week!' = 'IL0v3Sush!3x'\n• Unique password for each account\n• Password managers = Your best friend!\n\nWant to test a password idea? 🧪",
                        "🎮 PASSWORD CREATION GAME:\n\nStep 1: Pick 3 random words\nExample: 'Tiger', 'Pizza', 'Galaxy'\n\nStep 2: Add numbers and symbols\nTigerPizzaGalaxy → T1g3rP1zz4G@laxy!\n\nStep 3: Make it memorable!\n'My cat ate pizza in 2024!'\n'MyC@tAt3P1zz4In2024!'\n\nTry creating your own! 💪",
                        "🔑 THE SECRET TO STRONG PASSWORDS:\n\nThink of a sentence you'll remember:\n'My dog Sparky loves eating bacon!' → 'Myd0gSp@rkyL0vesB@c0n!'\n\n⚡ Pro moves:\n• Don't use birthdays (too easy!)\n• Don't use dictionary words (hackers have those!)\n• Use 2FA for extra protection\n• Change important passwords every 3 months\n\nYou're now a password expert! 🏆"
                    },
                    Category = "Password Safety",
                    Emoji = "🔐",
                    FollowUpQuestions = new[] { "What is 2FA?", "Tell me about password managers" },
                    RelatedTopics = new Dictionary<string, string[]>
                    {
                        { "next", new[] { "2fa", "security", "password manager" } },
                        { "tools", new[] { "password manager", "2fa" } }
                    }
                },
                new ChatResponse
                {
                    Keywords = new[] { "2fa", "two factor", "multi factor", "mfa" },
                    Synonyms = new[] { "2 step", "double authentication", "two-step" },
                    Responses = new[]
                    {
                        "🔑 2FA = SUPERHERO MODE for your accounts!\n\nWhat it does:\n• Asks for password + something you have\n• Your phone (SMS or authenticator app)\n• Your fingerprint or face\n• A physical security key\n\nWhy use it?\n• 99.9% more secure\n• Hackers hate it!\n• Even if they steal your password, they can't get in\n\n🚀 Fun fact: 2FA stops 99% of account takeovers!\n\nEnable it everywhere! 💪",
                        "🎯 2FA EXPLAINED WITH PIZZA:\n\nRegular Login = Ordering pizza with just a name 🍕\n2FA = Ordering pizza with name AND ID verification 🛡️\n\nTypes of 2FA:\n1. SMS codes (okay, but not the best)\n2. Authenticator apps (better! Google Authenticator, Authy)\n3. Physical keys (best! YubiKey)\n\nPro tip: Always choose authenticator app over SMS! ⚡"
                    },
                    Category = "Password Safety",
                    Emoji = "🔑",
                    FollowUpQuestions = new[] { "How to set up 2FA?", "What's the best 2FA app?" }
                },

                // ============ PHISHING (Advanced) ============
                new ChatResponse
                {
                    Keywords = new[] { "phishing", "scam", "fraud", "fake email", "spam" },
                    Synonyms = new[] { "trick", "deception", "con", "fake", "malicious" },
                    Responses = new[]
                    {
                        "🎣 PHISHING DETECTIVE TRAINING:\n\nCase #1: The Urgent Email\n'Your account will be closed in 24 hours!'\n\nRed Flags:\n❌ Creates panic\n❌ Asks for personal info\n❌ Suspicious sender email\n❌ Bad grammar\n\nVerdict: PHISHING! 🎣\n\nAlways verify by calling the company directly! 📞",
                        "🕵️ SPOT THE PHISHER GAME:\n\nWhich is real?\nA) 'Your bank needs your password immediately'\nB) 'Your bank needs you to call their official number'\n\nAnswer: B! Banks NEVER ask for passwords via email\n\n🔍 Warning Signs:\n• 'Verify your account' (real companies don't ask!)\n• 'Click here to confirm' (dangerous!)\n• 'You won a prize' (if it's too good to be true...)\n• Spelling mistakes (phishers aren't great writers!)\n\nYou're now a phishing detective! 🏆",
                        "🚨 PHISHING RED FLAGS (HACKERS HATE THESE TIPS!):\n\nAlways check:\n1. Email sender address (does it look legit?)\n2. Hover over links (where do they REALLY go?)\n3. Urgency (phishers rush you!)\n4. Personal info requests (BIG RED FLAG!)\n\n💡 Pro tip: When in doubt, throw it out!\n\nIf a link looks suspicious, don't click it!\nOpen a new browser and type the address yourself."
                    },
                    Category = "Phishing",
                    Emoji = "🎣",
                    FollowUpQuestions = new[] { "What do I do if I get a phishing email?", "How to report phishing?" }
                },

                // ============ SAFE BROWSING (Advanced) ============
                new ChatResponse
                {
                    Keywords = new[] { "browsing", "browse", "internet", "website", "safe browsing" },
                    Synonyms = new[] { "surfing", "web", "online", "net", "searching" },
                    Responses = new[]
                    {
                        "🌐 INTERNET SAFETY MAP:\n\n🌳 SAFE ZONES:\n• Sites with HTTPS (padlock icon)\n• Well-known websites\n• Official app stores\n\n⚠️ CAUTION ZONES:\n• Pop-up ads\n• 'Free downloads'\n• Pirated content sites\n\n🚫 DANGER ZONES:\n• Sites asking for personal info\n• Suspicious redirects\n• Too-good-to-be-true offers\n\nStay in the safe zones! 🗺️",
                        "🛡️ BROWSER SHIELD ACTIVATED:\n\nEssential Tools:\n1. AdBlocker (blocks annoying pop-ups)\n2. Privacy Extension (no tracking)\n3. HTTPS Everywhere (forces secure connections)\n\n🔒 Security Settings:\n• Enable 'Do Not Track'\n• Clear cookies regularly\n• Use incognito for sensitive stuff\n• Use a VPN on public Wi-Fi\n\n💪 You're now a browsing ninja!",
                        "📱 PUBLIC WI-FI SURVIVAL GUIDE:\n\nDO:\n• Use a VPN (your secret tunnel!)\n• Stick to HTTPS sites\n• Use 2FA for important stuff\n\nDON'T:\n• Access bank accounts\n• Enter passwords\n• Share personal info\n\nRemember: Public Wi-Fi is like talking loudly in a crowded room - everyone can hear! 🤫"
                    },
                    Category = "Safe Browsing",
                    Emoji = "🌐",
                    FollowUpQuestions = new[] { "What VPN should I use?", "How to protect my privacy?" }
                },

                // ============ FUN AND ENGAGEMENT ============
                new ChatResponse
                {
                    Keywords = new[] { "joke", "funny", "laugh", "humor" },
                    Synonyms = new[] { "comedy", "amuse", "entertain" },
                    Responses = new[]
                    {
                        "😂 Why did the hacker go to therapy?\n\nBecause he had too many issues! 🐛\n\nWant another one? 😄",
                        "🤖 What's a computer's favorite snack?\n\nMicrochips! 🍟\n\n...I'll see myself out 😅",
                        "👨‍💻 Why do programmers prefer dark mode?\n\nBecause light attracts bugs! 🐛\n\nThat's how I roll! 😎",
                        "🔐 What did the password say to the hacker?\n\n'You shall not pass!' 🧙‍♂️\n\nSecurity is magic! ✨",
                        "💻 Why was the computer cold?\n\nIt left its Windows open! 🪟\n\nGet it? Windows? ...I'll stop now 😄"
                    },
                    Category = "Fun",
                    Emoji = "😂",
                    FollowUpQuestions = new[] { "Tell me another joke!", "Give me a fun fact!" }
                },
                new ChatResponse
                {
                    Keywords = new[] { "fact", "trivia", "interesting", "did you know" },
                    Synonyms = new[] { "info", "knowledge", "learn", "cool" },
                    Responses = new[]
                    {
                        "💡 Did you know?\n\nThe first computer virus was created in 1971 and was called 'Creeper'! It showed the message: 'I'm the creeper, catch me if you can!' 🦠\n\nNow that's a dedicated hacker! 😄",
                        "🤯 MIND-BLOWING FACT:\n\nThe most common password in 2024 is still '123456'! \n\nThat's like using 'OPEN SESAME' as your bank PIN! 😅\n\nBe smarter than 123456! 💪",
                        "📊 SHOCKING STAT:\n\n81% of data breaches happen due to weak passwords!\n\nA strong password is like a superhero cape - it saves you! 🦸‍♂️",
                        "🕰️ HISTORY LESSON:\n\nThe first password ever used was 'OPEN SESAME' in the story of Ali Baba!\n\nFrom sesame to cybersecurity - we've come a long way! 🏺",
                        "🔒 INTERESTING FACT:\n\nThe average person has over 100 passwords to remember!\n\nThat's why password managers exist - they're like a digital vault! 🏦"
                    },
                    Category = "Fun",
                    Emoji = "💡",
                    FollowUpQuestions = new[] { "More facts!", "Tell me a joke instead" }
                },

                // ============ ADVANCED SECURITY ============
                new ChatResponse
                {
                    Keywords = new[] { "hacker", "hack", "attack", "breach", "compromise" },
                    Synonyms = new[] { "threat", "intruder", "villain", "malicious" },
                    Responses = new[]
                    {
                        "🛡️ UNDERSTANDING HACKERS:\n\nTypes of Hackers:\n👿 Black Hat = Bad guys (break into systems)\n😇 White Hat = Good guys (find vulnerabilities)\n🤔 Grey Hat = In-between (sometimes legal, sometimes not)\n\n💪 How to Defend:\n• Update software (hackers hate updates!)\n• Use strong passwords\n• Enable 2FA\n• Be skeptical of everything!\n\nRemember: The best defense is YOU! 🌟",
                        "🎯 COMMON ATTACK METHODS:\n\n1. Phishing (fake emails)\n2. Password cracking (guessing passwords)\n3. Malware (evil software)\n4. Man-in-the-middle (intercepting data)\n\n🚀 Your Defense:\n• Think before you click\n• Use 2FA everywhere\n• Keep software updated\n• Use antivirus\n\nYou're now a security warrior! ⚔️"
                    },
                    Category = "Advanced Security",
                    Emoji = "🛡️",
                    FollowUpQuestions = new[] { "What is ethical hacking?", "How to report a hack?" }
                },

                // ============ PRIVACY (Advanced) ============
                new ChatResponse
                {
                    Keywords = new[] { "privacy", "data", "personal information", "tracking" },
                    Synonyms = new[] { "info", "details", "identity", "records" },
                    Responses = new[]
                    {
                        "🔒 PRIVACY CHECKLIST:\n\n☑️ Social Media:\n• Limit what you share\n• Check privacy settings\n• Be careful with location sharing\n\n☑️ Online Shopping:\n• Use secure payment methods\n• Don't save card details\n• Check merchant reputation\n\n☑️ General:\n• Use encrypted messaging\n• Clear browsing data\n• Use a VPN\n\nYour data = YOUR power! 💪",
                        "🕵️ YOUR DIGITAL FOOTPRINT:\n\nEverything you do online leaves a trace:\n• Websites you visit\n• Things you search\n• What you share\n\n💡 Tips to Reduce Your Footprint:\n• Use private browsing\n• Delete old accounts\n• Limit social media sharing\n• Use disposable email addresses\n\nBe a ghost online! 👻"
                    },
                    Category = "Privacy",
                    Emoji = "🔒",
                    FollowUpQuestions = new[] { "What is a VPN?", "How to clear browsing data?" }
                },

                // ============ SOCIAL ENGINEERING ============
                new ChatResponse
                {
                    Keywords = new[] { "social engineering", "manipulation", "trick", "persuade" },
                    Synonyms = new[] { "psychological", "social attack", "human hacking" },
                    Responses = new[]
                    {
                        "🧠 SOCIAL ENGINEERING EXPLAINED:\n\nIt's NOT about technology - it's about PEOPLE!\n\nCommon Tricks:\n• Pretending to be IT support\n• Creating fake emergencies\n• Building false trust\n\n🛡️ Defense Strategy:\n• Always verify identities\n• Don't rush (hackers create urgency!)\n• Trust but VERIFY\n\nRemember: The weakest link in security is often humans - but YOU can be the strongest link! 💪",
                        "🎭 SOCIAL ENGINEERING DETECTION:\n\nReal Example:\n'This is IT support. We need your password urgently to fix a system issue.'\n\n🚨 RED FLAGS:\n• Unsolicited call/email\n• Asks for password\n• Creates urgency\n\n✅ CORRECT RESPONSE:\n'I'll call the IT department directly to verify this.'\n\nYou just dodged a social engineering attack! 🏆"
                    },
                    Category = "Social Engineering",
                    Emoji = "🧠",
                    FollowUpQuestions = new[] { "What is spear phishing?", "Tell me about baiting attacks" }
                }
            };
        }

        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return null;

            _conversationDepth++;
            var lowerInput = userInput.ToLower().Trim();

            // Check for exit
            if (IsExitCommand(lowerInput))
                return "EXIT";

            // Check for gratitude
            if (IsGratitude(lowerInput))
                return GetGratitudeResponse();

            // Expanded synonym matching
            string expandedInput = ExpandWithSynonyms(lowerInput);

            // Check for context-based responses
            if (_conversationDepth > 3 && _lastTopic != "General")
            {
                string contextResponse = GetContextResponse(expandedInput);
                if (contextResponse != null)
                    return contextResponse;
            }

            // Find best matching response
            var matchedResponse = FindBestMatch(expandedInput);

            if (matchedResponse != null)
            {
                _lastTopic = matchedResponse.Category;

                // Add follow-up question occasionally
                if (_random.Next(3) == 0 && matchedResponse.FollowUpQuestions != null && matchedResponse.FollowUpQuestions.Length > 0)
                {
                    string response = GetRandomResponse(matchedResponse.Responses);
                    string followUp = matchedResponse.FollowUpQuestions[_random.Next(matchedResponse.FollowUpQuestions.Length)];
                    return response + "\n\n💡 Follow-up question: " + followUp;
                }

                return GetRandomResponse(matchedResponse.Responses);
            }

            // Advanced fallback with personality
            return GetFallbackResponse();
        }

        private string ExpandWithSynonyms(string input)
        {
            string expanded = input;
            foreach (var kvp in _synonymMap)
            {
                foreach (var synonym in kvp.Value)
                {
                    if (input.Contains(synonym))
                    {
                        expanded = expanded.Replace(synonym, kvp.Key);
                    }
                }
            }
            return expanded;
        }

        private ChatResponse FindBestMatch(string input)
        {
            // Score-based matching
            var scoredResponses = _responses.Select(r => new
            {
                Response = r,
                Score = r.Keywords.Count(k => input.Contains(k.ToLower())) * 2 +
                        (r.Synonyms != null ? r.Synonyms.Count(s => input.Contains(s.ToLower())) : 0)
            })
            .Where(r => r.Score > 0)
            .OrderByDescending(r => r.Score)
            .ToList();

            if (scoredResponses.Any())
            {
                // If multiple matches, take the best one
                var best = scoredResponses.First();
                if (best.Score >= 2)
                    return best.Response;
            }

            // Check for partial matches
            foreach (var response in _responses)
            {
                if (response.Keywords.Any(k => input.Contains(k) || k.Contains(input) || input.Contains(k)))
                    return response;

                if (response.Synonyms != null && response.Synonyms.Any(s => input.Contains(s)))
                    return response;
            }

            return null;
        }

        private string GetContextResponse(string input)
        {
            // Check if asking about related topics
            foreach (var response in _responses)
            {
                if (response.RelatedTopics != null && response.RelatedTopics.ContainsKey("next"))
                {
                    foreach (var keyword in response.RelatedTopics["next"])
                    {
                        if (input.Contains(keyword))
                            return GetResponse($"tell me about {keyword}");
                    }
                }
            }
            return null;
        }

        private string GetRandomResponse(string[] responses)
        {
            return responses[_random.Next(responses.Length)];
        }

        private bool IsExitCommand(string input)
        {
            string[] exitCommands = { "exit", "quit", "bye", "goodbye", "see you", "later", "cya", "ttyl" };
            return exitCommands.Any(cmd => input.Contains(cmd));
        }

        private bool IsGratitude(string input)
        {
            string[] gratitude = { "thank", "thanks", "thx", "appreciate", "grateful" };
            return gratitude.Any(g => input.Contains(g));
        }

        private string GetGratitudeResponse()
        {
            string[] responses = {
                "You're welcome! Remember, knowledge is power! 💪",
                "My pleasure! Stay safe and keep learning! 🌟",
                "Anytime! You're doing great! 🚀",
                "You're awesome for caring about cybersecurity! 🎉",
                "Glad to help! Together we make the internet safer! 🤝"
            };
            return responses[_random.Next(responses.Length)];
        }

        private string GetFallbackResponse()
        {
            _conversationDepth = 0; // Reset context depth

            string[] fallbacks = {
                "🤔 That's a new one! I'm still learning, but I know a LOT about cybersecurity.\n\nTry asking me about:\n• Password safety\n• Phishing scams\n• Safe browsing\n• Data privacy\n• Fun facts!\n\nWhat catches your interest? 💡",
                "😅 I don't know everything (yet!), but I'm great at cybersecurity topics!\n\nHere are some things I can help with:\n🔐 Creating strong passwords\n🎣 Spotting phishing emails\n🌐 Browsing safely\n🔒 Protecting your privacy\n\nPick one and let's dive in! 🚀",
                "📚 Let me share what I know best - cybersecurity!\n\nYou can ask me:\n• 'How do I create a strong password?'\n• 'What is phishing?'\n• 'How to browse safely?'\n• 'Tell me a joke!'\n\nWhat would you like to explore? 🎯"
            };
            return fallbacks[_random.Next(fallbacks.Length)];
        }

        public string GetCategory(string userInput)
        {
            var lowerInput = userInput.ToLower().Trim();
            var expandedInput = ExpandWithSynonyms(lowerInput);
            var matched = FindBestMatch(expandedInput);
            return matched?.Category ?? "General";
        }

        public string GetEmojiForCategory(string category)
        {
            switch (category)
            {
                case "Password Safety": return "🔐";
                case "Phishing": return "🎣";
                case "Safe Browsing": return "🌐";
                case "General Security": return "🛡️";
                case "Privacy": return "🔒";
                case "Greeting": return "😊";
                case "Purpose": return "🎯";
                case "Fun": return "😂";
                case "Advanced Security": return "🛡️";
                case "Social Engineering": return "🧠";
                default: return "💡";
            }
        }
    }
}