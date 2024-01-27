using AbsenceService.Web.Models.Requests;
using AbsencesService.Domain.Models;
using AutoMapper;

namespace AbsenceService.Web.Mapper
{
    public class RequestsMappingProfile : Profile
    {
        public RequestsMappingProfile()
        {
            CreateMap<CreateAbsenceRequest, CreateAbsenceModel>()
                 .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => new EmployeeModel {Id = src.EmployeeId }));
            CreateMap<UpdateAbsenceRequest, UpdateAbsenceModel>();
            CreateMap<DeleteAbsenceRequest, DeleteAbsenceModel>();
        }
    }
}
