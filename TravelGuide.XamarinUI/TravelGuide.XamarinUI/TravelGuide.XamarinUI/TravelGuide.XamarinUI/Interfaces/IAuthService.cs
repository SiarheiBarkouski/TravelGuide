using System.Threading.Tasks;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.XamarinUI.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> Login();
        void Logout();
    }
}
