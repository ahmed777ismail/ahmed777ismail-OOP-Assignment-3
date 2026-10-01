namespace RefactoringLab.Part02.Enrollment;
public sealed class EnrollmentFacade(PaymentGateway payment, SeatInventory seats, InvoiceGenerator invoices, EmailService email)
{
    public void Enroll(string studentId, string courseId, decimal amount) { payment.Charge(studentId, amount); seats.Reserve(courseId, studentId); var invoiceId = invoices.Create(studentId, amount); email.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}"); }
}
