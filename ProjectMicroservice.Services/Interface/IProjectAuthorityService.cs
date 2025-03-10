﻿using ProjectMicroservice.Application;
using ProjectMicroservice.Domain.Entities;
using ProjectMicroservice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMicroservice.Services.Interface
{
    public interface IProjectAuthorityService
    {
        public Task CreateProjectAuthorities(int projectId, UserPrivilege privilege);
        public Task UpdateProjectAuthorities(int projectId,int userId, UserPrivilege privilege);
        public Task<ProjectAuthorityDto> GetAuthoritiesById(int id);
    }
}
