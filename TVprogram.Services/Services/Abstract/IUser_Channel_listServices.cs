using TVprogram.Services.Models;
namespace TVprogram.Services.Abstract;

public interface IUser_Channel_listService
{
    User_Channel_listModel GetUser_Channel_List(Guid id);

    User_Channel_listModel UpdateUser_Channel_list(Guid id, UpdateUser_Channel_listModel user_channel_list);

    void DeleteUser_Channel_list(Guid id);

    PageModel<User_Channel_listPreviewModel> GetUsers_Channel_list(int limit = 20, int offset = 0);
    User_Channel_listModel CreateUser_Channel_list(CreateUser_Channel_listModel user_channel_listModel);
}