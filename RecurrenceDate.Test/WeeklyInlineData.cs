using System.Collections;

namespace RecurrenceDate.Test;

internal sealed class WeeklyInlineData : IEnumerable<object[]>
{
    private readonly List<object[]> weeklyInlineData = new List<object[]>
    {
        new object[] //weekly saturday
        {
            new DateTime[]
            {
                new DateTime(2025, 03, 01),
                new DateTime(2025, 03, 08),
                new DateTime(2025, 03, 15),
                new DateTime(2025, 03, 22),
                new DateTime(2025, 03, 29),
            },
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            new DayOfWeek[]{DayOfWeek.Saturday},
            0, 0
        },

        new object[] //weekly saturday, sunday
        {
            new DateTime[]
            {
                new DateTime(2025, 03, 01), new DateTime(2025, 03, 02),
                new DateTime(2025, 03, 08), new DateTime(2025, 03, 09),
                new DateTime(2025, 03, 15), new DateTime(2025, 03, 16),
                new DateTime(2025, 03, 22), new DateTime(2025, 03, 23),
                new DateTime(2025, 03, 29), new DateTime(2025, 03, 30)
            },
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            new DayOfWeek[]{DayOfWeek.Saturday, DayOfWeek.Sunday},
            0, 0
        },

        new object[] // weekly saturday, sunday with separation
        {
            new DateTime[]
            {
                new DateTime(2025, 03, 01), new DateTime(2025, 03, 02),
                new DateTime(2025, 03, 15), new DateTime(2025, 03, 16),
                new DateTime(2025, 03, 29), new DateTime(2025, 03, 30)
            },
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            new DayOfWeek[]{DayOfWeek.Saturday, DayOfWeek.Sunday},
            0, 2
        },

        new object[] //weekly sunday with occurrence
        {
            new DateTime[]
            {
                new DateTime(2025, 03, 01),
                new DateTime(2025, 03, 08),
                new DateTime(2025, 03, 15)
            },
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            new DayOfWeek[]{DayOfWeek.Saturday},
            3, 1
        },

        new object[] // weekly saturday, sunday with separation and occurrence
        {
            new DateTime[]
            {
                new DateTime(2025, 03, 01),
                new DateTime(2025, 03, 15),
                new DateTime(2025, 03, 29)
            },
            new DateTime(2025, 03, 01),
            new DateTime(2025, 03, 31),
            new DayOfWeek[]{DayOfWeek.Saturday},
            3, 2
        },
    };

    public IEnumerator<object[]> GetEnumerator() => weeklyInlineData.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
