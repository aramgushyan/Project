using ProjectMicroservice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectmicroservice.Application.Models
{
    public class UpdateAuthorityRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public UserPrivilege Privilege { get; set; }
    }
}
