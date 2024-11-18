docker build -t webshop .

docker run -d -p 8080:80 --name webshopcontainer webshop

------------------------------------------------------------------------------
In project root, run following commands for EF = C:\Labb1Net23Gbg\WebShopSolution

{your path to repository} = C:\Labb1Net23Gbg\WebShopSolution\Repository
{your path to webshop} = C:\Labb1Net23Gbg\WebShopSolution\WebShop

dotnet ef migrations add InitialCreate --project {your path to repository} --startup-project {your path to webshop}

dotnet ef database update --project Repository --startup-project WebShop 