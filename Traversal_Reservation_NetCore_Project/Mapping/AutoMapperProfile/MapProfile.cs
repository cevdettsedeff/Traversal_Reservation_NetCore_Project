using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;

namespace Traversal_Reservation_NetCore_Project.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>();
            CreateMap<Announcement, AnnouncementAddDTO>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();

            CreateMap<AnnouncementListDTO, Announcement>();
            CreateMap<Announcement, AnnouncementListDTO>();

            CreateMap<AnnouncementUpdateDTO, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDTO>();

            CreateMap<ContactUsDTO, ContactUs>().ReverseMap();

        }
    }
}
