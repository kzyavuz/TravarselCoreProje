using AutoMapper;
using DTOLayer.DTOs.AnnonuncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.DestinationDTOs;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravarselCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<AnnonuncementAddDTO, Annonuncement>();
            CreateMap<Annonuncement, AnnonuncementAddDTO>();

            CreateMap<AnnonuncementUpdateDTO, Annonuncement>();
            CreateMap<Annonuncement, AnnonuncementUpdateDTO>();

            CreateMap<AnnouncementListDTO, Annonuncement>();
            CreateMap<Annonuncement, AnnouncementListDTO>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();
            
            CreateMap<AppUserSignInDTO, AppUser>();
            CreateMap<AppUser, AppUserSignInDTO>();

            CreateMap<MessageDTO, ContactInfo>().ReverseMap();

            //CreateMap<GuideDTO, Guide>().ReverseMap();
        }
    }
}
