using EasyForm.Entities;
using System.Threading.Tasks;

namespace EasyForm.Stores.Contracts
{
    public interface IApplicationStore
    {
        Task<bool> AddApplication(Application application);
    }
}
