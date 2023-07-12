using EasyForm.Entities;
using System.Threading.Tasks;

namespace EasyForm.Services.Contracts
{
    public interface IApplicationService
    {
        Task<bool> AddApplication(Application application);
    }
}
