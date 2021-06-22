﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Layui.Areas.Admin.Views.TagHelpers
{
    
    public class PermissionMenuTagHelper : TagHelper
    {
        public PermissionMenuTagHelper()
        {

        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //class='layui-nav layui-nav-tree' lay-shrink='all' id='LAY-system-side-menu' lay-filter='layadmin-system-side-menu'
            output.TagName = "ul";
            output.Attributes.Add("class", "layui-nav layui-nav-tree");
            output.Attributes.Add("lay-shrink", "all");
            output.Attributes.Add("id", "LAY-system-side-menu");
            output.Attributes.Add("lay-filter", "layadmin-system-side-menu");
            StringBuilder sbHtml = new StringBuilder();
            StrBuilderHtml(PermissionsList, "li", sbHtml);
            output.Content.SetHtmlContent(sbHtml.ToString());
            return base.ProcessAsync(context, output);
        }
        public List<EntitysModels.Base_Permission> PermissionsList { get; set; }
        public void StrBuilderHtml(List<EntitysModels.Base_Permission> models, string tagStr, StringBuilder sbHtml)
        {
            if (Equals(null, models)) { return; }
            foreach (var m in models)
            {
                if (tagStr.Contains("li"))
                {
                    sbHtml.Append("<li data-name='home' class='layui-nav-item layui-nav-itemed'>");
                    sbHtml.Append("<a href='javascript:; ' lay-tips='" + m.PermissionName + "' lay-direction='2'>");
                    sbHtml.Append("<i class='layui-icon layui-icon-home'></i>");
                    sbHtml.Append("<cite>" + m.PermissionName + "</cite>");
                    sbHtml.Append("</a>");
                    var listModel = models.Where(x => x.PermissionParentId == m.PermissionId).ToList();
                    if (!Equals(null, listModel) && listModel.Count > 0)
                    {
                        sbHtml.Append("<dl class='layui-nav-child'>");
                        StrBuilderHtml(listModel, "dl", sbHtml);
                        sbHtml.Append("</dl");
                    }
                    sbHtml.Append("</li>");
                }
                else
                {
                    sbHtml.Append("<dd data-name='console' class='layui-this'>");
                    sbHtml.Append("<a lay-href='/Admin/Main/Welcome'>欢迎页</a>");
                    var listModel = models.Where(x => x.PermissionParentId == m.PermissionId).ToList();
                    if (!Equals(null, listModel) && listModel.Count > 0)
                    {
                        sbHtml.Append("<dl class='layui-nav-child'>");
                        StrBuilderHtml(listModel, "dl", sbHtml);
                        sbHtml.Append("</dl");
                    }
                    sbHtml.Append("</dd>");
                }

            }

        }
    }
}
