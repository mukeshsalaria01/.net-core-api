using Microsoft.AspNetCore.Http;

namespace NexusCanadaTech.Web.API.Models
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Interests { get; set; }

        public string OauthInfo { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
