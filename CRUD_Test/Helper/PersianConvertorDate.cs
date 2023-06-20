namespace CRUD_Test;

public static class PersianConvertorDate
{

    public static string ToShamsi(this DateOnly value)
    {
        DateOnly date = new DateOnly(value.Year, value.Month, value.Day);
        //return date.ToString("dd/MM/yyyy");
        return date.ToString();
    }
}