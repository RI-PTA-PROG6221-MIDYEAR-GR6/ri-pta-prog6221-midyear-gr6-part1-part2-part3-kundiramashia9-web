using System.Media;

namespace ChatbotBot
{
    public class Greetings
    {
        public static void GreetUser(string userName)
        {
            Console.WriteLine($"Hello, {userName}! Welcome to the Chatbot.");
            PlayGreetingSound();
        }
        private static void PlayGreetingSound()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("WhatsApp Ptt 2026-08-19 at 12.43.50.wav"))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }
}

