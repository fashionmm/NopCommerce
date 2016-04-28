
using System.Data.Common;

namespace Nop.Core.Data
{
    /// <summary>
    /// 数据提供程序接口
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// 初始化连接工厂
        /// </summary>
        void InitConnectionFactory();

        /// <summary>
        /// 设置数据库初始化
        /// </summary>
        void SetDatabaseInitializer();

        /// <summary>
        /// 初始化数据库
        /// </summary>
        void InitDatabase();

        /// <summary>
        /// 返回一个值，该值指示此数据提供程序是否支持存储过程
        /// </summary>
        bool StoredProceduredSupported { get; }

        /// <summary>
        ///获取一个支持数据库参数对象（存储过程所使用）
        /// </summary>
        /// <returns>Parameter</returns>
        DbParameter GetParameter();
    }
}
