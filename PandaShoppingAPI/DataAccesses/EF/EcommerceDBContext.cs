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
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBatch> ProductBatch { get; set; }
        public virtual DbSet<ProductBatchInventory> ProductBatchInventory { get; set; }
        public virtual DbSet<ProductDeliveryMethod> ProductDeliveryMethod { get; set; }
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
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<User_> User_ { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehouseInput> WarehouseInput { get; set; }
        public virtual DbSet<WarehouseOutput> WarehouseOutput { get; set; }
        public virtual DbSet<WarehouseOutputDetail> WarehouseOutputDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.userId, "IX_Address_userId");

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

                entity.Property(e => e.name).HasMaxLength(50);

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

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_Address_User")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasIndex(e => e.cartId, "IX_CartDetail_cartId");

                entity.HasIndex(e => e.productOptionId, "IX_CartDetail_productOptionId");

                entity.HasOne(d => d.cart)
                    .WithMany(p => p.CartDetail)
                    .HasForeignKey(d => d.cartId)
                    .HasConstraintName("FK_CartDetail_Cart")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.CartDetail)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_CartDetail_ProductOption")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.imageId, "IX_Category_imageId");

                entity.HasIndex(e => e.parentId, "IX_Category_parentId");

                entity.HasIndex(e => e.templateId, "IX_Category_templateId");

                entity.Property(e => e.level).HasDefaultValueSql("((1))");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.image)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.imageId)
                    .HasConstraintName("FK_Category_Image")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentId)
                    .HasConstraintName("FK_Category_Category")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.template)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.templateId)
                    .HasConstraintName("FK_Category_Template")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasIndex(e => e.addressId, "IX_Delivery_addressId");

                entity.HasIndex(e => e.deliveryMethodId, "IX_Delivery_deliveryMethodId");

                entity.Property(e => e.finishedAt).HasColumnType("datetime");

                entity.Property(e => e.startedAt).HasColumnType("datetime");

                entity.HasOne(d => d.address)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.addressId)
                    .HasConstraintName("FK_Delivery_Address")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.deliveryMethod)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.deliveryMethodId)
                    .HasConstraintName("FK_Delivery_DeliveryPartner")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.order)
                    .WithOne(p => p.delivery)
                    .HasForeignKey<Delivery>(d => d.orderId)
                    .HasConstraintName("FK_Delivery_Order")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<DeliveryMethod>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                // TODO
                //entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<DeliveryPartner>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasIndex(e => e.parentId, "IX_Feedback_parentId");

                entity.HasIndex(e => e.productId, "IX_Feedback_productId");

                entity.HasIndex(e => e.userId, "IX_Feedback_userId");

                entity.Property(e => e.content).HasMaxLength(500);

                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.starNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.updatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.parent)
                    .WithMany(p => p.Inverseparent)
                    .HasForeignKey(d => d.parentId)
                    .HasConstraintName("FK_Feedback_Feedback")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.product)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_Feedback_Product")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.Feedback)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_Feedback_User")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.description).HasMaxLength(100);

                entity.Property(e => e.fileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).HasMaxLength(200);

                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);

                entity.HasOne(d => d.paymentMethod)
                   .WithMany(p => p.Invoice)
                   .HasForeignKey(d => d.paymentMethodId)
                   .HasConstraintName("FK_Invoice_PaymentMethod")
                   .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                // TODO
                //entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.resourceId, "IX_Permission_resourceId");

                entity.Property(e => e.canRead)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.resource)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.resourceId)
                    .HasConstraintName("FK_Permission_Resource")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.addressId, "IX_Product_addressId");

                entity.HasIndex(e => e.categoryId, "IX_Product_categoryId");

                entity.HasIndex(e => e.shopId, "IX_Product_shopId");

                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.HasOne(d => d.address)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.addressId)
                    .HasConstraintName("FK_Product_Address")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.categoryId)
                    .HasConstraintName("FK_Product_Category")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.shop)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.shopId)
                    .HasConstraintName("FK_Product_Shop")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductBatch>(entity =>
            {
                entity.HasIndex(e => e.productOptionId, "IX_ProductBatch_productOptionId");

                entity.HasIndex(e => e.warehouseInputId, "IX_ProductBatch_warehouseInputId");

                entity.Property(e => e.arriveDate).HasColumnType("datetime");

                entity.Property(e => e.expireDate).HasColumnType("datetime");

                entity.Property(e => e.manufactureDate).HasColumnType("datetime");

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.ProductBatch)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_ProductBatch_ProductOption")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.warehouseInput)
                    .WithMany(p => p.ProductBatch)
                    .HasForeignKey(d => d.warehouseInputId)
                    .HasConstraintName("FK_ProductBatch_WarehouseInput")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductBatchInventory>(entity =>
            {
                entity.HasIndex(e => e.productBatchId, "IX_ProductBatchInventory_productBatchId");

                entity.HasOne(d => d.productBatch)
                    .WithMany(p => p.ProductBatchInventory)
                    .HasForeignKey(d => d.productBatchId)
                    .HasConstraintName("FK_ProductBatchInventory_ProductBatch")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductDeliveryMethod>(entity =>
            {
                entity.HasIndex(e => e.deliveryMethodId, "IX_ProductDeliveryMethod_deliveryMethodId");

                entity.HasIndex(e => e.productId, "IX_ProductDeliveryMethod_productId");

                entity.HasOne(d => d.deliveryMethod)
                    .WithMany(p => p.ProductDeliveryMethod)
                    .HasForeignKey(d => d.deliveryMethodId)
                    .HasConstraintName("FK_ProductDeliveryMethod_DeliveryMethod")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductDeliveryMethod)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductDeliveryMethod_Product")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasIndex(e => e.imageId, "IX_ProductImage_imageId");

                entity.HasIndex(e => e.productId, "IX_ProductImage_productId");

                entity.HasOne(d => d.image)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.imageId)
                    .HasConstraintName("FK_ProductImage_Image")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductImage_Product")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.HasIndex(e => e.productId, "IX_ProductOption_productId");

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.price).HasColumnType("money");

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductOption)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductOption_Product")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductOptionImage>(entity =>
            {
                entity.HasIndex(e => e.imageId, "IX_ProductOptionImage_imageId");

                entity.HasIndex(e => e.productOptionId, "IX_ProductOptionImage_productOptionId");

                entity.HasOne(d => d.image)
                    .WithMany(p => p.ProductOptionImage)
                    .HasForeignKey(d => d.imageId)
                    .HasConstraintName("FK_ProductOptionImage_Image")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.ProductOptionImage)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_ProductOptionImage_ProductOption")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductOptionValue>(entity =>
            {
                entity.HasIndex(e => e.productOptionId, "IX_ProductOptionValue_productOptionId");

                entity.HasIndex(e => e.propertyId, "IX_ProductOptionValue_propertyId");

                entity.Property(e => e.value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.ProductOptionValue)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_ProductOptionValue_ProductOption")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.property)
                    .WithMany(p => p.ProductOptionValue)
                    .HasForeignKey(d => d.propertyId)
                    .HasConstraintName("FK_ProductOptionValue_Property")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<ProductPropertyValue>(entity =>
            {
                entity.HasIndex(e => e.productId, "IX_ProductPropertyValue_productId");

                entity.HasIndex(e => e.propertyId, "IX_ProductPropertyValue_propertyId");

                entity.Property(e => e.value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.product)
                    .WithMany(p => p.ProductPropertyValue)
                    .HasForeignKey(d => d.productId)
                    .HasConstraintName("FK_ProductPropertyValue_Product")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.property)
                    .WithMany(p => p.ProductPropertyValue)
                    .HasForeignKey(d => d.propertyId)
                    .HasConstraintName("FK_ProductPropertyValue_Property")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasIndex(e => e.secondaryId, "UQ__Property__2D08ACCF5EA3BA00")
                    .IsUnique()
                    .HasFilter("([secondaryId] IS NOT NULL)");

                entity.HasIndex(e => e.secondaryId, "UQ__Property__2D08ACCF6D2F21AB")
                    .IsUnique()
                    .HasFilter("([secondaryId] IS NOT NULL)");

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.secondaryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<PropertyTemplate>(entity =>
            {
                entity.HasIndex(e => e.propertyId, "IX_PropertyTemplate_propertyId");

                entity.HasIndex(e => e.templateId, "IX_PropertyTemplate_templateId");

                entity.Property(e => e.isRequired).HasDefaultValueSql("((1))");

                entity.Property(e => e.orderIndex).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.property)
                    .WithMany(p => p.PropertyTemplate)
                    .HasForeignKey(d => d.propertyId)
                    .HasConstraintName("FK_PropertyTemplate_Property")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.template)
                    .WithMany(p => p.PropertyTemplate)
                    .HasForeignKey(d => d.templateId)
                    .HasConstraintName("FK_PropertyTemplate_Template")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<PropertyTemplateValue>(entity =>
            {
                entity.HasIndex(e => e.propertyTemplateId, "IX_PropertyTemplateValue_propertyTemplateId");

                entity.Property(e => e.value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.propertyTemplate)
                    .WithMany(p => p.PropertyTemplateValue)
                    .HasForeignKey(d => d.propertyTemplateId)
                    .HasConstraintName("FK_PropertyTemplateValue_PropertyTemplate")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.id).ValueGeneratedNever();


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.user)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_Order_User")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                entity.HasOne(d => d.invoice)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.invoiceId)
                    .HasConstraintName("FK_Order_Invoice")
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasIndex(e => e.productOptionId, "IX_OrderDetail_productOptionId");

                entity.HasIndex(e => e.orderId, "IX_OrderDetail_orderId");

                entity.Property(e => e.createdAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.discountPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.price).HasColumnType("money");

                entity.HasOne(d => d.productOption)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.productOptionId)
                    .HasConstraintName("FK_OrderDetail_ProductOption")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.orderId)
                    .HasConstraintName("FK_OrderDetail_Order")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.roleId, "IX_UserRole_roleId");

                entity.HasIndex(e => e.userId, "IX_UserRole_userId");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.roleId)
                    .HasConstraintName("FK_UserRole_Role")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.userId)
                    .HasConstraintName("FK_UserRole_User")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<User_>(entity =>
            {
                entity.HasIndex(e => e.cartId, "IX_User__cartId");

                entity.HasIndex(e => e.shopId, "IX_User__shopId");

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
                    .HasConstraintName("FK_User_Cart")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.shop)
                    .WithMany(p => p.User_)
                    .HasForeignKey(d => d.shopId)
                    .HasConstraintName("FK_User_Shop")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasIndex(e => e.addressId, "IX_Warehouse_addressId");

                entity.HasIndex(e => e.shopId, "IX_Warehouse_shopId");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.address)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.addressId)
                    .HasConstraintName("FK_Warehouse_Address")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.shop)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.shopId)
                    .HasConstraintName("FK_Warehouse_Shop")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<WarehouseInput>(entity =>
            {
                entity.HasIndex(e => e.warehouseId, "IX_WarehouseInput_warehouseId");

                entity.Property(e => e.date).HasColumnType("datetime");

                entity.HasOne(d => d.warehouse)
                    .WithMany(p => p.WarehouseInput)
                    .HasForeignKey(d => d.warehouseId)
                    .HasConstraintName("FK_WarehouseInput_Warehouse")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<WarehouseOutput>(entity =>
            {
                entity.Property(e => e.date).HasColumnType("datetime");


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<WarehouseOutputDetail>(entity =>
            {
                entity.HasIndex(e => e.productBatchId, "IX_WarehouseOutputDetail_productBatchId");

                entity.HasIndex(e => e.warehouseOutputId, "IX_WarehouseOutputDetail_warehouseOutputId");

                entity.HasOne(d => d.productBatch)
                    .WithMany(p => p.WarehouseOutputDetail)
                    .HasForeignKey(d => d.productBatchId)
                    .HasConstraintName("FK_WarehouseOutputDetail_ProductBatch")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.warehouseOutput)
                    .WithMany(p => p.WarehouseOutputDetail)
                    .HasForeignKey(d => d.warehouseOutputId)
                    .HasConstraintName("FK_WarehouseOutputDetail_WarehouseOutput")
                    .OnDelete(DeleteBehavior.NoAction);


                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });


            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.isDeleted)
                    .HasDefaultValue(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
