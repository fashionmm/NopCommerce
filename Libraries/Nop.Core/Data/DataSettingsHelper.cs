using System;

namespace Nop.Core.Data
{
    /// <summary>
    /// 数据设置帮助类
    /// </summary>
    public partial class DataSettingsHelper
    {
        private static bool? _databaseIsInstalled;

        /// <summary>
        /// 返回一个值，标示数据库是否已安装
        /// </summary>
        /// <returns></returns>
        public static bool DatabaseIsInstalled()
        {
            if (!_databaseIsInstalled.HasValue)
            {
                var manager = new DataSettingsManager();
                var settings = manager.LoadSettings();
                _databaseIsInstalled = settings != null && !String.IsNullOrEmpty(settings.DataConnectionString);
            }
            return _databaseIsInstalled.Value;
        }

        //重置数据库标示信息
        public static void ResetCache()
        {
            _databaseIsInstalled = null;
        }
    }
}
