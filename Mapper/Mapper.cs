using MyProject.Models;
using MyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Mapper
{
    public static class Mapper
    {
        public static void ProductMap(this Product destination, ProductView source)
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
            destination.View = source.View;
            destination.Deleted = source.Deleted;
            destination.ManufacturerId = source.ManufacturerId;
            destination.VendorId = source.VendorId;
            destination.ProductCategoryId = source.ProductCategoryId;
            destination.ModifiedAt = now;
            destination.Active = source.Active;
        }

        public static void VendorMap(this Vendor destination, VendorView source)
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

        public static void ManufacturerMap(this Manufacturer destination, ManufacturerView source)
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
    }
}
