﻿using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Web.Models.ShoppingCart
{
    public partial class EstimateShippingModel : BaseNopModel
    {
        public EstimateShippingModel()
        {
            ShippingOptions = new List<ShippingOptionModel>();
            Warnings = new List<string>();
            
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }

        public bool Enabled { get; set; }

        public IList<ShippingOptionModel> ShippingOptions { get; set; }

        public IList<string> Warnings { get; set; }
        
        [NopResourceDisplayName("ShoppingCart.EstimateShipping.Country")]
        public int? CountryId { get; set; }
        [NopResourceDisplayName("ShoppingCart.EstimateShipping.StateProvince")]
        public int? StateProvinceId { get; set; }
        [NopResourceDisplayName("ShoppingCart.EstimateShipping.ZipPostalCode")]
        public string ZipPostalCode { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }

		#region Nested Classes

        public partial class ShippingOptionModel : BaseNopModel
        {
            public string Name { get; set; }

            public string Description { get; set; }

            public string Price { get; set; }
        }

		#endregion
    }
}