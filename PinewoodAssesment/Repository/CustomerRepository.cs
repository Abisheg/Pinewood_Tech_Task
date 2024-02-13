namespace PinewoodAssessment.Repositories
{
    using PinewoodAssessment.Models;
    using System.Collections.Generic;

    public class CustomerRepository
    {
        private static CustomerRepository _instance;
        private List<Customer> _customers;

        private CustomerRepository()
        {
            _customers = new List<Customer>
            {
        new Customer {
            Id = 1,
            Name = "Ross",
            Organization = "Org A",
            Contact = "55663345",
            IsActive = true,
            Address = "123 Main St, Cityville",
            ClientType = 1
        },
        new Customer {
            Id = 2,
            Name = "Arnold",
            Organization = "Org D",
            Contact = "12332144",
            IsActive = true,
            Address = "456 Oak St, Townsville",
            ClientType = 2
        },
        new Customer {
            Id = 3,
            Name = "Alice",
            Organization = "Org U",
            Contact = "123123123",
            IsActive = true,
            Address = "789 Elm St, Villagetown",
            ClientType = 1
        },
        new Customer {
            Id = 4,
            Name = "Mohammad",
            Organization = "Org I",
            Contact = "223345",
            IsActive = true,
            Address = "121 Pine St, Sheffield",
            ClientType = 2
        },
        new Customer {
            Id = 5,
            Name = "Ravi",
            Organization = "Org B",
            Contact = "44324234",
            IsActive = true,
            Address = "222 Oak St, Sparkhill",
            ClientType = 1
        },
        new Customer {
            Id = 6,
            Name = "Viki",
            Organization = "Org T",
            Contact = "99889988",
            IsActive = true,
            Address = "333 Maple St, SellyOak",
            ClientType = 2
        },
    };
        }

        public static CustomerRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerRepository();
                }
                return _instance;
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.Find(customer => customer.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            customer.IsActive=true; 
            customer.Id = _customers.Count + 1;
            _customers.Add(customer);
        }

        //Not used
        public void UpdateCustomer(Customer updatedCustomer)
        {
            var existingCustomer = _customers.Find(customer => customer.Id == updatedCustomer.Id);

            if (existingCustomer != null)
            {
                existingCustomer.Name = updatedCustomer.Name;
                existingCustomer.Organization = updatedCustomer.Organization;
                existingCustomer.Contact=updatedCustomer.Contact;
                existingCustomer.Address=updatedCustomer.Address;
            }
        }

        public void DeleteCustomer(int id)
        {
            var customerToRemove = _customers.Find(customer => customer.Id == id);

            if (customerToRemove != null)
            {
                customerToRemove.IsActive= false;
            }
        }
    }
}
