using Android.App;
using Android.Content;
using TravelGuide.Core.Common.Entities;
using TravelGuide.XamarinUI.Interfaces;

namespace TravelGuide.XamarinUI.Droid.AuthServices
{
    public class PreLoadLoginHandler : IPreLoadLoginHandler
    {
        public User GetLoginInformation()
        {
            return new User
            {
                SocialId = GetString("UserSocialId")
            };
        }

        public void UpdateLoginInformation(User user)
        {
            if (!string.IsNullOrEmpty(user.SocialId))
            {
                SaveString("UserSocialId", user.SocialId);
            }
        }

        private string GetString(string key)
        {
            var prefs = Application.Context.GetSharedPreferences(Application.Context.PackageName, FileCreationMode.Private);
            return prefs.GetString(key, string.Empty);
        }

        private void SaveString(string key, string value)
        {
            var prefs = Application.Context.GetSharedPreferences(Application.Context.PackageName, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            if (prefs.Contains(key))
                prefEditor.Remove(key);
            prefEditor.PutString(key, value);
            prefEditor.Commit();
        }
    }
}