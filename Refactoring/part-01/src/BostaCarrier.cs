namespace RefactoringLab;
public sealed class BostaCarrier : IShippingCarrier { public string Name => "Bosta"; public decimal Calculate(decimal weightKg) => weightKg * 10m; }
