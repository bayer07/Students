using AutoMapper;
using Students.Domain.Models;
using Students.Web.DTOs;
using System.Linq;

namespace Students.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.Patronymic}"))
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => string.Join(",", src.GroupStudents.ToList().Select(x => x.Group.Name))));

            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.GroupStudents.Count));
        }
    }
}
