using MyProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.ViewModels
{
    public class ProductView
    {
        public string Name { get; set; }
        /// <summary>
        /// thông số kỹ thuật
        /// </summary>
        public string Specifications { get; set; }

        public string Decriptions { get; set; }

        /// <summary>
        /// Giá gốc
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// Giá bán
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// Tồn kho
        /// </summary>
        public int Inventory { get; set; }

        // Hàng mới
        public bool IsNew { get; set; }
        
        
        /// <summary>
        /// Nhà cung cấp
        /// </summary>
        public int VendorId { get; set; }

        public int ProductCategoryId { get; set; }

        public int StatusId { get; set; }

        public int SupplierId { get; set; }

    }
}
