using System.Diagnostics;

var values = new List<int>();
for (var i = 0; i < 100_000; i++) values.Add(i);
var set = new HashSet<int>(values);
const int searches = 20_000;

var watch = Stopwatch.StartNew();
for (var i = 0; i < searches; i++) values.Contains(99_999);
watch.Stop();
Console.WriteLine($"List.Contains: {watch.ElapsedMilliseconds} ms");

watch.Restart();
for (var i = 0; i < searches; i++) set.Contains(99_999);
watch.Stop();
Console.WriteLine($"HashSet.Contains: {watch.ElapsedMilliseconds} ms");

foreach (var number in CountTo(10)) { Console.Write($"{number} "); if (number == 3) break; }
Console.WriteLine();

var text = "SIMULATION";
ReadOnlySpan<char> slice = text.AsSpan(0, 3);
Console.WriteLine(slice);
Console.WriteLine($"Classic: {text.WordCountClassic()}; C# 14: {text.WordCount}");

static IEnumerable<int> CountTo(int maximum)
{
    for (var i = 1; i <= maximum; i++) { if (i > 5) yield break; yield return i; }
}

public static class TextExtensions
{
    public static int WordCountClassic(this string value) => value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    extension(string value) { public int WordCount => value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; public static string Category => "Text"; }
}
