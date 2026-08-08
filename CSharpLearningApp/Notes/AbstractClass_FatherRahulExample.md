# Abstract Class — Father & Rahul Analogy

An **Abstract Class** serves as a restricted base blueprint that cannot be instantiated directly using `new`. It defines a contract and common behaviors for all child (derived) classes.

---

## 👨‍👦 The Father & Rahul Analogy

Think of an Abstract Class like a **Father** giving rules and gifts to his son **Rahul**:

| Method Type | Father's Rule | Child's Action | Has Body in Father? |
| :--- | :--- | :--- | :---: |
| 🔴 **`abstract` Method** | *"You MUST do this, but write your own recipe."* | **MUST** `override` | ❌ No |
| 🟡 **`virtual` Method** | *"Here is my recipe. Change it or keep it as you like."* | **CAN** `override` *(optional)* | ✅ Yes |
| 🟢 **Regular Method** | *"This is permanent. You get it as-is."* | Inherited automatically | ✅ Yes |

---

## 📜 Core Rules

> [!CAUTION]
> **Rule 1: Direct Instantiation is Forbidden**
> You cannot create a `Father` object directly (`new Father()`). It will cause a compile-time error.

> [!IMPORTANT]
> **Rule 2: Abstract Members Must Be Implemented**
> Any abstract method (`RunBusiness()`, `EarnMoney()`) or property (`Vehicle`) MUST be overridden in the child class `Rahul` using the `override` keyword.

> [!NOTE]
> **Rule 3: Virtual Methods are Optional**
> If `Rahul` does not override `CookDal()`, Father's default implementation executes automatically.

---

## 💻 Full C# Implementation

```csharp
using System;

namespace CSharpLearningApp;

// -------------------- THE FATHER (Abstract Base Class) --------------------
// Cannot create Father directly using 'new'. He is the blueprint.
public abstract class Father
{
    // Regular Property — inherited by all children
    public string Name { get; set; }

    // ABSTRACT Property — father says: 'You must have a vehicle', child picks which one
    public abstract string Vehicle { get; }

    // ABSTRACT Method 1 — father says: 'You MUST run a business' (no body {})
    public abstract void RunBusiness();

    // ABSTRACT Method 2 — father says: 'You MUST earn money' (no body {})
    public abstract void EarnMoney();

    // VIRTUAL Method — father gives default dal recipe. Child CAN override or keep it.
    public virtual void CookDal()
    {
        Console.WriteLine("Father's recipe: simple dal with turmeric and salt");
    }

    // REGULAR Method 1 — permanent surname. Child gets it as-is.
    public void GetSurname()
    {
        Console.WriteLine("Family surname: Sharma");
    }

    // REGULAR Method 2 — drives child's vehicle.
    public void Drive()
    {
        Console.WriteLine($"{Name} is driving a {Vehicle}");
    }
}

// -------------------- SON: RAHUL (Concrete Derived Class) --------------------
public class Rahul : Father
{
    // MUST implement abstract property
    public override string Vehicle => "Car";

    // MUST implement abstract method 1
    public override void RunBusiness()
    {
        Console.WriteLine($"{Name} runs a software company");
    }

    // MUST implement abstract method 2
    public override void EarnMoney()
    {
        Console.WriteLine($"{Name} earned 50000 this month");
    }

    // CookDal() -> Rahul kept Father's recipe (did NOT override)
    // GetSurname() -> Rahul inherits Father's surname (regular method)
    // Drive() -> Rahul inherits Father's drive logic (regular method)
}

// -------------------- EXECUTION (Program.cs) --------------------
public class Program
{
    public static void Main(string[] args)
    {
        // Father father = new Father(); // ❌ CS0144: Cannot create an instance of the abstract class

        Console.WriteLine("===== Rahul's Life =====");
        
        Rahul rahul = new Rahul();
        rahul.Name = "Rahul";

        rahul.RunBusiness(); // Rahul's code: 'Rahul runs a software company'
        rahul.CookDal();     // Father's code (not overridden): 'Father's recipe: simple dal...'
        rahul.GetSurname();  // Father's code (regular method): 'Family surname: Sharma'
        rahul.EarnMoney();   // Rahul's code: 'Rahul earned 50000 this month'
        rahul.Drive();       // Father's code using Rahul's Vehicle: 'Rahul is driving a Car'
    }
}
```

---

## 🖥️ Expected Console Output

```text
===== Rahul's Life =====
Rahul runs a software company
Father's recipe: simple dal with turmeric and salt
Family surname: Sharma
Rahul earned 50000 this month
Rahul is driving a Car
```

---

## 🎯 Key Interview Takeaways

> [!TIP]
> **Q1: Can an abstract class have a constructor?**
> **Yes.** An abstract class constructor cannot be called directly with `new AbstractClass()`, but it runs automatically when a child class instance is created (`new Rahul()`) to initialize base properties.

> [!WARNING]
> **Q2: What if a child class doesn't implement an abstract method?**
> The child class will fail to compile unless the child class itself is also marked as `abstract`.

> [!NOTE]
> **Q3: Abstract Class vs Interface — Quick Difference**
> - **Abstract Class**: Can have constructors, fields, non-virtual methods, and access modifiers (`protected`, `private`). Single inheritance only.
> - **Interface**: Pure contract (prior to C# 8), no state/fields, no base constructors. Multiple interface inheritance is supported.
