using ADType = AntDesign.DatePickerType;
using SSType = SimpleSurveys.Shared.DataTransferObjects.DatePickerType;

namespace SimpleSurveys.Client.Extensions;

public static class DatePickerTypeExtensions
{
    public static ADType ToAntDesignDatePickerType(this SSType type) => type switch 
    {
        SSType.Date => ADType.Date,
        SSType.Week => ADType.Week,
        SSType.Month => ADType.Month,
        SSType.Quarter => ADType.Quarter,
        SSType.Year => ADType.Year,
        SSType.Time => ADType.Time,
        _ => ADType.Date,
    };
}