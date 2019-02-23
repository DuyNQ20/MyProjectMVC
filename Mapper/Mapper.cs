using MyProjectMVC.ViewModels;
using MyProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyProjectMVC.Mapper
{
    public static class Mapper
    {

        public static void Map(this Product destination, ProductView source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var now =  DateTime.UtcNow;

            if (destination.CreatedAt == DateTimeOffset.MinValue)
            {
                destination.CreatedAt = now;
            }

            destination.Name = source.Name;
            destination.OriginalPrice = source.OriginalPrice;
            destination.SalePrice = source.SalePrice;
            destination.Specifications = source.Specifications;
            destination.Decriptions = source.Decriptions;
            destination.Inventory = source.Inventory;
            destination.IsNew = source.IsNew;
            destination.VendorId = source.VendorId;
            destination.SupplierId = source.SupplierId;
            destination.ProductCategoryId = source.ProductCategoryId;
            destination.ModifiedAt = now;
            destination.StatusId = source.StatusId;
            destination.Active = source.StatusId==1?true:false;
        }

        public static void SaveMap(this Product destination, ProductView source)
        {
            

            var now = DateTime.UtcNow;

            destination.Name = source.Name;
            destination.OriginalPrice = source.OriginalPrice;
            destination.SalePrice = source.SalePrice;
            destination.Specifications = source.Specifications;
            destination.Decriptions = source.Decriptions;
            destination.Inventory = source.Inventory;
            destination.IsNew = source.IsNew;
            destination.VendorId = source.VendorId;
            destination.SupplierId = source.SupplierId;
            destination.ProductCategoryId = source.ProductCategoryId;
            destination.ModifiedAt = now;
            destination.CreatedAt = now;
            destination.StatusId = source.StatusId;
            destination.Active = source.StatusId == 1 ? true : false;
        }

        public static void Map(this Vendor destination, VendorView source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var now = DateTime.UtcNow;

            if (destination.CreatedAt == null)
            {
                destination.CreatedAt = now;
            }

            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Email = source.Email;
            destination.Phone = source.Phone;
            destination.ModifiedAt = now;
            destination.Active = source.Active;
        }

        public static void Map(this Supplier destination, SupplierView source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var now = DateTime.UtcNow;

            if (destination.CreatedAt == null)
            {
                destination.CreatedAt = now;
            }

            destination.Name = source.Name;
            destination.Info = source.Info;
            destination.Logo = source.Logo;
            destination.ModifiedAt = now;
            destination.Active = source.Active;

        }


        // File
        

        public static void SaveMap(this File destination, IFormFile source)
        {
            var now = DateTime.UtcNow;

            destination.Name = source.Name;
            destination.Size = source.Length;
            destination.UploadedAt = now;
            destination.Path = StorageConfiguration.Path;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <param name="productId">Tham thieu toi Product</param>
        public static void SaveMap(this File destination, IFormFile source, int productId, bool thumbnail=false)
        {
            var now = DateTime.UtcNow;

            destination.Name = source.FileName;
            destination.Size = source.Length;
            destination.UploadedAt = now;
            destination.Path = System.IO.Path.Combine(StorageConfiguration.Path, source.FileName);
            destination.thumbnail = thumbnail;
            destination.ProductId = productId;
        }
    }
}
