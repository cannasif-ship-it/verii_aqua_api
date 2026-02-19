using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class ProjectCageDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long CageId { get; set; }
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
