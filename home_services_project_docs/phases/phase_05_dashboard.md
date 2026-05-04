# Phase 05 - Admin Dashboard

## Goal

بناء Dashboard تعرض إحصائيات الطلبات وآخر 10 طلبات.

## Inputs

- 01_requirements.md
- 02_architecture.md

## Tasks

- [ ] إنشاء DashboardController داخل Admin Area.
- [ ] إنشاء DashboardViewModel.
- [ ] جلب إجمالي الطلبات.
- [ ] جلب عدد Pending.
- [ ] جلب عدد Done.
- [ ] جلب آخر 10 طلبات بترتيب CreatedAt أو Id descending.
- [ ] إنشاء View للداشبورد.
- [ ] إضافة cards للإحصائيات.
- [ ] إضافة جدول آخر الطلبات.

## Files/Folders Expected

- Areas/Admin/Controllers/DashboardController.cs
- Areas/Admin/Views/Dashboard/Index.cshtml
- ViewModels/DashboardViewModel.cs

## Implementation Notes

- استخدم AsNoTracking.
- لا تحمل كل الطلبات في الذاكرة لحساب الأرقام.
- استخدم CountAsync.
- استخدم Projection للـ last orders.

## Validation / QA

- [ ] Dashboard لا يفتح بدون Login.
- [ ] الأرقام صحيحة.
- [ ] آخر 10 طلبات تظهر.
- [ ] Build ينجح.

## Acceptance Criteria

- [ ] Dashboard implemented.
- [ ] Counts correct.
- [ ] Last 10 orders shown.
- [ ] Build passes.

## Agent Prompt

```text
Read phase_05_dashboard.md. Implement admin dashboard with counts and last 10 orders. Use DashboardViewModel and AsNoTracking. Run dotnet build.
```

## Done Checklist

- [ ] Controller done.
- [ ] ViewModel done.
- [ ] View done.
- [ ] Counts tested.
- [ ] Build success.
