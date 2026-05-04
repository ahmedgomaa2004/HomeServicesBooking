# Phase 06 - Orders Management List, Search, Filter, Pagination

## Goal

تنفيذ صفحة إدارة الطلبات الرئيسية مع الجدول والبحث والفلترة والتقسيم لصفحات.

## Inputs

- 01_requirements.md
- 04_routes_pages_map.md
- 08_testing_strategy.md

## Tasks

- [ ] إنشاء Admin OrdersController Index.
- [ ] إنشاء OrdersListViewModel.
- [ ] إنشاء OrderRowViewModel.
- [ ] إضافة search parameter.
- [ ] إضافة status parameter.
- [ ] إضافة page parameter.
- [ ] تطبيق فلترة الحالة.
- [ ] تطبيق البحث بالاسم أو الهاتف.
- [ ] تطبيق Pagination بعد الفلترة.
- [ ] عرض 10 عناصر في الصفحة.
- [ ] إنشاء View للجدول.
- [ ] إضافة pagination controls.

## Files/Folders Expected

- Areas/Admin/Controllers/OrdersController.cs
- Areas/Admin/Views/Orders/Index.cshtml
- ViewModels/OrdersListViewModel.cs
- ViewModels/OrderRowViewModel.cs

## Implementation Notes

- الترتيب الافتراضي: الأحدث أولًا.
- لا تستخدم ToList قبل الفلترة والـ pagination.
- تأكد أن البحث لا يكسر لو search فارغ.
- تأكد أن page أقل من 1 تتحول إلى 1.
- احفظ query parameters عند التنقل بين الصفحات.

## Validation / QA

- [ ] البحث بالاسم يعمل.
- [ ] البحث بالموبايل يعمل.
- [ ] الفلترة بالحالة تعمل.
- [ ] Pagination يعرض 10 فقط.
- [ ] Build ينجح.

## Acceptance Criteria

- [ ] Orders table done.
- [ ] Search works.
- [ ] Filter works.
- [ ] Pagination works.
- [ ] Build passes.

## Agent Prompt

```text
Read phase_06_orders_management.md. Implement admin orders index with search, status filter, and 10-item pagination. Use ViewModels and efficient EF queries. Run dotnet build.
```

## Done Checklist

- [ ] Index action done.
- [ ] ViewModel done.
- [ ] Search done.
- [ ] Filter done.
- [ ] Pagination done.
- [ ] Build success.
