using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.ViewModels
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
        /// Lượt xem
        /// </summary>
        public int View { get; set; }



        public bool Deleted { get; set; }

        /// <summary>
        /// Nhà sản xuất
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Nhà cung cấp
        /// </summary>
        public int VendorId { get; set; }

        public int ProductCategoryId { get; set; }

        public bool Active;
    }
}
