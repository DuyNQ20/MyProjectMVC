using System;


namespace MyProjectMVC
{
    public class StorageConfiguration
    {
        /// <summary>
        /// thư mục gốc để upload file
        /// </summary>
        public string StorageDirectory { get; set; }
        /// <summary>
        /// Đường dẫn đến server
        /// </summary>
        public string FileServerUrl { get; set; }


        /// <summary>
        /// Đường dẫn tương đối file
        /// </summary>
        public static string Path { get; set; }

        public StorageConfiguration()
        {
            Path = "images\\product";
        }
    }
}
