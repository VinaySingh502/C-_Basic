// ══════════════════════════════════════════════════════════════════
// TASK 11: SINGLETON LOGGER — REAL E-COMMERCE APP SIMULATION
// ══════════════════════════════════════════════════════════════════
// Scenario:
//   A shopping app has 3 modules: UserService, OrderService, PaymentService.
//   ALL 3 must write to the SAME single logger.
//   If each had its own logger, logs would be split and incomplete.
//
// ── PART A: AppLogger (Singleton) ────────────────────────────────
// Requirements:
// 1. Declare in 'AppLogger':
//    - '_instance'  private static AppLogger
//    - 'AppName'    public string  (read-only after creation)
//    - 'LogCount'   public int     (starts at 0, auto-increments)
//
// 2. Private Constructor accepting 'appName':
//    - Sets AppName
//    - Prints: "✅ Logger created for: [appName]"
//    - Prints: "─────────────────────────────────"
//
// 3. Static method 'GetInstance(string appName = "MyApp")':
//    - Creates instance ONLY if null
//    - Returns same instance every time
//
// 4. Method 'Log(string module, string message)':
//    - Increments LogCount
//    - Prints: "[LOG #LogCount] [module] message"
//
// 5. Method 'PrintSummary()':
//    - Prints: "─────────────────────────────────"
//    - Prints: "App: [AppName]"
//    - Prints: "Total Logs Written: [LogCount]"
//
// ── PART B: Service Modules ───────────────────────────────────────
// Each service gets the logger via GetInstance() — NOT a new one!
//
// 6. Class 'UserService':
//    - Field: '_logger' = AppLogger.GetInstance()
//    - Method 'Login(string username)'  → logs "User '[username]' logged in"
//    - Method 'Logout(string username)' → logs "User '[username]' logged out"
//
// 7. Class 'OrderService':
//    - Field: '_logger' = AppLogger.GetInstance()
//    - Method 'PlaceOrder(string item)' → logs "Order placed for: [item]"
//
// 8. Class 'PaymentService':
//    - Field: '_logger' = AppLogger.GetInstance()
//    - Method 'ProcessPayment(double amount)' → logs "Payment processed: ₹[amount]"
//
// ── PART C: Test in Program.cs ────────────────────────────────────
// After writing all classes, test in Program.cs:
//    AppLogger logger = AppLogger.GetInstance("ShopApp");
//    UserService    user    = new UserService();
//    OrderService   order   = new OrderService();
//    PaymentService payment = new PaymentService();
//    user.Login("Vinay");
//    order.PlaceOrder("iPhone 15");
//    payment.ProcessPayment(79999);
//    user.Logout("Vinay");
//    logger.PrintSummary();   // Total Logs Written: 4
// ══════════════════════════════════════════════════════════════════

// TODO: AppLogger class (Singleton)
public class AppLogger
{
    // TODO: _instance, AppName, LogCount
     
     private static AppLogger _instance ;  
     public readonly string AppName;
     public int LogCount;
    

     
    // TODO: Private Constructor (accepts appName)
    
    private AppLogger(string appName)
    {   
        AppName = appName;
        Console.WriteLine($"Prints:Logger created for: {appName}");
        Console.WriteLine($"─────────────────────────────────");
    } 

      
    public static AppLogger GetInstance(string appName = "MyApp")
    {
        if(_instance == null)
        {
            _instance = new AppLogger(appName);
        }
        return _instance;
    }

    public void Log(string module,string message)
    {
        LogCount += 1;
        Console.WriteLine($"[LOG # {LogCount}] {module} {message}");
    }

    public void PrintSummary()
    {
          Console.WriteLine("─────────────────────────────────");
          Console.WriteLine($"App {AppName}");
          Console.WriteLine($"Total Logs Written: {LogCount}");
    }

}

// TODO: UserService class
public class UserService
{
    private AppLogger _logger = AppLogger.GetInstance();
    public void login(string Username)
    {
       _logger.Log("UserService",$"logs User {Username} logged in");
    } 

    public void logout(string username)
    {
        _logger.Log("UserService",$"logs User {username} logged out");
    }
}

// TODO: OrderService class
public class OrderService
{
   private AppLogger _logger = AppLogger.GetInstance();

    public void PlaceOrder(string item)
    {
        _logger.Log("OrderService",$"Order placed for: {item}");
    }
}

// TODO: PaymentService class
public class PaymentService
{
  private AppLogger _logger = AppLogger.GetInstance();
  public void ProcessPayment(double amount)
    {
        _logger.Log("PaymentService",$"Payment processed: ₹{amount}");    
    }  
}


## Your Question: "Why call GetInstance() in each service if it's already called at the start?"

You're right — `GetInstance("ShopApp")` is already called in `Program.cs` first. So why call it again in each service?

---

## The Answer — `GetInstance()` is NOT creating a new one

```csharp
// Program.cs — FIRST CALL — creates the instance
AppLogger logger = AppLogger.GetInstance("ShopApp");  
// → _instance is null → creates new AppLogger ✅

// UserService — SECOND CALL — gets the SAME one
private AppLogger _logger = AppLogger.GetInstance();  
// → _instance is NOT null → just returns existing one ✅

// OrderService — THIRD CALL — gets the SAME one
private AppLogger _logger = AppLogger.GetInstance();  
// → _instance is NOT null → just returns existing one ✅
```

Think of `GetInstance()` like this:

> **First call** = "The factory is empty — build the car, park it"
> **Every call after** = "Car already parked — here are the keys" 🔑

---

## Why not just pass the logger as a parameter to each service?

```csharp
// You COULD do this instead ❌ — but it's messy
var logger = new AppLogger("ShopApp");
var user    = new UserService(logger);   // pass it in
var order   = new OrderService(logger);  // pass it in
var payment = new PaymentService(logger); // pass it in
```

With Singleton each service just calls `GetInstance()` and gets the logger **without needing anyone to pass it** — cleaner, simpler, no dependency chain. ✅

---

## 🧠 Simple Rule

> **`GetInstance()` is always safe to call** — it creates only once, returns same object every time. Call it as many times as you want — it costs almost nothing.