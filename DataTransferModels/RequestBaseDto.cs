﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels
{
    public class RequestBaseDto
    {
        public RequestBaseDto(string actionUserName, string actionUserInfo)
        {
            ActionUserName = actionUserName;
            ActionUserInfo = actionUserInfo;
        }

        public string ActionUserName { get; protected set; }
        public string ActionUserInfo { get; protected set; }
    }
}
