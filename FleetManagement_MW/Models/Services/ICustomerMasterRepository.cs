namespace FleetManagement_MW.Models.Services
{
    public interface ICustomerMasterRepository
    {
        CustomerMaster GetCustomerById(long customerId);
        CustomerMaster GetCustomerByEmail(string email);
         Task<CustomerMaster> GetCustomerByIdAsync(long customerId);

        IEnumerable<CustomerMaster> GetAllCustomers();
        void AddCustomer(CustomerMaster customer);
        void UpdateCustomer(CustomerMaster customer);
        void RemoveCustomer(long customerId);
        void SaveChanges();
    }
}
