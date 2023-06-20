using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class CustomerRepository : ICustomerRepository
{
    private readonly MyCustomerContext db;
    public CustomerRepository(MyCustomerContext context)
    {

        this.db = context;

    }



    public IEnumerable<Customer> GetAllCustomer()
    {
        return db.Customers;
    }

    public Customer GetCustomerById(int customerId)
    {
        return db.Customers.Find(customerId);
    }



    //public bool IsExistCustomer(string firstName, string lastName, string email, DateTime dateOfBirth)
    //{
    //    return db.Customers.Any(a => a.Firstname == firstName || a.Lastname == lastName ||
    //      a.Email == email || a.DateOfBirth == dateOfBirth);

    //}
    public bool IsExistCustomer(Customer customer)
    {
        return db.Customers.Any(a => a.Firstname == customer.Firstname || a.Lastname == customer.Lastname ||
          a.Email == customer.Email || a.DateOfBirth == customer.DateOfBirth);

    }


    public bool InsertCustomer(Customer customer)
    {
        db.Add(customer);
        return true;
    }



    public bool UpdateCustomer(Customer customer)
    {
        db.Entry(customer).State = EntityState.Modified;
        return true;
    }
    public bool DeleteCustomer(Customer customer)
    {
        db.Entry(customer).State = EntityState.Deleted;
        return true;
    }

    public void Dispose()
    {
        db.Dispose();
    }
    public void Save()
    {
        db.SaveChanges();
    }

    public bool IsExistCustomerViewModel(InsertCustomerViewModel model)
    {
        return db.Customers.Any(a => a.Firstname == model.Firstname || a.Lastname == model.Lastname ||
           a.Email == model.Email || a.DateOfBirth == model.DateOfBirth);
    }
}
