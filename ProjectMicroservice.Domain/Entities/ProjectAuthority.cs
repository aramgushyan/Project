using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMicroservice.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjectMicroservice.Domain.Entities
{
    public class ProjectAuthority
    {
        [Key]
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public UserPrivilege Privilege { get; set; }
        public Project Project { get; set; } 

    }

}