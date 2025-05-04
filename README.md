# PandaShop Backend

A comprehensive e-commerce platform with integrated short video/music content capabilities.

## 🛠️ Core Features

### E-commerce
- Product management with variants
- Shopping cart 
- Order management
- Inventory management

### PanVideo (Short Video Platform)
- Video upload & streaming (DASH/HLS)
- FFmpeg-powered video processing
- WebP thumbnail generation

## 🚀 Technical Stack

- **.NET Core**: Backend framework
- **Entity Framework Core**: ORM
- **SQL Server**: Primary database
- **FFmpeg**: Video processing
- **Bento4**: DASH streaming
- **Hangfire**: Background jobs

## 📁 Project Structure

```
PandaShoppingAPI/
├── Controllers/
│   ├── Products/
│   ├── Orders/ 
│   ├── PanVideos/
│   ├── Templates/
│   ├── Properties/
│   └── Warehouse/
├── Services/
│   ├── Product/
│   ├── Order/
│   ├── PanVideo/
│   │   ├── PanVideoService.cs
│   │   └── PanvideoEncoder/
│   ├── Template/
│   ├── Category/
│   └── Warehouse/
├── Models/
│   ├── Address/
│   ├── Cart/
│   ├── Order/
│   ├── Product/
│   ├── Template/
│   ├── Warehouse/
│   └── Base/
├── DataAccesses/
│   ├── EF/
│   │   ├── Migrations/
│   │   └── Entities/
│   └── Repos/
│       ├── Base/
│       ├── Product/
│       ├── Order/
│       ├── Warehouse/
│       └── PanVideo/
├── Utils/
│   ├── Exceptions/
│   └── Extensions/
└── Configs/
    ├── DbConfig.cs
    ├── AuthConfig.cs 
    ├── FileConfig.cs
    └── Middlewares/
```

## 🔌 API Endpoints
Swagger APIs document supported. Please check it out once running API success.

## 🛠️ Setup & Installation

1. **Prerequisites**
```bash
brew install ffmpeg
brew install bento4
```

2. **Database Setup**
```bash
dotnet ef database update
```

3. **Run Application**
```bash
dotnet run
```

## 🔐 Security

- JWT authentication
- Role-based access control
- File upload validation
- Request rate limiting

## 📦 Dependencies

- Microsoft.EntityFrameworkCore
- Hangfire
- AutoMapper
- Newtonsoft.Json

## 🤝 Contributing

1. Fork repository
2. Create feature branch
3. Commit changes
4. Push to branch
5. Create Pull Request

## 📄 License

MIT License

