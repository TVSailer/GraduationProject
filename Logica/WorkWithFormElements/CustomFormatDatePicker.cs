using System.ComponentModel;

public enum CustomFormatDatePicker
{
    [Description("dd.MM.yyyy HH:mm")] dd_MM_yyyy_HH_mm,
    [Description("HH:mm")] HH_mm,
    [Description("dd.MM.yyyy")] dd_MM_yyyy,
    [Description("dd.MM.yyyy HH:mm-HH:mm")] dd_MM_yyyy_HH_mm_HH_mm
}
