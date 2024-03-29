﻿using EntitysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.BsaeRole.Response
{
    public class ResponseRolePageDto
    {
        public ResponseRolePageDto(List<Base_Role> pageList, int pageCount)
        {
            PageList = pageList;
            PageCount = pageCount;
        }

        public List<EntitysModels.Base_Role> PageList { get;protected set; }
        public int PageCount { get; protected set; }
    }
}
