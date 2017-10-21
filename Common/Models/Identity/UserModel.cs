using System;
using Newtonsoft.Json;

namespace Common
{
    public class UserModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "profilePictureUrl")]
        public string ProfilePictureUrl { get; set; }
    }
}
