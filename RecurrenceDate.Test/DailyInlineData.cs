using System.Collections;
namespace RecurrenceDate.Test;

internal sealed class DailyInlineData : IEnumerable<object[]>
{
    private readonly List<object[]> dailyInlineData = new List<object[]>
    {
        new object[] //daily
        {
            Enumerable.Range(0, 31)
                .Select(d => new DateTime(2025, 03, 01).AddDays(d).Date).ToArray(),
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            0, 0
        },

        new object[] //daily with occurrence
        {
            Enumerable.Range(0, 16)
                .Select(d => new DateTime(2025, 03, 01).AddDays(d).Date).ToArray(),
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            16, 0
        },

        new object[] //daily with separation
        {
            Enumerable.Range(0, 31)
                .Where(r => r % 2 == 0)
                .Select(d => new DateTime(2025, 03, 01).AddDays(d).Date).ToArray(),
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            0, 2
        },

        new object[] //daily with occurrence and separation
        {
            Enumerable.Range(0, 31)
                .Where(r => r % 2 == 0)
                .Select(d => new DateTime(2025, 03, 01).AddDays(d).Date).ToArray(),
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            16, 2
        },
    };

    public IEnumerator<object[]> GetEnumerator() => dailyInlineData.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
