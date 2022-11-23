using AutoMapper;
using TVprogram.Entity.Models;
using TVprogram.Services.Models;

namespace TVprogram.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email));

        #endregion

        /*#region Channel

        CreateMap<Channel, ChannelModel>().ReverseMap();
        CreateMap<Channel, ChannelPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name));

        #endregion
        #region Programa

        CreateMap<Programa, ProgramModel>().ReverseMap();
        CreateMap<Programa, ProgramPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Datetime, y => y.MapFrom(u => u.Datetime))
            .ForMember(x => x.Duration, y => y.MapFrom(u => u.Duration));

        #endregion

        #region Users_Channel_list

        CreateMap<User_Channel_list, User_Channel_listModel>().ReverseMap();
        CreateMap<User_Channel_list, Users_Channel_listPreviewModel>()
            .ForMember(x => x.Favorite_Channel, y => y.MapFrom(u => u.Favorite_Channel));
            

        #endregion*/





        
    }
}

