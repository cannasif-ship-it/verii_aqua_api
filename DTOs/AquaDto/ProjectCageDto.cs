using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class ProjectCageDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public long CageId { get; set; }
        public string? CageCode { get; set; }
        public string? CageName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReleasedDate { get; set; }
    }

    public class CreateProjectCageDto
    {
        public long ProjectId { get; set; }
        public long CageId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReleasedDate { get; set; }
    }

    public class UpdateProjectCageDto : CreateProjectCageDto
    {
    }
}
