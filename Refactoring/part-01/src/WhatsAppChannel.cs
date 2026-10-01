namespace RefactoringLab;
public sealed class WhatsAppChannel : INotificationChannel { public string Name => "whatsapp"; public void Send(string to, string message) => Console.WriteLine($"[whatsapp] {to}: {message}"); }
