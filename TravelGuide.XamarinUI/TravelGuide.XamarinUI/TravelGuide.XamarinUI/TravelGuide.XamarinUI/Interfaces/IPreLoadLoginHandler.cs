using TravelGuide.Core.Common.Entities;

namespace TravelGuide.XamarinUI.Interfaces
{
    public interface IPreLoadLoginHandler
    {
        User GetLoginInformation();

        void UpdateLoginInformation(User user);
    }
}