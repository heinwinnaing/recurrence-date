using System.Collections;

namespace RecurrenceDate.Test;

internal sealed class MonthlyInlineData : IEnumerable<object[]>
{
    private DateTime startDate => new DateTime(2025, 01, 01);
    private DateTime endDate => startDate.AddMonths(5).AddTicks(-1).Date; //new DateTime(2025, 12, 31);
    private int totalDays => (int)(endDate - startDate).TotalDays;
    private int totalMonths => ((endDate.Year - startDate.Year) * 12) + (endDate.Month - startDate.Month);
    private int[] dayOfMonths => new[] { 1, 2, 3 };

    private DateTime[] excludeMonths => Enumerable.Range(0, 5)
        .Select((s, i) => new { d = startDate.AddMonths(i * 2) })
        .Where(r => r.d.Month <= endDate.Month && r.d.Year <= endDate.Year)
        .Select(s => s.d)
        .ToArray();

    private IEnumerable<object[]> monthlyInlineData()
    {
        return new List<object[]>
        {
            new object[] //monthly
            {
                Enumerable.Range(0, totalDays)
                    .Select(d => startDate.AddDays(d).Date)
                    .Where(d => dayOfMonths.Contains(d.Day)).ToArray(),
                dayOfMonths,
                startDate,
                endDate,
                0, 0
            },

            new object[] //monthly with occurrence
            {
                Enumerable.Range(0, totalDays)
                    .Select(d => startDate.AddDays(d).Date)
                    .Where(d => dayOfMonths.Contains(d.Day))
                    .Take(5).ToArray(),
                dayOfMonths,
                startDate,
                endDate,
                5, 0
            },

            new object[] //monthly with separation
            {
                Enumerable.Range(0, totalDays)
                    .Select(d => startDate.AddDays(d).Date)
                    .Where(d => excludeMonths.Any(x => x.Month == d.Month && x.Year == d.Year) && dayOfMonths.Contains(d.Day))
                    .ToArray(),
                dayOfMonths,
                startDate,
                endDate,
                0, 2
            },

            new object[] //monthly with occurrence and separation
            {
                Enumerable.Range(0, totalDays)
                    .Select(d => startDate.AddDays(d).Date)
                    .Where(d => excludeMonths.Any(x => x.Month == d.Month && x.Year == d.Year) && dayOfMonths.Contains(d.Day))
                    .Take(5).ToArray(),
                dayOfMonths,
                startDate,
                endDate,
                5, 2
            },
        };
    }
    public IEnumerator<object[]> GetEnumerator() => monthlyInlineData().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}