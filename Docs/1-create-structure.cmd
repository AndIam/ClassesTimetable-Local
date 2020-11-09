rem Create solution with folder
dotnet new sln -o %1

rem Create projects: Core, Infrastructure, Web and Tests
cd %1
dotnet new classlib -o %1.Core
dotnet new classlib -o %1.Infrastructure
cd %1.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqLite
dotnet add package Microsoft.EntityFrameworkCore.Design
cd ..
dotnet new mvc -o %1.Web
cd %1.Web
dotnet add package Microsoft.EntityFrameworkCore.Design
cd ..
dotnet new xunit -o %1.Tests

rem Add references to projects
dotnet add %1.Infrastructure/%1.Infrastructure.csproj reference %1.Core/%1.Core.csproj
dotnet add %1.Web/%1.Web.csproj reference %1.Core/%1.Core.csproj
dotnet add %1.Web/%1.Web.csproj reference %1.Infrastructure/%1.Infrastructure.csproj
dotnet add %1.Tests/%1.Tests.csproj reference %1.Core/%1.Core.csproj
dotnet add %1.Tests/%1.Tests.csproj reference %1.Infrastructure/%1.Infrastructure.csproj

rem Add all projects to solution
dotnet sln %1.sln add %1.Core/%1.Core.csproj
dotnet sln %1.sln add %1.Infrastructure/%1.Infrastructure.csproj
dotnet sln %1.sln add %1.Web/%1.Web.csproj
dotnet sln %1.sln add %1.Tests/%1.Tests.csproj

cd ..