using System;
using TravelGuide.Core.Common.Enums;
using TravelGuide.Core.Common.Interfaces;

namespace TravelGuide.Core.Common.Entities
{
    public class User : IEntity<long>
    {
        public long Id { get; set; }
        public string SocialId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsOnline { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpireAt { get; set; }
        public LoginSource LoginSource { get; set; }
    }
}