

# Cybersecurity Awareness Chatbot

## 1. Introduction

The Cybersecurity Awareness Chatbot is a C# console application that helps users learn about basic cybersecurity. The chatbot allows the user to type questions and receive information about different cybersecurity topics.

The main topics covered by the chatbot are password security, phishing, MFA, social engineering, malware and online privacy.

The project was created to make learning about cybersecurity easier and more interactive while also demonstrating the programming skills used in C#.

## 2. Aim of the Project

The main aim of the chatbot is to give users simple advice about staying safe online.

The project also helped me demonstrate how C# can be used to create an interactive application that responds to user input.

The chatbot can:

* Respond to greetings.
* Ask for and use the user's name.
* Answer cybersecurity questions.
* Display a list of available topics.
* Keep a record of the conversation.
* Respond to goodbye messages.
* Play a greeting sound when the program starts.

## 3. Technologies Used

The following technologies were used to develop the application:

* C#
* .NET 8
* Visual Studio / Visual Studio Code
* Console Application
* WAV audio
* System.Media
* System.IO
* System.Threading
* Lists and dictionaries

## 4. Main Classes

The project is divided into different classes. Each class has its own purpose.

### Chatbot.cs

This is where the application starts.

It is responsible for starting the program, displaying the chatbot logo, playing the greeting sound and asking the user for their name.

After that, it starts the main chatbot conversation.

### ChatbotEngine.cs

This class controls most of the chatbot's functionality.

It receives the user's messages and checks what the user is asking about. It also handles greetings, goodbye messages, the menu and the conversation history.

The chatbot uses keywords to identify the topic of a question.

For example, if the user types:

`How can I create a strong password?`

the chatbot looks for keywords related to passwords and provides the relevant information.

### CyberAnswers.cs

This class contains the cybersecurity information used by the chatbot.

It contains information about:

* Passwords
* Phishing
* MFA/2FA
* Social engineering
* Malware
* Online privacy

Keeping the information in a separate class makes the project easier to organise and update.

### Greetings.cs

This class is used for the chatbot's greeting.

It can display a personalised greeting using the user's name. It is also responsible for playing the WAV sound when the application starts.

## 5. Cybersecurity Topics

### Password Security

The chatbot explains why strong passwords are important.

Some of the advice given includes:

* Use long passwords.
* Avoid using the same password on different accounts.
* Use a password manager.
* Enable MFA where possible.
* Change a password if an account may have been compromised.

### Phishing

Phishing is when someone tries to trick a person into giving away information, such as passwords or banking details.

The chatbot advises users to:

* Check who sent the message.
* Be careful with links.
* Look for unusual spelling or grammar.
* Avoid responding to unexpected urgent requests.
* Confirm suspicious requests using an official contact method.

### Multi-Factor Authentication

MFA adds another security step when logging into an account.

The chatbot recommends enabling MFA on important accounts and keeping backup codes safe.

It also explains that authenticator apps and other verification methods can provide additional protection.

### Social Engineering

Social engineering involves manipulating people into giving away information or allowing access to something they should not.

The chatbot teaches users to check who they are dealing with before sharing information and to be careful with unexpected requests.

### Malware

Malware is harmful software that can damage a device or be used to steal information.

The chatbot recommends keeping software updated, downloading applications from trusted sources and avoiding suspicious attachments and links.

Users are also encouraged to back up important files.

### Online Privacy

The chatbot also gives advice about protecting personal information online.

This includes checking privacy settings, being careful about information shared on social media and taking extra care when using public Wi-Fi.

## 6. How the Chatbot Works

When the program starts, the chatbot first plays the greeting sound and displays its logo.

The user is then asked to enter their name.

After entering their name, the chatbot gives them a personalised welcome message.

The user can then type a question.

The program checks the words in the question and tries to identify the cybersecurity topic.

For example:

`What is phishing?`

The chatbot recognises the word **phishing** and displays information about phishing attacks.

The user can also type:

`menu`

to see the available topics.

To stop the chatbot, the user can type:

`exit`

Other goodbye commands such as `bye`, `goodbye`, `quit`, `see you` and `take care` are also supported.

## 7. Conversation History

The chatbot keeps the user's messages in a `List<string>`.

This allows the application to keep track of the conversation while the program is running.

Dictionaries are also used to organise keywords and connect them with the correct cybersecurity responses.

## 8. Error Handling

The program includes basic error handling to prevent problems during normal use.

For example, if the user presses Enter without typing anything, the chatbot asks them to enter a message.

The audio also has error handling. If the WAV file cannot be found or played, the application can use a system beep instead of stopping the whole program.

## 9. Audio Greeting

One of the additional features of the project is the startup audio.

When the chatbot starts, it attempts to play the WAV file:

`WhatsApp Ptt 2026-08-19 at 12.43.50.wav`

The audio gives the application a more interactive feel instead of only displaying text.

## 10. Running the Application

To run the project:

1. Open the project in Visual Studio or Visual Studio Code.
2. Make sure .NET 8 is installed.
3. Check that the WAV audio file is included in the project.
4. Build the solution.
5. Start the application.

In Visual Studio, the application can be started using **Ctrl + F5** or the Start button.

## 11. Example Questions

The user can ask questions such as:

* What is phishing?
* How do I make a strong password?
* What is malware?
* What is social engineering?
* What is MFA?
* How can I protect my privacy?
* Give me some cybersecurity tips.

## 12. Features of the Application

The main features include:

* Personalised greetings
* Cybersecurity information
* Keyword-based responses
* Topic menu
* Conversation history
* Goodbye commands
* Audio greeting
* Typewriter effect
* Console colours
* Empty-input checking
* Error handling

## 13. C# Concepts Demonstrated

This project allowed me to use several C# programming concepts, including:

* Classes
* Methods
* Variables
* Lists
* Dictionaries
* Loops
* `if` statements
* String manipulation
* User input
* Exception handling
* File handling
* Audio playback
* Console formatting

## 14. Conclusion

The Cybersecurity Awareness Chatbot is a simple application that combines cybersecurity awareness with C# programming.

It gives users an easy way to ask questions about common online security problems and receive useful information.

The project also helped demonstrate how different C# features can be combined to create an interactive console application. Separating the project into different classes also makes the code easier to manage and improve in the future.
