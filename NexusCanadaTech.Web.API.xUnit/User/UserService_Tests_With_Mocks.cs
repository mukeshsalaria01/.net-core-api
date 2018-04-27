using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using NexusCanadaTech.Web.API.Core.Contracts.Repositories;
using NexusCanadaTech.Web.API.Core.Contracts.Services;
using NexusCanadaTech.Web.API.Services;
using NSubstitute;
using Shouldly;
using Xunit;

namespace NexusCanadaTech.Web.API.xUnit.User
{
    public class UserService_Tests_With_Mocks : WebApiTestServiceBase
    {

        private readonly IUserService _userService;

        public UserService_Tests_With_Mocks()
        {
            //Fake repository will contain 2 people
            var users = new List<Core.DbModels.User>
            {
                new Core.DbModels.User {FirstName = "John Nash"},
                new Core.DbModels.User {FirstName = "Forrest Gump"}
            };

            //Create the fake user repository
            var userRepository = Substitute.For<IUserRepository>();

            //Arrange GetAll() method to return the list above
            userRepository.GetAll().Returns(users);

            //Create UserService by providing the fake repository
            _userService = new UserService(userRepository);
        }

        [Fact]
        public async Task Should_Get_All_User()
        {
            //Run testing method
            var output =  _userService.GetAll();

            //Check results
            output.Count().ShouldBe(2);
            output.FirstOrDefault(p => p.FirstName == "John Nash").ShouldNotBe(null);
        }


    }
}
