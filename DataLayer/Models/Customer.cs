using System.ComponentModel.DataAnnotations;

namespace DataLayer;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;


    public string Email { get; set; } = string.Empty;


    public long BankAccountNumber { get; set; }



    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }





}
