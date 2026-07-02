# C# Constructors -- Must Know Interview Points

## ✅ Constructor Basics

-   Constructor name must be the same as the class name.
-   Constructor has **no return type** (not even `void`).
-   A constructor is used to initialize an object.
-   A constructor executes automatically when an object is created using
    the `new` keyword.

### Example

``` csharp
class Student
{
    public Student()
    {
        Console.WriteLine("Constructor Called");
    }
}

Student s = new Student();
```

**Output**

``` text
Constructor Called
```

------------------------------------------------------------------------

## ✅ Implicit Default Constructor

-   Created automatically by the **Compiler**.
-   Generated only when **no constructor** is defined.
-   It is a **parameterless constructor**.

**Remember**

> No constructor written = Compiler creates one.

### Example

``` csharp
class Employee
{
    public int Id { get; set; }
}

Employee emp = new Employee();
```

------------------------------------------------------------------------

## ✅ Explicit Constructor

-   Written by the **Developer**.
-   Can be parameterless or parameterized.
-   If any constructor is written, the compiler does **not** create the
    implicit default constructor.

### Example

``` csharp
class Employee
{
    public string Name;

    public Employee(string name)
    {
        Name = name;
    }
}

Employee emp = new Employee("Vinay");
Console.WriteLine(emp.Name);
```

**Output**

``` text
Vinay
```

------------------------------------------------------------------------

## ✅ Instance Constructor

-   Initializes instance members.
-   Runs every time an object is created.
-   Executed by the CLR.

### Example

``` csharp
class Car
{
    public Car()
    {
        Console.WriteLine("Instance Constructor");
    }
}

new Car();
new Car();
```

**Output**

``` text
Instance Constructor
Instance Constructor
```

------------------------------------------------------------------------

## ✅ Static Constructor

-   Initializes static members.
-   Runs only once.
-   Cannot have parameters.
-   Cannot have access modifiers.
-   Cannot be called manually.

### Example

``` csharp
class Demo
{
    static Demo()
    {
        Console.WriteLine("Static Constructor");
    }

    public Demo()
    {
        Console.WriteLine("Instance Constructor");
    }
}

new Demo();
new Demo();
```

**Output**

``` text
Static Constructor
Instance Constructor
Instance Constructor
```

------------------------------------------------------------------------

## ✅ Constructor Chaining

-   Use `this()` to call another constructor in the same class.
-   Use `base()` to call a parent class constructor.

### this() Example

``` csharp
class Student
{
    public Student() : this("Unknown")
    {
    }

    public Student(string name)
    {
        Console.WriteLine(name);
    }
}

new Student();
```

### base() Example

``` csharp
class Person
{
    public Person(string name)
    {
        Console.WriteLine(name);
    }
}

class Employee : Person
{
    public Employee() : base("Vinay")
    {
    }
}

new Employee();
```

------------------------------------------------------------------------

## ✅ Important Rules

-   Constructors can be overloaded.
-   Constructors cannot be inherited.
-   Constructors cannot be abstract.
-   Constructors cannot be virtual.
-   Static constructors cannot be overloaded.

------------------------------------------------------------------------

# 🔥 Golden Interview Formula

``` text
Compiler Creates  → Implicit Default Constructor

Developer Writes  → Explicit Constructor

Developer Triggers → new Keyword

CLR Executes      → All Constructors

Static Constructor  → Runs Once

Instance Constructor → Runs Per Object
```

# 📝 One-Line Revision

> **Implicit = Compiler-generated, Explicit = Developer-written,
> Instance = Runs per object, Static = Runs once per class, CLR executes
> all constructors.**
