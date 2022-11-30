using AutoMapper;
using TVprogram.Entity.Models;
using TVprogram.Repository;
using TVprogram.Services.Abstract;
using TVprogram.Services.Models;

namespace TVprogram.Services.Implementation;

public class ChannelService :IChannelService
{
    private readonly IRepository<Channel> channelRepository;
    private readonly IMapper mapper;
    public ChannelService(IRepository<Channel> channelRepository, IMapper mapper)
    {
        this.channelRepository = channelRepository;
        this.mapper = mapper;
    }

    public void DeleteChannel(Guid id)
    {
        var channelToDelete =channelRepository.GetById(id);
        if (channelToDelete == null)
        {
            throw new Exception("Channel not found");
        }
        channelRepository.Delete(channelToDelete);
    }

    public ChannelModel GetChannel(Guid id)
    {
        var channel =channelRepository.GetById(id);
        return mapper.Map<ChannelModel>(channel);
    }

    public PageModel<ChannelPreviewModel> GetChannels(int limit = 20, int offset = 0)
    {
        var channel =channelRepository.GetAll();
        int totalCount =channel.Count();
        var chunk=channel.OrderBy(x=>x.Name).Skip(offset).Take(limit);

        return new PageModel<ChannelPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ChannelPreviewModel>>(channel),
            TotalCount = totalCount
        };
    }

    public ChannelModel UpdateChannel(Guid id, UpdateChannelModel channel)
    {
        var existingChannel = channelRepository.GetById(id);
        if (existingChannel == null)
        {
            throw new Exception("Channel not found");
        }
        existingChannel.Name=channel.Name;
        existingChannel = channelRepository.Save(existingChannel);
        return mapper.Map<ChannelModel>(existingChannel);
    }
    ChannelModel IChannelService.CreateChannel(ChannelModel channelModel)
    {
       channelRepository.Save(mapper.Map<Entity.Models.Channel>(channelModel));
        return channelModel;
    }
}