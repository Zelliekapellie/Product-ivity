using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_ivity.Models
{
    public class ProductModel 
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public double Price { get; set; }
    }
}