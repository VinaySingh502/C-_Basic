# Copy Constructor in C#

## What Is It?

A **Copy Constructor** is a constructor that takes an object of the **same class** as its parameter
and creates a **new independent object** by copying all the property values from the existing one.

```csharp
public ClassName(ClassName other)   // ← takes same class as parameter
{
    this.Property1 = other.Property1;
    this.Property2 = other.Property2;
}
```

---

## Why Does It Exist?

In C#, when you do this:

```csharp
Product copy = original;   // ❌ NOT a copy — both point to SAME object
```

Both variables point to the **same object in memory**.
Changing `copy` will also change `original` — which is usually NOT what you want.

A Copy Constructor solves this by creating a **brand new object in memory** with the same values.

---

## When To Use It?

| Scenario | Reason |
|---|---|
| You need a **duplicate** of an object | Create a fresh independent copy |
| Modify a copy **without affecting the original** | Each object has its own memory |
| Use an object as a **template** | Copy it, then customize the copy |
| Undo/history features | Save a snapshot of an object's state |

---

## Full Example — Product Inventory

```csharp
public class Product
{
    public string Name     { get; set; }
    public double Price    { get; set; }
    public string Category { get; set; }
    public bool   InStock  { get; set; }

    // Master Constructor
    public Product(string name, double price, string category, bool inStock)
    {
        this.Name     = name;
        this.Price    = price;
        this.Category = category;
        this.InStock  = inStock;
    }

    // ✅ Copy Constructor
    public Product(Product other)
    {
        this.Name     = other.Name;
        this.Price    = other.Price;
        this.Category = other.Category;
        this.InStock  = other.InStock;
    }
}
```

---

## Using the Copy Constructor

```csharp
// Step 1 — Create original product
Product original = new Product("Laptop", 75000, "Electronics", true);

// Step 2 — Create a copy using copy constructor
Product copy = new Product(original);

// Step 3 — Modify the copy
copy.Name  = "Laptop Pro";
copy.Price = 95000;

// Step 4 — Original is untouched ✅
Console.WriteLine(original.Name);   // Laptop     ← unchanged
Console.WriteLine(original.Price);  // 75000      ← unchanged
Console.WriteLine(copy.Name);       // Laptop Pro ← only copy changed
Console.WriteLine(copy.Price);      // 95000      ← only copy changed
```

---

## ❌ Reference vs ✅ Copy — Side by Side

```csharp
// ❌ REFERENCE — same object, dangerous
Product copy = original;
copy.Price = 99999;
Console.WriteLine(original.Price);  // 99999 — original also changed! ❌

// ✅ COPY CONSTRUCTOR — new independent object
Product copy = new Product(original);
copy.Price = 99999;
Console.WriteLine(original.Price);  // 75000 — original safe! ✅
```

---

## Memory Diagram

```
// ❌ Reference assignment
original ──────────────────┐
                           ▼
copy     ─────────────► [Laptop, 75000]   ← SAME object

// ✅ Copy Constructor
original ─────────────► [Laptop, 75000]   ← original object
copy     ─────────────► [Laptop, 75000]   ← NEW separate object
```

---

## Interview Tips 🎯

| Question | Answer |
|---|---|
| What is a copy constructor? | A constructor that creates a new object by copying values from an existing object of the same class |
| Is `Product copy = original` a copy? | No — it's a reference. Both point to the same object |
| What is shallow vs deep copy? | Shallow copy copies the reference of nested objects. Deep copy creates new nested objects too |
| When does C# need a deep copy? | When your class has properties that are themselves objects (not primitives) |

---

## 🧠 Simple Rule to Remember

> `Product copy = original`     → Same object, shared memory ❌
> `Product copy = new Product(original)` → New object, independent memory ✅
