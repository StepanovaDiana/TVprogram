using TVprogram.Entity.Models;
using TVprogram.Services.Models;
using TVprogram.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
namespace TVprogram.Test;
[TestFixture]
public partial class ChannelTests
{
    [Test]
    public async Task GetTrain_Success()
    {
        var model = new ChannelModel(){
            Name = "Diana",
          
        };

        var channelId = new Guid("E40B66BC-84CE-407D-A3B4-033A340D1E68");
        var channel = channelService.GetChannel(chaannelId);

        Assert.AreEqual(model.Name, channel.ChannelNumber);
      
    }

    [Test]
    public async Task GetChannel_NotExisting()
    {
        var channelId = new Guid("E40B66BC-84CE-407D-A3B4-033A340D1E68");

        Assert.Throws<Exception>( ()=>
        {
            channelService.GetChannel(channelId);
        });   
    }
}