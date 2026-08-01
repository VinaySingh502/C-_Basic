# Dependency Injection (DI) — Quick Reference Guide

---

## 💻 1. Full C# Code

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

public class BluetoothSpeakerOutput : IAudioOutput
{
    public void PlayAudio(string songTitle)
    {
        Console.WriteLine($"🔊 Playing '{songTitle}' loudly through Bluetooth Speaker!");
    }
}

public class AudioPlayerService
{
    private readonly IAudioOutput _audioOutput;

    public AudioPlayerService(IAudioOutput audio)
    {
        _audioOutput = audio;
    }

    public void PlaySong(string songTitle)
    {
        _audioOutput.PlayAudio(songTitle);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IAudioOutput headphone = new HeadphonesOutput();
        AudioPlayerService playerService = new AudioPlayerService(headphone);
        playerService.PlaySong("Hotel California");
    }
}
```

---

## 🔍 2. Line-by-Line Breakdown & Analogy

### Line 1: `IAudioOutput headphone = new HeadphonesOutput();`
* **What happens:** Creates the `HeadphonesOutput` object in RAM, typed under the Interface contract (`IAudioOutput`).
* **Why use Interface on left side:** Tells C# *"I don't care about the brand, only that it obeys the contract."*
* **Analogy:** You buy a pair of Headphones and put them on the table.

```text
[ RAM Memory ]
Heap:  [ HeadphonesOutput Object ]  <--- headphone (IAudioOutput contract)
```

---

### Line 2: `AudioPlayerService playerService = new AudioPlayerService(headphone);`
* **What happens:** **The Injection Step.** Passes `headphone` into `AudioPlayerService`'s constructor.
* **Behind the scenes:** `_audioOutput` field saves the `headphone` object reference.
* **Analogy:** You plug the Headphones cable into the Music Player slot.

```text
[ RAM Memory Connection ]
[ AudioPlayerService Object ] ---> _audioOutput field ---> [ HeadphonesOutput Object ]
```

---

### Line 3: `playerService.PlaySong("Hotel California");`
* **What happens:** `AudioPlayerService` calls `_audioOutput.PlayAudio("Hotel California")`.
* **Result:** `🎧 Playing 'Hotel California' in high quality through Headphones!`

---

### 🔌 Swapping Dependencies:
To switch to Bluetooth Speaker, only change Line 1 & Line 2 in `Program.cs`. **`AudioPlayerService.cs` is NEVER modified!**

```csharp
IAudioOutput speaker = new BluetoothSpeakerOutput();
AudioPlayerService playerService = new AudioPlayerService(speaker);
```

---

## 🎯 3. Top 3 Reasons Why We Use DI

1. **Open-Closed Principle:** Add new devices without changing `AudioPlayerService.cs`.
2. **Memory Efficiency:** Creates and uses only the 1 required object in RAM.
3. **Easy Unit Testing:** Inject a fake test object into `AudioPlayerService` for fast offline testing.

---

## 🧠 4. The 1-Line Interview Answer

> *"We use Dependency Injection to make our classes loosely coupled, memory efficient, easy to extend without breaking existing code, and easy to unit test."*
