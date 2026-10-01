# Part 02 - answers

## Reports
- **Problem:** The exporters duplicated load, validate, save, and orchestration code.
- **Change:** `ReportExporter.Export` is the Template Method; subclasses override only `Format`.
- **Why abstract class:** They need shared implementation and a fixed sequence, not only a contract. The abstract class protects that workflow and exposes one variation point.

## Enrollment
- **Problem:** The caller knew all four services, call order, and result passing.
- **Change:** `EnrollmentFacade.Enroll` owns the workflow; `Program.cs` makes one call.
- **Why:** The caller no longer needs to know which services participate, their order, or how the invoice reaches email.
