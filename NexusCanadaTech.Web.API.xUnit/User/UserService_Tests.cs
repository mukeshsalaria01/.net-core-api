using System.Linq;
using System.Threading.Tasks;
using NexusCanadaTech.Web.API.Core.Contracts.Services;
using Shouldly;
using Xunit;
//https://github.com/aspnetboilerplate/aspnetboilerplate-samples/blob/master/SimpleTaskSystem/Tests/SimpleTaskSystem.Test/People/PersonAppService_Tests_With_Mocks.cs
namespace NexusCanadaTech.Web.API.xUnit.User
{
    public class UserService_Tests : WebApiTestServiceBase
    { 
        private readonly IUserService _userService;

        public UserService_Tests()
        {
            _userService = LocalIocManager.Resolve<IUserService>();
        }

        [Fact]
        public async Task Should_Get_All_People()
        {
            var output = _userService.GetAll();
            output.Count().ShouldBe(4);
        }
    }
}
