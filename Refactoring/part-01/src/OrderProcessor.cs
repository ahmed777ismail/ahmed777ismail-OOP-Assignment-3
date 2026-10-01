namespace RefactoringLab;
public interface IOrderRepository { void Save(int orderId, DateTime processedAt); }
public interface IOrderConfirmationSender { void Send(string to, string body); }
public sealed class OrderProcessor(IOrderRepository repository, IOrderConfirmationSender confirmationSender)
{
    public void Process(int orderId, string customerEmail) { var processedAt = DateTime.Now; repository.Save(orderId, processedAt); confirmationSender.Send(customerEmail, $"Order {orderId} confirmed at {processedAt}"); }
}
public sealed class SqlOrderRepository : IOrderRepository { public void Save(int orderId, DateTime processedAt) => Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}"); }
public sealed class SmtpEmailSender : IOrderConfirmationSender { public void Send(string to, string body) => Console.WriteLine($"[SMTP] to={to} body={body}"); }
