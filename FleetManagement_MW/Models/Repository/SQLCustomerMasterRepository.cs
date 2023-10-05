using FleetManagement_MW.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement_MW.Models.Repository
{
    public class SQLCustomerMasterRepository : ICustomerMasterRepository
    {
        private readonly AppDbContext _context;

        public SQLCustomerMasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public CustomerMaster GetCustomerById(long customerId)
        {
            return _context.CustomerMasters
               // .Include(c => c.city)
                //.Include(c => c.state)
                .FirstOrDefault(c => c.customerId == customerId);
        }


        public  CustomerMaster GetCustomerByEmail(string email)
        {
            return _context.CustomerMasters.FirstOrDefault(c => c.email == email);
        }
        public IEnumerable<CustomerMaster> GetAllCustomers()
        {
            return _context.CustomerMasters
               // .Include(c => c.city)
             //   .Include(c => c.state)
                .ToList();
        }

        public void AddCustomer(CustomerMaster customer)
        {
            _context.CustomerMasters.Add(customer);
        }

        public void UpdateCustomer(CustomerMaster customer)
        {
            _context.CustomerMasters.Update(customer);
        }

        public void RemoveCustomer(long customerId)
        {
            var customer = _context.CustomerMasters.Find(customerId);
            if (customer != null)
            {
                _context.CustomerMasters.Remove(customer);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

       public async Task<CustomerMaster> GetCustomerByIdAsync(long customerId)
        {
            return await _context.CustomerMasters.FirstOrDefaultAsync(c => c.customerId == customerId);   
                }
    }
}

