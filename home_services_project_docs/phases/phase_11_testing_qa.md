# Phase 11 - Testing and QA

## Goal

اختبار كل المسارات الأساسية وإصلاح الأخطاء قبل التسليم.

## Inputs

- 08_testing_strategy.md
- checklists/acceptance_criteria.md

## Tasks

- [ ] تشغيل dotnet build.
- [ ] تشغيل المشروع.
- [ ] اختبار Home.
- [ ] اختبار Services.
- [ ] اختبار Order Form valid/invalid.
- [ ] اختبار Admin Login valid/invalid.
- [ ] اختبار Dashboard.
- [ ] اختبار Orders search/filter/pagination.
- [ ] اختبار Update Status.
- [ ] اختبار Services CRUD.
- [ ] تسجيل bugs وإصلاحها.
- [ ] إعادة اختبار المسارات المتأثرة.

## Files/Folders Expected

- 08_testing_strategy.md
- checklists/acceptance_criteria.md
- bugfix notes حسب الحاجة

## Implementation Notes

- لا تضف features جديدة أثناء QA.
- أي bug يتم إصلاحه بأصغر تعديل آمن.
- بعد كل fix مهم شغل build.
- تأكد من قاعدة البيانات بعد عمليات الحفظ.

## Validation / QA

- [ ] كل test cases الأساسية ناجحة.
- [ ] لا توجد build errors.
- [ ] لا توجد runtime errors في المسارات الأساسية.
- [ ] Acceptance criteria مكتملة.

## Acceptance Criteria

- [ ] Manual QA completed.
- [ ] Bugs fixed.
- [ ] Acceptance criteria passed.
- [ ] Build passes.

## Agent Prompt

```text
Read 08_testing_strategy.md. Execute manual QA checklist. Fix bugs only. Do not add new features. Run dotnet build after fixes.
```

## Done Checklist

- [ ] Build checked.
- [ ] Public tested.
- [ ] Admin tested.
- [ ] CRUD tested.
- [ ] Bugs fixed.
- [ ] Acceptance criteria passed.
