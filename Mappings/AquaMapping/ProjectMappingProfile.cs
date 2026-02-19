using AutoMapper;
using aqua_api.DTOs;
using aqua_api.Models;

namespace aqua_api.Mappings
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
        }
    }
}
