using System;


namespace MyProjectMVC
{
    public class StorageConfiguration
    {
        /// <summary>
        /// thư mục gốc để upload file
        /// </summary>
        public static string StorageDirectory { get; set; }
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
            StorageDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\", "wwwroot","images","smartphone"));
            
            Path = System.IO.Path.Combine("images", "smartphone"); // Tạo đường dẫn tương đối
        }
    }
}
