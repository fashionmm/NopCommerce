
using System.Collections.Generic;

namespace Nop.Web.Infrastructure.Installation
{
    /// <summary>
    /// 安装过程的本地化服务接口
    /// </summary>
    public partial interface IInstallationLocalizationService
    {
        /// <summary>
        /// 获取本地资源值
        /// </summary>
        /// <param name="resourceName">资源名称</param>
        /// <returns>资源值</returns>
        string GetResource(string resourceName);

        /// <summary>
        /// 获取安装页的当前语言。
        /// </summary>
        /// <returns>当前语言</returns>
        InstallationLanguage GetCurrentLanguage();

        /// <summary>
        /// 保存安装页的语言。
        /// </summary>
        /// <param name="languageCode">语言编码</param>
        void SaveCurrentLanguage(string languageCode);

        /// <summary>
        /// 获得可用语言列表。
        /// </summary>
        /// <returns>可安装语言</returns>
        IList<InstallationLanguage> GetAvailableLanguages();
    }
}
