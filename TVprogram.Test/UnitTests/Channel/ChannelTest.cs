using TVprogram.Entity.Models;
using TVprogram.Services.Models;
using TVprogram.Shared.Exceptions;
using NUnit.Framework;
namespace TVprogram.Test;

[TestFixture]
public partial class ChannelTests : UnitTest
{
    private  IChannelService channelService;
    private  IRepository<Entities.Models.Channel> channelRepository;
    
    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        channelService = services.Get<IchannelService>();
        channelRepository = services.Get<IRepository<Entities.Models.Channel>>();
    }

    protected async override Task ClearDb()
    {
        var channelRepository = services.Get<IRepository<Entities.Models.channel>>();
        var channels = channelRepository.GetAll().ToList();
        foreach(var channel in channels)
        {
            channelRepository.Delete(channel);
        }
    }

}
