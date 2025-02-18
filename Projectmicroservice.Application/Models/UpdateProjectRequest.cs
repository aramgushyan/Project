using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMicroservice.Application
{
    public class UpdateProjectRequest
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Tint { get; set; }
        public int LeadId { get; set; }
        public int WorkspaceId { get; set; }

    }
}
