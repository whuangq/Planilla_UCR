using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; }
        public String Project_Name { get; }
        public int Publication { get; }
        public String Group { get; }

        public ProjectDTO(int id, String name, int publication, String investigation_group)
        {
            Id = id;
            Project_Name = name;
            Publication = publication;
            Group = investigation_group;
        }

    }
}
