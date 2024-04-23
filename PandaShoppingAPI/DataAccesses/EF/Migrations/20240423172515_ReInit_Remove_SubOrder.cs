using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class ReInit_Remove_SubOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maxDeliveryHours = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPartner",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPartner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    fileName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    secondaryId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseOutput",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseOutput", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    paymentMethodId = table.Column<int>(type: "int", nullable: false),
                    paymentStatus = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.id);
                    table.ForeignKey(
                        name: "FK_Invoice_PaymentMethod_paymentMethodId",
                        column: x => x.paymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    resourceId = table.Column<int>(type: "int", nullable: false),
                    canRead = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    canWrite = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_Permission_Resource",
                        column: x => x.resourceId,
                        principalTable: "Resource",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User_",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    shopId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Cart",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_User_Shop",
                        column: x => x.shopId,
                        principalTable: "Shop",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    level = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    imageId = table.Column<int>(type: "int", nullable: true),
                    templateId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.parentId,
                        principalTable: "Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Category_Image",
                        column: x => x.imageId,
                        principalTable: "Image",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Category_Template",
                        column: x => x.templateId,
                        principalTable: "Template",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTemplate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    templateId = table.Column<int>(type: "int", nullable: false),
                    propertyId = table.Column<int>(type: "int", nullable: false),
                    isRequired = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    orderIndex = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTemplate", x => x.id);
                    table.ForeignKey(
                        name: "FK_PropertyTemplate_Property",
                        column: x => x.propertyId,
                        principalTable: "Property",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PropertyTemplate_Template",
                        column: x => x.templateId,
                        principalTable: "Template",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    provinceOrCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    provinceOrCityCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    district = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    districtCode = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    communeOrWard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    streetAndHouseNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_User",
                        column: x => x.userId,
                        principalTable: "User_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    invoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodid = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Invoice",
                        column: x => x.userId,
                        principalTable: "Invoice",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Order_PaymentMethod_PaymentMethodid",
                        column: x => x.PaymentMethodid,
                        principalTable: "PaymentMethod",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.userId,
                        principalTable: "User_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserRole_User",
                        column: x => x.userId,
                        principalTable: "User_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyTemplateValue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyTemplateId = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTemplateValue", x => x.id);
                    table.ForeignKey(
                        name: "FK_PropertyTemplateValue_PropertyTemplate",
                        column: x => x.propertyTemplateId,
                        principalTable: "PropertyTemplate",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    starNum = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    sellingNum = table.Column<int>(type: "int", nullable: false),
                    remainingNum = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    shopId = table.Column<int>(type: "int", nullable: false),
                    addressId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Address",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Product_Shop",
                        column: x => x.shopId,
                        principalTable: "Shop",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    addressId = table.Column<int>(type: "int", nullable: false),
                    shopId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Address",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Warehouse_Shop",
                        column: x => x.shopId,
                        principalTable: "Shop",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    finishedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    deliveryMethodId = table.Column<int>(type: "int", nullable: false),
                    addressId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_Delivery_Address",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryPartner",
                        column: x => x.deliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Delivery_Order",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    starNum = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedback_Feedback",
                        column: x => x.parentId,
                        principalTable: "Feedback",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Feedback_Product",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Feedback_User",
                        column: x => x.userId,
                        principalTable: "User_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductDeliveryMethod",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    deliveryMethodId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDeliveryMethod", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductDeliveryMethod_DeliveryMethod",
                        column: x => x.deliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductDeliveryMethod_Product",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    imageId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Image",
                        column: x => x.imageId,
                        principalTable: "Image",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductImage_Product",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductOption",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    productId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductOption_Product",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductPropertyValue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    propertyId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPropertyValue", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductPropertyValue_Product",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductPropertyValue_Property",
                        column: x => x.propertyId,
                        principalTable: "Property",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "WarehouseInput",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehouseId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseInput", x => x.id);
                    table.ForeignKey(
                        name: "FK_WarehouseInput_Warehouse",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productNum = table.Column<int>(type: "int", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    productOptionId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CartDetail_ProductOption",
                        column: x => x.productOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    discountPercent = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    productNum = table.Column<int>(type: "int", nullable: false),
                    productOptionId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_ProductOption",
                        column: x => x.productOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionImage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productOptionId = table.Column<int>(type: "int", nullable: false),
                    imageId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionImage", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductOptionImage_Image",
                        column: x => x.imageId,
                        principalTable: "Image",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductOptionImage_ProductOption",
                        column: x => x.productOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionValue",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productOptionId = table.Column<int>(type: "int", nullable: false),
                    propertyId = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionValue", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductOptionValue_ProductOption",
                        column: x => x.productOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductOptionValue_Property",
                        column: x => x.propertyId,
                        principalTable: "Property",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductBatch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehouseInputId = table.Column<int>(type: "int", nullable: false),
                    productOptionId = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    manufactureDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    arriveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatch", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductBatch_ProductOption",
                        column: x => x.productOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProductBatch_WarehouseInput",
                        column: x => x.warehouseInputId,
                        principalTable: "WarehouseInput",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProductBatchInventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productBatchId = table.Column<int>(type: "int", nullable: false),
                    remainingNumber = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatchInventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductBatchInventory_ProductBatch",
                        column: x => x.productBatchId,
                        principalTable: "ProductBatch",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "WarehouseOutputDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehouseOutputId = table.Column<int>(type: "int", nullable: false),
                    productBatchId = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseOutputDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_WarehouseOutputDetail_ProductBatch",
                        column: x => x.productBatchId,
                        principalTable: "ProductBatch",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_WarehouseOutputDetail_WarehouseOutput",
                        column: x => x.warehouseOutputId,
                        principalTable: "WarehouseOutput",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_userId",
                table: "Address",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_cartId",
                table: "CartDetail",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_productOptionId",
                table: "CartDetail",
                column: "productOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_imageId",
                table: "Category",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_parentId",
                table: "Category",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_templateId",
                table: "Category",
                column: "templateId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_addressId",
                table: "Delivery",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_deliveryMethodId",
                table: "Delivery",
                column: "deliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery",
                column: "orderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_parentId",
                table: "Feedback",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_productId",
                table: "Feedback",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_userId",
                table: "Feedback",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_orderId",
                table: "Invoice",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_paymentMethodId",
                table: "Invoice",
                column: "paymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentMethodid",
                table: "Order",
                column: "PaymentMethodid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderId",
                table: "OrderDetail",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productOptionId",
                table: "OrderDetail",
                column: "productOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_resourceId",
                table: "Permission",
                column: "resourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_addressId",
                table: "Product",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_shopId",
                table: "Product",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatch_productOptionId",
                table: "ProductBatch",
                column: "productOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatch_warehouseInputId",
                table: "ProductBatch",
                column: "warehouseInputId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatchInventory_productBatchId",
                table: "ProductBatchInventory",
                column: "productBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeliveryMethod_deliveryMethodId",
                table: "ProductDeliveryMethod",
                column: "deliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeliveryMethod_productId",
                table: "ProductDeliveryMethod",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_imageId",
                table: "ProductImage",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_productId",
                table: "ProductImage",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_productId",
                table: "ProductOption",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionImage_imageId",
                table: "ProductOptionImage",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionImage_productOptionId",
                table: "ProductOptionImage",
                column: "productOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionValue_productOptionId",
                table: "ProductOptionValue",
                column: "productOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionValue_propertyId",
                table: "ProductOptionValue",
                column: "propertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPropertyValue_productId",
                table: "ProductPropertyValue",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPropertyValue_propertyId",
                table: "ProductPropertyValue",
                column: "propertyId");

            migrationBuilder.CreateIndex(
                name: "UQ__Property__2D08ACCF5EA3BA00",
                table: "Property",
                column: "secondaryId",
                unique: true,
                filter: "([secondaryId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Property__2D08ACCF6D2F21AB",
                table: "Property",
                column: "secondaryId",
                unique: true,
                filter: "([secondaryId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTemplate_propertyId",
                table: "PropertyTemplate",
                column: "propertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTemplate_templateId",
                table: "PropertyTemplate",
                column: "templateId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTemplateValue_propertyTemplateId",
                table: "PropertyTemplateValue",
                column: "propertyTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_User__cartId",
                table: "User_",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_User__shopId",
                table: "User_",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_roleId",
                table: "UserRole",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_userId",
                table: "UserRole",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_addressId",
                table: "Warehouse",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_shopId",
                table: "Warehouse",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseInput_warehouseId",
                table: "WarehouseInput",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOutputDetail_productBatchId",
                table: "WarehouseOutputDetail",
                column: "productBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseOutputDetail_warehouseOutputId",
                table: "WarehouseOutputDetail",
                column: "warehouseOutputId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "DeliveryPartner");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "ProductBatchInventory");

            migrationBuilder.DropTable(
                name: "ProductDeliveryMethod");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductOptionImage");

            migrationBuilder.DropTable(
                name: "ProductOptionValue");

            migrationBuilder.DropTable(
                name: "ProductPropertyValue");

            migrationBuilder.DropTable(
                name: "PropertyTemplateValue");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "WarehouseOutputDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");

            migrationBuilder.DropTable(
                name: "PropertyTemplate");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ProductBatch");

            migrationBuilder.DropTable(
                name: "WarehouseOutput");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "WarehouseInput");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "User_");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Shop");
        }
    }
}
