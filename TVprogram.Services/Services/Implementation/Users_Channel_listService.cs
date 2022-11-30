using AutoMapper;
using TVprogram.Entity.Models;
using TVprogram.Repository;
using TVprogram.Services.Abstract;
using TVprogram.Services.Models;

namespace TVprogram.Services.Implementation;

public class Users_Channel_listService : IUser_Channel_listService
{
    private readonly IRepository<Users_Channel_list> users_channel_listRepository;
    private readonly IMapper mapper;
    public Users_Channel_listService(IRepository<Users_Channel_list> users_channel_listRepository, IMapper mapper)
    {
        this.users_channel_listRepository = users_channel_listRepository;
        this.mapper = mapper;
    }

    public void DeleteUser_Channel_list(Guid id)
    {
        var user_channel_listToDelete =users_channel_listRepository.GetById(id);
        if (user_channel_listToDelete == null)
        {
            throw new Exception("User_Channel_list not found");
        }
        users_channel_listRepository.Delete(user_channel_listToDelete);
    }

    public User_Channel_listModel GetUser_Channel_List(Guid id)
    {
        var user_channel_list =users_channel_listRepository.GetById(id);
        return mapper.Map<User_Channel_listModel>(user_channel_list);
    }

    public PageModel<User_Channel_listPreviewModel> GetUsers_Channel_list(int limit = 20, int offset = 0)
    {
        var users_channel_list =users_channel_listRepository.GetAll();
        int totalCount = users_channel_list.Count();
        var chunk = users_channel_list.OrderBy(x => x.ChannelId).Skip(offset).Take(limit);

        return new PageModel<User_Channel_listPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<User_Channel_listPreviewModel>>(users_channel_list),
            TotalCount = totalCount
        };
    }

    public User_Channel_listModel UpdateUser_Channel_list(Guid id, UpdateUser_Channel_listModel user_channel_list)
    {
        var existingUser_Channel_list = users_channel_listRepository.GetById(id);
        if (existingUser_Channel_list == null)
        {
            throw new Exception("User_Channel_list not found");
        }
        existingUser_Channel_list.Favorite_Channel=user_channel_list.Favorite_Channel;
        existingUser_Channel_list =users_channel_listRepository.Save(existingUser_Channel_list);
        return mapper.Map<User_Channel_listModel>(existingUser_Channel_list);
    }
    User_Channel_listModel IUser_Channel_listService.CreateUser_Channel_list(CreateUser_Channel_listModel user_channel_listModel)
    {
      var user_channel_list= mapper.Map<Entity.Models.Users_Channel_list>(user_channel_listModel);
       return mapper.Map<User_Channel_listModel>(users_channel_listRepository.Save(user_channel_list));
    }
}