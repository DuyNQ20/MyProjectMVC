using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectMVC.Models
{
    public class File : BaseModel
    {
        /// <summary>
        /// Tên gốc của file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phần mở rộng
        /// </summary>
        public string Extention { get; set; }

        /// <summary>
        /// Kích thước file
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Upload bởi
        /// </summary>
        public string UploadedBy { get; set; }

        /// <summary>
        /// Thời gian upload
        /// </summary>
        public DateTime UploadedAt { get; set; }

        /// <summary>
        /// Đường dẫn tương đối trên ổ đĩa
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Đường dẫn
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Mã hash của files
        /// </summary>
        public string Hash { get; set; }

        public bool thumbnail { get; set; }

        /// <summary>
        /// Phân loại file. Ex: Catalog, Hotel, ...
        /// </summary>
        public string Module { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
