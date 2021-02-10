using WebApplication.Models.CustomHelpers;
using WebApplication.Localization;

namespace WebApplication.Models.Firefighters
{
    /// <summary>
    /// ���� ������������� ������� ������ 
    /// </summary>
    public enum InspectionPeriodicity
    {
        [LocalizedDescription(nameof(Home.InspectionYear), typeof(Home))]
        Annual = 1,
        [LocalizedDescription(nameof(Home.InspectionFiveYear), typeof(Home))]
        FiveYear = 2,
    }
}