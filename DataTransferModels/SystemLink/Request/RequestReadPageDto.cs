﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModels.SystemLink.Request
{
     public class RequestReadPageDto
     {
          public RequestReadPageDto(int linkID, string linkName, bool? isValid, int pageIndex, int pageSize)
          {
            LinkID = linkID;
               LinkName = linkName;
               IsValid = isValid;
               PageIndex = pageIndex;
               PageSize = pageSize;
          }

          public int LinkID { get;protected set; }
          public string LinkName { get; protected set; }
          public bool? IsValid { get; protected set; }
          public int PageIndex { get; protected set; }
          public int PageSize { get; protected set; }
     }
}
