

using NexusCanadaTech.Web.API.Core.DbModels;
using NexusCanadaTech.Web.API.Repositories;

namespace NexusCanadaTech.Web.API.xUnit.InitialData
{
    public class WebApiInitialDataBuilder
    {

        public void Build(NexusRepository context)
        {
            //Add some user            
            context.Users.Add(
                new Core.DbModels.User() { FirstName = "sumit", LastName = "Thakur",Email = "sumitthakur841@gmail.com",Interests = "Cricket"});
            context.Users.Add(
                new Core.DbModels.User() { FirstName = "mukesh", LastName = "Thakur", Email = "mukeshsalaria01@gmail.com", Interests = "Cricket" });
            context.Users.Add(
                new Core.DbModels.User() { FirstName = "ankush", LastName = "sharma", Email = "ankush@gmail.com", Interests = "Cricket" });
            context.SaveChanges();
            
        }

    }
}
