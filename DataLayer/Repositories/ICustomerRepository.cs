using DataLayer.ViewModels;

namespace DataLayer;

public interface ICustomerRepository : IDisposable
{
    //bool IsExistCustomer(string firstName, string lastName, string email, DateTime dateOfBirth);
    bool IsExistCustomer(Customer customer);

    IEnumerable<Customer> GetAllCustomer();
    Customer GetCustomerById(int customerId);
    bool InsertCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(Customer customer);
    void Save();
    bool IsExistCustomerViewModel(InsertCustomerViewModel model);
}
