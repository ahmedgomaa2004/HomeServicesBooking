# Codex Task Prompts

استخدم هذه البرومبتات مع Codex داخل VS Code، واحدة واحدة.

## Task 01 - Project Setup Review

```text
Read plan.md, AGENTS.md, and phases/phase_01_project_setup.md.
Review the current ASP.NET Core MVC project structure.
Implement only the setup requirements from Phase 01.
Do not implement database models yet unless the phase explicitly asks.
After changes, run dotnet build and fix errors.
```

## Task 02 - Database Models and DbContext

```text
Read 03_database_design.md and phases/phase_02_database_models_ef.md.
Create Models: Order, Service, AdminUser, OrderStatus.
Create ApplicationDbContext.
Configure entity properties, relationships, and indexes.
Register DbContext in Program.cs.
Do not build UI in this task.
Run dotnet build and fix errors.
```

## Task 03 - Public Website and Booking

```text
Read phases/phase_03_public_website_and_booking.md and 05_validation_and_business_rules.md.
Implement Home page, services list, service details, and order creation form.
Use OrderFormViewModel.
Apply validation.
Save valid orders to database with Pending status.
Show success/error messages using TempData.
Run dotnet build and fix errors.
```

## Task 04 - Admin Login

```text
Read phases/phase_04_admin_authentication.md and 06_security_auth.md.
Implement Admin AuthController with Login and Logout.
Configure Cookie Authentication.
Protect Admin Area.
Use password hashing.
Seed a default admin if needed.
Run dotnet build and fix errors.
```

## Task 05 - Dashboard

```text
Read phases/phase_05_dashboard.md.
Implement Admin Dashboard with total orders, pending orders, done orders, and last 10 orders.
Use DashboardViewModel.
Use AsNoTracking for read queries.
Run dotnet build and fix errors.
```

## Task 06 - Orders Management

```text
Read phases/phase_06_orders_management.md.
Implement Admin Orders Index page with search by customer name or phone, filter by status, and pagination of 10 items per page.
Use a ViewModel and do not pass raw IQueryable to views.
Run dotnet build and fix errors.
```

## Task 07 - Order Details and Status Update

```text
Read phases/phase_07_order_details_status_update.md.
Implement Order Details page and status update form.
Allowed statuses are Pending, InProgress, Done.
After updating status, save to database and show success message.
Run dotnet build and fix errors.
```

## Task 08 - Services CRUD

```text
Read phases/phase_08_services_management_crud.md.
Implement Admin Services CRUD: list, create, edit, delete or deactivate.
Use validation.
Make sure public website only shows active services.
Run dotnet build and fix errors.
```

## Task 09 - Validation and Error Handling Review

```text
Read phases/phase_09_validation_errors_logging.md.
Review all forms and controllers.
Ensure validation rules are implemented.
Ensure POST actions use ValidateAntiForgeryToken.
Ensure errors are logged and user messages are clear.
Run dotnet build and fix errors.
```

## Task 10 - UI Polish

```text
Read phases/phase_10_ui_ux_notifications.md.
Improve public and admin UI using simple clean Bootstrap styling.
Add status badges and shared alerts partial.
Do not change business logic unless needed for UI.
Run dotnet build and fix errors.
```

## Task 11 - Final QA

```text
Read phases/phase_11_testing_qa.md and 08_testing_strategy.md.
Run through the manual testing checklist.
Fix discovered bugs only.
Run dotnet build and ensure the project runs.
```

## Task 12 - Delivery Files

```text
Read phases/phase_12_delivery_readme_screenshots_video.md and 09_delivery_checklist.md.
Prepare README, database SQL script, and delivery checklist.
Do not include bin/obj folders in final zip.
```
