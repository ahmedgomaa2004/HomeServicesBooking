# Phase 09 - Validation, Error Handling, and Logging

## Goal

مراجعة شاملة لكل قواعد التحقق ورسائل الخطأ والـ logging.

## Inputs

- 05_validation_and_business_rules.md
- 08_testing_strategy.md

## Tasks

- [ ] مراجعة OrderForm validation.
- [ ] إضافة DateNotInPastAttribute لو غير موجود.
- [ ] مراجعة Login validation.
- [ ] مراجعة Service validation.
- [ ] إضافة AntiForgery في POST forms.
- [ ] مراجعة try/catch في عمليات الحفظ المهمة.
- [ ] إضافة ILogger في controllers المهمة.
- [ ] توحيد TempData keys.
- [ ] إضافة shared alerts partial.

## Files/Folders Expected

- Helpers/DateNotInPastAttribute.cs
- Views/Shared/_Alerts.cshtml
- Controllers/OrdersController.cs
- Areas/Admin/Controllers/*.cshtml or *.cs

## Implementation Notes

- لا تعرض exception raw للمستخدم.
- استخدم رسائل عربية واضحة.
- تأكد من client-side validation لو متاحة.
- تأكد من server-side validation دائمًا.

## Validation / QA

- [ ] كل validation scenarios تفشل بشكل صحيح.
- [ ] كل POST forms بها AntiForgery.
- [ ] الأخطاء المهمة يتم تسجيلها.
- [ ] Build ينجح.

## Acceptance Criteria

- [ ] Validation complete.
- [ ] Error handling complete.
- [ ] Logging added.
- [ ] Build passes.

## Agent Prompt

```text
Read validation and testing docs. Review all forms and controllers for validation, anti-forgery, error handling, and logging. Do not add new features. Run dotnet build.
```

## Done Checklist

- [ ] Order validation checked.
- [ ] Login validation checked.
- [ ] Service validation checked.
- [ ] AntiForgery checked.
- [ ] Logging checked.
- [ ] Build success.
