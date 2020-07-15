## PG migrations
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations remove

## Attach to PG to check things
docker exec -it <container> /bin/bash
