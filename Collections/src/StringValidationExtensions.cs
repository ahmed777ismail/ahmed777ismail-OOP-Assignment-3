using System.Text.RegularExpressions;
namespace Assignment.Collections;
public static partial class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string? value) => !string.IsNullOrWhiteSpace(value) && EgyptianPhoneRegex().IsMatch(value);
    public static bool IsValidEgyptianNationalId(this string? value) => !string.IsNullOrWhiteSpace(value) && EgyptianNationalIdRegex().IsMatch(value);
    [GeneratedRegex(@"^(?:01[0125]\d{8}|\+201[0125]\d{8})$")] private static partial Regex EgyptianPhoneRegex();
    [GeneratedRegex(@"^[23]\d{13}$")] private static partial Regex EgyptianNationalIdRegex();
}
