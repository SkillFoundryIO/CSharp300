namespace NullableTypes;

public class SurveyAnswers
{
    public DateTime? FutureDate { get; set; }

    public TimeSpan DaysUntilFutureEvent()
    {
        if(FutureDate.HasValue)
        {
            return FutureDate.Value.Subtract(DateTime.Today);
        }

        return new TimeSpan(0);
    }
}
