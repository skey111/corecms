using CoreCms.Application.Entity;
using CoreCms.Application.Interfaces;
using CoreCms.ViewModels.LearningModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skey.CoreCms.Layouts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skey.CoreCms.Layouts.Controllers
{
    /// <summary>
    /// 知识库管理
    /// </summary>
    public partial class LearningController : BaseUserController
    {
        private readonly ILogger<LearningController> _logger;
        ILearningService _learningService;
        public LearningController(ILogger<LearningController> logger, ILearningService learningService)
        {
            _logger = logger;
            _learningService = learningService;
        }

        /// <summary>
        /// 内容管理
        /// </summary>
        /// <returns></returns>
        public IActionResult LearningInfoList()
        {
            QueryPara queryPara = new QueryPara();

            var result = _learningService.QueryInfos(queryPara);

            List<LearningInfoModel> dlist = new List<LearningInfoModel>();
            foreach (var item in result.Data)
            {
                dlist.Add(_learningService.ConverToInfoModel(item));
            }

            return View(dlist);
        }

        /// <summary>
        /// 编辑内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult LearningInfoEdit(LearningInfoModel model)
        {
            LearningInfoModel vmodel = new LearningInfoModel();
            string id = GetParameterViewBag("id");

            if (!string.IsNullOrEmpty(id))
            {
                var info = _learningService.SingleInfo(id);
                vmodel = _learningService.ConverToInfoModel(info);

            }

            View(vmodel);


            if (Post)
            {
                model.SetBase(HttpContext);

                if (string.IsNullOrEmpty(id))
                {
                    var result = _learningService.AddInfo(model);
                }
                else
                {
                    var result = _learningService.UpdateInfo(model);
                }

                return RedirectToAction("LearningInfoList", "Learning");
            }

            return View();
        }

        /// <summary>
        /// 分类管理
        /// </summary>
        /// <returns></returns>
        public IActionResult LearningTypeList()
        {
            QueryPara queryPara = new QueryPara();

            var result = _learningService.LoadTypes();

            List<LearningTypeModel> dlist = new List<LearningTypeModel>();
            var treeData = _learningService.ConverTree(result.ToList());
            foreach (var item in treeData)
            {
                dlist.Add(_learningService.ConverToTypeModel(item));
            }

            return View(dlist);
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <returns></returns>
        public IActionResult LearningTypeEdit(LearningTypeModel model)
        {
            LearningTypeModel vmodel = new LearningTypeModel();
            string id = GetParameterViewBag("id");

            if (!string.IsNullOrEmpty(id))
            {
                var info = _learningService.SingleType(id);
                vmodel = _learningService.ConverToTypeModel(info);
            }

            View(vmodel);


            if (Post)
            {
                model.SetBase(HttpContext);

                if (string.IsNullOrEmpty(id))
                {
                    var result = _learningService.AddType(model);
                }
                else
                {
                    var result = _learningService.UpdateType(model);
                }

                return RedirectToAction("LearningTypeList", "Learning");
            }

            return View();
        }

    }
}
