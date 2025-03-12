# Recurrence Date
A recurrence date refers to a specific date on which a repeating event occurs. It is commonly used in scheduling systems, calendars, and task management applications to define repeating events (e.g., meetings, reminders, subscriptions, or payments).

#### Daily Recurrence Sample
```csharp
var startDate = DateTime.Now;
var endDate = DateTime.Now.AddMonths(1);
var recurrenceDailyResult = new RecurrenceDateBuilder()
    .SetRecurringType(RecurrenceType.Daily)
    .SetStartDate(startDate)
    .SetEndDate(endDate)
    .Build();
```

#### Weekly Recurrence Sample
```csharp
var startDate = DateTime.Now;
var endDate = DateTime.Now.AddMonths(1);
var daysOfWeek = new DayOfWeek[]{DayOfWeek.Saturday, DayOfWeek.Sunday};
var recurrenceDailyResult = new RecurrenceDateBuilder()
    .SetRecurringType(RecurrenceType.Weekly)
    .SetDayOfWeek(daysOfWeek)
    .SetStartDate(startDate)
    .SetEndDate(endDate)
    .Build();
```
