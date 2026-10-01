namespace RefactoringLab.Part02.Reports;
public sealed class JsonReportExporter : ReportExporter
{
    protected override string Format(List<string[]> rows) { var items = rows.Skip(1).Select(row => $"{{\"Id\":\"{row[0]}\",\"Name\":\"{row[1]}\"}}"); return "[" + string.Join(",", items) + "]"; }
}
