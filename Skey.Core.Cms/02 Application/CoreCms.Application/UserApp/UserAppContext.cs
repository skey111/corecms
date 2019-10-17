using CoreCms.Application.Interfaces;
using CoreCms.Application.Services;
using CoreCms.ViewModels.LearningModels;
using System.Collections.Generic; 

namespace CoreCms.Application.UserApp
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserAppContext
    {
        private static ILearningService _learningService;

        private static void Init()
        {
            var ser = ServiceLocator.Services.GetService(typeof(ILearningService));
            if (ser != null)
            {
                _learningService = ser as ILearningService;
            }
        }

        /// <summary>
        /// 获取导航菜单 
        /// </summary>
        /// <returns></returns>
        public static List<LearningTypeModel> GetNavs()
        {
            if (_learningService == null)
            {
                Init();
            }

            List<LearningTypeModel> list = new List<LearningTypeModel>();
            var dlist = _learningService.LoadTypes();

            foreach (var item in dlist)
            {
                if (item.ParentId == 0)
                {
                    list.Add(_learningService.ConverToTypeModel(item));
                }
            }

            return list;
        }
    }
}
