﻿using System.Collections.Generic;
using System.IO;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;

namespace Nop.Services.ExportImport
{
    /// <summary>
    /// Export manager interface
    /// </summary>
    public partial interface IExportManager
    {
        /// <summary>
        /// Export manufacturer list to xml
        /// </summary>
        /// <param name="manufacturers">Manufacturers</param>
        /// <returns>Result in XML format</returns>
        string ExportManufacturersToXml(IList<Manufacturer> manufacturers);

        /// <summary>
        /// Export category list to xml
        /// </summary>
        /// <returns>Result in XML format</returns>
        string ExportCategoriesToXml();

        /// <summary>
        /// Export product list to xml
        /// </summary>
        /// <param name="products">Products</param>
        /// <returns>Result in XML format</returns>
        string ExportProductsToXml(IList<Product> products);

        /// <summary>
        /// Export products to XLSX
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="products">Products</param>
        void ExportProductsToXlsx(Stream stream, IList<Product> products);

        /// <summary>
        /// Export order list to xml
        /// </summary>
        /// <param name="orders">Orders</param>
        /// <returns>Result in XML format</returns>
        string ExportOrdersToXml(IList<Order> orders);

        /// <summary>
        /// Export orders to XLSX
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="orders">Orders</param>
        void ExportOrdersToXlsx(Stream stream, IList<Order> orders);
        
        /// <summary>
        /// Export customer list to XLSX
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="customers">Customers</param>
        void ExportCustomersToXlsx(Stream stream, IList<Customer> customers);
        
        /// <summary>
        /// Export customer list to xml
        /// </summary>
        /// <param name="customers">Customers</param>
        /// <returns>Result in XML format</returns>
        string ExportCustomersToXml(IList<Customer> customers);

        /// <summary>
        /// Export newsletter subscribers to TXT
        /// </summary>
        /// <param name="subscriptions">Subscriptions</param>
        /// <returns>Result in TXT (string) format</returns>
        string ExportNewsletterSubscribersToTxt(IList<NewsLetterSubscription> subscriptions);

        /// <summary>
        /// Export states to TXT
        /// </summary>
        /// <param name="states">States</param>
        /// <returns>Result in TXT (string) format</returns>
        string ExportStatesToTxt(IList<StateProvince> states);
    }
}
