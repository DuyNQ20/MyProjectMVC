using CatalogService.Api.Data;
using MyProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class Product : BaseModel
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
        

        /// <summary>
        /// Nhà cung cấp
        /// </summary>
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        /// <summary>
        /// Thương hiệu (nhà sản xuất)
        /// </summary>
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }


        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<File> Files { get; set; }
    }
}
