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
            modelBuilder.Entity<File>().ToTable("File");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Color>().ToTable("Color");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Cart>().ToTable("Cart");

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
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
                new Supplier
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
                    Name = "Hoàng Hà Mobile",
                    Address = "Địa chỉ Hà Nội",
                    Email = "hoangha@gmail.com",
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
                    Name = "CellPhone S",
                    Address = "Địa chỉ Cầu giấy",
                    Email = "Cellphones@gmail.com",
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
                   Name = "Điện thoại",                   
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               },
               new ProductCategory
               {
                   Id = 2,
                   Name = "Ipad",
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               },
               new ProductCategory
               {
                   Id = 3,
                   Name = "Laptop",
                   Active = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               }
            );
            modelBuilder.Entity<Status>().HasData(
              new Status
              {
                  Id = 1,
                  Name = "Xuất bản",
                  Active = true,
                  CreatedAt = DateTime.Now,
                  CreatedBy = "Quang Duy",
                  ModifiedAt = DateTime.Now,
                  ModifiedBy = "Quang Duy"
              },
              new Status
              {
                  Id = 2,
                  Name = "Chưa xuất bản",
                  Active = true,
                  CreatedAt = DateTime.Now,
                  CreatedBy = "Quang Duy",
                  ModifiedAt = DateTime.Now,
                  ModifiedBy = "Quang Duy"
              }
           );
            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin",
                Active = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "Quang Duy",
                ModifiedAt = DateTime.Now,
                ModifiedBy = "Quang Duy"
            }
         );
            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id = 1,
                  Name = "Xuất bản",
                  Address = "Hà Nội",
                  Email = "user@gmail.com",
                  Phone = "0987654321",
                  Username = "quangduy",
                  Password = "123456",
                  RoleId = 1,
                  Active = true,
                  CreatedAt = DateTime.Now,
                  CreatedBy = "Quang Duy",
                  ModifiedAt = DateTime.Now,
                  ModifiedBy = "Quang Duy"
              }
           );

          

            modelBuilder.Entity<Color>().HasData(
             new Color
             {
                 Id = 1,
                 Name = "Xanh",
                 Active = true,
                 CreatedAt = DateTime.Now,
                 CreatedBy = "Quang Duy",
                 ModifiedAt = DateTime.Now,
                 ModifiedBy = "Quang Duy"
             },
             new Color
             {
                 Id = 2,
                 Name = "Đỏ",
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
                   VendorId = 1,
                   ProductCategoryId = 1,
                   ColorId = 1,
                   StatusId = 1,
                   SupplierId = 1,
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
                   Id = 2,
                   Name = "Samsung X",
                   OriginalPrice = 20000000,
                   SalePrice = 25000000,
                   Specifications = "Nhà sản xuất:Apple </br>Hệ điều hành: iOS 11 </br>Kích thước:	143,6 x 70,9 x 7,7 mm </br>Trọng lượng: 174g </br>Ngày giới thiệu:	13 / 09 / 2017",
                   Decriptions = "Cuối cùng iPhone X cũng đã ra mắt trong sự kiện diễn ra rạng sáng nay (13/9) theo giờ Việt Nam. </br>Đây là sản phẩm được Apple tung ra để kỷ niệm 10 năm iPhone.",
                   Inventory = 1000,
                   IsNew = true,
                   View = 500,
                   VendorId = 1,
                   ProductCategoryId = 1,
                   ColorId = 1,
                   StatusId = 1,
                   SupplierId = 1,
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
            modelBuilder.Entity<File>().HasData(
               new File
               {
                   Id = 1,
                   ProductId = 1,
                   Path = "images\\smartphone\\iphonex.png",
                   Name = "iphonex",
                   Extention = ".png",
                   thumbnail = true,
                   CreatedAt = DateTime.Now,
                   CreatedBy = "Quang Duy",
                   ModifiedAt = DateTime.Now,
                   ModifiedBy = "Quang Duy"
               }
            );

            modelBuilder.Entity<Cart>().HasData(
              new Cart
              {
                  Id = 1,
                  ProductId = 1,
                  UserId = 1,
                  Active = true,                  
                  CreatedAt = DateTime.Now,
                  CreatedBy = "Quang Duy",
                  ModifiedAt = DateTime.Now,
                  ModifiedBy = "Quang Duy"
              }
           );

            modelBuilder.Entity<Cart>().HasData(
              new Cart
              {
                  Id = 2,
                  ProductId = 2,
                  UserId = 1,
                  Active = true,
                  CreatedAt = DateTime.Now,
                  CreatedBy = "Quang Duy",
                  ModifiedAt = DateTime.Now,
                  ModifiedBy = "Quang Duy"
              }
           );

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
