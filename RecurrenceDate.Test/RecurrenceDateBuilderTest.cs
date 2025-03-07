namespace RecurrenceDate.Test;

public class RecurrenceDateBuilderTest
{
    [Theory]
    [ClassData(typeof(DailyInlineData))]
    public void TestDailyRecurrsive_Success(DateTime[] expected,
        DateTime dtStart,
        DateTime dtEnd,
        int occurrenceCount,
        int separationCount)
    {
        //arrange
        var builder = new RecurrenceDateBuilder()
            .SetRecurringType(RecurrenceType.Daily)
            .SetStartDate(dtStart)
            .SetEndDate(dtEnd)
            .SetNumOfOccurrence(occurrenceCount)
            .SetSeparationCount(separationCount);

        //act
        var result = builder.Build();

        //assert
        Assert.NotNull(result);
        var objResult = Assert.IsType<List<DateTime>>(result);
        Assert.NotNull(objResult);
        Assert.Equal(expected.Length, objResult.Count);
        Assert.Equal(expected, objResult.ToArray());
    }

    [Theory]
    [ClassData(typeof(WeeklyInlineData))]
    public void TestWeeklyRecurrsive_Success(DateTime[] expected,
        DateTime dtStart,
        DateTime dtEnd,
        DayOfWeek[] dayOfWeeks,
        int occurrenceCount,
        int separationCount)
    {
        //arrange
        var builder = new RecurrenceDateBuilder()
            .SetRecurringType(RecurrenceType.Weekly)
            .SetDayOfWeek(dayOfWeeks)
            .SetStartDate(dtStart)
            .SetEndDate(dtEnd)
            .SetNumOfOccurrence(occurrenceCount)
            .SetSeparationCount(separationCount);

        //act
        var result = builder.Build();

        //assert
        Assert.NotNull(result);
        var objResult = Assert.IsType<List<DateTime>>(result);
        Assert.NotNull(objResult);
        Assert.Equal(expected.Length, objResult.Count);
        Assert.Equal(expected, objResult.ToArray());
    }

    [Theory]
    [ClassData(typeof(MonthlyInlineData))]
    public void TestMonthlyRecurrsive_Success(DateTime[] expected,
        int[] dayOfMonths,
        DateTime dtStart,
        DateTime dtEnd,
        int occurrenceCount,
        int separationCount)
    {
        //arrange
        var builder = new RecurrenceDateBuilder()
            .SetRecurringType(RecurrenceType.Monthly)
            .SetDayOfMonth(dayOfMonths)
            .SetStartDate(dtStart)
            .SetEndDate(dtEnd)
            .SetNumOfOccurrence(occurrenceCount)
            .SetSeparationCount(separationCount);

        //act
        var result = builder.Build();

        //assert
        Assert.NotNull(result);
        var objResult = Assert.IsType<List<DateTime>>(result);
        Assert.NotNull(objResult);
        Assert.Equal(expected.Length, objResult.Count);
        Assert.Equal(expected, objResult.ToArray());
    }
}
