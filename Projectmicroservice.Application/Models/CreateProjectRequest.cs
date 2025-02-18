using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMicroservice.Application
{
    public class CreateProjectRequest
    {
        public int WorkspaceId { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Tint { get; set; }
        [Required]
        public int LeadId { get; set; }

    }
}
