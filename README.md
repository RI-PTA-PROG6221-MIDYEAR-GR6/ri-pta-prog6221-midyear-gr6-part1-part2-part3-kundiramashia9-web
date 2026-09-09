[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/SAB2_YS4)
# Chatbot - Cybersecurity Awareness Bot

## Project Description

Chatbot is a C# console-based cybersecurity awareness chatbot designed to help users learn about common cybersecurity threats and how to stay safe online.

The chatbot allows users to have a simple conversation and ask questions about topics such as:

* Password Security
* Phishing Attacks
* Multi-Factor Authentication (MFA/2FA)
* Social Engineering
* Malware Protection
* Online Privacy
* General Cybersecurity Tips

The chatbot uses keyword detection to understand the user's questions and provide relevant cybersecurity information.

## Project Objectives

The main objectives of this project are to:

1. Educate users about cybersecurity.
2. Provide simple and useful cybersecurity advice.
3. Demonstrate C# programming concepts.
4. Create an interactive console-based chatbot.
5. Allow users to ask questions naturally.
6. Provide different responses to greetings and farewells.
7. Include an audio greeting when the application starts.

## Technologies Used

* C#
* .NET 8
* Visual Studio
* System.Media
* System.Threading
* System.IO
* Console Application
* WAV audio file

## Project Structure

```text
ChatbotBot/
│
├── Chatbot.cs
├── ChatbotEngine.cs
├── CyberAnswers.cs
├── Greetings.cs
├── WhatsApp Ptt 2026-08-19 at 12.43.50.wav
└── ChatbotBot.csproj
```

## Chatbot.cs

This is the main entry point of the application.

It:

* Starts the chatbot.
* Plays the greeting sound.
* Displays the chatbot logo.
* Requests the user's name.
* Displays the welcome message.
* Starts the chat engine.

## ChatbotEngine.cs

This class controls the main conversation.

It handles:

* User input.
* Greetings.
* Farewells.
* The topic menu.
* Keyword detection.
* Conversation history.
* Generating chatbot responses.

The chatbot stores user input in conversation history and uses dictionaries to manage keywords and responses.

## CyberAnswers.cs

This class contains the cybersecurity knowledge base.

It provides information about:

* Password Security
* Phishing
* Multi-Factor Authentication
* Social Engineering
* Malware
* Online Privacy

Each topic contains an overview, best practices, and common mistakes.

## Greetings.cs

This class handles the chatbot greeting and greeting sound.

It displays a personalized greeting using the user's name and plays the WAV audio file.

## Cybersecurity Topics

### 1. Password Security

The chatbot teaches users how to create and manage strong passwords.

Examples of recommendations include:

* Use passwords with 12 or more characters.
* Do not reuse passwords.
* Enable 2FA.
* Use a password manager.
* Change passwords if a breach is suspected.

### 2. Phishing Attacks

Users learn how attackers use fake communications to steal sensitive information.

The chatbot recommends:

* Checking sender addresses.
* Checking links before clicking.
* Looking for spelling errors.
* Being suspicious of urgent requests.
* Verifying requests through official channels.

### 3. Multi-Factor Authentication

The chatbot explains how MFA provides additional security when logging into accounts.

Users are encouraged to:

* Enable MFA.
* Use authenticator applications.
* Keep backup codes secure.
* Use biometrics where available.
* Review active sessions.

### 4. Social Engineering

The chatbot explains how social engineering uses psychological manipulation to gain unauthorized access to information or systems.

Users are advised to:

* Verify identities.
* Be careful with unsolicited requests.
* Follow security procedures.
* Report suspicious behaviour.
* Trust but verify.

### 5. Malware Protection

The chatbot explains malware and provides ways to protect computers from malicious software.

Recommended practices include:

* Install reliable antivirus software.
* Keep software updated.
* Download software from official sources.
* Be careful with attachments and links.
* Back up important files.

### 6. Online Privacy

The chatbot provides advice on protecting personal information online.

Users are encouraged to:

* Review privacy settings.
* Use VPNs on public Wi-Fi.
* Be careful about information shared online.
* Use privacy-focused browsers.
* Clear cookies and browsing history regularly.

## How to Run the Project

### Step 1: Open the Project

Open the project using Visual Studio.

### Step 2: Check the .NET Version

The project uses:

```text
.NET 8
```

### Step 3: Check the Audio File

Make sure the WAV audio file is included in the project:

```text
WhatsApp Ptt 2026-08-19 at 12.43.50.wav
```

The project file is configured to copy the audio file to the output directory when the project is built.

### Step 4: Build the Project

In Visual Studio:

```text
Build → Build Solution
```

### Step 5: Run the Chatbot

Press:

```text
Ctrl + F5
```

or press the Start button in Visual Studio.

## How to Use the Chatbot

When the program starts:

1. The greeting sound plays.
2. The chatbot logo is displayed.
3. The user enters their name.
4. The chatbot welcomes the user.
5. The user can ask cybersecurity questions.

Example questions:

```text
What is phishing?
How do I create a strong password?
What is malware?
What is social engineering?
How can I protect my privacy online?
What is 2FA?
Give me cybersecurity tips
```

The user can also type:

```text
menu
```

to display the cybersecurity topics.

To end the conversation, type:

```text
exit
```

Other supported farewell commands include:

```text
bye
goodbye
quit
see you
take care
```

## Key Features

* Interactive conversation
* Personalized responses using the user's name
* Keyword-based question detection
* Cybersecurity knowledge base
* Multiple responses for greetings
* Multiple responses for farewells
* Conversation history
* Topic menu
* Typewriter text effect
* Console colours
* Startup greeting sound
* Null input handling
* General cybersecurity advice

## Error Handling

The application checks for empty user input and asks the user to enter something when no input is provided.

The greeting sound also includes error handling. If the WAV file cannot be found or played, the program attempts to use a system beep instead.

## Purpose of the Application

The purpose of Chatbot is to provide users with an easy and interactive way to learn about cybersecurity.

The application focuses on cybersecurity awareness and teaches users how to protect their accounts, devices, personal information, and online activities.

## Conclusion

Chatbot demonstrates how C# can be used to create an interactive console application.

The project combines:

* Object-oriented programming concepts
* Collections
* Dictionaries
* Lists
* Conditional statements
* Loops
* Methods
* String processing
* Exception handling
* File handling
* Audio playback
* User interaction

The chatbot provides a simple cybersecurity learning experience while demonstrating practical C# programming skills.
