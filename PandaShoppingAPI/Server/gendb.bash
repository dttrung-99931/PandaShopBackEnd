// Home 
dotnet ef dbcontext scaffold "Server=localhost,1433;Database=PandaShopDB;User Id=sa;Password=0988202071aA@;"  Microsoft.EntityFrameworkCore.SqlServer -o DataAccesses/EF -c  EcommerceDBContext --use-database-names --no-pluralize --no-onconfiguring -f

// Company
dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Initial Catalog=PandaShopDB;Integrated Security=True"  Microsoft.EntityFrameworkCore.SqlServer -o DataAccesses/EF -c  EcommerceDBContext --use-database-names --no-pluralize --no-onconfiguring -f
