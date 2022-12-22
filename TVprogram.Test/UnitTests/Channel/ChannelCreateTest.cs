
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
    public async Task CreateChannel_Success()
    {
        var model = new ChannelModel(){
            
            Name  =  "first"
        };

        var addChannel =channelService.AddChannel(model);
        var channel= channelService.GetChannel(addChannel.Id);
    

        Assert.AreEqual(model.ChannelNumber, channel.ChannelNumber);
    
    }

    [Test]
    public async Task CreateChannel_NotExisting()
    {
        var model = new ChannelModel(){
            Name = "number"
           
        };
        var addChannel = channelService.AddChannel(model);

        Assert.Throws<Exception>( ()=>
        {
            channelService.AddChannel(model);
        });   
    }
}