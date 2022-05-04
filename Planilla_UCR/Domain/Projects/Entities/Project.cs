using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Projects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects.Entities
{
    public class Project : AggregateRoot
    {
        public int Id { get; }
        public String Project_Name { get; }
        public int Publication { get; }
        public String Group { get; }

        public Project(int id, String name, int publication, String Group)
        {
            Id = id;
            Project_Name = name;
            Publication = publication;
            Group = Group;
        }

        public Project(int id)
        {
            Id = id;
        }

        public Project(int id, String name)
        {
            Id = id;
            Project_Name = name;
        }
    }
}
