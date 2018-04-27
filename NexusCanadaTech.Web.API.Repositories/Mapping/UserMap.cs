using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusCanadaTech.Web.API.Core.DbModels;

namespace NexusCanadaTech.Web.API.Repositories.Mapping
{
    internal class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName);
            entityBuilder.Property(t => t.LastName);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.Interests);
            entityBuilder.Property(t => t.OauthInfo);
            entityBuilder.Property(t => t.IsAuthenticated);
            entityBuilder.Property(t => t.DateCreated);
            entityBuilder.Property(t => t.DateModified);
            entityBuilder.Property(t => t.IsDeleted);
        }

    }
}
