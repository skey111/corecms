using CoreCms.Application.Config;
using CoreCms.Application.Interfaces;
using CoreCms.Domain.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skey.Core.Framework.Common.Helper;
using Skey.CoreCms.Layouts.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions; 

namespace Skey.CoreCms.Layouts.Controllers
{
    public partial class ServicesController : BaseController
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly ILearningService _learningService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServicesController(ILogger<ServicesController> logger, ILearningService learningService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _learningService = learningService;
            _webHostEnvironment = webHostEnvironment;
        }

        public JsonResult LoadLearningTypes()
        {
            List<LearningType> data = new List<LearningType>();

            data = _learningService.LoadTypes().ToList();

            var tree = _learningService.ConverTree(data);

            return Json(data);
        }

        public JsonResult FileManager()
        {
            var hashtable = GetFiles();
            return Json(hashtable);
        }

        public JsonResult UploadImg()
        {
            var htable = UploadFile();
            return Json(htable);
        }

        #region 上传文件操作
        public Hashtable UploadFile()
        {
            Hashtable hash = new Hashtable();
            //String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);
            string aspxUrl = Appsettings.UploadDirectory;

            //文件保存目录路径
            String savePath = Appsettings.UploadDirectory;

            //文件保存目录URL
            String saveUrl = aspxUrl;

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "gif,jpg,jpeg,png,bmp");
            extTable.Add("flash", "swf,flv");
            extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
            extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2,pdf");

            //最大文件大小
            long maxSize = 3000000000;

            var imgFile = Request.Form.Files["imgFile"];
            if (imgFile == null)
            {
                showError("请选择文件。");
            }

            String dirPath = _webHostEnvironment.WebRootPath + UrlHelper.GetFilePath(savePath);
            //String dirPath = context.Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                showError("上传目录不存在。");
            }

            String dirName = GetParameter("dir");

            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                showError("目录名不正确。");
            }

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();

            if (imgFile == null || imgFile.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }

            //创建文件夹
            dirPath += dirName + "/";
            saveUrl += dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            dirPath += ymd + "/";
            saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = UrlHelper.GetFilePath(dirPath) + newFileName;

            //imgFile.SaveAs(filePath);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                imgFile.CopyTo(fs);
                fs.Flush();
            }

            String fileUrl = saveUrl + newFileName;

            hash["error"] = 0;
            hash["url"] = fileUrl;
            //context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            //context.Response.Write(DN.Framework.Utility.Serializer.SerializeObject(hash));
            //context.Response.End();

            return hash;
        }

        private Hashtable showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            //context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            //context.Response.Write(DN.Framework.Utility.Serializer.SerializeObject(hash));
            //context.Response.End();

            return hash;
        }
        #endregion

        #region 上传文件管理

        private Hashtable GetFiles()
        {
            Hashtable result = new Hashtable();

            String aspxUrl = Request.Path.ToString().Substring(0, Request.Path.ToString().LastIndexOf("/") + 1);

            //根目录路径，相对路径
            String rootPath = Appsettings.UploadDirectory;
            //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
            //String rootUrl = aspxUrl + "../attached/";
            string rootUrl = Appsettings.UploadDirectory;

            //图片扩展名
            String fileTypes = "gif,jpg,jpeg,png,bmp";

            String currentPath = "";
            String currentUrl = "";
            String currentDirPath = "";
            String moveupDirPath = "";

            string webRootPath = _webHostEnvironment.WebRootPath;

            String dirPath = _webHostEnvironment.WebRootPath + rootPath;
            String dirName = GetParameter("dir");
            if (!String.IsNullOrEmpty(dirName))
            {
                if (Array.IndexOf("image,flash,media,file".Split(','), dirName) == -1)
                {
                    //context.Response.Write("Invalid Directory name.");
                    //context.Response.End();
                    return result;
                }
                dirPath += dirName + "/";
                rootUrl += dirName + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }

            //根据path参数，设置各路径和URL
            String path = GetParameter("path");
            path = String.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            String order = GetParameter("order");
            order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                //context.Response.Write("Access is not allowed.");
                //context.Response.End();

                return result;
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                //context.Response.Write("Parameter is not valid.");
                //context.Response.End();

                return result;
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                //context.Response.Write("Directory does not exist.");
                //context.Response.End();

                return result;
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                try
                {
                    FileInfo file = new FileInfo(fileList[i]);
                    Hashtable hash = new Hashtable();
                    hash["is_dir"] = false;
                    hash["has_file"] = false;
                    hash["filesize"] = file.Length;
                    hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                    hash["filetype"] = file.Extension.Substring(1);
                    hash["filename"] = file.Name;
                    hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                    dirFileList.Add(hash);
                }
                catch (Exception)
                {

                }
            }

            return result;
        }

        public class NameSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.FullName.CompareTo(yInfo.FullName);
            }
        }

        public class SizeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Length.CompareTo(yInfo.Length);
            }
        }

        public class TypeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Extension.CompareTo(yInfo.Extension);
            }
        }
        #endregion

    }
}
