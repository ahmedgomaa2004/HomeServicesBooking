# Phase 02 - Database, Models, and EF Core

## Goal

تصميم وتنفيذ Models و DbContext و Migration وربط المشروع بقاعدة بيانات SQL Server.

## Inputs

- 03_database_design.md
- 05_validation_and_business_rules.md
- 06_security_auth.md

## Tasks

- [ ] إضافة EF Core SQL Server packages المناسبة للبيئة.
- [ ] إنشاء OrderStatus enum.
- [ ] إنشاء Service model.
- [ ] إنشاء Order model.
- [ ] إنشاء AdminUser model.
- [ ] إنشاء ApplicationDbContext.
- [ ] تكوين العلاقات والـ indexes.
- [ ] تسجيل DbContext في Program.cs.
- [ ] إضافة connection string.
- [ ] إنشاء Initial Migration.
- [ ] تحديث قاعدة البيانات.
- [ ] تجهيز seed data للأدمن والخدمات.

## Files/Folders Expected

- Models/Order.cs
- Models/Service.cs
- Models/AdminUser.cs
- Models/OrderStatus.cs
- Data/ApplicationDbContext.cs
- Data/DbInitializer.cs
- Migrations/

## Implementation Notes

- Status يفضل أن يكون Enum في الكود ويتم تخزينه كنص أو int حسب اختيار التنفيذ.
- ServiceId داخل Order يكون nullable لتفادي كسر الطلبات القديمة.
- احفظ ServiceName داخل Order كـ snapshot.
- Admin password يجب أن يكون hashed.
- استخدم indexes للبحث والفلترة.

## Validation / QA

- [ ] Migration تنشئ الجداول بنجاح.
- [ ] Database update يعمل.
- [ ] الجداول تظهر في SQL Server.
- [ ] Seed admin والخدمات يعمل بدون تكرار عند إعادة التشغيل.
- [ ] dotnet build ينجح.

## Acceptance Criteria

- [ ] Models created.
- [ ] DbContext configured.
- [ ] Database created.
- [ ] Seed data inserted.
- [ ] Build passes.

## Agent Prompt

```text
Read 03_database_design.md. Create EF Core models and ApplicationDbContext. Configure relationships and indexes. Add seed data for default services and admin user with hashed password. Create migration and update database. Run dotnet build.
```

## Done Checklist

- [ ] Models done.
- [ ] DbContext done.
- [ ] Migration done.
- [ ] Database update done.
- [ ] Build success.
