using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        Customer cast2Customer(CustomerCRVM customer2aBCasted);
        CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted);
        CustomerCRVM cast2CustomerCRVM(Customer customer);
        CustomerEditVM cast2CustomerEditVM(Customer customer);
        Customer cast2Customer(CustomerEditVM customer2BCasted);
    }
}