using System;
using System.Collections.Generic;

namespace Nop.Core.Data
{
    /// <summary>
    /// 数据设置信息类 (connection string information)
    /// </summary>
    public partial class DataSettings
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DataSettings()
        {
            RawDataSettings=new Dictionary<string, string>();
        }

        /// <summary>
        ///数据提供者
        /// </summary>
        public string DataProvider { get; set; }

        /// <summary>
        /// 数据链接字符串
        /// </summary>
        public string DataConnectionString { get; set; }

        /// <summary>
        /// Raw settings file
        /// </summary>
        public IDictionary<string, string> RawDataSettings { get; private set; }

        /// <summary>
        /// 返回一个值，指示是否输入信息是有效的
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return !String.IsNullOrEmpty(this.DataProvider) && !String.IsNullOrEmpty(this.DataConnectionString);
        }
    }
}
