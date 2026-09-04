# WebApplication1

Brief overview
-------------
WebApplication1 is a sample ASP.NET Core web application (targeting .NET 10) that demonstrates a small school-style module with Students and Attendance functionality. The project combines server-rendered MVC views for manual testing and simple JSON API endpoints for automated usage.

Key features
------------
- Students: full Create / Read / Update / Delete (CRUD) via MVC pages and API endpoints (/Student, /api/students).
- Attendance: record and manage attendance linked to students via MVC pages and API endpoints (/Attendance, /api/attendances). The Attendance index supports filtering by student.
- Data access: Repository pattern backed by Entity Framework Core using the InMemory provider (Microsoft.EntityFrameworkCore.InMemory). All repository methods are async Task-based.
- Seed data: sample students (Alice, Bob) are seeded at startup so the UI has initial data.

Tech stack / libraries
----------------------
- .NET 10 (net10.0)
- ASP.NET Core MVC (Razor views)
- Entity Framework Core (InMemory provider)
- Bootstrap + jQuery (UI assets under wwwroot/lib)

Project structure (important files)
----------------------------------
- WebApplication1/Program.cs - app startup, DI and seeding
- WebApplication1/Controllers/StudentController.cs - MVC UI for students
- WebApplication1/Controllers/AttendanceController.cs - MVC UI for attendance
- WebApplication1/Controllers/StudentsController.cs - API for students
- WebApplication1/Controllers/AttendancesController.cs - API for attendance
- WebApplication1/Data/ApplicationDbContext.cs - EF Core DbContext
- WebApplication1/Models - Student, Attendance, repository interfaces
- WebApplication1/Repositories - EF-backed repository implementations
- WebApplication1/Views - Razor views for Student and Attendance modules

How to run
----------
Prerequisites: .NET 10 SDK, Visual Studio 2022/2024/2026 or newer (IDE optional).

From the solution root (this repo):

1. Restore packages (if needed):

   dotnet restore

2. Run the web app:

   dotnet run --project WebApplication1/WebApplication1.csproj

3. Open a browser:

   - Home / UI: https://localhost:{port}/
	 - Manage Students: /Student
	 - Manage Attendance: /Attendance
   - API endpoints (JSON):
	 - GET /api/students
	 - GET /api/students/{id}
	 - POST /api/students
	 - GET /api/attendances
	 - GET /api/attendances/{id}
	 - GET /api/attendances/bystudent/{studentId}
	 - POST /api/attendances

Notes
-----
- The application uses an in-memory database (EF Core InMemory). Data is ephemeral and resets when the app restarts. To persist data, replace the InMemory provider with a persistent provider (SQLite or SQL Server) and add EF Core migrations.
- Repository methods are async. Controllers consume the async methods.
- The project includes simple server-side validation and client-side validation via the standard _ValidationScriptsPartial.

Suggested next steps
---------------------
- Switch to a persistent database (SQLite/SQL Server) and add EF Core migrations.
- Add authentication/authorization to protect API and UI endpoints.
- Add unit and integration tests for controllers and repositories.

Contact / contribution
----------------------
This repository is a sample for demonstration and testing. Contributions and improvements are welcome via pull requests.
