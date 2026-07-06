using System;

namespace CSharpLearningApp;
public class Program
{
    private static void Main(string[] args)
    {
        var obj = AppLogger.GetInstance("ShopApp");
        UserService user = new UserService();
        OrderService order = new OrderService();
        PaymentService payment = new PaymentService();

        user.login("vinay");
        order.PlaceOrder("Iphone");
        payment.ProcessPayment(1000);
        user.logout("vinay");
        obj.PrintSummary();

    }
}
