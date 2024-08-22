using RMDesktopUI.MVVM.Models;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.API
{
    public interface IAPIHelper
    {
        Task<AuthenticadedUser> Authenticate(string username, string password);
    }
}