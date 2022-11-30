using TVprogram.Services.Models;
namespace TVprogram.Services.Abstract;

public interface IChannelService
{
    ChannelModel GetChannel(Guid id);

    ChannelModel UpdateChannel(Guid id, UpdateChannelModel channel);

    void DeleteChannel(Guid id);

    PageModel<ChannelPreviewModel> GetChannels(int limit = 20, int offset = 0);
    ChannelModel CreateChannel(ChannelModel channelModel);
}