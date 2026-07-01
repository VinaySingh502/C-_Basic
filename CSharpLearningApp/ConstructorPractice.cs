using System;

namespace CSharpLearningApp;

// ════════════════════════════════════════════════════════════════
//             CONSTRUCTORS PRACTICE CHALLENGES
// ════════════════════════════════════════════════════════════════
// Complete the tasks below by writing your code in each class skeleton.
// Once done, select option 12 in the program menu to verify your work!
// ════════════════════════════════════════════════════════════════

// ──────────────────────────────────────────────────────────────
// TASK 4: REAL-WORLD API CONFIGURATION (CHAINING)
// ──────────────────────────────────────────────────────────────
// Requirements:
// 1. In the 'ApiConfig' class, declare properties:
//    - 'Endpoint' (string)
//    - 'TimeoutSeconds' (int)
//    - 'MaxRetries' (int)
// 2. Create a Master Parameterized Constructor that initializes all 3 properties.
// 3. Create a Parameterless Constructor that chains to the master constructor
//    setting Endpoint to "https://api.default.com", TimeoutSeconds to 30, and MaxRetries to 3.
// 4. Create a Constructor accepting Endpoint & TimeoutSeconds that chains to the master constructor
//    setting MaxRetries to 3.
// ──────────────────────────────────────────────────────────────
public class ApiConfig
{
    // TODO: Declare properties

    public string Endpoint {get;set;}
    public int TimeoutSeconds {get;set;}
    public int MaxRetries {get;set;}


    public ApiConfig(string endpoint ,int timeoutSeconds,int maxretries )
    {
        this.Endpoint = endpoint;
        this.TimeoutSeconds = timeoutSeconds;
        this.MaxRetries = maxretries;

        Console.WriteLine("this is master constrcutors");
    }

    public ApiConfig(string endpoint,int timeoutSeconds) : this(endpoint,timeoutSeconds,3)
    {
        Console.WriteLine("this is 2 parameters constructors ");
    }

    public ApiConfig() : this("https://api.default.com",30,3)
    {
        Console.WriteLine("this is paramterless constrcutors");
    }
    
}

// ──────────────────────────────────────────────────────────────
// TASK 5: REAL-WORLD USER ACCOUNT CREATION (CHAINING & VALIDATION)
// ──────────────────────────────────────────────────────────────
// Requirements:
// 1. In the 'UserAccount' class, declare properties:
//    - 'Username' (string)
//    - 'Email' (string)
//    - 'Role' (string)
//    - 'IsActive' (bool)
// 2. Create a Master Parameterized Constructor that initializes all 4 properties.
//    - IMPORTANT: If 'username' or 'email' is null or empty/whitespace, throw an 'ArgumentException'.
// 3. Create a Constructor accepting Username & Email that chains to the master constructor
//    setting Role to "Standard" and IsActive to true.
// 4. Create a Constructor accepting Username, Email & Role that chains to the master constructor
//    setting IsActive to true.
// ──────────────────────────────────────────────────────────────
public class UserAccount
{
    // TODO: Declare properties

    public string Username {get;set;}
    public string Email {get;set;}
    public string Role {get;set;}
    public bool IsActive {get;set;}

    public UserAccount(string username,string email,string role,bool isactive)
    {
        if(!string.IsNullOrWhiteSpace(username)|| !string.IsNullOrWhiteSpace(email))
        {
        this.Email = email;
        this.Username = username;
        this.Role= role;
        this.IsActive = isactive;
        }
        else
            throw new ArgumentException("can not null of username and email");
         
    
    }

    public UserAccount(string username,string email) : this(username,email,"Standard",true)
    {
        Console.WriteLine("Initialize construcutor 2 parameterized constracutor");
    }

    public UserAccount(string username,string email,string role): this(username, email, role, true)
    {
        Console.WriteLine("Initiallize constructors 3 parameters constracutor");
    }

}

// ──────────────────────────────────────────────────────────────
// TASK 6: COPY CONSTRUCTOR — PRODUCT INVENTORY
// ──────────────────────────────────────────────────────────────
// Requirements:
// 1. In the 'Product' class, declare these properties:
//    - 'Name'     (string)
//    - 'Price'    (double)
//    - 'Category' (string)
//    - 'InStock'  (bool)
//
// 2. Create a Master Constructor that initializes all 4 properties.
//
// 3. Create a Copy Constructor that accepts a 'Product' object
//    and copies all its property values into the new object.
//
// 4. After copying, the two objects must be INDEPENDENT —
//    changing one must NOT affect the other.
// ──────────────────────────────────────────────────────────────
public class Product
{
    // TODO: Declare 4 properties (Name, Price, Category, InStock)


    // TODO: Master Constructor — initializes all 4 properties


    // TODO: Copy Constructor — accepts a Product object, copies all properties

}
