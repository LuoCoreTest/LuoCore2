﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BsaeRole.Request
{
    public class RequestCreateRoleDto:RequestBaseDto
    {
        public RequestCreateRoleDto(Guid roleId, string roleName,string roleDescription, bool isValid, DateTime createTime,string actionUserName, string actionUserInfo) : base(actionUserName, actionUserInfo)
        {
            RoleId = roleId;
            RoleName = roleName;
            this.RoleDescription = roleDescription;
            IsValid = isValid;
            CreateTime = createTime;
        }

        public Guid RoleId { get; protected set; }
        public string RoleName { get; protected set; }
        public string RoleDescription { get;protected set; }
        public bool IsValid { get; protected set; }
        public DateTime CreateTime { get; protected set; }
        
    }
}
