﻿using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Configuration;
using Nop.Core.Events;
using Nop.Core.Infrastructure;
using Nop.Services.Events;

namespace Nop.Admin.Infrastructure.Cache
{
    /// <summary>
    /// Model cache event consumer (used for caching of presentation layer models)
    /// </summary>
    public partial class ModelCacheEventConsumer: 
        //settings
        IConsumer<EntityUpdated<Setting>>,
        //specification attributes
        IConsumer<EntityInserted<SpecificationAttribute>>,
        IConsumer<EntityUpdated<SpecificationAttribute>>,
        IConsumer<EntityDeleted<SpecificationAttribute>>
    {
        /// <summary>
        /// Key for nopCommerce.com news cache
        /// </summary>
        public const string OFFICIAL_NEWS_MODEL_KEY = "Nop.pres.admin.official.news";
        public const string OFFICIAL_NEWS_PATTERN_KEY = "Nop.pres.admin.official.news";
        
        /// <summary>
        /// Key for specification attributes caching (product details page)
        /// </summary>
        public const string SPEC_ATTRIBUTES_MODEL_KEY = "Nop.pres.admin.product.specs";
        public const string SPEC_ATTRIBUTES_PATTERN_KEY = "Nop.pres.admin.product.specs";


        private readonly ICacheManager _cacheManager;
        
        public ModelCacheEventConsumer()
        {
            //TODO inject static cache manager using constructor
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("nop_cache_static");
        }

        public void HandleEvent(EntityUpdated<Setting> eventMessage)
        {
            //clear models which depend on settings
            _cacheManager.RemoveByPattern(OFFICIAL_NEWS_PATTERN_KEY); //depends on CommonSettings.HideAdvertisementsOnAdminArea
        }
        
        //specification attributes
        public void HandleEvent(EntityInserted<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(SPEC_ATTRIBUTES_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(SPEC_ATTRIBUTES_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(SPEC_ATTRIBUTES_PATTERN_KEY);
        }
    }
}
