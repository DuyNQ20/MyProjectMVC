using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
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

        public static string Path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\" + "FileStorage";
    }
}
