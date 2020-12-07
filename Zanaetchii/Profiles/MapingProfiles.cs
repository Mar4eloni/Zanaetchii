using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zanaetchii.Models.ViewModels;
using Zanaetcii.Entities.Models;

namespace Zanaetchii.Profiles
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {
            CreateMap<WorkFieldViewModel, WorkField>();
            CreateMap<WorkViewModel, Work>();
            CreateMap<UserViewModel, Users>();
            CreateMap<WorkerViewModel, Worker>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Workfield, opt => opt.MapFrom(src => src.Workfield));
            


            CreateMap<WorkField, WorkFieldViewModel>();
            CreateMap<Work, WorkViewModel>();
            CreateMap<Users, UserViewModel>();
            CreateMap<Worker, WorkerViewModel>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Workfield, opt => opt.MapFrom(src => src.Workfield));
            
        }
    }
}
