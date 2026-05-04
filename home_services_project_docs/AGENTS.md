# AGENTS.md - Instructions for Windsurf, Codex, and AI Coding Agents

## Project Mission

Build a complete Home Services Booking System from scratch using ASP.NET Core MVC and SQL Server.

## Non-Negotiable Requirements

- Use ASP.NET Core MVC.
- Use SQL Server.
- Do not use external APIs.
- Do not use cloud services.
- Build Admin Panel.
- Build Public Booking Flow.
- Use clean and understandable code.
- Run `dotnet build` after each phase.

## Work Method

Do not implement the whole project in one step.

Work phase by phase:

1. Read `plan.md`.
2. Read the current phase file from `phases/`.
3. Implement only that phase.
4. Run build.
5. Fix build errors.
6. Update checklist.
7. Move to the next phase.

## Architecture Rules

- Put admin controllers inside `Areas/Admin/Controllers`.
- Put admin views inside `Areas/Admin/Views`.
- Use `ViewModels` for forms and list pages.
- Use `Models` for database entities.
- Use `ApplicationDbContext` for EF Core.
- Use Cookie Authentication for admin login.
- Use Anti-Forgery tokens in POST forms.
- Do not store plain text passwords.

## Data Rules

- New orders must default to Pending.
- OrderDate cannot be in the past.
- Phone must be exactly 11 digits.
- CustomerName must be at least 3 characters.
- Services should support CRUD.
- Prefer soft delete with IsActive for services.

## UI Rules

- Public layout and Admin layout should be separated.
- Use clear forms and validation messages.
- Use Bootstrap alerts or toast notifications.
- Use status badges for order statuses.

## Build Command

```bash
dotnet build
```

## Useful EF Commands

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations script -o database.sql
```

## Do Not Do

- Do not introduce APIs or cloud dependencies.
- Do not create customer login unless requested later.
- Do not add payment.
- Do not add SMS/Email notifications.
- Do not skip validation.
- Do not keep admin pages public.
