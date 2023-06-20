using DataLayer;
using DataLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Test.Controllers;
[Route("Customer")]
public class CustomerController : Controller
{

    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    [HttpGet("Index")]
    public IActionResult Index()
    {
        return View(_customerRepository.GetAllCustomer());
    }

    [HttpGet("Create")]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Create")]
    public IActionResult Create(InsertCustomerViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (!_customerRepository.IsExistCustomerViewModel(model))
            {
                var customer = new Customer()
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    BankAccountNumber = model.BankAccountNumber,
                    DateOfBirth = model.DateOfBirth,
                };

                _customerRepository.InsertCustomer(customer);
                _customerRepository.Save();
                return RedirectToAction("Index");
            }
        }
        return View(model);
    }


    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        var customer = _customerRepository.GetCustomerById(id);
        if (customer != null)
        {
            var model = new UpdateCustomerViewModel()
            {
                CustomerID = customer.CustomerID,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                BankAccountNumber = customer.BankAccountNumber,
                DateOfBirth = customer.DateOfBirth,
            };

            return View(model);
        }
        return RedirectToAction("Index");

    }


    [HttpPost("Edit/{id}")]
    public IActionResult Edit(UpdateCustomerViewModel model)
    {

        var customer = _customerRepository.GetCustomerById(model.CustomerID);

        if (customer != null)
        {
            if (ModelState.IsValid)
            {
                customer.Firstname = model.Firstname;
                customer.Lastname = model.Lastname;
                customer.Email = model.Email;
                customer.PhoneNumber = model.PhoneNumber;
                customer.BankAccountNumber = model.BankAccountNumber;
                customer.DateOfBirth = model.DateOfBirth;

                _customerRepository.UpdateCustomer(customer);
                _customerRepository.Save();
                return RedirectToAction("Index");

            }
        }

        //return View(model);
        return RedirectToAction("Index");

    }





    [HttpGet("Delete/{id}")]

    public ActionResult Delete(int id)
    {
        var customer = _customerRepository.GetCustomerById(id);

        return View(customer);
    }

    [HttpPost("Delete/{id}")]

    public ActionResult Delete(int? id)
    {
        var customer = _customerRepository.GetCustomerById(id.Value);
        if (customer != null)
        {

            _customerRepository.DeleteCustomer(customer);
            _customerRepository.Save();

            return RedirectToAction("Index");

        }
        return RedirectToAction("Index");

    }



    [HttpGet("Details/{id}")]
    public ActionResult Details(int? id)
    {

        if (id == null)
        {
            return NotFound();
        }
        var customer = _customerRepository.GetCustomerById(id.Value);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);

    }

}
