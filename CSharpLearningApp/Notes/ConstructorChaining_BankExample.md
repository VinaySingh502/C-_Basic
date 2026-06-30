# Constructor Chaining — Bank Account Example

## What is Constructor Chaining?

Constructor chaining means one constructor calls another constructor using `: this(...)`.
The constructor being called (the **Master**) always runs **first**, before the body of the calling constructor.

---

## The Golden Rule

> **Master Constructor** = Logic that EVERY object needs, no matter how it is created.
> **Chained Constructor Body** = Extra logic ONLY for that specific scenario.

Let me make it super concrete with a **Bank Account** example:

---

## 🏦 Bank Account — Real Scenario

```csharp
public class BankAccount
{
    public string AccountNumber { get; set; }
    public string AccountType   { get; set; }
    public double Balance        { get; set; }

    // ✅ MASTER — handles ALL the core logic
    public BankAccount(string accountNumber, string accountType, double balance)
    {
        this.AccountNumber = accountNumber;
        this.AccountType   = accountType;
        this.Balance       = balance;

        Console.WriteLine("✅ Account created in database");  // core logic
    }

    // ─────────────────────────────────────────────
    // Called when: new BankAccount()
    // Scenario: Walk-in customer, bank gives defaults
    // ─────────────────────────────────────────────
    public BankAccount() : this("ACC-DEFAULT", "Savings", 0)
    {
        // Master already created the account ✅
        // NOW — extra step ONLY for this scenario:
        Console.WriteLine("📧 Send welcome email to new walk-in customer");
        Console.WriteLine("🎁 Add ₹500 joining bonus for new account");
    }

    // ─────────────────────────────────────────────
    // Called when: new BankAccount("ACC-001", 50000)
    // Scenario: Online customer brings their own account number & balance
    // ─────────────────────────────────────────────
    public BankAccount(string accountNumber, double balance) : this(accountNumber, "Current", balance)
    {
        // Master already created the account ✅
        // NOW — extra step ONLY for this scenario:
        Console.WriteLine("🔐 Enable 2-factor authentication for online user");
        Console.WriteLine("📱 Send OTP to verify mobile number");
    }
}
```

---

## 🔍 Now See What Happens

### Case 1 — Walk-in customer
```csharp
new BankAccount()
```
```
✅ Account created in database       ← Master runs
📧 Send welcome email                ← Parameterless body runs
🎁 Add ₹500 joining bonus            ← Parameterless body runs
```

### Case 2 — Online customer
```csharp
new BankAccount("ACC-001", 50000)
```
```
✅ Account created in database       ← Master runs
🔐 Enable 2-factor authentication   ← 2-param body runs
📱 Send OTP to verify mobile         ← 2-param body runs
```

---

## 💡 The Key Insight

> Walk-in customer should NOT get OTP verification.
> Online customer should NOT get ₹500 joining bonus.

That **specific-to-the-situation** logic — that's what goes in the chained constructor's body.

| Action                  | Walk-in `new BankAccount()` | Online `new BankAccount("ACC-001", 50000)` |
|-------------------------|:---------------------------:|:------------------------------------------:|
| Create account in DB    | ✅ Both                     | ✅ Both                                    |
| Welcome email + bonus   | ✅ Yes                      | ❌ No                                      |
| OTP + 2FA               | ❌ No                       | ✅ Yes                                     |

**Master** = what EVERYONE needs
**Chained body** = what ONLY THIS TYPE of caller needs
