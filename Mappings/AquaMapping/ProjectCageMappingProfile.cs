using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class ProjectCageMappingProfile : Profile
    {
        public ProjectCageMappingProfile()
        {
            CreateMap<ProjectCage, ProjectCageDto>();
            CreateMap<CreateProjectCageDto, ProjectCage>();
            CreateMap<UpdateProjectCageDto, ProjectCage>();
        }
    }
}
