namespace NexusCanadaTech.Web.API.Core.DbModels
{
    public class User : BaseDbModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] Picture { get; set; }

        public string Interests { get; set; }

        public string OauthInfo { get; set; }

        public bool? IsAuthenticated { get; set; }
    }
}
