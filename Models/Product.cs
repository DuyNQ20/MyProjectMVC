using CatalogService.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// thông số kỹ thuật
        /// </summary>
        public string Specifications { get; set; }

        public string Decriptions { get; set; }

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
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Nhà cung cấp
        /// </summary>
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
