using MyProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using MyProjectMVC.Models;

namespace CatalogService.Api.Data
{
    public class DataContext : DbContext
    {
        private DbContextOptions<DataContext> Options { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Options = options;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer
                {
                    Id = 1,
                    Name = "Apple",
                    Info = "Thông tin apple",
                    Logo = "Logo Apple",
                    Active = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Quang Duy",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "Quang Duy"
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "Samsung",
                    Info = "Thông tin samsung",
                    Logo = "Logo Samsung",
                    Active = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Quang Duy",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "Quang Duy"
                }
             );

            modelBuilder.Entity<Vendor>().HasData(
                new Vendor
                {
                    Id = 1,
                    Name = "Apple",
                    Address = "Địa chỉ apple",
                    Email = "apple@gmail.com",
                    Phone = "0987654321",
                    Active = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Quang Duy",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "Quang Duy"
                },
                new Vendor
                {
                    Id = 2,
                    Name = "Samsung",
                    Address = "Địa chỉ samsung",
                    Email = "samsung@gmail.com",
                    Phone = "0123456789",
                    Active = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Quang Duy",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "Quang Duy"
                }
             );

            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory
               {
                   Id = 1,
                   Name = "IPhone",                   
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               },
               new ProductCategory
               {
                   Id = 2,
                   Name = "Samsung",
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               },
               new ProductCategory
               {
                   Id = 3,
                   Name = "Oppo",
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               }
            );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "IPhone X",
                   OriginalPrice = 20000000,
                   SalePrice = 25000000,
                   Specifications = "Nhà sản xuất:Apple </br>Hệ điều hành: iOS 11 </br>Kích thước:	143,6 x 70,9 x 7,7 mm </br>Trọng lượng: 174g </br>Ngày giới thiệu:	13 / 09 / 2017",
                   Decriptions = "Cuối cùng iPhone X cũng đã ra mắt trong sự kiện diễn ra rạng sáng nay (13/9) theo giờ Việt Nam. </br>Đây là sản phẩm được Apple tung ra để kỷ niệm 10 năm iPhone.",
                   Inventory = 1000,
                   IsNew = true,
                   View = 500,
                   Deleted = false,
                   ManufacturerId = 1,
                   VendorId = 1,
                   ProductCategoryId = 1,
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               }
            );

            modelBuilder.Entity<Comment>().HasData(
               new Comment
               {
                   Id = 1,
                   ProductId = 1,
                   content = "Nội dung bình luận 1 cho iphone",
                   Active = true,
                   Delected = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               },
                new Comment
                {
                    Id = 2,
                    ProductId = 1,
                    content = "Nội dung bình luận 2 cho iphone",
                    Delected = false,
                    Active = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Quang Duy",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "Quang Duy"
                }
            );
            modelBuilder.Entity<Image>().HasData(
               new Image
               {
                   Id = 1,
                   ProductId = 1,
                   Url = "images/smartphone/iphonex.jpg",
                   Name = "iphonex",
                   Extention = ".png",
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               }
            );
            
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
    }
}
