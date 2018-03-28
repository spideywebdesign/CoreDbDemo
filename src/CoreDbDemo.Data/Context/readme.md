Powershell EF commands not working?
==========================================

To enable CLI commands (e.g. dotnet EF Migrations)  Don't forget     <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" /> in .csproj
Also the class "DesignTimeDbContextFactory" as exempified in this project, is required