using System;
using System.Security.Cryptography.X509Certificates;

namespace CSharpLearningApp;



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

// ══════════════════════════════════════════════════════════════════
// TASK 12: SINGLETON CACHE MANAGER — INTERVIEW LEVEL
// ══════════════════════════════════════════════════════════════════
// Scenario:
//   An e-commerce app has ProductService and UserService.
//   Both need to read/write to a SHARED in-memory cache.
//   Without Singleton — each service has its own cache (data splits!).
//   With Singleton — ONE cache shared by ALL services.
//
// ── PART A: CacheManager (Singleton) ─────────────────────────────
// 1. Declare in 'CacheManager':
//    - '_instance'   private static CacheManager
//    - '_cache'      private Dictionary<string, string>
//                    (key = item name, value = item data)
//    - 'HitCount'    public int  (how many times cache was READ)
//
// 2. Private Constructor:
//    - Initializes _cache as new Dictionary<string, string>()
//    - Sets HitCount to 0
//    - Prints: "CacheManager initialized ✅"
//
// 3. Static 'GetInstance()' method (no params):
//    - Standard Singleton null check + return
//
// 4. Method 'Add(string key, string value)':
//    - Adds key/value to _cache
//    - Prints: "Cached: [key] = [value]"
//
// 5. Method 'Get(string key)':
//    - Increments HitCount
//    - If key exists → prints "Cache HIT [HitCount]: [key] = [value]" → returns value
//    - If not exists → prints "Cache MISS: [key] not found" → returns null
//
// 6. Method 'PrintStats()':
//    - Prints: "Total Items Cached: [_cache.Count]"
//    - Prints: "Total Cache Hits: [HitCount]"
//
// ── PART B: Services that USE the Cache ──────────────────────────
// 7. Class 'ProductService':
//    - Gets CacheManager via GetInstance()
//    - Method 'GetProduct(string name)':
//        → Tries cache first with Get(name)
//        → If null (miss) → simulates DB fetch: Add(name, "₹79999") and returns "₹79999"
//        → If found (hit) → returns cached value directly
//
// 8. Class 'PriceService':
//    - Gets CacheManager via GetInstance()
//    - Method 'GetPrice(string item)':
//        → Same pattern — check cache first, add if missing
//
// ── PART C: Test in Program.cs ────────────────────────────────────
//    var ps  = new ProductService();
//    var prs = new PriceService();
//    ps.GetProduct("iPhone");    // MISS → fetches from DB → caches
//    ps.GetProduct("iPhone");    // HIT  → from cache
//    prs.GetPrice("iPhone");     // HIT  → PriceService reads ProductService's cache!
//    CacheManager.GetInstance().PrintStats();
//    // Total Items Cached: 1 | Total Cache Hits: 2
// ══════════════════════════════════════════════════════════════════
public class CacheManager
{
    private static CacheManager _instance;
    private Dictionary<string ,string> _cache;

    private int HitCount;

    private CacheManager()
    {
        _cache = new Dictionary<string, string>();
        HitCount = 0;
    }

    public static CacheManager GetInstance()
    {
        if(_instance == null)
        {
            _instance = new CacheManager ();
        }
        return _instance;
    }

    public void Add(string key , string value)
    {
        _cache.Add(key,value);
        Console.WriteLine($"Cached: {key}  {value}");
    }

    public string Get(string key)
    {

foreach (var item in _cache)
        {
         item.Key[0].Equals("data");
        }

        if(_cache.ContainsKey(""))
        {
                   HitCount += 1;
                   Console.WriteLine($"Cache HIT {HitCount} : {_cache.Keys} = {_cache.Values}");
                   return _cache.Values.ToString();
        }
        else
        {
         Console.WriteLine($"Cache HIT :{key} not found");
          return null;
        }
    }

    public void PrintStats()
    {
        Console.WriteLine($"Total Item Cached {_cache.Count}");
        Console.WriteLine($"Total Cache Hits:{HitCount}");
    }
}

public class ProductService
{ 
    public string GetProduct(string name)
    {
     var data = CacheManager.GetInstance().Get(name);
        if(data == null)
        {
           data = "₹79999"; 
           CacheManager.GetInstance().Add(name,data);
        }

        return data;
    }
}


public class PriceService
{
   public string GetPrice(string item)
    {
         var data = CacheManager.GetInstance().Get(item);
        if(data == null)
        {
           data = "₹79999"; 
           CacheManager.GetInstance().Add(item,data);
        }

        return data;
    }
}
