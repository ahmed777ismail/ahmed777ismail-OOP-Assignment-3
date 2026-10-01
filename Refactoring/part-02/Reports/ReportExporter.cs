namespace RefactoringLab.Part02.Reports;
public abstract class ReportExporter
{
    public void Export(string path) { var rows = Load(); if (!Validate(rows)) throw new InvalidOperationException("Invalid data"); File.WriteAllText(path, Format(rows)); }
    protected abstract string Format(List<string[]> rows);
    private static List<string[]> Load() => [["Id", "Name"], ["1", "Keyboard"], ["2", "Mouse"]];
    private static bool Validate(List<string[]> rows) => rows.Count > 1 && rows[0].Length > 0;
}
