dotnet ef database update 0 --context RideShareDbContext

dotnet ef migrations remove --context RideShareDbContext

dotnet ef migrations add InitialCreate --context RideShareDbContext

dotnet ef database update --context RideShareDbContext
