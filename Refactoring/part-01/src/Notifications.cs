namespace RefactoringLab;
public interface INotificationChannel { string Name { get; } void Send(string to, string message); }
public sealed class EmailChannel : INotificationChannel { public string Name => "email"; public void Send(string to, string message) => Console.WriteLine($"[email] {to}: {message}"); }
public sealed class SmsChannel : INotificationChannel { public string Name => "sms"; public void Send(string to, string message) => Console.WriteLine($"[sms] {to}: {message}"); }
public interface IMessageModifier { string Modify(string message); }
public sealed class UrgentModifier : IMessageModifier { public string Modify(string message) => $"[URGENT] {message}"; }
public sealed class Notification(INotificationChannel channel, DateTime? sendAt = null, params IMessageModifier[] modifiers)
{
    public void Send(string to, string message) { foreach (var modifier in modifiers) message = modifier.Modify(message); if (sendAt is null) channel.Send(to, message); else Console.WriteLine($"[{channel.Name} scheduled {sendAt:g}] {to}: {message}"); }
}
