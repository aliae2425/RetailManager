using RMDesktopUI.MVVM.Models;
using System.Threading.Tasks;

namespace RMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticadedUser> Authenticate(string username, string password);
    }
}