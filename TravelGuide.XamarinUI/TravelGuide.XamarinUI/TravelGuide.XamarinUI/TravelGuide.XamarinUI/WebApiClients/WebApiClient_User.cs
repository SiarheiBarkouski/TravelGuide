using System.Collections.Generic;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.XamarinUI.WebApiClients
{
    public partial class WebApiClient
    {
        public User GetUserLoginInfo(string socialId)
        {
            return Get<User>($"/api/User/Get?socialId={socialId}");
        }

        public User AddUser(User user)
        {
            return Post<User, User>($"/api/User/Add", user);
        }

        public List<Route> GetRoutes()
        {
            return Get<List<Route>>("/api/Route/Get");
        }

        //public User GetUserByName(string userName)
        //{
        //    return Get<User>($"/api/User/GetUserByName?userName={userName}");
        //}

        //public User Authenticate(string userName, string password)
        //{
        //    return Get<User>($"/api/User/Authenticate?userName={userName}&password={password}");
        //}

        //public IList<UserRoleViewResult> GetUserRoles(Guid userId)
        //{
        //    return Get<IList<UserRoleViewResult>>($"/api/User/GetUserRoles?userId={userId.ToString()}");
        //}

        //public List<UserMenusViewResult> GetUserMenus(string[] roles)
        //{
        //    return Post<string[], List<UserMenusViewResult>>("/api/User/GetUserMenus", roles);
        //}
    }
}