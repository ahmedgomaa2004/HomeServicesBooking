# Decisions Log

## Decision 001 - Build from scratch

### Decision

المشروع سيتم بناؤه من الصفر بدل تعديل مشروع موجود.

### Reason

العميلة أوضحت أنه لا يوجد Source Code أو Database جاهزين.

### Impact

- زيادة السعر والمدة.
- الحاجة إلى تصميم architecture و database من البداية.

## Decision 002 - Use ASP.NET Core MVC

### Decision

استخدام ASP.NET Core MVC كما طلبت العميلة.

### Reason

هذا هو الـ stack المطلوب صراحة.

## Decision 003 - Use SQL Server

### Decision

استخدام SQL Server مع Entity Framework Core.

### Reason

العميلة طلبت SQL Server، و EF Core مناسب لتسريع بناء المشروع وتنظيم البيانات.

## Decision 004 - Use Admin Area

### Decision

وضع لوحة التحكم داخل `Areas/Admin`.

### Reason

لفصل كود الإدارة عن كود الموقع العام بشكل منظم.

## Decision 005 - Use Cookie Authentication

### Decision

استخدام Cookie Authentication مع جدول AdminUsers.

### Reason

المشروع يحتاج Admin Login بسيط وليس نظام مستخدمين كامل.

## Decision 006 - Use Soft Delete for Services

### Decision

المقترح تعطيل الخدمة باستخدام `IsActive` بدل حذف نهائي.

### Reason

الحذف النهائي قد يؤثر على الطلبات القديمة المرتبطة بالخدمة.
