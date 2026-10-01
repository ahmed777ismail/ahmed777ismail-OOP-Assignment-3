# Part 01 - answers

## ShippingCostCalculator
- **Problem:** A switch required editing the calculator for every carrier, violating OCP.
- **Change:** `IShippingCarrier` strategies own their prices; the calculator receives them. `BostaCarrier` proves extension without modification.

## OrderProcessor
- **Problem:** It constructed SQL and SMTP dependencies internally, violating DIP and making testing difficult.
- **Change:** Constructor injection supplies abstractions, and one timestamp is shared by both operations.

## Notifications
- **Problem:** Inheritance created a class for every channel/urgent/scheduled combination.
- **Change:** `Notification` composes a channel, optional schedule, and modifiers. Any channel can use any combination.

## Proof
- New carrier file(s): `src/BostaCarrier.cs`
- New notification channel file(s): `src/WhatsAppChannel.cs`
- Existing classes left unchanged? **Yes for extension:** each new type is separate; only `Program.cs` wires it in.
