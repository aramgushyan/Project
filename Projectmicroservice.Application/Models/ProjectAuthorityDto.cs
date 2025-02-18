using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProjectMicroservice.Domain.Enums;

namespace ProjectMicroservice.Application
{
    public class ProjectAuthorityDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public UserPrivilege Privilege { get; set; }

        

    }
}
