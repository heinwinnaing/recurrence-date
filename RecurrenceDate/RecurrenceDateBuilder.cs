namespace RecurrenceDate;

public enum RecurrenceType
{
    Daily,
    Weekly,
    Monthly,
    Yearly
}

public sealed class RecurrenceDateBuilder
{
    public int MaxOccurrence { get; private set; }
    public int Interval { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public RecurrenceType RecurrenceType { get; private set; }
    public DayOfWeek[] DaysOfWeek { get; private set; }
    public int[] DaysOfMonth { get; private set; }
    public RecurrenceDateBuilder()
    {
        this.RecurrenceType = RecurrenceType.Daily;
        this.StartDate = DateTime.UtcNow.Date;
        this.MaxOccurrence = 0;
        this.Interval = 1;
        this.DaysOfWeek = Array.Empty<DayOfWeek>();
        this.DaysOfMonth = Array.Empty<int>();
    }

    public RecurrenceDateBuilder SetRecurringType(RecurrenceType recurrenceType)
    {
        this.RecurrenceType = recurrenceType;
        return this;
    }

    public RecurrenceDateBuilder SetDayOfWeek(DayOfWeek[] daysOfWeek)
    {
        this.DaysOfWeek = daysOfWeek
            .Distinct()
            .ToArray();
        return this;
    }

    public RecurrenceDateBuilder SetDayOfMonth(int[] daysOfMonth)
    {
        this.DaysOfMonth = daysOfMonth
            .Distinct()
            .ToArray();
        return this;
    }

    public RecurrenceDateBuilder SetNumOfOccurrence(int maxOccurrence)
    {
        if (maxOccurrence < 0) maxOccurrence = 0;
        this.MaxOccurrence = maxOccurrence;
        return this;
    }

    public RecurrenceDateBuilder SetSeparationCount(int interval)
    {
        if (interval <= 0) interval = 1;
        this.Interval = interval;
        return this;
    }

    public RecurrenceDateBuilder SetStartDate(DateTime startDate)
    {
        this.StartDate = startDate;
        return this;
    }

    public RecurrenceDateBuilder SetEndDate(DateTime endDate)
    {
        this.EndDate = endDate;
        return this;
    }

    public List<DateTime> Build()
    {
        List<DateTime> dateTimes = new();
        if (this.RecurrenceType == RecurrenceType.Daily)
        {
            if (MaxOccurrence > 0) EndDate = null;
            DailyRecurrsive(dateTimes, StartDate.Date, EndDate.GetValueOrDefault().Date);
        }
        else if (this.RecurrenceType == RecurrenceType.Weekly)
        {
            if (MaxOccurrence > 0) EndDate = null;
            WeeklyRecurrsive(dateTimes, StartDate.Date, EndDate.GetValueOrDefault().Date);
        }
        else if (this.RecurrenceType == RecurrenceType.Monthly)
        {
            if (MaxOccurrence > 0) EndDate = null;
            MonthlyRecurrsive(dateTimes, StartDate.Date, EndDate.GetValueOrDefault().Date);
        }
        return dateTimes;
    }

    private void DailyRecurrsive(List<DateTime> dateTimes,
        DateTime dtStart,
        DateTime dtEnd)
    {
        if (dtStart <= dtEnd
            || MaxOccurrence > dateTimes.Count())
        {
            dateTimes.Add(dtStart.Date);
            dtStart = dtStart.AddDays(Interval);
            DailyRecurrsive(dateTimes, dtStart, dtEnd);
        }
    }

    private void WeeklyRecurrsive(List<DateTime> dateTimes,
        DateTime dtStart,
        DateTime dtEnd)
    {
        Interval = Interval <= 0 ? 1 : Interval;
        if (MaxOccurrence > dateTimes.Count()
            || dtStart <= dtEnd)
        {
            Enumerable.Range(0, 7)
            .Select(s => new { dt = dtStart.AddDays(s).Date, dayOfWeek = dtStart.AddDays(s).DayOfWeek })
            .ToList()
            .ForEach(e =>
            {
                if (DaysOfWeek.Contains(e.dayOfWeek)
                    && (dateTimes.Count < MaxOccurrence || e.dt <= dtEnd))
                {
                    dateTimes.Add(e.dt);
                }
            });
            dtStart = dtStart.AddDays(7 * Interval);
            WeeklyRecurrsive(dateTimes, dtStart, dtEnd);
        }
    }

    private void MonthlyRecurrsive(List<DateTime> dateTimes,
        DateTime dtStart,
        DateTime dtEnd,
        int occurrance = 0)
    {
        if (dtStart <= dtEnd
            || MaxOccurrence > dateTimes.Count())
        {
            var totalDays = (int)(dtStart.AddMonths(1) - dtStart).TotalDays;
            Enumerable.Range(0, totalDays)
                .Select(s => new { dt = dtStart.AddDays(s).Date, dayOfMonth = dtStart.AddDays(s).Day })
                .ToList()
                .ForEach(e =>
                {
                    if (DaysOfMonth.Contains(e.dayOfMonth)
                        && (e.dt <= dtEnd || MaxOccurrence > dateTimes.Count()))
                    {
                        dateTimes.Add(e.dt);
                    }
                });

            dtStart = dtStart.AddMonths(1).AddMonths(Interval - 1);
            MonthlyRecurrsive(dateTimes, dtStart, dtEnd);
        }
    }
}
