# Steps to run the project

1. Clone the project using command `git clone https://github.com/mrameezraja/Assignment`
2. Make sure if you have installed [DotnetCore SDK 2.2.4"](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.402-windows-x64-installer)
3. Build the solution to restore nuget packages
4. Create a database `Assignment` in sql server management studio 
5. Change connection string in `appsettings.json` file of `Assignment.Web.Host` project
6. Select `Assignment.Web.Host` as `Set as startup project`
7. Open `Package Manager Console` and select `Assignment.EntityFrameworkCore` project in dropdown
8. Run `update-database` command, this will create tables neccessary for application to run
9. Start the application from visual studio
10. This will display a Swagger UI, this means api is launched successfully
11. Required endpoints are Cows and Sensors