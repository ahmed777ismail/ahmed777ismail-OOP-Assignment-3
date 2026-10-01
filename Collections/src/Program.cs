using Assignment.Collections;
var phones = new (string Input, bool Expected)[] { ("01012345678", true), ("+201512345678", true), ("01312345678", false), ("0101234567", false), ("0101234567a", false) };
var ids = new (string Input, bool Expected)[] { ("29901011234567", true), ("19901011234567", false), ("2990101123456", false) };
foreach (var test in phones) Console.WriteLine($"Phone {test.Input}: {test.Input.IsValidEgyptianPhone()} (expected {test.Expected})");
foreach (var test in ids) Console.WriteLine($"National ID {test.Input}: {test.Input.IsValidEgyptianNationalId()} (expected {test.Expected})");
string? missing = null;
Console.WriteLine($"Null phone: {missing.IsValidEgyptianPhone()} (expected False)");
Console.WriteLine($"Spaces national ID: {"   ".IsValidEgyptianNationalId()} (expected False)");
