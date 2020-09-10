:: cd src\Magicodes.Admin.EntityFrameworkCore
:: dotnet ef database update
cd src\data\Magicodes.Admin.Migrator
dotnet run Magicodes.Admin.Migrator.dll
@pause