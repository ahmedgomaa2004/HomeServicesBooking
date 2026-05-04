# Windsurf Main Prompt

استخدم هذا البرومبت مع Windsurf في بداية المشروع.

```text
You are working on a new ASP.NET Core MVC project called HomeServicesBooking.

The goal is to build a complete Home Services Booking System from scratch using ASP.NET Core MVC, SQL Server, Entity Framework Core, Razor Views, and Cookie Authentication.

Important context:
- This is not an existing project modification anymore.
- There is no source code and no database from the client.
- Build the project from scratch based on the documentation files.

Before writing code, read:
1. plan.md
2. 01_requirements.md
3. 02_architecture.md
4. 03_database_design.md
5. AGENTS.md
6. The current phase file inside phases/

Rules:
- Work phase by phase only.
- Do not implement everything at once.
- After each phase, run dotnet build and fix errors.
- Use Areas/Admin for admin panel.
- Use Models, ViewModels, Data, Helpers folders.
- Use SQL Server and EF Core.
- Use Cookie Authentication for admin.
- Do not use external APIs.
- Do not use cloud services.
- Do not store passwords as plain text.
- Use validation rules from 05_validation_and_business_rules.md.

Start with phase_01_project_setup.md and implement only what is required in that phase.
```
