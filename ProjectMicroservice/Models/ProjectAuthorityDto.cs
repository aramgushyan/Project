using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMicroservice.Domain.Entities
{
    internal class ProjectAuthorityDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public UserPrivileg Privileg { get; set; }

    }
    public enum UserPrivileg
    {

        Read,
        Write,
        Admin

    }
}
