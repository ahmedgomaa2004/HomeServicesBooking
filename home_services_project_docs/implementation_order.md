# Implementation Order

هذا ترتيب التنفيذ المقترح لتقليل الأخطاء.

## Step 1 - Create Project

- Create MVC project.
- Run project.
- Confirm Home page opens.

## Step 2 - Configure Database

- Add EF Core packages.
- Add connection string.
- Add ApplicationDbContext.
- Register DbContext in Program.cs.

## Step 3 - Create Models

- Service
- Order
- AdminUser
- OrderStatus

## Step 4 - Create Migration

- Add initial migration.
- Update database.
- Check tables in SQL Server.

## Step 5 - Seed Data

- Add default services.
- Add default admin.

## Step 6 - Public Website

- Home.
- Services list.
- Service details.
- Order form.
- Save order.

## Step 7 - Admin Auth

- Login.
- Logout.
- Protect Admin Area.

## Step 8 - Dashboard

- Counts.
- Last 10 Orders.

## Step 9 - Orders Management

- List.
- Search.
- Filter.
- Pagination.

## Step 10 - Order Details

- Details page.
- Update status.

## Step 11 - Services Management

- CRUD.

## Step 12 - Validation and Polish

- Review validations.
- Add alerts/toasts.
- Improve UI.

## Step 13 - Testing and Delivery

- Test all flows.
- Generate SQL script.
- Write README.
- Screenshots.
- Demo video.
