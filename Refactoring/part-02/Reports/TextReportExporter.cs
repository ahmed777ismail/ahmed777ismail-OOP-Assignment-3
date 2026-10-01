namespace RefactoringLab.Part02.Reports;
public sealed class TextReportExporter : ReportExporter { protected override string Format(List<string[]> rows) => string.Join(Environment.NewLine, rows.Select(row => string.Join(" | ", row))); }
