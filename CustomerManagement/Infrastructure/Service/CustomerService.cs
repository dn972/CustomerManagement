using Infrastructure.Entities;
using Infrastructure.Repository;
using System.Linq;

namespace Infrastructure.Service
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return customerRepository.GetById(id);
        }

        public void InsertCustomer(Customer customer)
        {
            customerRepository.Insert(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customerRepository.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            customerRepository.Delete(customer);
        }
    }
}


