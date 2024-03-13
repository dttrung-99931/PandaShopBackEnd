using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PandaShoppingAPI.DataAccesses.EF
{
    public partial class EcommerceDBContext : DbContext
    {
        public EcommerceDBContext()
        {
        }

        public EcommerceDBContext(DbContextOptions<EcommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetail> CartDetail { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public virtual DbSet<DeliveryPartner> DeliveryPartner { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Order_> Order_ { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductOption> ProductOption { get; set; }
        public virtual DbSet<ProductOptionImage> ProductOptionImage { get; set; }
        public virtual DbSet<ProductOptionValue> ProductOptionValue { get; set; }
        public virtual DbSet<ProductPropertyValue> ProductPropertyValue { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyTemplate> PropertyTemplate { get; set; }
        public virtual DbSet<PropertyTemplateValue> PropertyTemplateValue { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<User_> User_ { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=PandaShopDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.communeOrWard)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.district)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.districtCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.provinceOrCity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.provinceOrCityCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.streetAndHouseNum)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasOne(d => d.cart)
                    .WithMany(p => p.CartDetail)
                    .HasForeignKey(d => d.cartId)
                    .HasConstraintName("FK_CartDetail_Cart");

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.CartDetail)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_CartDetail_ProductOption");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.level).HasDefaultValueSql("((1))");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.image)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.imageId)
                    .HasConstraintName("FK_Category_Image");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentId)
                    .HasConstraintName("FK_Category_Category");

                entity.HasOne(d => d.template)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.templateId)
                    .HasConstraintName("FK_Category_Template");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.Property(e => e.finishedAt).HasColumnType("datetime");

                entity.Property(e => e.startedAt).HasColumnType("datetime");

                entity.Property(e => e.state)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.deliveryMethod)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.deliveryMethodId)
                    .HasConstraintName("FK_Delivery_DeliveryPartner");
            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.pricePerKm).HasColumnType("money");

                entity.HasOne(d => d.deliveryPartner)
                    .WithMany(p => p.DeliveryMethod)
                    .HasForeignKey(d => d.deliveryPartnerId)
                    .HasConstraintName("FK_DeliveryMethod_DeliveryPartner");
            });

            modelBuilder.Entity<DeliveryPartner>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.content).HasMaxLength(500);

                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.starNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.updatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Feedback");

                entity.HasOne(d => d.product)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.productId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Product");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_Feedback_User");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.description).HasMaxLength(100);

                entity.Property(e => e.fileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).HasMaxLength(200);

                entity.HasOne(d => d.order)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.orderId)
                    .HasConstraintName("FK_Invoice_Order");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.discountPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.price).HasColumnType("money");

                entity.HasOne(d => d.order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.orderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_OrderDetail_ProductOption");
            });

            modelBuilder.Entity<Order_>(entity =>
            {
                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).HasMaxLength(200);

                entity.Property(e => e.updatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.address)
                    .WithMany(p => p.Order_)
                    .HasForeignKey(d => d.addressId)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.delivery)
                    .WithMany(p => p.Order_)
                    .HasForeignKey(d => d.deliveryId)
                    .HasConstraintName("FK_Order_Delivery");

                entity.HasOne(d => d.paymentMethod)
                    .WithMany(p => p.Order_)
                    .HasForeignKey(d => d.paymentMethodId)
                    .HasConstraintName("FK_Order_PaymentMethod");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Order_)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.canRead)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.resource)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.resourceId)
                    .HasConstraintName("FK_Permission_Resource");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.HasOne(d => d.address)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.addressId)
                    .HasConstraintName("FK_Product_Address");

                entity.HasOne(d => d.category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.categoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.shop)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.shopId)
                    .HasConstraintName("FK_Product_Shop");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasOne(d => d.image)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.imageId)
                    .HasConstraintName("FK_ProductImage_Image");

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductImage_Product");
            });

            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.price).HasColumnType("money");

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductOption)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductOption_Product");
            });

            modelBuilder.Entity<ProductOptionImage>(entity =>
            {
                entity.HasOne(d => d.image)
                    .WithMany(p => p.ProductOptionImage)
                    .HasForeignKey(d => d.imageId)
                    .HasConstraintName("FK_ProductOptionImage_Image");

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.ProductOptionImage)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_ProductOptionImage_ProductOption");
            });

            modelBuilder.Entity<ProductOptionValue>(entity =>
            {
                entity.Property(e => e.value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.ProductOptionValue)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_ProductOptionValue_ProductOption");

                entity.HasOne(d => d.property)
                    .WithMany(p => p.ProductOptionValue)
                    .HasForeignKey(d => d.propertyId)
                    .HasConstraintName("FK_ProductOptionValue_Property");
            });

            modelBuilder.Entity<ProductPropertyValue>(entity =>
            {
                entity.Property(e => e.value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductPropertyValue)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductPropertyValue_Product");

                entity.HasOne(d => d.property)
                    .WithMany(p => p.ProductPropertyValue)
                    .HasForeignKey(d => d.propertyId)
                    .HasConstraintName("FK_ProductPropertyValue_Property");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasIndex(e => e.secondaryId, "UQ__Property__2D08ACCF1B484926")
                    .IsUnique();

                entity.HasIndex(e => e.secondaryId, "UQ__Property__2D08ACCFB0D82A98")
                    .IsUnique();

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.secondaryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyTemplate>(entity =>
            {
                entity.Property(e => e.isRequired).HasDefaultValueSql("((1))");

                entity.Property(e => e.orderIndex).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.property)
                    .WithMany(p => p.PropertyTemplate)
                    .HasForeignKey(d => d.propertyId)
                    .HasConstraintName("FK_PropertyTemplate_Property");

                entity.HasOne(d => d.template)
                    .WithMany(p => p.PropertyTemplate)
                    .HasForeignKey(d => d.templateId)
                    .HasConstraintName("FK_PropertyTemplate_Template");
            });

            modelBuilder.Entity<PropertyTemplateValue>(entity =>
            {
                entity.Property(e => e.value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.propertyTemplate)
                    .WithMany(p => p.PropertyTemplateValue)
                    .HasForeignKey(d => d.propertyTemplateId)
                    .HasConstraintName("FK_PropertyTemplateValue_PropertyTemplate");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.roleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<User_>(entity =>
            {
                entity.HasIndex(e => e.phone, "Unique_User_Phone")
                    .IsUnique();

                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.updatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.cart)
                    .WithMany(p => p.User_)
                    .HasForeignKey(d => d.cartId)
                    .HasConstraintName("FK_User_Cart");

                entity.HasOne(d => d.shop)
                    .WithMany(p => p.User_)
                    .HasForeignKey(d => d.shopId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_User_Shop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
