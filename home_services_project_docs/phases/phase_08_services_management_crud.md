# Phase 08 - Services Management CRUD

## Goal

تنفيذ إدارة الخدمات كاملة داخل لوحة التحكم.

## Inputs

- 01_requirements.md
- 03_database_design.md
- 05_validation_and_business_rules.md

## Tasks

- [ ] إنشاء Admin ServicesController.
- [ ] إنشاء Services Index.
- [ ] إنشاء ServiceFormViewModel.
- [ ] تنفيذ Create GET/POST.
- [ ] تنفيذ Edit GET/POST.
- [ ] تنفيذ Delete GET/POST أو Deactivate.
- [ ] تطبيق validation.
- [ ] التأكد أن الخدمات النشطة فقط تظهر في الموقع العام.

## Files/Folders Expected

- Areas/Admin/Controllers/ServicesController.cs
- Areas/Admin/Views/Services/Index.cshtml
- Areas/Admin/Views/Services/Create.cshtml
- Areas/Admin/Views/Services/Edit.cshtml
- Areas/Admin/Views/Services/Delete.cshtml
- ViewModels/ServiceFormViewModel.cs

## Implementation Notes

- يفضل Soft Delete عبر IsActive.
- عند التعطيل لا تظهر الخدمة للمستخدم.
- لا تحذف الطلبات القديمة المرتبطة بالخدمة.
- استخدم TempData للنجاح والخطأ.

## Validation / QA

- [ ] إضافة خدمة تعمل.
- [ ] تعديل خدمة يعمل.
- [ ] حذف/تعطيل خدمة يعمل.
- [ ] الخدمة المعطلة لا تظهر في public services.
- [ ] Build ينجح.

## Acceptance Criteria

- [ ] Services list done.
- [ ] Create done.
- [ ] Edit done.
- [ ] Delete/deactivate done.
- [ ] Build passes.

## Agent Prompt

```text
Read phase_08_services_management_crud.md. Implement admin services CRUD. Prefer IsActive soft delete. Ensure public pages show only active services. Run dotnet build.
```

## Done Checklist

- [ ] Index done.
- [ ] Create done.
- [ ] Edit done.
- [ ] Delete/deactivate done.
- [ ] Public active filter done.
- [ ] Build success.
