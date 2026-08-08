# Dependency Injection (DI) — Complete 3-Type Reference Guide

---

## 1️⃣ Constructor Injection (95% Industry Standard)

### 📖 Explanation:
* **How it works:** The dependency is passed through the class **constructor**.
* **When to use:** For **required dependencies** that the class cannot live without.
* **Analogy:** Buying a car that requires an Engine right at the time of manufacturing.

### 💻 Full Code Example:
```csharp
using System;

namespace CSharpLearningApp;

public interface IAudioOutput
{
    void PlayAudio(string songTitle);
}

public class HeadphonesOutput : IAudioOutput
{
    public void PlayAudio(string songTitle)
    {
        Console.WriteLine($"🎧 Playing '{songTitle}' in high quality through Headphones!");
    }
}

public class AudioPlayerService
{
    private readonly IAudioOutput _audioOutput;

    // ✅ CONSTRUCTOR INJECTION: Injected when creating AudioPlayerService
    public AudioPlayerService(IAudioOutput audio)
    {
        _audioOutput = audio;
    }

    public void PlaySong(string songTitle)
    {
        _audioOutput.PlayAudio(songTitle);
    }
}

// Program.cs:
public class Program
{
    public static void Main(string[] args)
    {
        IAudioOutput headphone = new HeadphonesOutput();
        AudioPlayerService player = new AudioPlayerService(headphone); // Injected in Constructor!
        player.PlaySong("Hotel California");
    }
}
```

---

## 2️⃣ Property Injection (Setter Injection)

### 📖 Explanation:
* **How it works:** The dependency is assigned to a **public Property (`get; set;`)** *after* the class is created.
* **When to use:** For **optional dependencies** that have a safe default fallback.
* **Analogy:** Think of a Smartphone with a built-in speaker:
If you don't plug in anything, sound plays through the default built-in speaker.
If you want, you can attach a Headphone (Property) to override the default speaker.

### 💻 Full Code Example:
```csharp
using System;

namespace CSharpLearningApp;

public interface IPrinterDevice
{
    void Print(string documentName);
}

public class StandardPrinter : IPrinterDevice
{
    public void Print(string documentName)
    {
        Console.WriteLine($"🖨️ Standard B&W Print: {documentName}");
    }
}

public class PhotoPrinter : IPrinterDevice
{
    public void Print(string documentName)
    {
        Console.WriteLine($"🖼️ High-Gloss Color Photo Print: {documentName}");
    }
}

public class DocumentService
{
    // ✅ PROPERTY INJECTION: Defaults to StandardPrinter if not set by caller!
    public IPrinterDevice Printer { get; set; } = new StandardPrinter();

    public void ProcessDocument(string documentName)
    {
        Printer.Print(documentName);
    }
}

// Program.cs:
public class Program
{
    public static void Main(string[] args)
    {
        DocumentService docService = new DocumentService();

        // Usage A: Uses Default Property Printer (StandardPrinter)
        docService.ProcessDocument("Invoice.pdf");

        // Usage B: Override Property with PhotoPrinter
        docService.Printer = new PhotoPrinter(); // 👈 Injected via Property!
        docService.ProcessDocument("FamilyPhoto.jpg");
    }
}
```

---

## 3️⃣ Method Injection

### 📖 Explanation:
* **How it works:** The dependency is passed directly into a **method parameter**.
* **When to use:** When a dependency is **only needed for 1 specific action**, not for the whole class.
* **Analogy:** Think of a Printing Shop: The shop stays in one place (DocumentPrinter). When you go there, you hand over your USB Pen Drive (IPrinter) just for that 1 print job. The shop doesn't keep your Pen Drive forever!.

### 💻 Full Code Example:
```csharp
using System;

namespace CSharpLearningApp;

public interface INotificationGateway
{
    void SendNotification(string message);
}

public class EmailGateway : INotificationGateway
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"📧 Email Sent: {message}");
    }
}

public class SmsGateway : INotificationGateway
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"📱 SMS Sent: {message}");
    }
}

public class UserAlertService
{
    // ✅ METHOD INJECTION: Injected directly into the method parameter!
    public void SendAlert(string userMessage, INotificationGateway gateway)
    {
        gateway.SendNotification(userMessage);
    }
}

// Program.cs:
public class Program
{
    public static void Main(string[] args)
    {
        UserAlertService alertService = new UserAlertService();

        // Call 1: Inject EmailGateway into Method Call 1
        alertService.SendAlert("Security Alert: New Login", new EmailGateway());

        // Call 2: Inject SmsGateway into Method Call 2
        alertService.SendAlert("Security OTP: 492103", new SmsGateway());
    }
}
```

---

## 📊 Summary Comparison of All 3 DI Types

| Injection Type | Where is it passed? | Required or Optional? | Frequency |
|---|---|---|---|
| **1. Constructor Injection** | `new Service(dependency)` | **Mandatory** | ⭐ **95% (Standard)** |
| **2. Property Injection** | `service.Property = dependency` | **Optional** (Has default) | ⚠️ Rare |
| **3. Method Injection** | `service.Method(dependency)` | **Per Method Call** | 🛠️ Occasional |

---

## 🧠 Summary Table

| Injection Type | Real-Life Analogy | When to use in C#? |
|---|---|---|
| **Constructor Injection** | Buying a Car with an Engine | Required tool (95% standard) |
| **Property Injection** | Phone with Default Speaker (Headphones optional) | Optional tool with a default |
| **Method Injection** | Handing a USB Pen Drive to a Print Shop | Temporary tool for 1 specific action |

## 🧠 Interview 1-Line Answer

> *"We use Dependency Injection to make our classes loosely coupled, memory efficient, easy to extend without breaking existing code, and easy to unit test."*
------------------------

Viewed ConstructorPractice.cs:38-62

Here is a **3-Step Memory Formula** to make sure you NEVER forget Dependency Injection again:

---

## 🧠 The "S-P-C" Memory Formula

Whenever you think of Dependency Injection, remember **S - P - C**:

```
S — Socket     (Interface & Constructor Parameter)
P — Plug       (Concrete Helper Classes)
C — Connect    (Passing it in Program.cs)
```

---

### 1️⃣ S — Socket (The Interface & Constructor)
You define what tool you need, but you **don't create it inside**. You just make a socket parameter:
```csharp
public class AudioPlayerService
{
    private readonly IAudioOutput _output;

    // 🔌 THE SOCKET: Ask for the interface in constructor
    public AudioPlayerService(IAudioOutput output) 
    {
        _output = output;
    }
}
```

---

### 2️⃣ P — Plug (The Implementation Classes)
Create the actual tools that plug into that socket:
```csharp
public class HeadphonesOutput : IAudioOutput { ... }
public class BluetoothSpeakerOutput : IAudioOutput { ... }
```

---

### 3️⃣ C — Connect (Program.cs)
In `Program.cs`, create the plug and **connect it into the socket**:
```csharp
IAudioOutput headphones = new HeadphonesOutput();             // The Plug
AudioPlayerService player = new AudioPlayerService(headphones); // Connected!
```

---

## 🛑 The Golden Rule to Remember (The 1-Second Check):

> **"If you see `new` inside a Service constructor — it is NOT Dependency Injection."**
> **"If `new` is in `Program.cs` and passed into the Service constructor — IT IS Dependency Injection!"**

If you ever forget during coding, just ask yourself:  
**"Am I writing `new` inside my service class?"**  
If YES $\rightarrow$ Stop, remove `new`, and add a constructor parameter instead! 💡

