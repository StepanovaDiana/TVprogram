using AutoMapper;
using TVprogram.WebAPI.Models;
using TVprogram.Services.Models;

namespace TVprogram.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region Pages

        CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
        CreateMap<UserResponse, UserPreviewModel>().ReverseMap();
        
        #endregion

        #region Channels

        CreateMap<ChannelModel, ChannelResponse>().ReverseMap();
        CreateMap<UpdateChannelRequest, UpdateChannelModel>().ReverseMap();
        CreateMap<ChannelPreviewModel, ChannelPreviewResponse>().ReverseMap();
        CreateMap<ChannelResponse, ChannelPreviewModel>().ReverseMap();
        
        #endregion

        #region Programs

        CreateMap<ProgramModel, ProgramResponse>().ReverseMap();
        CreateMap<UpdateProgramRequest, UpdateProgramModel>().ReverseMap();
        CreateMap<ProgramPreviewModel, ProgramPreviewResponse>().ReverseMap();
        CreateMap<ProgramResponse, ProgramPreviewModel>().ReverseMap();
        
        #endregion

        #region Users_Channel_list

        CreateMap<User_Channel_listModel, User_Channel_listResponse>().ReverseMap();
        CreateMap<UpdateUser_Channel_listRequest, UpdateUser_Channel_listModel>().ReverseMap();
        CreateMap<User_Channel_listPreviewModel, User_Channel_listPreviewResponse>().ReverseMap();
        CreateMap<User_Channel_listResponse, User_Channel_listPreviewModel>().ReverseMap();
        
        #endregion

        #region Admin

        CreateMap<AdminModel, AdminResponse>().ReverseMap();
        CreateMap<UpdateAdminRequest, UpdateAdminModel>().ReverseMap();
        CreateMap<AdminPreviewModel, AdminPreviewResponse>().ReverseMap();
        CreateMap<AdminResponse, AdminPreviewModel>().ReverseMap();
        
        #endregion

    }
}
