using System;

namespace CyberSecurityChat.Services
{
    public class ChatService
    {
        private readonly ResponseService _responseService;
        private readonly UIService _uiService;
        private int _questionCount = 0;
        private string _lastQuestion = "";
        private string _userName = "";

        public ChatService()
        {
            _responseService = new ResponseService();
            _uiService = new UIService();
        }

        public string GetUserName()
        {
            _uiService.DisplaySeparator();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("🦸 What's your name? ");
            Console.ResetColor();

            _userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(_userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("😅 Even superheroes need names! Try again:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("🦸 Please enter your name: ");
                Console.ResetColor();
                _userName = Console.ReadLine();
            }

            string[] nicknames = { "Cyber Warrior", "Digital Ninja", "Security Star", "Tech Guardian", "Firewall Master" };
            Random rand = new Random();
            string nickname = nicknames[rand.Next(nicknames.Length)];

            _uiService.DisplayWelcomeMessage(_userName, nickname);
            _uiService.DisplayHelpSection();
            _uiService.DisplaySeparator();

            return _userName;
        }

        public void StartChat(string userName)
        {
            bool isRunning = true;
            Random rand = new Random();

            string[] welcomeResponses = {
                "I'm ready to answer ALL your cybersecurity questions! 🚀",
                "Unlimited knowledge on cybersecurity coming your way! 💪",
                "Ask me anything about staying safe online! 🦸‍♂️",
                "Your personal cybersecurity encyclopedia with jokes! 😉"
            };

            _uiService.DisplayResponse(welcomeResponses[rand.Next(welcomeResponses.Length)], "MOTIVATION");

            while (isRunning)
            {
                _questionCount++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\n{_userName} (Question #{_questionCount}): ");
                Console.ResetColor();

                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    _uiService.DisplayResponse("Type something! I'm ready to help! 💪");
                    continue;
                }

                if (userInput.ToLower().Trim() == "help")
                {
                    _uiService.DisplayHelpSection();
                    continue;
                }

                _lastQuestion = userInput;
                _uiService.DisplayUserMessage(userInput);

                string response = _responseService.GetResponse(userInput);

                if (response == "EXIT")
                {
                    _uiService.DisplayResponse($"You asked {_questionCount} questions! That's awesome! 🎉");
                    isRunning = false;
                    continue;
                }

                string category = _responseService.GetCategory(userInput);
                string emoji = _responseService.GetEmojiForCategory(category);

                _uiService.DisplayResponse(response, $"{emoji} {category}");
            }
        }
    }
}