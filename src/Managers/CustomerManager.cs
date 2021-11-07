using System;
using System.Collections.Generic;
using System.Linq;
using Database;

namespace Managers
{
    public  class CustomerManager
    {
        private readonly DataClassesDataContext _context = new DataClassesDataContext();

        public IEnumerable<Customer> GetCustomers()
        {
            var q = from c in _context.Customers
                    select c;
            return q;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            var q = from c in _context.Customers
                    where c.Id == customerId
                    select c;
            return q.SingleOrDefault();
        }

        public void ApproveCustomer(Guid customerId)
        {
            Customer customer = GetCustomerById(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Could not load customer.");
            }
            customer.IsApproved = true;
            _context.SubmitChanges();
        }

        public void RejectCustomer(Guid customerId)
        {
            Customer customer = GetCustomerById(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Could not load customer.");
            }
            customer.IsApproved = false;
            _context.SubmitChanges();
        }

        public void DeleteCustomer(Guid customerId)
        {
            Customer customer = GetCustomerById(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Could not load customer.");
            }
            _context.Customers.DeleteOnSubmit(customer);
            _context.SubmitChanges();
        }

        public void AddCustomer(Guid customerId, string userName)
        {
            Customer customer = new Customer {Id = customerId, UserName = userName };
            _context.Customers.InsertOnSubmit(customer);
            _context.SubmitChanges();
        }
    }
}
