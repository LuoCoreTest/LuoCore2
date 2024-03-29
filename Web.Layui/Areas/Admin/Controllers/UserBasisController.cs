﻿using Common;
using CrossCutting.Filters;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.UserBasis.Request;

namespace Web.Layui.Areas.Admin.Controllers
{

    [TypeFilter(typeof(AdminLoginAuthorizationFilter))]
    public class UserBasisController : BaseController<IUserBasisService>
    {
        public UserBasisController(IUserBasisService service) : base(service)
        {
        }

        public IActionResult PermissionManage()
        {
            return View();
        }

        public async Task<IActionResult> PermissionSelectBoxAsync()
        {
            List<ViewModels.Layui.SelectBoxVm> res = new List<ViewModels.Layui.SelectBoxVm>();
            ViewModels.Layui.SelectBoxVm selectbox = new ViewModels.Layui.SelectBoxVm() { Name = "顶级", value = "" };
            var result = await _SERVICE.GetPermissionSelectBoxAsync(selectbox.value);
            if (result.Status && !Equals(null, result.Data))
            {
                selectbox.children = result.Data;
            }
            res.Add(selectbox);
            return Json(res);
        }

        public async Task<IActionResult> PermissionTableAsync(ViewModels.UserBasis.Request.RequestGetPermissionVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            res = await _SERVICE.GetPermissionTable(req);
            return Json(res);
        }

        public IActionResult PermissionDialog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PermissionCreateAsync(ViewModels.UserBasis.Request.RequestAddPermissionVm req)
        {

            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            ResultVm res = await _SERVICE.AddPermission(req);
            return Json(res);
        }
        [HttpPut]
        public async Task<IActionResult> PermissionUpdateByIdAsync(ViewModels.UserBasis.Request.RequestUpdatePermissionVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            ResultVm res = await _SERVICE.UpdatePermissionById(req);
            return Json(res);
        }

        [HttpDelete]
        public async Task<IActionResult> PermissionDeleteByIdsAsync(ViewModels.UserBasis.Request.RequestDeletePermissionVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            ResultVm res = await _SERVICE.DeletePermissionByIds(req);
            return Json(res);
        }

        public IActionResult RoleManage()
        {
            return View();
        }

        public async Task<IActionResult> RoleTableAsync(ViewModels.UserBasis.Request.RequestGetRoleVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            res = await _SERVICE.GetRoleTable(req);
            return Json(res);
        }


        public IActionResult RoleDialog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreateAsync(RequestAddRoleVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            ResultVm res = await _SERVICE.AddRole(req);
            return Json(res);
        }

        [HttpPut]
        public async Task<IActionResult> RoleUpdateByIdAsync(RequestUpdateRoleVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            ResultVm res = await _SERVICE.UpdateRoleById(req);
            return Json(res);
        }

        public IActionResult RolePermissionDialog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RolePermissionCreate(RequestAddRolePermissionVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            ResultVm res = await _SERVICE.AddRolePermission(req);
            return Json(res);
        }

        /// <summary>
        /// 获取所有权限树形结构
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetPermissionTreeAsync(string roleId)
        {
            List<ViewModels.Layui.TreeVm> treeDatas = new List<ViewModels.Layui.TreeVm>();

            var tree = new ViewModels.Layui.TreeVm() { title = "顶级", id = "" };
            var result = await _SERVICE.GetPermissionTreeBoxByRoleIdAsync(tree.id, roleId);
            if (result.Status && !Equals(null, result.Data))
            {
                tree.spread = true;
                tree.@checked = false;
                tree.children = new List<ViewModels.Layui.TreeVm>();
                tree.children = result.Data;
            }
            treeDatas.Add(tree);
            return Json(treeDatas);
        }


        public async Task<IActionResult> GetRolePermissionAsync(string roleId)
        {
            var result = await _SERVICE.GetRolePermissionByRoleIdAsync(roleId);
            
            return Json(result);
        }

        public async Task<IActionResult> AddRolePermissionAsync(RequestAddRolePermissionVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            var result = await _SERVICE.AddRolePermission(req);
            return Json(result);
        }


        public IActionResult UserManage()
        {
            return View();
        }

        public async Task<IActionResult> GetUserInfoAsync(RequestGetUserVm req)
        {
            ViewModels.Layui.TableVm res = new ViewModels.Layui.TableVm();
            res = await _SERVICE.GetUserTable(req);
            return Json(res);
        }


        public IActionResult UserDialog() 
        {
            return View();
        }


        public async Task<IActionResult> GetValidRoleSelectBoxAsync(string userId)
        {
            var res = await _SERVICE.GetRoleSelectBox(userId);
            return Json(res);
        }

        public async Task<IActionResult> UserCreateAsync(RequestAddUserVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            var res = await _SERVICE.UserCreate(req);
            return Json(res);
        }

        public async Task<IActionResult> UserUpdateByIdAsync(RequestUpdateUserVm req)
        {
            req.ActionUserInfo = User.FindFirst("UserDataInfo").Value;
            req.ActionUserName = User.Identity.Name;
            var res = await _SERVICE.UserUpdateById(req);
            return Json(res);
        }
    }
}
