using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Tint { get; set; }
        public int LeadId { get; set; } 
        public int WorkSpaceId { get; set; }

        public ICollection<ProjectAuthority> Authorities { get; set; }

    }
}
