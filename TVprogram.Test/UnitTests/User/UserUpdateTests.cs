using TVprogram.Services.Models;
using TVprogram.Shared.Exceptions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TVprogram.Entity.Models;
using Microsoft.AspNetCore.Identity;
namespace TVprogram.Test;
[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task UpdateUser_Success()
    {
        var model = new RegisterUserModel(){
            Name = "Test 1",
            Password = "Test 2",
            Email = "test@test",
           // Role = Entities.Models.Role.Admin            
        };

        var resultModel = await authService.RegisterUser(model);

        var newModel = new UpdateUserModel(){
            Name = "new  name"
        };

        var resultModel2 = userService.UpdateUser(resultModel.Id, newModel);

        Assert.AreEqual(resultModel.Email, resultModel2.Email);
        Assert.AreEqual(newModel.Name, resultModel2.Name);
       // Assert.AreEqual(resultModel.Role, resultModel2.Role);
    }

    [Test]
    public async Task UpdateUser_NotExisting()
    {
        var newModel = new UpdateUserModel(){
            Name = "new  name"
        };
        var randonGuid = Guid.NewGuid();

        Assert.Throws<LogicException>( ()=>
        {
            var result = userService.UpdateUser(randonGuid, newModel); 
        });   
    }
}