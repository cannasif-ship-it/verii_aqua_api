using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class CreateProjectDto
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateProjectDto : CreateProjectDto
    {
    }
}
