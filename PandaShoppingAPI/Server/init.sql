
BEGIN TRAN;
    IF (OBJECT_ID('Role', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM Role))
    BEGIN
        INSERT INTO Role(id, name) VALUES(1, 'user');
        INSERT INTO Role(id, name) VALUES(2, 'shop');
        INSERT INTO Role(id, name) VALUES(3, 'admin');
        INSERT INTO Role(id, name) VALUES(4, 'driver');
    END

    -- init Category
    IF (OBJECT_ID('Category', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM Category))
    BEGIN
    SET IDENTITY_INSERT [dbo].[Image] ON 
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (5, NULL, N'4c9c3141-e27e-4758-b80a-ef3ee1eb3287.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (6, NULL, N'fac58171-42d9-48d6-8915-5c2e6513f45d.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (12, NULL, N'3916f275-4ea3-4805-b0f3-1a4aba7469ed.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (13, NULL, N'c805713a-02b8-4ef0-8f6c-c06240a1bc6d.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (14, NULL, N'6ab8c903-fbe2-4d1e-9dfd-a2dbae47e081.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (15, NULL, N'b56c401c-f590-4107-a418-3a696b423ec7.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (16, NULL, N'58b326a4-23ca-4b92-b83f-1ffae14f2f22.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (17, NULL, N'08dcfdd3-5687-4458-95ba-1235869b3c42.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (18, NULL, N'c9bcbd82-2764-48de-b373-73d1386c74f0.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (19, NULL, N'7d30139e-b27e-4f13-b800-8766a6ec1274.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (20, NULL, N'abf73b14-2205-48ea-886a-858292e64f6c.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (21, NULL, N'44a7fb51-07cd-48c9-bd73-7e36666e9ac6.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (22, NULL, N'3b075693-03d9-4d5d-98cd-d3e3adc59b44.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (23, NULL, N'85b9a5ff-f144-4249-b3c6-9ddab1d35b32.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (24, NULL, N'671af3b1-31a7-43cd-b37f-e0de94a49f44.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (25, NULL, N'49e93330-cca6-49a8-ad84-e38dc616dd9a.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (26, NULL, N'057f8f8c-6334-480c-a126-53c92b1d4895.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (27, NULL, N'b167e903-e418-4e20-a8ac-6641700c725c.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (28, NULL, N'b1612f41-287b-4eac-b878-28752c5676fb.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (29, NULL, N'27a327e3-afa1-442b-a877-3c6361d533fc.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (1028, NULL, N'37f4ea01-4fec-4e7d-a4fc-0eb90501ec7d.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2028, NULL, N'9e697748-1bcb-4a63-8719-7fd41295f99a.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2029, NULL, N'1766ca6a-572a-490f-9fee-b2a45307bcb3.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2030, NULL, N'cfed44b4-8337-4e6f-a176-be2bd937ea44.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (2031, NULL, N'fd047561-986e-4fe9-91e8-7dbaedaa477f.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3028, NULL, N'c82d6982-a116-412b-bf27-f0922d62b65b.png')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3029, NULL, N'0245fb92-fc2c-4947-b4e9-9eb023d8e6a3.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3030, NULL, N'2c50399a-f58d-4958-b6c5-aaae44c1fcba.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3031, NULL, N'f197088b-e5a5-47bf-902a-05d78dd108fb.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3032, NULL, N'5cba8dd7-8e4f-42fe-8162-02827916b6d1.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3033, NULL, N'1dffe229-e037-4245-918d-f1f81d470963.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3034, NULL, N'3557515c-8263-42c1-80a6-a7924d1f3828.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3035, NULL, N'f17caa80-cbab-4146-8343-2400a4961cf8.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3036, NULL, N'7cdf416e-d3b0-433e-ac3c-1a9ad93c4603.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3037, NULL, N'd1aa61a7-0c2b-4501-bf90-a43872dd10b8.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3038, NULL, N'158b7d0a-420e-4bf6-a870-62c5f07c91a3.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3039, NULL, N'74b49992-de7a-400b-922e-58052284d294.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3040, NULL, N'73e8c6d8-0dbe-4892-840d-ddd96a8260b0.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3041, NULL, N'f2ad1e5e-8ea0-4079-830c-d5af11f92f67.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3042, NULL, N'2064285a-32fa-4b9b-b172-9329d2342f52.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3043, NULL, N'55b3d79b-47e3-43b4-9f05-bf5efbd1513e.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3044, NULL, N'060fb3f3-d247-43ff-8eb5-75a9ebc8a702.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3045, NULL, N'79de2185-ca12-4ac1-ba3a-61eeb7476258.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3046, NULL, N'3686ef1c-ba0b-4cab-b91e-907c041810da.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3047, NULL, N'9501ad7d-fe4f-405e-9121-3988303ebacf.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3048, NULL, N'ce21886a-647f-4d8d-aed2-61ff5edd1998.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3049, NULL, N'9bbcbc1d-c2c7-4a79-b5be-f9c3a14192b7.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3050, NULL, N'611773ec-aa39-4abb-a0f1-405081afb586.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3051, NULL, N'4b63e0b6-5d5f-4e94-ac9f-c7bdeb8f5b7f.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3052, NULL, N'44277907-e595-4425-b9ff-84a47e2dc4fa.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3053, NULL, N'2e96393e-dc3b-413c-9cd0-b7c99c940ca8.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3054, NULL, N'062d5bd6-d241-47dc-b30c-f51dfce8ee73.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3055, NULL, N'7f842d1f-d38c-4289-91cb-04c93c51cb16.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3056, NULL, N'f3286400-723e-40af-b588-c4b8b1eba699.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3057, NULL, N'2a07700c-e227-4912-8ea5-1b1e6f26dbea.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3058, NULL, N'3d6b8d5c-ea30-46fb-aad2-3636e0836531.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3059, NULL, N'b89d09f6-b998-458d-a266-cbef2aceccb2.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3060, NULL, N'7a23a9ac-3dbe-4bdf-b99d-1d11a0c00520.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3061, NULL, N'a8795bd5-2a46-4abe-92a4-1c130f650d5a.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3062, NULL, N'cb449af3-02be-484b-95e5-0a78a68308cb.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3063, NULL, N'7cd87c1c-d4a5-4062-9de6-bc18040e542f.jpeg')
        INSERT [dbo].[Image] ([id], [description], [fileName]) VALUES (3064, NULL, N'd7b0e98b-cde9-4196-b74b-b2dea3b054ab.jpeg')
        SET IDENTITY_INSERT [dbo].[Image] OFF

        SET IDENTITY_INSERT [dbo].[Property] ON 
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (3, N'RAM', N'3')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (4, N'Bộ nhớ trong', N'4')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (5, N'Màu sắc', N'color')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (6, N'Độ phân giải', N'resoulution')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (7, N'Chất vải', N'chatvai')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (8, N'Chiều dài áo', N'chieudaiao')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (9, N'Họa tiết', N'hoatiet')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (10, N'Kiểu cổ áo', N'kieucoao')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (11, N'Dạng váy', N'dangvay')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (12, N'Hãng sản xuất', N'hangsanxuat')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (13, N'Hệ điều hành', N'hedieuhanh')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (14, N'Kích thước màn hình', N'ktmh')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (15, N'Loại ổ cứng', N'loc')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (16, N'Vi xử lý', N'vsl')
        INSERT [dbo].[Property] ([id], [name], [secondaryId]) VALUES (17, N'Resolution', N'resolution')
        SET IDENTITY_INSERT [dbo].[Property] OFF

        SET IDENTITY_INSERT [dbo].[Template] ON 
        INSERT [dbo].[Template] ([id]) VALUES (1)
        INSERT [dbo].[Template] ([id]) VALUES (2)
        INSERT [dbo].[Template] ([id]) VALUES (3)
        INSERT [dbo].[Template] ([id]) VALUES (4)
        SET IDENTITY_INSERT [dbo].[Template] OFF

        SET IDENTITY_INSERT [dbo].[Category] ON 
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (2, NULL, N'Thời trang nữ', 1, 12, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (3, NULL, N'Thời trang nam', 1, 13, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (4, 3, N'Áo thun nam', 2, NULL, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (5, 3, N'Áo khoác nam', 2, NULL, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (6, 2, N'Đầm, váy', 2, NULL, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (7, 2, N'Đồ lót nữ', 2, NULL, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (8, 4, N'Áo thun ngắn tay', 3, 16, 4)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (9, 4, N'Áo thun dài tay', 3, 17, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (10, NULL, N'Thiết bị điện tử', 1, 15, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (12, 10, N'Smartphone', 2, NULL, 2)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (13, 10, N'Laptop', 2, NULL, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (14, 12, N'IPhone', 3, 18, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (15, 12, N'Samsung', 3, 19, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (16, 13, N'Dell', 3, 20, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (17, 13, N'Asus', 3, 21, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (18, NULL, N'Đồ gia dụng', 1, 14, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (19, 18, N'Xoong nồi', 2, 6, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (20, 18, N'Chảo', 2, 5, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (21, 12, N'Huawei', 3, 22, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (22, 12, N'Oppo', 3, 23, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (23, 12, N'Sony', 3, 24, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (24, 6, N'Váy trắng tay nơ', 3, 25, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (25, 3, N'Quần tây', 2, 3029, NULL)
        INSERT [dbo].[Category] ([id], [parentId], [name], [level], [imageId], [templateId]) VALUES (27, 3, N'Áo sơ mi', 2, 3031, NULL)
        SET IDENTITY_INSERT [dbo].[Category] OFF


        SET IDENTITY_INSERT [dbo].[PropertyTemplate] ON 
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (5, 2, 3, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (6, 3, 7, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (7, 3, 8, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (8, 3, 9, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (9, 3, 10, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (10, 4, 7, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (11, 4, 8, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (12, 4, 9, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (13, 4, 10, 1, 0)
        INSERT [dbo].[PropertyTemplate] ([id], [templateId], [propertyId], [isRequired], [orderIndex]) VALUES (15, 2, 4, 1, 0)
        SET IDENTITY_INSERT [dbo].[PropertyTemplate] OFF
    END

    -- Warehouse data
    IF (OBJECT_ID('Warehouse', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM Warehouse))
    BEGIN
        SET IDENTITY_INSERT [dbo].[Shop] ON 
        INSERT [dbo].[Shop] (id, name) 
        VALUES (1, N'Panda')
        SET IDENTITY_INSERT [dbo].[Shop] OFF

        SET IDENTITY_INSERT [dbo].[Cart] ON 
        INSERT [dbo].[Cart]  (id) 
        VALUES (1)
        SET IDENTITY_INSERT [dbo].[Cart] OFF

        SET IDENTITY_INSERT [dbo].[User_] ON 
        INSERT [dbo].[User_] (id, name, phone, email, password, shopId, cartId) 
        VALUES (1, N'Panda', N'0988202071', N'banhchuoi1999@gmail.com', N'aa123456', 1, 1)
        SET IDENTITY_INSERT [dbo].[User_] OFF

        SET IDENTITY_INSERT [dbo].[NotificationReceiver] ON 
        insert into NotificationReceiver(id, userId, senderType) VALUEs(1, 1, 1)
        SET IDENTITY_INSERT [dbo].[NotificationReceiver] OFF

        SET IDENTITY_INSERT [dbo].[UserRole] ON 
        INSERT [dbo].[UserRole] (id, roleId, userId) VALUES (1, 1, 1) -- user role
        INSERT [dbo].[UserRole] (id, roleId, userId) VALUES (2, 2, 1) -- shop role
        SET IDENTITY_INSERT [dbo].[UserRole] OFF

        SET IDENTITY_INSERT [dbo].[Address] ON 
        INSERT [dbo].[Address] (id, provinceOrCity, provinceOrCityCode, district, districtCode, communeOrWard, streetAndHouseNum, userId, name, lat, long_) 
        VALUES (12, N'Cần Thơ', 92, N'Ninh Kiều', 916, N'Cái Khế', N'Street A', 1, N'Home', 10.035248174503156, 105.78782090262496)
        
        INSERT [dbo].[Address] (id, provinceOrCity, provinceOrCityCode, district, districtCode, communeOrWard, streetAndHouseNum, userId, name, lat, long_) 
        VALUES (13, N'Hồ Chí Minh', 79, N'Tân Bình', 766, N'13', N'Hẻm 91 Thân Nhân Trung', 1, N'giao hang tk', 10.803047940654723, 106.66800285089103)
        SET IDENTITY_INSERT [dbo].[Address] OFF

        SET IDENTITY_INSERT [dbo].[Warehouse] ON 
        INSERT [dbo].[Warehouse] ([id], name, addressId, shopId) VALUES (1, 'Kho A', 12, 1)
        SET IDENTITY_INSERT [dbo].[Warehouse] OFF

    END

    -- init Delivery method, payemnt method
    IF (OBJECT_ID('DeliveryMethod', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM DeliveryMethod))
    BEGIN
        SET IDENTITY_INSERT [dbo].[DeliveryMethod] ON 
        insert into DeliveryMethod(id, name, maxDeliveryHours) values(1, N'Giao hàng hỏa tốc', 24) 
        insert into DeliveryMethod(id, name, maxDeliveryHours) values(2, N'Giao hàng nhanh', 48) 
        insert into DeliveryMethod(id, name, maxDeliveryHours) values(3, N'Giao hàng tiết kiệm', 72)
        SET IDENTITY_INSERT [dbo].[DeliveryMethod] OFF

        SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 
        insert into PaymentMethod(id, name) values(1, N'Thanh toán khi nhận hàng')
        SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
    END

    -- Init delivery partner 
    IF (OBJECT_ID('DeliveryPartner', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM DeliveryPartner))
    BEGIN
        SET IDENTITY_INSERT [dbo].[DeliveryPartner] ON 
        insert into DeliveryPartner(id, name) values(1, N'Giao hàng tiết kiệm') 
        SET IDENTITY_INSERT [dbo].[DeliveryPartner] OFF
    END
    IF (OBJECT_ID('DeliveryPartnerUnit', 'U') IS NOT NULL AND NOT EXISTS(SELECT * FROM DeliveryPartnerUnit))
    BEGIN
        SET IDENTITY_INSERT [dbo].[DeliveryPartnerUnit] ON 
        insert into DeliveryPartnerUnit(id, name, deliveryPartnerId, addressId) values(1, N'Giao hàng tk Tân Bình', 1, 13) 
        SET IDENTITY_INSERT [dbo].[DeliveryPartnerUnit] OFF
    END

    IF @@ERROR = 0 
    BEGIN 
        COMMIT TRAN;
    END ELSE 
    BEGIN 
        ROLLBACK TRAN;
    END

