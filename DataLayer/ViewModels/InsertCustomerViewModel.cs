using System.ComponentModel.DataAnnotations;

namespace DataLayer.ViewModels;

public class InsertCustomerViewModel
{
    [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
    public string Firstname { get; set; } = string.Empty;
    [Required(ErrorMessage = "لطفا نام خانوادگی خود را وارد کنید")]
    public string Lastname { get; set; } = string.Empty;

    [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$"
        , ErrorMessage = "ایمیل معتبر وارد کنید")]
    public string Email { get; set; } = string.Empty;

    [DataType(DataType.CreditCard)]
    [RegularExpression(@"^[0-9]{16}$"
, ErrorMessage = "حساب بانکی معتبر وارد کنید")]
    public long BankAccountNumber { get; set; }

    [RegularExpression("^(?!0{1,2}\\d)[1-9]\\d*$",
            ErrorMessage = "شماره موبایل معتبر وارد کنید")]

    public string PhoneNumber { get; set; } = string.Empty;

    //[RegularExpression("^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/13\\d{2}$",
    //       ErrorMessage = "تاریخ معتبر وارد کنید")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

}
