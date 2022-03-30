
DotNet WebApi with MySql

Tutorial Available at: https://code-maze.com/net-core-series/

Docker Setup

docker run --name some-mysql -e MYSQL_ROOT_PASSWORD=my-secret-pw -d mysql


dotnet add package Microsoft.EntityFrameworkCore
dotnet add package NLog
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
