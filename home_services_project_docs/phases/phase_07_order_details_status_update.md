# Phase 07 - Order Details and Status Update

## Goal

تنفيذ صفحة تفاصيل الطلب وتحديث الحالة داخل قاعدة البيانات.

## Inputs

- 01_requirements.md
- 05_validation_and_business_rules.md

## Tasks

- [ ] إنشاء Details GET داخل Admin OrdersController.
- [ ] إنشاء OrderDetailsViewModel.
- [ ] عرض كل بيانات الطلب.
- [ ] إضافة dropdown للحالة.
- [ ] إنشاء UpdateStatus POST.
- [ ] التحقق أن الحالة ضمن القيم المسموحة.
- [ ] تحديث Status و UpdatedAt.
- [ ] حفظ التغيير.
- [ ] إظهار رسالة تم تحديث الحالة.

## Files/Folders Expected

- Areas/Admin/Controllers/OrdersController.cs
- Areas/Admin/Views/Orders/Details.cshtml
- ViewModels/OrderDetailsViewModel.cs

## Implementation Notes

- استخدم id للتحقق من وجود الطلب.
- لو الطلب غير موجود اعرض NotFound.
- استخدم ValidateAntiForgeryToken.
- لا تسمح بقيمة status عشوائية.
- يمكن لاحقًا إضافة AJAX، لكن النسخة الأساسية تكون form POST.

## Validation / QA

- [ ] تفاصيل الطلب تظهر كاملة.
- [ ] تغيير الحالة يحفظ.
- [ ] رسالة نجاح تظهر.
- [ ] قيمة غير صالحة لا تحفظ.
- [ ] Build ينجح.

## Acceptance Criteria

- [ ] Details page done.
- [ ] Status update done.
- [ ] Validation done.
- [ ] Build passes.

## Agent Prompt

```text
Read phase_07_order_details_status_update.md. Implement order details and status update. Allowed statuses only. Save UpdatedAt. Show success message. Run dotnet build.
```

## Done Checklist

- [ ] Details GET done.
- [ ] Details view done.
- [ ] Update POST done.
- [ ] Status validation done.
- [ ] Build success.
