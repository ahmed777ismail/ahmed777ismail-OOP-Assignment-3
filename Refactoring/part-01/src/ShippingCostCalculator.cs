namespace RefactoringLab;
public interface IShippingCarrier { string Name { get; } decimal Calculate(decimal weightKg); }
public sealed class AramexCarrier : IShippingCarrier { public string Name => "Aramex"; public decimal Calculate(decimal weightKg) => weightKg * 12m; }
public sealed class FedExCarrier : IShippingCarrier { public string Name => "FedEx"; public decimal Calculate(decimal weightKg) => weightKg * 15m; }
public sealed class DhlCarrier : IShippingCarrier { public string Name => "DHL"; public decimal Calculate(decimal weightKg) => weightKg * 18m; }
public sealed class ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
{
    private readonly Dictionary<string, IShippingCarrier> _carriers = Build(carriers);
    private static Dictionary<string, IShippingCarrier> Build(IEnumerable<IShippingCarrier> carriers) { var result = new Dictionary<string, IShippingCarrier>(StringComparer.OrdinalIgnoreCase); foreach (var carrier in carriers) result.Add(carrier.Name, carrier); return result; }
    public decimal Calculate(string carrier, decimal weightKg) => _carriers.TryGetValue(carrier, out var strategy) ? strategy.Calculate(weightKg) : throw new ArgumentException($"Unknown carrier: {carrier}", nameof(carrier));
}
