


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberGuardBot
{
    public partial class MainWindow : Window
    {
        private readonly List<SavedMessage> messages = new();

        private SoundPlayer? greetingPlayer;

        private readonly string historyPath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "CyberGuardBot",
            "messages.json");

        public MainWindow()
        {
            InitializeComponent();

            // Play the greeting sound once when the application starts.
            PlayGreetingSound();

            // Load and display the saved conversation.
            LoadMessages();

            if (messages.Count == 0)
            {
                AddMessage(
                    "CyberGuardBot",
                    "Hello! Welcome to CyberGuardBot. " +
                    "I can help you learn about cybersecurity. " +
                    "Type a question or select Topics to get started.",
                    false);
            }
            else
            {
                foreach (SavedMessage savedMessage in messages)
                {
                    AddMessageBubble(
                        savedMessage.Sender,
                        savedMessage.Message,
                        savedMessage.IsUser);
                }
            }

            StatusTextBlock.Text = "Ready";
        }

        // Greeting audio only. No speech synthesis is used.
        private void PlayGreetingSound()
        {
            try
            {
                string soundPath = Path.Combine(
                    AppContext.BaseDirectory,
                    "WhatsApp Ptt 2026-08-19 at 12.43.50 - Copy.wav");

                if (!File.Exists(soundPath))
                {
                    StatusTextBlock.Text = "Greeting sound file not found";
                    return;
                }

                greetingPlayer = new SoundPlayer(soundPath);
                greetingPlayer.Load();
                greetingPlayer.Play();
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Greeting sound could not play";
                System.Diagnostics.Debug.WriteLine(
                    "Greeting sound error: " + ex.Message);
            }
        }

        private void SendButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            SendMessage();
        }

        private void MessageTextBox_PreviewKeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.Key == Key.Enter &&
                Keyboard.Modifiers == ModifierKeys.None)
            {
                e.Handled = true;
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string userMessage = MessageTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            AddMessage("You", userMessage, true);

            MessageTextBox.Clear();
            StatusTextBlock.Text = "Responding...";

            string response = GetResponse(userMessage);

            AddMessage("CyberGuardBot", response, false);

            StatusTextBlock.Text = "Ready";
            MessageTextBox.Focus();
        }

        private string GetResponse(string input)
        {
            string message = input.ToLowerInvariant();

            if (ContainsAny(message, "hello", "hi", "hey", "good morning",
                    "good afternoon", "good evening"))
            {
                return "Hello! How can I help you with cybersecurity today?";
            }

            if (ContainsAny(message, "help", "topics", "what can you do"))
            {
                return GetTopics();
            }

            if (ContainsAny(message, "password", "passphrase"))
            {
                return "Password safety tips:\n\n" +
                       "• Use long, unique passwords for your accounts.\n" +
                       "• Avoid using personal information in passwords.\n" +
                       "• Use a reputable password manager.\n" +
                       "• Never share your password with other people.\n" +
                       "• Enable multi-factor authentication where possible.";
            }

            if (ContainsAny(message, "phishing", "fake email",
                    "suspicious email", "scam message"))
            {
                return "Phishing is an attempt to trick you into sharing " +
                       "personal information or clicking unsafe links.\n\n" +
                       "Look out for unexpected messages, urgent demands, " +
                       "unfamiliar senders and suspicious links. Verify " +
                       "the sender independently before responding. " +
                       "Do not share passwords or verification codes.";
            }

            if (ContainsAny(message, "multi-factor", "two-factor",
                    "2fa", "mfa", "authentication"))
            {
                return "Multi-factor authentication (MFA) adds another " +
                       "security check when you sign in. It may use an " +
                       "authenticator app, a security key or another " +
                       "verification method. Turn it on for important " +
                       "accounts whenever it is available.";
            }

            if (ContainsAny(message, "social engineering"))
            {
                return "Social engineering is when someone manipulates " +
                       "a person into revealing information or taking an " +
                       "unsafe action. Be cautious of unexpected requests, " +
                       "verify identities through a trusted channel, and " +
                       "never rush because someone claims an emergency.";
            }

            if (ContainsAny(message, "malware", "virus", "ransomware",
                    "spyware"))
            {
                return "Malware is software designed to harm devices, " +
                       "steal information or disrupt systems. Keep your " +
                       "software updated, use trusted security tools, " +
                       "avoid unknown downloads and attachments, and " +
                       "back up important files regularly.";
            }

            if (ContainsAny(message, "privacy", "personal information",
                    "data protection"))
            {
                return "Protect your privacy by sharing only necessary " +
                       "information online, reviewing app permissions, " +
                       "using privacy settings, keeping accounts secure, " +
                       "and checking that websites and services are " +
                       "trustworthy before sharing personal details.";
            }

            if (ContainsAny(message, "public wi-fi", "public wifi",
                    "public network"))
            {
                return "When using public Wi-Fi, avoid sensitive activities " +
                       "on networks you do not trust. Use HTTPS websites, " +
                       "disable automatic connections, keep your device " +
                       "updated, and use your mobile connection for " +
                       "particularly sensitive tasks when practical.";
            }

            if (ContainsAny(message, "update", "updates", "patch"))
            {
                return "Software updates often fix security weaknesses. " +
                       "Install updates for your operating system, browser " +
                       "and apps from official sources, and enable automatic " +
                       "updates where appropriate.";
            }

            if (ContainsAny(message, "backup", "backups"))
            {
                return "Back up important files regularly. Keep a separate " +
                       "backup that is protected from unauthorised access, " +
                       "and check occasionally that you can restore your files.";
            }

            if (ContainsAny(message, "thank you", "thanks"))
            {
                return "You're welcome! Stay safe online.";
            }

            if (ContainsAny(message, "bye", "goodbye", "see you"))
            {
                return "Goodbye! Remember to stay alert and protect your " +
                       "personal information online.";
            }

            return "I can help with passwords, phishing, multi-factor " +
                   "authentication, social engineering, malware, online " +
                   "privacy, public Wi-Fi, software updates and backups.\n\n" +
                   "Type \"Topics\" to see the available topics.";
        }

        private static bool ContainsAny(
            string input,
            params string[] keywords)
        {
            return keywords.Any(keyword =>
                input.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        private string GetTopics()
        {
            return "Here are the cybersecurity topics I can help with:\n\n" +
                   "1. Password safety\n" +
                   "2. Phishing and scam messages\n" +
                   "3. Multi-factor authentication (MFA)\n" +
                   "4. Social engineering\n" +
                   "5. Malware and viruses\n" +
                   "6. Online privacy and data protection\n" +
                   "7. Public Wi-Fi safety\n" +
                   "8. Software updates\n" +
                   "9. Backups\n\n" +
                   "Type a topic or ask a question to learn more.";
        }

        private void HelpButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            AddMessage("You", "Show me the available topics.", true);
            AddMessage("CyberGuardBot", GetTopics(), false);
        }

        private void ClearButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to clear the conversation?",
                "Clear Chat",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            messages.Clear();
            ConversationPanel.Children.Clear();
            SaveMessages();

            AddMessage(
                "CyberGuardBot",
                "Chat cleared. How can I help you with cybersecurity?",
                false);

            StatusTextBlock.Text = "Ready";
        }

        private void AddMessage(
            string sender,
            string message,
            bool isUser)
        {
            messages.Add(new SavedMessage
            {
                Sender = sender,
                Message = message,
                IsUser = isUser
            });

            AddMessageBubble(sender, message, isUser);
            SaveMessages();
        }

        private void AddMessageBubble(
            string sender,
            string message,
            bool isUser)
        {
            Border bubble = new Border
            {
                Background = isUser
                    ? new SolidColorBrush(
                        Color.FromRgb(230, 237, 247))
                    : new SolidColorBrush(
                        Color.FromRgb(255, 249, 239)),

                BorderBrush = new SolidColorBrush(
                    Color.FromRgb(216, 207, 191)),

                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(12),
                Margin = new Thickness(0, 5, 0, 5),
                MaxWidth = 650,
                HorizontalAlignment = isUser
                    ? HorizontalAlignment.Right
                    : HorizontalAlignment.Left
            };

            StackPanel messagePanel = new StackPanel();

            TextBlock senderText = new TextBlock
            {
                Text = sender,
                FontWeight = FontWeights.Bold,
                FontSize = 12,
                Foreground = new SolidColorBrush(
                    Color.FromRgb(23, 36, 58)),
                Margin = new Thickness(0, 0, 0, 5)
            };

            TextBlock messageText = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14,
                Foreground = new SolidColorBrush(
                    Color.FromRgb(23, 36, 58)),
                MaxWidth = 620
            };

            messagePanel.Children.Add(senderText);
            messagePanel.Children.Add(messageText);

            bubble.Child = messagePanel;
            ConversationPanel.Children.Add(bubble);

            ConversationScrollViewer.ScrollToEnd();
        }

        private void LoadMessages()
        {
            try
            {
                if (!File.Exists(historyPath))
                {
                    return;
                }

                string json = File.ReadAllText(historyPath);

                ChatHistory? savedHistory =
                    JsonSerializer.Deserialize<ChatHistory>(json);

                if (savedHistory?.Messages != null)
                {
                    messages.AddRange(savedHistory.Messages);
                }
            }
            catch (Exception ex)
            {
                messages.Clear();

                System.Diagnostics.Debug.WriteLine(
                    "Could not load chat history: " + ex.Message);
            }
        }

        private void SaveMessages()
        {
            try
            {
                string? directory = Path.GetDirectoryName(historyPath);

                if (!string.IsNullOrWhiteSpace(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                ChatHistory history = new ChatHistory
                {
                    Messages = messages
                };

                string json = JsonSerializer.Serialize(
                    history,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                File.WriteAllText(historyPath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Could not save chat history: " + ex.Message);
            }
        }

        private void Window_Closed(
            object? sender,
            EventArgs e)
        {
            SaveMessages();

            if (greetingPlayer != null)
            {
                greetingPlayer.Stop();
                greetingPlayer.Dispose();
                greetingPlayer = null;
            }
        }
    }

    public class SavedMessage
    {
        public string Sender { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public bool IsUser { get; set; }
    }

    public class ChatHistory
    {
        public List<SavedMessage> Messages { get; set; } = new();
    }
}
