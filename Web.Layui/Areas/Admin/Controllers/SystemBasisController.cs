﻿using IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Web.Layui.Areas.Admin.Controllers
{
    public class SystemBasisController : BaseController<ISystemBasisService>
    {
        public SystemBasisController(ISystemBasisService service) : base(service)
        {
        }

        public IActionResult Permission()
        {
            return View();
        }

        public async Task<IActionResult> PermissionSelectBoxAsync()
        {
            List<ViewModels.Layui.SelectBoxVm> res = new List<ViewModels.Layui.SelectBoxVm>();
            ViewModels.Layui.SelectBoxVm selectbox = new ViewModels.Layui.SelectBoxVm() { Name = "顶级", value = "",selected = true };
            var result = await _SERVICE.GetPermissionSelectBoxAsync(selectbox.value);
            if (result.Status && !Equals(null, result.Data))
            {
                selectbox.children = result.Data;
            }
            res.Add(selectbox);
            return Json(res);
        }
    }
}
