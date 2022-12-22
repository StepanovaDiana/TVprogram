using TVprogram.Services.Models;
using TVprogram.Shared.Exceptions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
namespace TVprogram.Test;
[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task DeleteUser_Success()
    {
        var model = new RegisterUserModel(){
            Name = "Test 1",
            Password = "Test 2",
            Email = "test@test",
            //Role = Entities.Models.Role.Admin            
        };

        var resultModel = await authService.RegisterUser(model);
        userService.DeleteUser(resultModel.Id);
        
        Assert.Throws<LogicException>(()=>
            {
                var checkUser = userService.GetUser(resultModel.Id);
            }
        );
    }

    [Test]
    public async Task DeleteUser_NotExisting()
    {
        var randomGuid = Guid.NewGuid();
        Assert.Throws<LogicException>(()=>
            userService.DeleteUser(randomGuid)
        );
    }
}